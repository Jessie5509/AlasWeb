using BussinesLogic.Helpers;
using BussinesLogic.interfaces;
using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic
{
    public class ProxyVideo : IVideo
    {

        private IVideo video;
        public ProxyVideo(IVideo video)
        {

            this.video = video;

        }

        public string AgregarVideo(DtoCliente dto)
        {

            string existe = HCompra.getInstace().TieneVideo(dto);

            if (existe == null)
            {
                HVideo.getInstace().AsignarVideo(dto);
                 existe = HCompra.getInstace().TieneVideo(dto);

            }
            else if ( existe != null)
            {

                return existe;
            }
            return existe;
        }
    }
}
