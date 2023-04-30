using SOAP.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml.XPath;

namespace SOAP
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class ExerciseService : System.Web.Services.WebService
    {
        private readonly string PATH = @"C:\temp\";
        private List<Exercise> exercises;
        public ExerciseService()
        {
            exercises = new List<Exercise>();
            loadExercises();
        }

        private void loadExercises()
        {
            using (var reader = new StreamReader(PATH + "exercises.xml"))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Exercise>));

                var savedExercises = (List<Exercise>)serializer.Deserialize(reader);

                if (savedExercises == null)
                    return;

                savedExercises.ForEach(e => exercises.Add(e));
            }
        }

        [WebMethod]
        public string SearchExerciseByName(string exerciseName)
        {
            XElement xmlDoc = new XElement("Exercises");

            foreach (Exercise exercise in exercises)
            {
                XElement exerciseElement = new XElement("Exercise",
                    new XElement("Force", exercise.Force),
                    new XElement("Name", exercise.Name),
                    new XElement("SecondaryMuscles", exercise.SecondaryMuscles),
                    new XElement("Type", exercise.Type),
                    new XElement("Primary_Muscles",
                        exercise.PrimaryMuscles.Select(m => new XElement("Muscle", m))
                    ),
                    new XElement("Workout_Type", exercise.WorkoutType),
                    new XElement("Youtube_link", exercise.YoutubeLink)
                );

                xmlDoc.Add(exerciseElement);
            }

            string filePathName = PATH + "soap_xml.xml";
            xmlDoc.Save(filePathName);

            XElement value = xmlDoc.XPathSelectElement($"//Exercise[Name[text()='{exerciseName}']]");

            if (value == null)
                return "";

            return value.ToString();


        }
    }
}
