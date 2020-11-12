using BussinesLogic.Helpers;
using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AlasPUM.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoginV()
        {
            if (User.Identity.IsAuthenticated == true)
            {
                return Redirect("/Home");
            }

            return View();
        }

        public ActionResult LogOut()
        {
            //SignOut() Limpia la Cookie de Autenticación
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("LoginV");
        }


        public ActionResult Login(DtoAdm dto)
        {
            bool existe = HAdmin.getInstace().ExisteEmpleado(dto);

            if (existe)
            {
                //Crea la Cookie para que el usuario sea autenticado
                FormsAuthentication.SetAuthCookie(dto.NombreUsuario, false);
                Session["NombreDeUsuario"] = dto.NombreUsuario;
                Session["Contraseña"] = dto.contraseña;

                return Redirect("/Home");
            }

            return View();
        }

    }
}