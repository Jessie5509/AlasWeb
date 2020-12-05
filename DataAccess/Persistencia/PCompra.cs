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
                int? numAero = vuelo.numeroAeronaveAsignada;
                Aeronave aero = context.Aeronave.FirstOrDefault(f => f.numeroAeronave == numAero);

                foreach (Asiento item in aero.Asiento)
                {
                    if (item.seleccionado == false)
                    {
                        DtoAsiento asiento = MAsiento.MapToDto(item);
                        lstAsientos.Add(asiento);
                    }
                    
                }

            }

            return lstAsientos;
        }

        public DtoAsiento asientoComprado(int id)
        {
            DtoAsiento asientos = new DtoAsiento();

            using (AlasPUMEntities context = new AlasPUMEntities())
            {
                Asiento asiento = context.Asiento.FirstOrDefault(f => f.numeroAsiento == id);
                asiento.seleccionado = true;

                asientos = MAsiento.MapToDto(asiento);

                context.SaveChanges();

            }

            return asientos;

        }

    }
}
