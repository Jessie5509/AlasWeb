using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class DtoCompra
    {
        [DisplayName("Código de compra")]
        public int idCompra { get; set; }

        [DisplayName("Número de vuelo")]
        public string numeroVuelo { get; set; }

        [DisplayName("Fecha de compra")]
        public Nullable<System.DateTime> dtCompra { get; set; }

        [DisplayName("Precio total")]
        public double precioTotal { get; set; }

        [DisplayName("Documento del cliente")]
        public string DocumentoCli { get; set; }
    }
}
