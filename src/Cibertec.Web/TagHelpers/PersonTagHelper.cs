using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace Cibertec.Web.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("person")]
    public class PersonTagHelper : TagHelper
    {
        [HtmlAttributeName("descripcion")]
        public string Descripcion { get; set; }
        [HtmlAttributeName("stock")]
        public int Stock { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            var sb = new StringBuilder();
            sb.AppendFormat("<div>");
            sb.AppendFormat("<h3>{0}</h3>", this.Descripcion);
            sb.AppendFormat("<p>Stock: {0}</p>", this.Stock);

            output.PreContent.SetHtmlContent(sb.ToString());
            output.PostContent.SetHtmlContent("</div>");
        }
    }
}
