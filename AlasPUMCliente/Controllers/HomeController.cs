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
            //ViewBag.PriceSort = sortOrder == "Price" ? "price_desc" : "Price";

            List<DtoVuelo> colVuelo = new List<DtoVuelo>();


            colVuelo = HVuelo.getInstace().GetVuelo();
            //Buscador por nombre de producto
            //if (!String.IsNullOrEmpty(searchString))
            //{
            //    colProducto = colProducto.Where(s => s.Descripcion.Contains(searchString)).ToList();
            //}
            //else
            //{

            //    colProducto = HProducto.getInstace().GetProducto();
            //}
            //Filtrado por precio
            //switch (sortOrder)
            //{

            //    case "Price":
            //        colProducto = colProducto.OrderBy(s => s.PrecioVenta).ToList();
            //        break;
            //    default:
            //        colProducto = colProducto.OrderByDescending(s => s.PrecioVenta).ToList();
            //        break;
            //}

            //Cargar viebag de familia
            //List<DtoCategoria> colTipos = HCategoria.getInstace().GetCategoria();

            //List<SelectListItem> colSelectItems = new List<SelectListItem>();

            //foreach (DtoCategoria item in colTipos)
            //{
            //    SelectListItem opcion = new SelectListItem();
            //    opcion.Text = item.Nombre;
            //    opcion.Value = item.Nombre;
            //    colSelectItems.Add(opcion);
            //}

            //ViewBag.colFamilias = colSelectItems;



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