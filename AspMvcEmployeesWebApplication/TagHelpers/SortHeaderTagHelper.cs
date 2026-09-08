using AspMvcEmployeesWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Data.SqlClient;

namespace AspMvcEmployeesWebApplication.TagHelpers
{
    public class SortHeaderTagHelper : TagHelper
    {
        public SortState Property { get; set; }
        public SortState CurrentState { get; set; }
        public string? Action { get; set; }
        public bool Asc { get; set; }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; } = null!;

        IUrlHelperFactory urlHelperFactory;
        public SortHeaderTagHelper(IUrlHelperFactory urlHelperFactory)
        {
            this.urlHelperFactory = urlHelperFactory;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
            output.TagName = "a";

            string? url = urlHelper.Action(Action, new { sortOrder = Property });
            output.Attributes.SetAttribute("href", url);

            if(CurrentState == Property)
            {
                TagBuilder tag = new TagBuilder("i");
                tag.AddCssClass("bi");

                if (Asc == true)
                    tag.AddCssClass("bi-arrow-up-square");
                else
                    tag.AddCssClass("bi-arrow-down-square");

                output.PreContent.AppendHtml(tag);
            }
        }
    }
}
