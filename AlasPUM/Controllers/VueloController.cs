using BussinesLogic.Helpers;
using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlasPUM.Controllers
{
    public class VueloController : Controller
    {
        // GET: Vuelo
        public ActionResult AgregarVuelo()
        {
            return View();
        }

        public ActionResult Frecuencia(List<int> days)
        {

            bool msg = true;
            TempData["days"] = days; 
            return View();
        }

        [HttpPost]
        public ActionResult AddVuelo(DtoVuelo nuevovuelo)
        {

            List<int> days = (List<int>)TempData["days"];
            bool msg = HVuelo.getInstace().AddVuelo(nuevovuelo);

            if (msg == true)
            {
                TempData["MessageP"] = "Vuelo agregado satisfactoriamente!";
            }
            else
            {
                TempData["MessageP"] = "Error, verifique los datos por favor!";
            }

            return RedirectToAction("AgregarVuelo");
        }

        public ActionResult ListarVuelo(string Tipo)
        {

            return View();
        }

        



    }
}