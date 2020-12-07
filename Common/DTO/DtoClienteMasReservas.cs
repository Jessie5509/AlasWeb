using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class DtoClienteMasReservas
    {
        public string documento { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin { get; set; }
    }
}
