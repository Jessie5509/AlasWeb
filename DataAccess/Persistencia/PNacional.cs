﻿using Common.DTO;
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

        public bool VueloNacional( DtoVuelo dto)
        {
            bool msg = true;

            using (AlasPUMEntities context = new AlasPUMEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        Nacional Nac = new Nacional();
                        Nac.numVuelo = dto.Nacional.numeroVuelo;
                        Nac.Vuelo.origen = dto.origen;
                        Nac.Vuelo.destino = dto.destino;
                        Nac.Vuelo.dtLlegada = dto.dtLlegada;
                        Nac.Vuelo.dtSalida = dto.dtSalida;
                        Nac.Vuelo.HorasTotales = dto.HorasTotales;
                        Nac.Vuelo.numeroAeronaveAsignada = dto.numeroAeronaveAsignada;
                        Nac.NumAero = dto.NumAero;

                        Vuelo vuel = new Vuelo();
                        vuel.numeroVuelo = dto.numeroVuelo;
                        vuel.origen = dto.origen;
                        vuel.destino = dto.destino;
                        vuel.dtLlegada = dto.dtLlegada;
                        vuel.dtSalida = dto.dtSalida;
                        vuel.HorasTotales = dto.HorasTotales;
                        vuel.numeroAeronaveAsignada = dto.numeroAeronaveAsignada;
                        vuel.numeroAeronaveAsignada = dto.NumAero;
                        vuel.Nacional.Add(Nac);



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

    }
}
