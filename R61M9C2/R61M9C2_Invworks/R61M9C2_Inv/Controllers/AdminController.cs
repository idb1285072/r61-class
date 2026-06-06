using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace R61M9C2_Inv.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
