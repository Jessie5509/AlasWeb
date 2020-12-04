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
    public class PRegional
    {
       
        public bool VueloRegional(DtoVuelo dto, List<string> days)
        {
            bool msg = true;

            using (AlasPUMEntities context = new AlasPUMEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {                                            

                        Regional Reg = new Regional();
                        Reg.tasaRegional = dto.Regional.tasaRegional;
                        Reg.documentacion = dto.Regional.documentacion;

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
                        vuel.Regional.Add(Reg);



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

        public List<DtoRegional> GetVuelo()
        {
            List<DtoRegional> coldtoVuelo = new List<DtoRegional>();
            using (AlasPUMEntities context = new AlasPUMEntities())
            {

                List<Regional> colVuelo = context.Regional.Select(s => s).ToList();

                foreach (Regional reg in colVuelo)
                {
                    DtoRegional dto = MRegional.MapToDto(reg);
                    coldtoVuelo.Add(dto);
                }
            }
            return coldtoVuelo;
        }

    }
}
