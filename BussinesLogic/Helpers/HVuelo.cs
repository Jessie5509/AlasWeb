using Common.DTO;
using DataAccess.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Helpers
{
    public class HVuelo
    {

        private static HVuelo _instance;
        public static HVuelo getInstace()
        {
            if (_instance == null)
            {
                _instance = new HVuelo();
            }

            return _instance;
        }

        public bool AddVuelo(DtoVuelo dto, List<string> days)
       {
            if (dto.Regional.documentacion != null && dto.Regional.tasaRegional != 0)
            {

                PRegional pr = new PRegional();
                return pr.VueloRegional(dto, days);

            }
            else if (dto.Intercontinental.documentacion != null && dto.Intercontinental.tasaIntercontinental != 0 && dto.Intercontinental.visa != null)
            {
                PIntercontinental pi = new PIntercontinental();
               return pi.VueloInternacional(dto, days);

            }
            else if (dto.Intercontinental.documentacion == null && dto.Intercontinental.tasaIntercontinental == 0 && dto.Intercontinental.visa == null && dto.Regional.documentacion == null && dto.Regional.tasaRegional == 0)
            {
                PNacional pn = new PNacional();
                return pn.Frecuencia(dto, days);

            }
            return true;
       }

        public DtoVuelo GetVueloInfo(string id)
        {
            PVuelo pp = new PVuelo();
            return pp.GetVueloInfo(id);
        }

        public List<DtoVuelo> GetVuelo()
        {
            PVuelo pc = new PVuelo();
            return pc.GetVuelo();
        }



    }
}
