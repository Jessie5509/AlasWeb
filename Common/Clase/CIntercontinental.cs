using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Clase
{
    public class CIntercontinental : Vuelo
    {

        public string numeroVuelo { get; set; }
        public string origen { get; set; }
        public string destino { get; set; }
        public System.DateTime dtLlegada { get; set; }
        public System.DateTime dtSalida { get; set; }
        public double HorasTotales { get; set; }
        public Nullable<int> numeroAeronaveAsignada { get; set; }
        public double precio { get; set; }
        public string documentacion { get; set; }
        public double tasaRegional { get; set; }
        public string visa { get; set; }
        public int NumAero { get; set; }

        public override void AgregarVuelo()
        {
            throw new NotImplementedException();
        }

        protected override Vuelo ListarVuelo()
        {
            throw new NotImplementedException();
        }
    }
}
