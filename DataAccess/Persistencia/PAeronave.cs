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
    public class PAeronave
    {
        public bool AddAeronave(DtoAeronave dto)
        {
            bool msg;

            using (AlasPUMEntities context = new AlasPUMEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        Aeronave nuevaAeronave = new Aeronave();
                        nuevaAeronave.anioIngreso = dto.anioIngreso;
                        nuevaAeronave.cantAsientos = dto.cantAsientos;
                        nuevaAeronave.horasVuelo = dto.horasVuelo;
                        nuevaAeronave.modelo = dto.modelo;

                        //Agregar la lista de asientos.
                      
                        context.Aeronave.Add(nuevaAeronave);
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

        public List<DtoAsiento> Asientos(DtoAsiento asiento)
        {
            List<DtoAsiento> lstAsientos = new List<DtoAsiento>();

            using (AlasPUMEntities context = new AlasPUMEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        Asiento nuevoAsiento = new Asiento();
                        nuevoAsiento.tipo = asiento.tipo;
                        nuevoAsiento.fila = asiento.fila;
                        nuevoAsiento.desde = asiento.desde;
                        nuevoAsiento.hasta = asiento.hasta;

                        //Mapper

                        //lstAsientos.Add(nuevoAsiento);

                        
                        context.SaveChanges();

                        scope.Complete();

                    }
                    catch (Exception ex)
                    {
                        scope.Dispose();
                        

                    }

                    return lstAsientos;
                }

            }

        }


    }
}
