using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Vital.Api.Copyshop;
using Vital.Doctor;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Vital.Api.Controllers
{
    [Route("[controller]")]
    public class PdfController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public PdfController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [AllowAnonymous]
        [HttpGet("PrintTaxInformationCertificate/{idDoctor}/{year}/{language}")]
        // GET: /<controller>/
        public IActionResult PrintTaxInformationCertificate(int idDoctor, int year, string language)
        {
            //ActionContext
            return new ActionAsPdf(_hostingEnvironment,Request.Host.Value+ "/pdf/footer.html", Request.Host.Value + "/pdf/header.html");
        }

        [AllowAnonymous]
        [HttpGet("TaxInformationCertificate/{idDoctor}/{year}/{language}")]
        public IActionResult TaxInformationCertificate(int idDoctor, int year, string language)
        {
            return View("TaxInformationCertificate_" + language, new TaxInformationCerficate{Cif = "E17329822", Name = "ANESTESIA GIRONA C.B.", Year = "2017"});
        }

        [AllowAnonymous]
        [HttpGet("Footer")]
        public IActionResult Footer()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet("Header")]
        public IActionResult Header()
        {
            return View();
        }
    }
}
    