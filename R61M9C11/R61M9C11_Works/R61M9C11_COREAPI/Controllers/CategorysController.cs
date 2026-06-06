using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using R61M9C11_COREAPI.Models;

namespace R61M9C11_COREAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategorysController : ControllerBase
    {
        private readonly InventoryContext _inventoryContext;
        public CategorysController(InventoryContext inventoryContext)
        {
            this._inventoryContext = inventoryContext;
        }
        [HttpGet]
        public IActionResult Get()
        {

            return Ok(this._inventoryContext.Categories.ToList());
        }
    }
}
