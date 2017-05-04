using System.Web.Mvc;

namespace ComputerStore.Web.Extensions
{
    public static class HtmlHelperExtensions
    {

        public static MvcHtmlString Image(this HtmlHelper helpre, string url, string alt)
        {
            TagBuilder builder = new TagBuilder("img");
            builder.AddCssClass("img-thumbnail");
            builder.MergeAttribute("src", url);
            builder.MergeAttribute("style", "width:700px; height:500px;");
            builder.MergeAttribute("alt", alt);

            return new MvcHtmlString(builder.ToString(TagRenderMode.SelfClosing));

        }

        public static MvcHtmlString Image2(this HtmlHelper helpre, string url, string alt)
        {
            TagBuilder builder = new TagBuilder("img");
            builder.AddCssClass("img-thumbnail");
            builder.MergeAttribute("src", url);
            builder.MergeAttribute("style", "width:300px; height:200px;");
            builder.MergeAttribute("alt", alt);

            return new MvcHtmlString(builder.ToString(TagRenderMode.SelfClosing));

        }
        public static MvcHtmlString Image3(this HtmlHelper helpre, string url, string alt)
        {
            TagBuilder builder = new TagBuilder("img");
            builder.AddCssClass("img-thumbnail");
            builder.MergeAttribute("src", url);
            builder.MergeAttribute("style", "background");
            builder.MergeAttribute("alt", alt);

            return new MvcHtmlString(builder.ToString(TagRenderMode.SelfClosing));

        }

    }
}