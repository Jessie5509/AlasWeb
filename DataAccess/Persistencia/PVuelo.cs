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

        public DtoVuelo GetVueloInfo(int id)
        {
            DtoVuelo dto = new DtoVuelo();

            using (AlasPUMEntities context = new AlasPUMEntities())
            {
                Vuelo vuelo = context.Vuelo.FirstOrDefault(f => f.numeroVuelo == id.ToString());
                
                if (vuelo.Nacional != null)
                {
                    dto.tipo = "Nacional";
                    dto.numeroVuelo = vuelo.numeroVuelo;
                    dto.origen = vuelo.origen;
                    dto.destino = vuelo.destino;
                    dto.dtLlegada = vuelo.dtLlegada;
                    dto.dtSalida = vuelo.dtSalida;
                    dto.HorasTotales = vuelo.HorasTotales;
                    dto.precio = vuelo.precio;
                    dto.numeroAeronaveAsignada = vuelo.numeroAeronaveAsignada;
                    dto.desde = vuelo.desde;
                    dto.hasta = vuelo.hasta;

                }
                else if (vuelo.Intercontinental != null)
                {
                    Intercontinental inter = context.Intercontinental.FirstOrDefault(f => f.numVueloI == id.ToString());

                    dto.tipo = "Intercontinental";
                    dto.numeroVuelo = vuelo.numeroVuelo;
                    dto.origen = vuelo.origen;
                    dto.destino = vuelo.destino;
                    dto.dtLlegada = vuelo.dtLlegada;
                    dto.dtSalida = vuelo.dtSalida;
                    dto.HorasTotales = vuelo.HorasTotales;
                    dto.precio = vuelo.precio;
                    dto.numeroAeronaveAsignada = vuelo.numeroAeronaveAsignada;
                    dto.desde = vuelo.desde;
                    dto.hasta = vuelo.hasta;
                    dto.documentacion = inter.documentacion;
                    dto.tasaIntercontinental = inter.tasaInter;
                    dto.visa = inter.visa;

                }
                else if (vuelo.Regional != null)
                {
                    Regional re = context.Regional.FirstOrDefault(f => f.numVueloR == id.ToString());

                    dto.tipo = "Regional";
                    dto.numeroVuelo = vuelo.numeroVuelo;
                    dto.origen = vuelo.origen;
                    dto.destino = vuelo.destino;
                    dto.dtLlegada = vuelo.dtLlegada;
                    dto.dtSalida = vuelo.dtSalida;
                    dto.HorasTotales = vuelo.HorasTotales;
                    dto.precio = vuelo.precio;
                    dto.numeroAeronaveAsignada = vuelo.numeroAeronaveAsignada;
                    dto.desde = vuelo.desde;
                    dto.hasta = vuelo.hasta;
                    dto.documentacion = re.documentacion;
                    dto.tasaRegional = re.tasaRegional;
                    

                }

            }

            return dto;

        }


    }
}
