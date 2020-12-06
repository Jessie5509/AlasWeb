using BussinesLogic.Helpers;
using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlasPUM.Controllers
{
    public class PasajesController : Controller
    {
        // GET: Pasajes
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult pasajesRealizados()
        {
            List<DtoCompra> colCompra = HCompra.getInstace().getCompras();
            return View(colCompra);

        }

    }
}