using Common.DTO;
using DataAccess.Mappers;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Persistencia
{
    public class PCompra
    {
        public List<DtoAsiento> AsientosByVuelo(string id)
        { 
            List<DtoAsiento> lstAsientos = new List<DtoAsiento>();

            using (AlasPUMEntities context = new AlasPUMEntities())
            {
                Vuelo vuelo = context.Vuelo.FirstOrDefault(f => f.numeroVuelo == id);
                Aeronave aero = context.Aeronave.FirstOrDefault(f => f.numeroAeronave == vuelo.numeroAeronaveAsignada);

                foreach (Asiento item in aero.Asiento)
                {
                    DtoAsiento asiento = MAsiento.MapToDto(item);
                    lstAsientos.Add(asiento);
                }

            }

            return lstAsientos;
        }

    }
}
