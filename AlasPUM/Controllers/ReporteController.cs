using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlasPUM.Controllers
{
    public class ReporteController : Controller
    {
        // GET: Reporte
        public ActionResult Index()
        {
            return View();
        }

        //Reporte 1
        public ActionResult PorcentajeVuelos()
        {

            return View();
        }

        public ActionResult Reporte1()
        {
            return RedirectToAction("PorcentajeVuelos");
        }

        //Reporte 2

        public ActionResult ClienteMasReservas()
        {

            return View();
        }

        //Reporte 3

        public ActionResult VuelosMasAsientosVacios()
        {
            return View();        
        }

    }
}