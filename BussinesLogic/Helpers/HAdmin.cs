using Common.DTO;
using DataAccess.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Helpers
{
    public class HAdmin
    {
        private static HAdmin _instance;
        public static HAdmin getInstace()
        {
            if (_instance == null)
            {
                _instance = new HAdmin();
            }

            return _instance;
        }

        public bool ExisteEmpleado(DtoAdm dto)
        {
            PAdmin pe = new PAdmin();
            return pe.existeEmpleado(dto);
        }

        public bool AddAdministrador(DtoAdm dto)
        {
            PAdmin pe = new PAdmin();
            return pe.RegistrarEmpleado(dto);

        }
    }
}
