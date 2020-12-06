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
    public class PVideo
    {

        public void AsignarVideo(DtoCliente dto)
        {
            bool msg = true;

            using (AlasPUMEntities context = new AlasPUMEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        Compra compra = context.Compra.OrderByDescending(o => o.dtCompra).FirstOrDefault(f => f.DocumentoCli == dto.documento);
                        Aeronave aero = context.Vuelo.FirstOrDefault(f => f.numeroVuelo == compra.numeroVuelo).Aeronave;
                        Video video = context.Video.FirstOrDefault(a => a.numAeronave == aero.numeroAeronave);

                        aero.url = video.UrlAeronave;
                        double? visitas = video.visitas +1;
                        video.visitas = visitas;

                        context.SaveChanges();

                        scope.Complete();

                    }
                    catch (Exception ex)
                    {
                        scope.Dispose();
                        
                    }


                }

            }
        }

    }
}
