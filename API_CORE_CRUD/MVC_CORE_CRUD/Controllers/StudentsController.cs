using Microsoft.AspNetCore.Mvc;
using MVC_CORE_CRUD.Models;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MVC_CORE_CRUD.Controllers
{

    public class StudentsController : Controller
    {
        private string url = "https://localhost:7044/api/students";
        private HttpClient client = new HttpClient();

        [HttpGet]
        public IActionResult Index()
        {
            List<Student> students = new List<Student>();
            HttpResponseMessage response = client.GetAsync(url).Result;
            if(response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<List<Student>>(result);  
                if(data != null)
                {
                    students = data;
                }
            }
            return View(students);
        }
    }
}
