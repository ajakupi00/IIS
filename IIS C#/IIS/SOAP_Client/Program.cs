using SOAP_Client.Models;
using System.Diagnostics;
using System.Text;
using System.Xml.Serialization;

ExerciseReference.ExerciseServiceSoapClient service = new ExerciseReference.ExerciseServiceSoapClient(ExerciseReference.ExerciseServiceSoapClient.EndpointConfiguration.ExerciseServiceSoap);

var xml = service.SearchExerciseByName("Barbell Bench Press");

XmlSerializer serializer = new XmlSerializer(typeof(Exercise));
MemoryStream memStream = new MemoryStream(Encoding.UTF8.GetBytes(xml));
var exercise = (Exercise)serializer.Deserialize(memStream);

Console.WriteLine(exercise.Name);
Console.WriteLine(exercise.Type);