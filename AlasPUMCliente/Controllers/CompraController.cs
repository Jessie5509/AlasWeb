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
            if (id == null)
            {
                id = (string)Session["idVuelo"];
            }

            Session["idVuelo"] = id;

            List<DtoAsiento> lstAsientos = new List<DtoAsiento>();
            lstAsientos = HCompra.getInstace().getAsientos(id);

            return View(lstAsientos);
        }
        
        public ActionResult ComprarPasaje(int id)
        {
            List<DtoAsiento> lstasientosComprados = null;

            if (Session["AsientosComprados"] == null)
            {
                lstasientosComprados = new List<DtoAsiento>();

            }
            else
            {
                lstasientosComprados = (List<DtoAsiento>)Session["AsientosComprados"];

            }

            DtoAsiento asientos = new DtoAsiento();
            asientos = HCompra.getInstace().asientoComprado(id);

            lstasientosComprados.Add(asientos);

            Session["AsientosComprados"] = lstasientosComprados;


            return RedirectToAction("SelectAsientosV");
        }

        public ActionResult ConfirmarAsientos()
        {
            List<DtoAsiento> AsientosConfirmados = (List<DtoAsiento>)Session["AsientosComprados"];
            float precio = 0;

            foreach (DtoAsiento item in AsientosConfirmados)
            {
                precio = (float)(precio + item.precio);
            }

            TempData["Precio"] = precio;

            return View(AsientosConfirmados);
        }

        public ActionResult DatosClienteV()
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"].ToString();

            }

            return View();
        }

        public ActionResult RellenarCompra(DtoCliente dto)
        {
            string idVuelo = (string)Session["idVuelo"];
            List<DtoAsiento> AsientosConfirmados2 = (List<DtoAsiento>)Session["AsientosComprados"];

            bool msg = HCompra.getInstace().AddClienteCompra(dto, idVuelo, AsientosConfirmados2);

            //TempData Messages
            if (msg == true)
            {
                TempData["Compra"] = "¡Compra realizada con éxito!";
                Session.Clear();
                return RedirectToAction("MsgCompra");
            }
            else
            {
                TempData["Message"] = "Completa todos los campos por favor!";
                Session.Clear();
                return RedirectToAction("DatosClienteV");
            }

        }

        public ActionResult MsgCompra()
        {
            if (TempData["Compra"] != null)
            {
                ViewBag.Compra = TempData["Compra"].ToString();

            }

            return View();
        }





    }
}