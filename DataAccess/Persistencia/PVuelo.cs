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
    public class PVuelo
    {

        public bool Vuelo(DtoVuelo dto)
        {
            bool msg = true;

            using (AlasPUMEntities context = new AlasPUMEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {

                        Vuelo vc = new Vuelo();
                        vc.numeroVuelo = dto.numeroVuelo;
                        vc.origen = dto.origen;
                        vc.destino = dto.destino;
                        vc.dtLlegada = dto.dtLlegada;
                        vc.dtSalida = dto.dtSalida;
                        vc.HorasTotales = dto.HorasTotales;
                        vc.numeroAeronaveAsignada = dto.numeroAeronaveAsignada;
                        vc.numeroAeronaveAsignada = dto.NumAero;


                        context.Vuelo.Add(vc);
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
