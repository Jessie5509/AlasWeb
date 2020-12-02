using BussinesLogic.Helpers;
using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlasPUMCliente.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
/*
        public ActionResult VueloInfo(int id)
        {
            DtoVuelo vuelo = new DtoVuelo();
            vuelo = HVuelo.getInstace().GetProductoInfo(id);

            return View(vuelo);
        }
*/
    }
}