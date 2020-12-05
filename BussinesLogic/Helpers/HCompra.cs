using Common.DTO;
using DataAccess.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Helpers
{
    public class HCompra
    {
        private static HCompra _instance;
        public static HCompra getInstace()
        {
            if (_instance == null)
            {
                _instance = new HCompra();
            }

            return _instance;
        }

        public List<DtoAsiento> getAsientos(string id)
        {
            PCompra pe = new PCompra();
            return pe.AsientosByVuelo(id);
        }

        public DtoAsiento asientoComprado(int id)
        {
            PCompra pe = new PCompra();
            return pe.asientoComprado(id);
        }

        public bool AddClienteCompra(DtoCliente dto, string idVuelo, List<DtoAsiento> colAsientos)
        {
            PCompra pe = new PCompra();
            return pe.AddClienteCompra(dto, idVuelo, colAsientos);
        }
        


    }
}
