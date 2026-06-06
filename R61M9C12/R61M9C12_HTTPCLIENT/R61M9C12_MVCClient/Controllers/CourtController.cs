using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using R61M9C12_MVCClient.DTOs;

namespace R61M9C12_MVCClient.Controllers
{
    public class CourtController : Controller
    {
        private readonly IHttpClientFactory _factory;
        IConfiguration _config;
        string apiUrl = "";

        public CourtController( IHttpClientFactory factory, IConfiguration config )
        {
            this._factory = factory;
            this._config = config;
            apiUrl = config.GetValue<string>("WebAPIBaseUrl")??"";
        }
        public async Task<IActionResult> Index()
        {

            return View(await Get());
        }
        [HttpGet()]
        public async Task<IEnumerable<CourtVM>> Get( )
        {
            try
            {
                HttpClient client = _factory.CreateClient();
                client.BaseAddress = new Uri( apiUrl);
               
               
                var response = await client.GetAsync("Courts");
                response.EnsureSuccessStatusCode();
                var model = await response.Content.ReadFromJsonAsync<IEnumerable<CourtVM>>();
                return model ?? Enumerable.Empty<CourtVM>();
            }
            catch (Exception ex) {
                ViewBag.err = ex.Message;
                return Enumerable.Empty<CourtVM>();
            }
        }
        public async Task<CourtVM> GetById(int id)
        {
            try
            {
                HttpClient client = _factory.CreateClient();
                client.BaseAddress = new Uri(apiUrl);
                var response = await client.GetAsync("Courts/"+id);
                response.EnsureSuccessStatusCode();
                var model = await response.Content.ReadFromJsonAsync<CourtVM>();
                return model?? new CourtVM();
            }
            catch (Exception ex)
            {
                ViewBag.err = ex.Message;
                return new CourtVM();
            }
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(CourtVM courtVM)
        {
            try
            {
                HttpClient client = _factory.CreateClient();
                client.BaseAddress = new Uri(apiUrl);
                var response = await client.PostAsJsonAsync("Courts",courtVM);
                response.EnsureSuccessStatusCode();
                //var model = await response.Content.ReadFromJsonAsync<IEnumerable<CourtVM>>();
                var code = response.StatusCode;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else {
                   ModelState.AddModelError("", response.ReasonPhrase??"Save failed");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(courtVM);
        }
        public async Task<ActionResult> Edit(int?id)
        {
            if(id == null)
            { return BadRequest("Id not provided"); }
            var model = await GetById(id.Value);
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(CourtVM courtVM)
        {
            try
            {
                HttpClient client = _factory.CreateClient();
                client.BaseAddress = new Uri(apiUrl);
                var response = await client.PutAsJsonAsync("Courts/"+courtVM.CourtId, courtVM);
                response.EnsureSuccessStatusCode();
                //var model = await response.Content.ReadFromJsonAsync<IEnumerable<CourtVM>>();
                var code = response.StatusCode;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", response.ReasonPhrase ?? "Save failed");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(courtVM);
        }
        [HttpGet]
        public async Task< ActionResult> Delete(int? id) {

            if (id == null)
            { return BadRequest("Id not provided"); }
            try
            {
                HttpClient client = _factory.CreateClient();
                client.BaseAddress = new Uri(apiUrl);
                var response = await client.DeleteAsync("Courts/" + id);
                response.EnsureSuccessStatusCode();
                //var model = await response.Content.ReadFromJsonAsync<CourtVM>();
            }
            catch (Exception ex)
            {
                ViewBag.err = ex.Message;
            }
            return RedirectToAction("Index");
        }
    }
}
