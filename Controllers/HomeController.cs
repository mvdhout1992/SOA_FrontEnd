using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SOA_FrontEnd.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Index(PaymentValidationReference.PaymentType paymentType)
        {
            paymentType.ExpireDate = "0316";
            var client = new PaymentValidationReference.validatePaymentPortTypeClient();
            client.Open();
            var res = client.validate(paymentType);
            var response = new PaymentValidationReference.validateResponse(res);
            Debug.WriteLine(res.Status);

            ViewBag.Response = res.Status;
            return View("Thanks");
        }

        public ActionResult Thanks()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}