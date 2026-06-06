//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;

using Microsoft.AspNetCore.Mvc;

namespace Evidence_M9_MD_AJAX_Component.ViewComponents
{
    public class DetailsViewComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View());
        }
    }
}
