using BussinesLogic.Helpers;
using Common.DTO;
using DataAccess.Mappers;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlasPUMCliente.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string Destino, string Origen, string FechaSalida, string Fechallegada, string cant)
        {
            //ViewBag.PriceSort = sortOrder == "Price" ? "price_desc" : "Price";

            List<DtoVuelo> colVuelo = new List<DtoVuelo>();
            List<DtoAeronave> colAero = new List<DtoAeronave>();

            colVuelo = HVuelo.getInstace().GetVuelo();
            
            //Buscador por nombre de producto
            if (!String.IsNullOrEmpty(Destino) && !String.IsNullOrEmpty(Origen))
            {
                colVuelo = colVuelo.Where(s => s.destino == Destino && s.origen == Origen).ToList();
            }
            else if (!String.IsNullOrEmpty(FechaSalida) && !String.IsNullOrEmpty(Fechallegada))
            {
                colVuelo = colVuelo.Where(s => s.dtLlegada == DateTime.Parse(Fechallegada) && s.dtSalida == DateTime.Parse(FechaSalida)).ToList();
            }
            
            else if (!String.IsNullOrEmpty(cant) )
            {
                int id = int.Parse(cant);
                colVuelo = HVuelo.getInstace().Getcant(id, colVuelo);
            }


            return View(colVuelo);
        }

        public ActionResult VueloInfo(string id)
        {
            DtoVuelo vuelo = new DtoVuelo();
            vuelo = HVuelo.getInstace().GetVueloInfo(id);

            return View(vuelo);
        }

    }
}