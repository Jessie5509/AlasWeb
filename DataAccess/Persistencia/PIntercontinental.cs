using Common.DTO;
using DataAccess.Mappers;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DataAccess.Persistencia
{
    public class PIntercontinental
    {
        
      public bool VueloInternacional(DtoVuelo dto)
        {
            bool msg = true;

            using (AlasPUMEntities context = new AlasPUMEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {

                        Intercontinental Inter = new Intercontinental();
                        Inter.tasaInter = dto.Intercontinental.tasaIntercontinental;
                        Inter.documentacion = dto.Intercontinental.documentacion;
                        Inter.visa = dto.Intercontinental.visa;

                        Vuelo vuel = new Vuelo();
                        vuel.numeroVuelo = dto.numeroVuelo;
                        vuel.origen = dto.origen;
                        vuel.destino = dto.destino;
                        vuel.dtLlegada = dto.dtLlegada;
                        vuel.dtSalida = dto.dtSalida;
                        vuel.HorasTotales = dto.HorasTotales;
                        vuel.precio = dto.precio;
                        vuel.numeroAeronaveAsignada = dto.numeroAeronaveAsignada;
                        vuel.desde = dto.desde;
                        vuel.hasta = dto.hasta;
                        vuel.imagen = dto.imagen;
                        vuel.Intercontinental.Add(Inter);

                        context.Vuelo.Add(vuel);
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


        public List<DtoIntercontinental> GetVuelo()
        {
            List<DtoIntercontinental> coldtoVuelo = new List<DtoIntercontinental>();
            using (AlasPUMEntities context = new AlasPUMEntities())
            {

                List<Intercontinental> colVuelo = context.Intercontinental.Select(s => s).ToList();

                foreach (Intercontinental reg in colVuelo)
                {
                    DtoIntercontinental dto = MIntercontinental.MapToDto(reg);
                    coldtoVuelo.Add(dto);
                }
            }
            return coldtoVuelo;
        }
    }
}
