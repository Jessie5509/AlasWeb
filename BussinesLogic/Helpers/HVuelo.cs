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

       public bool AddVuelo(DtoVuelo dto)
        {
            if (dto.Regional.documentacion != null && dto.Regional.tasaRegional != 0)
            {

                PRegional pr = new PRegional();
                return pr.VueloRegional(dto);

            }
            else if (dto.Intercontinental.documentacion != null && dto.Intercontinental.tasaIntercontinental != 0 && dto.Intercontinental.visa != null)
            {
                PIntercontinental pi = new PIntercontinental();
               return pi.VueloInternacional(dto);

            }
            else if (dto.Intercontinental.documentacion == null && dto.Intercontinental.tasaIntercontinental == 0 && dto.Intercontinental.visa == null && dto.Regional.documentacion == null && dto.Regional.tasaRegional == 0)
            {
                PNacional pn = new PNacional();
                return pn.VueloNacional(dto);

            }
            return true;
        }

        public List<DtoVuelo> GetVuelo(string Tipo)
        {
            switch (Tipo)
            {
               /* case "Regional":
                    PRegional pr = new PRegional();
                    return pr.GetVuelo();

                case "Intercontinental":
                    PIntercontinental pi = new PIntercontinental();
                    return pi.GetVuelo();
               */
                default:
                    PNacional pn = new PNacional();
                    return pn.GetVuelo();
            }

        }

    }
}
