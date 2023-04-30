using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SOAP_Client.Models
{
    [DataContract]
    public class Exercises
    {
        [DataMember(Order = 0)]
        public List<Exercise> ListOfExercises { get; set; }

        public Exercises()
        {

        }
        public Exercises(List<Exercise> exercises)
        {
            ListOfExercises = exercises;
        }
    }

    [DataContract]
    public class Exercise
    {
        [DataMember(Order = 0)]
        public string Force { get; set; }

        [DataMember(Order = 1)]
        public string Name { get; set; }

        [DataMember(Order = 2)]
        public string SecondaryMuscles { get; set; }
        [DataMember(Order = 3)]
        public string Type{ get; set; }
        [DataMember(Order = 4)]
        public List<string> Primary_Muscles { get; set; }

        public Exercise()
        {

        }
    }
}
