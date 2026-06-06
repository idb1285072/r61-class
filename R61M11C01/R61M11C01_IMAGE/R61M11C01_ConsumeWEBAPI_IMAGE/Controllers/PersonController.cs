using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using R61M11C01_ConsumeWEBAPI_IMAGE.ViewModels;

namespace R61M11C01_ConsumeWEBAPI_IMAGE.Controllers
{
    public class PersonController : Controller
    {
        private HttpClient _httpClient;
        string WebAPI = "";
        IConfiguration configuration;
        public PersonController(HttpClient HttpClient,
            IConfiguration configuration) {
            this._httpClient = HttpClient;
            WebAPI = configuration.GetValue<string>("WebApiUrl") + "Person" ?? "";
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> Create(PersonVM entity)
        {
            var content = new MultipartFormDataContent();
            content.Add(new StringContent(entity.Name), "Name");
            content.Add(new StringContent(entity.EmailAddress), "EmailAddress");
            content.Add(new StringContent(entity.ContactNumber), "ContactNumber");
            if (entity.Image != null)
            {
                var imageContent = new StreamContent(entity.Image.OpenReadStream());
                imageContent.Headers.ContentType = new MediaTypeHeaderValue(entity.Image.ContentType);
                content.Add(imageContent, "LOGOFile", entity.Image.FileName);

            }
            var response = await _httpClient.PostAsync(WebAPI, content);
            //response.EnsureSuccessStatusCode();
            //var output= await response.Content.ReadFromJsonAsync<Adalot>();
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("index");
            }
            return View();
        }
    }
}
