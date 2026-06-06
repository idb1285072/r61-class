using Microsoft.AspNetCore.Mvc;
using R61M9C11_ViewComponent.Models;

namespace R61M9C11_ViewComponent.ViewComponents
{
    public class CategoryViewComponent:ViewComponent
    {
        private readonly InventoryContext _context;
        public CategoryViewComponent(InventoryContext context)
        {
            _context = context; 
            
        }
        public async Task<IViewComponentResult>   InvokeAsync()
        {
            var model = _context.Categories.OrderBy(c=>c.CategoryName).ToList();
            return View(model);
        }
    }
}
