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
    public class PRegional
    {
       
        public bool VueloRegional(DtoVuelo dto)
        {
            bool msg = true;

            using (AlasPUMEntities context = new AlasPUMEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {

                        Regional Reg = new Regional();
                        Reg.numVueloR = dto.Regional.numeroVuelo;
                        Reg.Vuelo.origen = dto.origen;
                        Reg.Vuelo.destino = dto.destino;
                        Reg.Vuelo.dtLlegada = dto.dtLlegada;
                        Reg.Vuelo.dtSalida = dto.dtSalida;
                        Reg.Vuelo.HorasTotales = dto.HorasTotales;
                        Reg.Vuelo.numeroAeronaveAsignada = dto.numeroAeronaveAsignada;
                        Reg.NumAeroR = dto.NumAero;
                        Reg.tasaRegional = dto.Regional.tasaRegional;
                        Reg.documentacion = dto.Regional.documentacion;


                        context.Regional.Add(Reg);
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
