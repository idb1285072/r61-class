using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using R61M9C11_ViewComponent.Models;

namespace R61M9C11_ViewComponent.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly InventoryContext _context;
        public HomeController(ILogger<HomeController> logger,InventoryContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index(int? id)
        {
            var model = _context.Products.OrderBy(p => p.ProductName).ToList();
            if (id.HasValue)
            {
                 model = model.Where(p => p.CategoryID.Equals(id.Value)).ToList();
            }
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
