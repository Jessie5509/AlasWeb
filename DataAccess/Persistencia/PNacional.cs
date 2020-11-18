using Common.DTO;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DataAccess.Persistencia
{
   public class PNacional
    {

        public bool RegistarNacional(DtoNacional dto)
        {
            bool msg = true;

            using (AlasPUMEntities context = new AlasPUMEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        
                        Nacional Nac = new Nacional();
                        Nac.numeroVuelo = dto.numeroVuelo;
                        Nac.origen = dto.origen;
                        Nac.destino = dto.destino;
                        Nac.dtLlegada = dto.dtLlegada;
                        Nac.dtSalida = dto.dtSalida;
                        Nac.HorasTotales = dto.HorasTotales;
                        Nac.numeroAeronaveAsignada = dto.numeroAeronaveAsignada;
                        Nac.NumAero = dto.NumAero;

                        context.Nacional.Add(Nac);
                        context.SaveChanges();

                        scope.Complete();

                    }
                    catch (Exception ex)
                    {
                        scope.Dispose();
                        return msg = false;
                    }

                    return msg = true;


                }

            }
        }

    }
}
