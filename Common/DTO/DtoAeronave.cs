using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class DtoAeronave
    {
        public int numeroAeronave { get; set; }

        [DisplayName("Año de ingreso")]
        public Nullable<int> anioIngreso { get; set; }

        [DisplayName("Horas de vuelo")]
        public Nullable<int> horasVuelo { get; set; }

        [DisplayName("Modelo")]
        [StringLength(75, ErrorMessage = "El {0} de la aeronave no debe superar los {1} carácteres")]
        public string modelo { get; set; }

        [DisplayName("Cantidad de asientos")]
        [Required(ErrorMessage = "La {0} de la aeronave es requerida!")]
        public int cantAsientos { get; set; }

    }
}
