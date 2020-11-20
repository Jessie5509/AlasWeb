using Common.DTO;
using DataAccess.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Helpers
{
    public class HAeronave
    {
        private static HAeronave _instance;
        public static HAeronave getInstace()
        {
            if (_instance == null)
            {
                _instance = new HAeronave();
            }

            return _instance;
        }

        public bool AddAeronave(DtoAeronave dto)
        {
            PAeronave pe = new PAeronave();
            return pe.AddAeronave(dto);

        }

        public List<DtoAsiento> AsignAsientos(DtoAsiento dto)
        {
            PAeronave pe = new PAeronave();
            return pe.Asientos(dto);

        }



    }
}
