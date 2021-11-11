using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCVuelos.Controllers
{
        public class HomeController : Controller
        {
            // GET: Home
            public ActionResult Index()
            {
            ViewBag.Fecha = DateTime.Now.ToShortDateString();
            ViewBag.Title = "Bienvenidos al sitio web!";
            return View();
        }
        }

    }