using System.Web;
using System.Web.Mvc;
namespace OnlineGame.Web.CustomHtmlHelper
{
    public static class CustomHtmlHelper
    {
        public static IHtmlString Image(this HtmlHelper customHtmlHelper, string src, string alt)
        {
            // Create <img> tag
            TagBuilder tb = new TagBuilder("img");
            // Add src attribute
            tb.Attributes.Add("src", VirtualPathUtility.ToAbsolute(src));
            // Add alt attribute
            tb.Attributes.Add("alt", alt);
            // return MvcHtmlString object which implements IHtmlString interface.
            return new MvcHtmlString(tb.ToString(TagRenderMode.SelfClosing));
        }
        public static string ImageString(this HtmlHelper customHtmlHelper, string src, string alt)
        {
            // Create <img> tag
            TagBuilder tb = new TagBuilder("img");
            // Add src attribute
            tb.Attributes.Add("src", VirtualPathUtility.ToAbsolute(src));
            // Add alt attribute
            tb.Attributes.Add("alt", alt);
            // return MvcHtmlString object which implements IHtmlString interface.
            return tb.ToString(TagRenderMode.SelfClosing);
        }
    }
}
/*
1.
Create Custom Html Helper
1.1.
Html helper is an extension method,
so an extension method needs to be a static method in a static class.
The first parameter must have this keyword represents the calling object.
In this case, "this System.Web.Mvc.HtmlHelper customHtmlHelper"
1.2.
Use TagBuilder to create HTML tag.
1.3.
Return MvcHtmlString object which implements IHtmlString interface.
1.4.
The view which uses this Html helper needs to "using this namespace".
In this case, "Using OnlineGame.Web.CustomHtmlHelper"
If you want this HTML helper is available in all views,
You need to include this namespace in Views/web.config file.
E.g.
//<system.web.webPages.razor>
//<host factoryType = "System.Web.Mvc.MvcWebRazorHostFactory, System.Web.Mvc, Version=5.2.3.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" />
//< pages pageBaseType="System.Web.Mvc.WebViewPage">
//<namespaces>
//    <add namespace="System.Web.Mvc" />
//    <add namespace="System.Web.Mvc.Ajax" />
//    <add namespace="System.Web.Mvc.Html" />
//    <add namespace="System.Web.Routing" />
//    <add namespace="OnlineGame.Web" />
//    <add namespace="OnlineGame.Web.CustomHtmlHelper" />
//</namespaces>
//</pages>
//</system.web.webPages.razor>
*/
