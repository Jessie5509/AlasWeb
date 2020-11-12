using BussinesLogic.Helpers;
using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlasPUM.Controllers
{
    public class AdministradorController : Controller
    {
        // GET: Administrador
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RegistroAdm()
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"].ToString();

            }

            return View();
        }

        [HttpPost]
        public ActionResult AddAdministrador(DtoAdm nuevoAdministrador)
        {
            bool msg = HAdmin.getInstace().AddAdministrador(nuevoAdministrador);

            if (msg == true)
            {
                TempData["Message"] = "Empleado registrado satisfactoriamente!";
            }
            else
            {
                TempData["Message"] = "Completa todos los campos por favor!";
            }

            return RedirectToAction("RegistroAdm");
        }
    }
}