using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using System.Xml.Schema;

namespace IIS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExerciseController : ControllerBase
    {
        [HttpPost]
        public void XSD(string responseXML)
        {
            try
            {
                XDocument xml = XDocument.Parse(responseXML);

                XmlSchemaSet xmlSchemaSet = new XmlSchemaSet();
                xmlSchemaSet.Add("", "./Validators/ExerciseXSD.xsd");

                xml.Validate(xmlSchemaSet, (o, e) =>
                {
                    Console.WriteLine("Valid");
                });
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
