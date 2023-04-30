using System.Collections.Generic;
using System.Xml.Serialization;

namespace SOAP.Models
{
    [XmlRoot(ElementName = "row")]
    public class Exercise
    {
        [XmlElement(ElementName = "Force")]
        public string Force { get; set; }
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "SecondaryMuscles")]
        public string SecondaryMuscles { get; set; }
        [XmlElement(ElementName = "Type")]
        public string Type { get; set; }
        [XmlElement(ElementName = "Primary_Muscles")]
        public List<string> PrimaryMuscles { get; set; }
        [XmlElement(ElementName = "Workout_Type")]
        public string WorkoutType { get; set; }
        [XmlElement(ElementName = "Youtube_link")]
        public string YoutubeLink { get; set; }
    }

    [XmlRoot(ElementName = "root")]
    public class Root
    {
        [XmlElement(ElementName = "row")]
        public Exercise Exercise{ get; set; }
    }
}
