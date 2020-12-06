using BussinesLogic;
using BussinesLogic.Clases;
using BussinesLogic.interfaces;
using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlasPUMCliente.Controllers
{
    public class VideoController : Controller
    {
        // GET: Video
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult VerVideo(DtoCliente dto)
        {

            IVideo videoproxy = new ProxyVideo(new ClaseVideo());
            string video = videoproxy.AgregarVideo(dto);
            ViewBag.UrlVideo = video;
            return View();

        }
    }
}
