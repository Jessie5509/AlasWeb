using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class DtoAsiento
    {
        public int numeroAsiento { get; set; }
        public string tipo { get; set; }
        public Nullable<int> cantidad { get; set; }
        public Nullable<double> precio { get; set; }
        public Nullable<bool> seleccionado { get; set; }
        public string fila { get; set; }
    }
}
