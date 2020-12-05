using BussinesLogic.Helpers;
using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlasPUM.Controllers
{
    public class TiposVueloController : Controller
    {
        // GET: TiposVuelo
        public ActionResult Index()
        {
            return View();
        }
/*
        public ActionResult ModificarNacional(int numero)
        {
            DtoVuelo nac = new DtoVuelo();

            nac = HVuelo.getInstace().GetVuelo(numero);



            return View(nac);
        }
*/
    
    public ActionResult ListarNacional()
        {
            List<DtoNacional> ColNac = new List<DtoNacional>();
            ColNac = HTipo.getInstace().GetNacional();
            return View("ListarNacional", ColNac);
        }

        public ActionResult ListarRegional()
        {
            List<DtoRegional> ColReg = new List<DtoRegional>();
            ColReg = HTipo.getInstace().GetRegional();
            return View("ListarRegional", ColReg);
        }


        public ActionResult ListarIntercontinental()
        {
            List<DtoIntercontinental> colInt = new List<DtoIntercontinental>();
            colInt = HTipo.getInstace().GetIntercontinental();
            return View("ListarIntercontinental", colInt);
        }

    }
}