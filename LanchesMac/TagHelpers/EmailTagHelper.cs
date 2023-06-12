using Microsoft.AspNetCore.Razor.TagHelpers;

namespace LanchesMac.TagHelpers
{
    public class EmailTagHelper : TagHelper
    {
        public string Address { get; set; }
        public string EmailContent { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Attributes.SetAttribute("href", "mailto:" + Address);
            output.Content.SetContent(EmailContent);
        }
    }
}
