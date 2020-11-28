﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class DtoVuelo
    {

        [DisplayName("Numero Vuelo")]
        [Required(ErrorMessage = "El {0} de el vuelo es requerido!")]
        [StringLength(75, ErrorMessage = "El {0} del vuelo no debe superar los {1} caracteres")]
        public string numeroVuelo { get; set; }

        [DisplayName("Origen")]
        [Required(ErrorMessage = "El {0} de el vuelo es requerido!")]
        [StringLength(125, ErrorMessage = "El {0} del vuelo no debe superar los {1} caracteres")]
        public string origen { get; set; }

        [DisplayName("Destino")]
        [Required(ErrorMessage = "El {0} de el vuelo es requerido!")]
        [StringLength(125, ErrorMessage = "El {0} del vuelo no debe superar los {1} caracteres")]
        public string destino { get; set; }

        [DisplayName("dtLlegada")]
        [Required(ErrorMessage = "El {0} de el vuelo es requerido!")]
        public System.DateTime dtLlegada { get; set; }

        [DisplayName("dtSalida")]
        [Required(ErrorMessage = "El {0} de el vuelo es requerido!")]
        public System.DateTime dtSalida { get; set; }

        [DisplayName("HorasTotales")]
        [Required(ErrorMessage = "El {0} de el vuelo es requerido!")]
        public double HorasTotales { get; set; }

        [DisplayName("numeroAeronaveAsignada")]
        public Nullable<int> numeroAeronaveAsignada { get; set; }

        [DisplayName("Precio")]
        [Required(ErrorMessage = "El {0} de el vuelo es requerido!")]
        public double precio { get; set; }

        [DisplayName("NumAero")]
        [Required(ErrorMessage = "El {0} de el vuelo es requerido!")]
        public int NumAero { get; set; }

        public DtoIntercontinental Intercontinental { get; set; }

        public DtoRegional Regional { get; set; }
        public DtoNacional Nacional { get; set; }
    }
}
