using BussinesLogic.Helpers;
using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

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
            List<DtoAsiento> asientos = (List<DtoAsiento>)Session["lstAsientos"];

            bool msg = HAeronave.getInstace().AddAeronave(nuevaAero, asientos);

            Session.Clear();

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

        [HttpPost]
        public ActionResult AsignAsientos(DtoAsiento asiento, SelectList selectList)
        {
            foreach (ListItem item in selectList.Items)
            {
                if (item.Value == asiento.tipo)
                    item.Enabled = false;
            }
            
            //selectList.Items.FindByValue(asiento.tipo).Enabled = false;
            

            //string tipo = asiento.tipo;
            List<DtoAsiento> asientos = null;
            //Usar session para mantener esa lista y luego pasarla por parametro en addaeronave.
            if (Session["lstAsientos"] == null)
            {
                asientos = new List<DtoAsiento>();

            }
            else
            {
                asientos = (List<DtoAsiento>)Session["lstAsientos"];

            }
       
            DtoAsiento dtoAsiento = new DtoAsiento();
            dtoAsiento = HAeronave.getInstace().AsignAsientos(asiento);
            asientos.Add(dtoAsiento);

            if (asientos.Count >= 4)
            {
                return RedirectToAction("AltaAeronave");
            }

            Session["lstAsientos"] = asientos;

            //Remove select values


            return RedirectToAction("AsignarAsientos");
        }

        public ActionResult ListadoAeronavesV()
        {
            List<DtoAeronave> colAero = HAeronave.getInstace().ListadoAeronaves();
            return View(colAero);
        }

        public ActionResult RemoveAeronave(int id)
        {
            HAeronave.getInstace().RemoveAeronave(id);
            return RedirectToAction("ListadoAeronavesV");
        }

        public ActionResult ConfirmarCambios(DtoAeronave dto)
        {
            dto.numeroAeronave = (int)Session["IdAeronave"];
            HAeronave.getInstace().ModificarAeronave(dto);
            Session.Clear();

            return RedirectToAction("ListadoAeronavesV");

        }

        public ActionResult ModificarAeronave(int id)
        {
            Session["IdAeronave"] = id;
            DtoAeronave aero = new DtoAeronave();

            aero = HAeronave.getInstace().GetAeronaveM(id);

            return View(aero);
        }



    }
}