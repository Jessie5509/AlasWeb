using BussinesLogic.Helpers;
using Common.DTO;
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

        public ActionResult ClienteMasReservasV()
        {

            return View();
        }

        public ActionResult ClienteMasReservas(DtoClienteMasReservas dto)
        {
            DtoCliente reporte = new DtoCliente();
            reporte = HReporte.getInstace().getClienteMasReservas(dto);

            return View();
        }


        //Reporte 3

        public ActionResult VuelosMasAsientosVaciosV()
        {

            return View();        
        }

        public ActionResult VuelosMasAsientosVacios(DtoVuelosMasAsientosVacios dto)
        {
            List<DtoVuelo> lstVuelosMasAsientos = new List<DtoVuelo>();
            lstVuelosMasAsientos = HReporte.getInstace().getVuelosMasAsientos(dto);

            return View(lstVuelosMasAsientos);
        }

    }
}