using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class DtoVuelosMasAsientosVacios
    {
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin { get; set; }

        public int cantidad { get; set; }
        public string numeroVuelo { get; set; }

        public int mas { get; set; } 
        public int menos { get; set; } 
    }
}
