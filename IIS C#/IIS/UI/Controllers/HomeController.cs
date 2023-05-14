using CookComputing.XmlRpc;
using IIS.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;
using System.Xml.Serialization;
using UI.Models;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _clientFactory;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _clientFactory = clientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult XSD()
        {
            return View();
        }

        public IActionResult RNG()
        {
            return View();
        }

        public IActionResult API()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> API(string exercise)
        {
            var client = new RestClient($"https://exerciseapi3.p.rapidapi.com/search/?name={exercise}");
            var request = new RestRequest();
            request.AddHeader("X-RapidAPI-Key", "98b9e65825msh6872f5f3ea5be38p183390jsnf6b9ed449f72");
            request.AddHeader("X-RapidAPI-Host", "exerciseapi3.p.rapidapi.com");
            RestResponse response = client.Execute(request);
            var deserialized = JsonConvert.DeserializeObject<List<UI.Models.Root>>(response.Content)[0];
            return View(deserialized);

        }

        public async Task<IActionResult> SOAP()
        {
            ServiceReference1.ExerciseServiceSoapClient service = new ServiceReference1.ExerciseServiceSoapClient(ServiceReference1.ExerciseServiceSoapClient.EndpointConfiguration.ExerciseServiceSoap);

            var xml = await service.SearchExerciseByNameAsync("Barbell Bench Press");
            XmlSerializer serializer = new XmlSerializer(typeof(UI.Models.Exercise));
            MemoryStream memStream = new MemoryStream(Encoding.UTF8.GetBytes(xml.Body.SearchExerciseByNameResult));
            var exercise = (UI.Models.Exercise)serializer.Deserialize(memStream);
            return View(exercise);
        }

        [HttpPost]
        public async Task<IActionResult> XSD(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var client = _clientFactory.CreateClient();
                var content = new MultipartFormDataContent();
                content.Add(new StreamContent(file.OpenReadStream())
                {
                    Headers =
                    {
                        ContentLength = file.Length,
                        ContentType = new MediaTypeHeaderValue(file.ContentType)
                    }
                }, "File", file.FileName);

                var response = await client.PostAsync("http://localhost:5001/Exercise/xsd", content);
                string valid = "XML is";
                if (response.IsSuccessStatusCode)
                    valid += " valid";
                else
                    valid += " not valid";
                ViewBag.xml = valid;
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RNG(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var client = _clientFactory.CreateClient();
                var content = new MultipartFormDataContent();
                content.Add(new StreamContent(file.OpenReadStream())
                {
                    Headers =
                    {
                        ContentLength = file.Length,
                        ContentType = new MediaTypeHeaderValue(file.ContentType)
                    }
                }, "File", file.FileName);
                string valid = "XML is";
                var response = await client.PostAsync("http://localhost:5001/Exercise/rng", content);
                if (response.IsSuccessStatusCode)
                    valid += " valid";
                else
                    valid += " not valid";
                ViewBag.xml = valid;
            }
            return View();
        }
    }
}
