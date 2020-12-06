using Common.DTO;
using DataAccess.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Helpers
{
    public class HVideo
    {

        private static HVideo _instance;
        public static HVideo getInstace()
        {
            if (_instance == null)
            {
                _instance = new HVideo();
            }

            return _instance;
        }

        public void AsignarVideo(DtoCliente dto)
        {
            PVideo pc = new PVideo();
             pc.AsignarVideo(dto);
        }


    }
}
