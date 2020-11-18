using BussinesLogic.Helpers;
using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlasPUM.Controllers
{
    public class NacionalController : Controller
    {
        // GET: Nacional
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddNacional()
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"].ToString();

            }

            return View();
        }

        [HttpPost]
        public ActionResult RegistrarNacional(DtoNacional NewNacional)
        {
            bool msg = HNacional.getInstace().RegistrarNacional(NewNacional);

            if (msg == true)
            {
                TempData["MessageP"] = "Vuelo Nacional agregado satisfactoriamente!";
            }
            else
            {
                TempData["MessageP"] = "Error, verifique los datos por favor!";
            }

            return RedirectToAction("AddNacional");
        }


    }
}