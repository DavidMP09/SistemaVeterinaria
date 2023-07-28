using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Veterinaria.Models;

namespace Veterinaria.Controllers
{
    [ValidarIniciodeSesion]
    public class HomeController : Controller
    {
        // --------
        DaoTotales daoTotales = new DaoTotales();
        //-------------
        public ActionResult Index()
        {
            List<EntidadTotales> listado = daoTotales.listar();
            return View(listado);
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