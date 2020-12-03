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

        //public DtoVuelo GetVueloInfo(int id)
        //{ 
        //    DtoVuelo dto = new DtoVuelo();
       
        //    using (AlasPUMEntities context = new AlasPUMEntities())
        //    {
        //        Vuelo vuelo = context.Vuelo.FirstOrDefault(f => f.numeroVuelo == id.ToString());
        //        //bool existe = context.Vuelo.Any(a => a.Nacional != null);

        //        if (vuelo.Nacional != null)
        //        {
        //            vuelo.tipo = "Nacional";
        //            vuelo.

        //        }
        //        else if (dto.Intercontinental.documentacion != null && dto.Intercontinental.tasaIntercontinental != 0 && dto.Intercontinental.visa != null)
        //        {
        //            PIntercontinental pi = new PIntercontinental();
        //            return pi.VueloInternacional(dto);

        //        }
           

              

                




        //    }

        //    return dto;

        //}
        

    }
}
