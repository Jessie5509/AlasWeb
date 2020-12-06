using BussinesLogic.interfaces;
using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Clases
{
    public class ClaseVideo : IVideo
    {

        public ClaseVideo video { get; set; }
        public string AgregarVideo(DtoCliente dto) { return "";
        }

    }
}
