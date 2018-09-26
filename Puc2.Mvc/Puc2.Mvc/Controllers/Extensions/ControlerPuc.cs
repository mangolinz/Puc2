using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Puc2.Controllers.Extensions
{
    public class ControlerPuc : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpRequestBase req = filterContext.HttpContext.Request;
            HttpResponseBase res = filterContext.HttpContext.Response;
#if !DEBUG
            if (!req.IsSecureConnection && !req.IsLocal)
            {
                var builder = new UriBuilder(req.Url)
                {
                    Scheme = Uri.UriSchemeHttps,
                    Port = 443
                };
                res.Redirect(builder.Uri.ToString());
            }
#endif

            Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            DateTime buildDate = new DateTime(2000, 1, 1)
                                    .AddDays(version.Build).AddSeconds(version.Revision * 2);
            ViewBag.DisplayVersion = $"{version} ({buildDate})";

            if (filterContext.HttpContext.Request.IsAuthenticated)
            {

            }

            base.OnActionExecuting(filterContext);
        }
    }

}