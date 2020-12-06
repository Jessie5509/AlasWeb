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
                return pr.Frecuencia(dto, days);

            }
            else if (dto.Intercontinental.documentacion != null && dto.Intercontinental.tasaIntercontinental != 0 && dto.Intercontinental.visa != null)
            {
                PIntercontinental pi = new PIntercontinental();
               return pi.Frecuencia(dto, days);

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

        public List<DtoVuelo> Getcant(int cant, List<DtoVuelo> colVuelo)
        {
            PVuelo pp = new PVuelo();
            return pp.Getcant(cant, colVuelo);
        }
        public List<DtoVuelo> GetTodos(int cant, List<DtoVuelo> colVuelo, string Origen, string Destino, string FechaSalida, string Fechallegada)
        {
            PVuelo pp = new PVuelo();
            return pp.GetTodos(cant, colVuelo, Origen, Destino, FechaSalida, Fechallegada);
        }
        
        public List<DtoVuelo> GetVuelo()
        {
            PVuelo pc = new PVuelo();
            return pc.GetVuelo();
        }



    }
}
