using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Evidence_M9_MD_AJAX_Component.CustomComponents
{
    [HtmlTargetElement("my")]
    public class MyTagHelper : TagHelper
    {
        public string Message { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Content.SetContent($"Message: {Message}");
            base.Process(context, output);
        }
    }
}
