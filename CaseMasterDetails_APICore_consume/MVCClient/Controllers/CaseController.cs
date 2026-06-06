using Microsoft.AspNetCore.Mvc;
using MVCClient.DTO;

namespace MVCClient.Controllers
{
	public class CaseController : Controller
	{
		private readonly IHttpClientFactory _factory;
			IConfiguration _config;
			string apiUrl = "";

			public CaseController(IHttpClientFactory factory, IConfiguration config)
			{
				this._factory = factory;
				this._config = config;
				apiUrl = config.GetValue<string>("WebAPIBaseUrl") ?? "";
			}
			public async Task<IActionResult> Index()
			{

				return View(await Get());
			}
			[HttpGet()]
			public async Task<IEnumerable<CaseMaster>> Get()
			{
				try
				{
					HttpClient client = _factory.CreateClient();
					client.BaseAddress = new Uri(apiUrl);


					var response = await client.GetAsync("CaseMasters");
					response.EnsureSuccessStatusCode();
					var model = await response.Content.ReadFromJsonAsync<IEnumerable<CaseMaster>>();
					return model ?? Enumerable.Empty<CaseMaster>();
				}
				catch (Exception ex)
				{
					ViewBag.err = ex.Message;
					return Enumerable.Empty<CaseMaster>();
				}
			}
			public async Task<CaseMaster> GetById(int id)
			{
				try
				{
					HttpClient client = _factory.CreateClient();
					client.BaseAddress = new Uri(apiUrl);
					var response = await client.GetAsync("CaseMasters/" + id);
					response.EnsureSuccessStatusCode();
					var model = await response.Content.ReadFromJsonAsync<CaseMaster>();
					return model ?? new CaseMaster();
				}
				catch (Exception ex)
				{
					ViewBag.err = ex.Message;
					return new CaseMaster();
				}
			}
			public ActionResult Create()
			{
				return View();
			}
			[HttpPost]
			public async Task<ActionResult> Create(CaseMaster courtVM)
			{
				try
				{
					HttpClient client = _factory.CreateClient();
					client.BaseAddress = new Uri(apiUrl);
					var response = await client.PostAsJsonAsync("Master", courtVM);
					//response.EnsureSuccessStatusCode();
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
			public async Task<ActionResult> Edit(int? id)
			{
				if (id == null)
				{ return BadRequest("Id not provided"); }
				var model = await GetById(id.Value);
				return View(model);
			}
			[HttpPost]
			public async Task<ActionResult> Edit(CaseMaster courtVM)
			{
				try
				{
					HttpClient client = _factory.CreateClient();
					client.BaseAddress = new Uri(apiUrl);
					var response = await client.PutAsJsonAsync("Master/" + courtVM.Id, courtVM);
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
			public async Task<ActionResult> Delete(int? id)
			{

				if (id == null)
				{ return BadRequest("Id not provided"); }
				try
				{
					HttpClient client = _factory.CreateClient();
					client.BaseAddress = new Uri(apiUrl);
					var response = await client.DeleteAsync("Case/" + id);
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

