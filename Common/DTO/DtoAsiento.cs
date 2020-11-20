using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class DtoAsiento
    {
        public int numeroAsiento { get; set; }

        [DisplayName("Tipo")]
        public string tipo { get; set; }
        public Nullable<int> cantidad { get; set; }
        public Nullable<double> precio { get; set; }
        public Nullable<bool> seleccionado { get; set; }

        [DisplayName("Fila")]
        [StringLength(15, ErrorMessage = "La {0} no debe superar los {1} carácteres")]
        public string fila { get; set; }

        [DisplayName("Desde")]
        [Required(ErrorMessage = "Se debe ingresar desde que número de asiento empieza!")]
        public int desde { get; set; }

        [DisplayName("Hasta")]
        [Required(ErrorMessage = "Se debe ingresar hasta que número de asiento finaliza!")]
        public int hasta { get; set; }


      
    }

  
}
