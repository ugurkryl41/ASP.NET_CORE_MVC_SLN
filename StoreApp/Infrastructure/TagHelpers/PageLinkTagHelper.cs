using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using StoreApp.Models;

namespace StoreApp.Infrastructure.TagHelpers
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper
    {
        private readonly IUrlHelperFactory _urlHeperFactory;

        [ViewContext]
        [HtmlAttributeNotBound] //Html sayfasıyla bu ifadelerin eşleşmesini engeller.
        public ViewContext? ViewContext { get; set; }

        public Pagination PageModel { get; set; }
        public String? PageAction { get; set; }

        public bool PageClassesEnabled { get; set; } = false;
        public String PageClass { get; set; } = String.Empty;
        public String PageClassNormal { get; set; } = String.Empty;
        public String PageClassSelected { get; set; } = String.Empty;

        public PageLinkTagHelper(IUrlHelperFactory urlHeperFactory)
        {
            _urlHeperFactory = urlHeperFactory;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (ViewContext is not null && PageModel is not null)
            {
                IUrlHelper urlHelper = _urlHeperFactory.GetUrlHelper(ViewContext);

                TagBuilder result = new TagBuilder("div");

                for (int i = 1; i <= PageModel.TotalPages; i++)
                {
                    TagBuilder tag = new TagBuilder("a");
                    tag.Attributes["href"] = urlHelper.Action(PageAction, new { PageNumber = i });
                    if (PageClassesEnabled)
                    {
                        tag.AddCssClass(PageClass);
                        tag.AddCssClass(i == PageModel.CurrenPage ? PageClassSelected : PageClassNormal);
                    }
                    tag.InnerHtml.Append(i.ToString());
                    result.InnerHtml.AppendHtml(tag);
                }

                output.Content.AppendHtml(result.InnerHtml);
            }
        }
    }
}
