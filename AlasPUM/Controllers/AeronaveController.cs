using BussinesLogic.Helpers;
using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlasPUM.Controllers
{
    public class AeronaveController : Controller 
    {
        // GET: Aeronave
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AltaAeronave()
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"].ToString();

            }

            return View();
        }

        [HttpPost]
        public ActionResult AddAeronave(DtoAeronave nuevaAero)
        {
            bool msg = HAeronave.getInstace().AddAeronave(nuevaAero);

            if (msg == true)
            {
                TempData["Message"] = "Aeronave guardada satisfactoriamente!";
            }
            else
            {
                TempData["Message"] = "Completa todos los campos por favor!";
            }

            return RedirectToAction("AltaAeronave");
        }

        public ActionResult AsignarAsientos()
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"].ToString();

            }

            return View();
        }

        //[HttpPost]
        //public ActionResult AsignAsientos(DtoAsiento asiento)
        //{
        //    bool msg = HAeronave.getInstace().AsignAsientos(asiento);

        //    if (msg == true)
        //    {
        //        TempData["Message"] = "Aeronave guardada satisfactoriamente!";
        //    }
        //    else
        //    {
        //        TempData["Message"] = "Completa todos los campos por favor!";
        //    }

        //    return RedirectToAction("AltaAeronave");
        //}

    }
}