using Puc2.Controllers.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Puc2.Mvc.Controllers
{
    public class HomeController : ControlerPuc
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Descrição da aplicação.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Pagina de contato.";

            return View();
        }
    }
}