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
    public class PAeronave
    {
        public bool AddAeronave(DtoAeronave dto, List<DtoAsiento> asientos)
        {
            bool msg;

            using (AlasPUMEntities context = new AlasPUMEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        Aeronave nuevaAeronave = new Aeronave();
                        int cantA = 0;
                        int num = 1;

                        //Agregar la lista de asientos.

                        foreach (DtoAsiento dt in asientos)
                        {

                            for (int i = dt.desde; i <= dt.hasta; i++)
                            {
                          
                                if (dt.numeroAsiento == 0)
                                {
                                    dt.numeroAsiento = num;
                                    num = num + 1;
                                }
                                else
                                {
                                    dt.numeroAsiento = num;
                                    num = num + 1;
                                }
         
                                Asiento DBasiento = new Asiento();
                                DBasiento = MAsiento.MapToEntity(dt);

                                //context.Asiento.Add(DBasiento);
                                nuevaAeronave.Asiento.Add(DBasiento);

                            }

                            //Asiento asiento = MAsiento.MapToEntity(dt);
                            //nuevaAeronave.Asiento.Add(asiento);

                            if (cantA < dt.hasta)
                            {
                                cantA = dt.hasta;

                            }


                        }

                        nuevaAeronave.anioIngreso = dto.anioIngreso;
                        nuevaAeronave.cantAsientos = cantA;
                        nuevaAeronave.horasVuelo = dto.horasVuelo;
                        nuevaAeronave.modelo = dto.modelo;

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

        public DtoAsiento Asientos(DtoAsiento asiento)
        {
            DtoAsiento asientos = new DtoAsiento();
            asientos = asiento;

            //using (AlasPUMEntities context = new AlasPUMEntities())
            //{
            //    using (TransactionScope scope = new TransactionScope())
            //    {
            //        try
            //        {
            //            Asiento nuevoAsiento = new Asiento();
            //            nuevoAsiento.tipo = asiento.tipo;
            //            nuevoAsiento.fila = asiento.fila;
            //            nuevoAsiento.desde = asiento.desde;
            //            nuevoAsiento.hasta = asiento.hasta;

            //            //Mapper
            //            DtoAsiento dto = MAsiento.MapToDto(nuevoAsiento);
            //            lstAsientos.Add(dto);

            //            context.SaveChanges();

            //            scope.Complete();

            //        }
            //        catch (Exception ex)
            //        {
            //            scope.Dispose();

            //        }

            //        return asientos;
            //    }

            //}

            return asientos;

        }


    }
}
