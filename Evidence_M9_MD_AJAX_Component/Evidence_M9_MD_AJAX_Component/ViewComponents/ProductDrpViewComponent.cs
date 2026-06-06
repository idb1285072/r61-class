using Evidence_M9_MD_AJAX_Component.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Evidence_M9_MD_AJAX_Component.ViewComponents
{
    public class ProductDrpViewComponent : ViewComponent
    {
        private readonly DbEv7Context _db;
        public ProductDrpViewComponent(DbEv7Context db)
        {
            _db = db;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.ProductId = new SelectList( _db.Products.OrderBy(p=>p.Name),"Id","Name");
            return await Task.FromResult((IViewComponentResult)View( ));
        }
    }
}
