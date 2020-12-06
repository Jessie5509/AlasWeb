using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class DtoCliente
    {
        [DisplayName("Documento")]
        [StringLength(75, ErrorMessage = "El {0} no debe superar los {1} carácteres")]
        [Required(ErrorMessage = "El {0} es requerido!")]
        public string documento { get; set; }

        [DisplayName("Nombre")]
        [StringLength(50, ErrorMessage = "El {0} no debe superar los {1} carácteres")]
        [Required(ErrorMessage = "El {0} es requerido!")]
        public string nombre { get; set; }

        [DisplayName("Apellido")]
        [StringLength(50, ErrorMessage = "El {0} no debe superar los {1} carácteres")]
        [Required(ErrorMessage = "El {0} es requerido!")]
        public string apellido { get; set; }

        [DisplayName("Pasaporte")]
        [StringLength(75, ErrorMessage = "El {0} no debe superar los {1} carácteres")]
        [Required(ErrorMessage = "El {0} es requerido!")]
        public string pasaporte { get; set; }

        [DisplayName("Email")]
        [StringLength(75, ErrorMessage = "El {0} no debe superar los {1} carácteres")]
        [Required(ErrorMessage = "El {0} es requerido!")]
        public string email { get; set; }

        [DisplayName("Visa")]
        [StringLength(100, ErrorMessage = "La {0} no debe superar los {1} carácteres")]
        public string visa { get; set; }

        public virtual ICollection<DtoCompra> Compra { get; set; }

    }
}
