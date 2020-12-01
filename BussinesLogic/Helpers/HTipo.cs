using Common.DTO;
using DataAccess.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Helpers
{
    public class HTipo
    {

        private static HTipo _instance;
        public static HTipo getInstace()
        {
            if (_instance == null)
            {
                _instance = new HTipo();
            }

            return _instance;
        }

        public List<DtoNacional> GetNacional()
        {
                    PNacional pn = new PNacional();
                    return pn.GetVuelo();         

        }

        public List<DtoRegional> GetRegional()
        {
            PRegional pr = new PRegional();
            return pr.GetVuelo();

        }

        public List<DtoIntercontinental> GetIntercontinental()
        {
            PIntercontinental pi = new PIntercontinental();
            return pi.GetVuelo();

        }

    }
}
