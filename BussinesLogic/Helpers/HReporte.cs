using Common.DTO;
using DataAccess.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Helpers
{
    public class HReporte
    {
        private static HReporte _instance;
        public static HReporte getInstace()
        {
            if (_instance == null)
            {
                _instance = new HReporte();
            }

            return _instance;
        }

        public DtoCliente getClienteMasReservas(DtoClienteMasReservas dto)
        {
            PReporte pe = new PReporte();
            return pe.getClienteMasReservas(dto);

        }

        public List<DtoVuelo> getVuelosMasAsientos(DtoVuelosMasAsientosVacios dto)
        {
            PReporte pe = new PReporte();
            return pe.getVuelosMasAsientos(dto);

        }
        

    }
}
