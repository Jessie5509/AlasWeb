using Common.DTO;
using DataAccess.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Helpers
{
    public class HNacional
    {

        private static HNacional _instance;
        public static HNacional getInstace()
        {
            if (_instance == null)
            {
                _instance = new HNacional();
            }

            return _instance;
        }

        public bool RegistrarNacional(DtoNacional dto)
        {
            PNacional pn = new PNacional();
            return pn.RegistarNacional(dto);
        }

    }
}
