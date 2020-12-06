using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class DtoVideo
    {

        public int idVideo { get; set; }
        public string UrlAeronave { get; set; }
        public Nullable<double> precio { get; set; }
        public Nullable<double> visitas { get; set; }

    }
}
