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

        [HttpPost]
        public ActionResult AddVuelo(DtoVuelo nuevovuelo, List<int> days)
        {
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

        [HttpGet]
        public ActionResult Filtro(string Tipo)
        {
            
            switch (Tipo)
            {
                case "Regional":
                    List<DtoVuelo> colReg = new List<DtoVuelo>();
                    colReg = HVuelo.getInstace().GetVuelo(Tipo);
                    return View(colReg);
                case "Intercontinental":
                    List<DtoVuelo> colInter = new List<DtoVuelo>();
                    colInter = HVuelo.getInstace().GetVuelo(Tipo);
                    return PartialView(colInter);
                case "Nacional":
                    List<DtoVuelo> colNac = new List<DtoVuelo>();
                    colNac = HVuelo.getInstace().GetVuelo(Tipo);
                    return PartialView( colNac);
                default:
                    return RedirectToAction("ListarVuelo");

            }
                       

        }


    }
}