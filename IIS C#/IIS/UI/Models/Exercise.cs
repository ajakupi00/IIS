using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace UI.Models
{
    [DataContract(Name = "Exercises")]
    public class Exercises
    {
        [DataMember(Order = 0, Name = "Exercise")]
        public List<Exercise> ListOfExercises { get; set; } = new List<Exercise>();
    }

    [XmlRoot("Exercise")]
    public class Exercise
    {
        [XmlElement("Force")]
        public string Force { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("SecondaryMuscles")]
        public string SecondaryMuscles { get; set; }

        [XmlElement("Type")]
        public string Type { get; set; }

        [XmlArray("Primary_Muscles")]
        [XmlArrayItem("Muscle")]
        public List<string> PrimaryMuscles { get; set; }

        [XmlElement("Workout_Type")]
        public string WorkoutType { get; set; }

        [XmlElement("Youtube_link")]
        public string YoutubeLink { get; set; }

        public Exercise()
        {
            PrimaryMuscles = new List<string>();
        }
    }
}

