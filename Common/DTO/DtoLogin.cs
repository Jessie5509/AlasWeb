using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class DtoLogin
    {
        [DisplayName("Usuario")]
        [Required(ErrorMessage = "El {0} del administrador es requerido!")]
        public string nombreUsuario { get; set; }

        [DisplayName("Contraseña")]
        [Required(ErrorMessage = "La {0} del administrador es requerida!")]
        public string contraseña { get; set; }
    }
}
