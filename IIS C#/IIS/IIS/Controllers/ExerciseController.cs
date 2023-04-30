using Commons.Xml.Relaxng;
using IIS.Models;
using IIS.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace IIS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExerciseController : ControllerBase
    {
        private readonly List<Exercise> exercises;

        public ExerciseController()
        {
            exercises = new List<Exercise>();
            loadExercises();
        }


        [HttpPost("xsd")]
        public async Task<IActionResult> xsd(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("File is not valid!");

            var schemaSet = new XmlSchemaSet();
            using (var fileStream = System.IO.File.OpenRead("./Validators/ExerciseXSD.xsd"))
            {
                schemaSet.Add("", XmlReader.Create(fileStream));
            }

            XmlDocument document = new XmlDocument();
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                memoryStream.Position = 0;
                document.Load(memoryStream);
            }

            bool xmlValid = true;
            string validationErrorMessage = "";

            document.Schemas.Add(schemaSet);
            document.Validate((sender, args) =>
            {
                xmlValid = false;
                validationErrorMessage = $"XML is not valid: {args.Message}";
            });

            if (!xmlValid)
                return BadRequest(validationErrorMessage);

            var root = ValidationUtils.DeserializeXmlToObject<Root>(document);

            if (root == null)
                return BadRequest("Error when deserialzing the object.");

            exercises.Add(root.Exercise);
            saveExercises();


            return Ok(root.Exercise);

        }

        private void saveExercises()
        {
            XmlSerializer serialiser = new XmlSerializer(typeof(List<Exercise>));

            TextWriter filestream = new StreamWriter(@"C:\temp\exercises.xml");

            serialiser.Serialize(filestream, exercises);

            filestream.Close();
        }

        [HttpPost("rng")]
        public async Task<IActionResult> rng(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("File is not valid!");

            XmlDocument document = new XmlDocument();
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                memoryStream.Position = 0;
                document.Load(memoryStream);
            }

            XmlReader xml = new XmlNodeReader(document);
            XmlReader rng = XmlReader.Create(Path.GetFullPath("./Validators/ExerciseRNG.rng"));

            bool xmlValid = true;
            string validationErrorMessage = "";

            using (var reader = new RelaxngValidatingReader(xml, rng))
            {
                reader.InvalidNodeFound += (sender, message) =>
                {
                    xmlValid = false;
                    validationErrorMessage = $"XML is not valid: {message}";
                    return true;
                };

                XDocument doc = XDocument.Load(reader);
            }

            if (!xmlValid)
                return BadRequest(validationErrorMessage);


            var root = ValidationUtils.DeserializeXmlToObject<Root>(document);

            if (root == null)
                return BadRequest("Error when deserialzing the object.");

            exercises.Add(root.Exercise);
            saveExercises();

            return Ok(root.Exercise);
        }


        private void loadExercises()
        {
            using (var reader = new StreamReader(@"C:\temp\exercises.xml"))
            {
                if (String.IsNullOrEmpty(reader.ReadToEnd()))
                    return;
                XmlSerializer serializer = new XmlSerializer(typeof(List<Exercise>));
                
                var savedExercises = (List<Exercise>)serializer.Deserialize(reader);
                
                if (savedExercises == null)
                    return;

                savedExercises.ForEach(e => exercises.Add(e));
            }
        }
    }
}
