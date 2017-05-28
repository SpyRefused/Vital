using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Vital.Api.Copyshop.Options;

namespace Vital.Api.Copyshop
{
    public class ActionAsPdf : AsPdfResultBase
    {
        public ActionAsPdf(IHostingEnvironment hostingEnvironment, string footer, string header) : base(hostingEnvironment)
        {
            PageMargins = new Margins(0, 0, 20, 0);
            Footer = footer;
            //Header = header;
        }

        protected override string GetUrl(ActionContext context)
        {
            return context.HttpContext.Request.GetDisplayUrl().Replace("Print",string.Empty);
        }
    }
}
