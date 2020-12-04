using BussinesLogic.Helpers;
using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlasPUMCliente.Controllers
{
    public class CompraController : Controller
    {
        // GET: Compra
        public ActionResult SelectAsientosV(string id)
        {
            List<DtoAsiento> lstAsientos = new List<DtoAsiento>();
            lstAsientos = HCompra.getInstace().getAsientos(id);

            return View(lstAsientos);
        }


    }
}