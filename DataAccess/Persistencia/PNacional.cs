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
                        Nac.departamento = "prueba";

                        Vuelo vuel = new Vuelo();
                        vuel.numeroVuelo = dto.numeroVuelo;
                        vuel.origen = dto.origen;
                        vuel.destino = dto.destino;
                        vuel.dtLlegada = dto.dtLlegada;
                        vuel.dtSalida = dto.dtSalida;
                        vuel.HorasTotales = dto.HorasTotales;
                        vuel.precio = dto.precio;
                        vuel.numeroAeronaveAsignada = dto.numeroAeronaveAsignada;
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


        public List<DtoNacional> GetVuelo()
        {
            List<DtoNacional> coldtoVuelo = new List<DtoNacional>();
            using (AlasPUMEntities context = new AlasPUMEntities())
            {

                List<Nacional> colVuelo = context.Nacional.Select(s => s).ToList();
                
                foreach (Nacional nac in colVuelo)
                {
                    DtoNacional dto = MNacional.MapToDto(nac);
                    coldtoVuelo.Add(dto);
                }
            }
            return coldtoVuelo;
        }

        /*
                public bool Frecuencia(DtoVuelo dto)
                {
                    bool msg = true;

                    using (AlasPUMEntities context = new AlasPUMEntities())
                    {
                        using (TransactionScope scope = new TransactionScope())
                        {
                            try
                            {
                                DateTime fechaS = (DateTime)dto.dtSalida;
                                DateTime fechaLL = (DateTime)dto.dtLlegada;
                                TimeSpan diferencia = fechaLL - fechaS;

                                List<DateTime> colDate = new List<DateTime>();
                                for (int i = 0; i < 90; i++)
                                {
                                    fechaS = fechaS.AddHours(24);
                                    colDate.Add(fechaS);
                                }

                                if ( days.Count == 0) // Diario Para tres Meses
                                {
                                    vueloDiario(colDate, dto, context, diferencia);
                                }
                                else if (days.Count > 0 && days[0].ToCharArray().Count() > 2) // Semanal para Tres Meses
                                {
                                    vueloSemanal(days, colDate, dto, context, diferencia);
                                }
                                else if (days.Count == 1 && days[0].ToCharArray().Count() <= 2) // Mensual para tres meses
                                {
                                    string day = days.FirstOrDefault();
                                    DateTime date = DateTime.Now;
                                    day = date.Year + "-" + date.Month + "-" + day;
                                    DateTime myDate = DateTime.ParseExact(day, "yyyy-MM-dd",
                                                       System.Globalization.CultureInfo.InvariantCulture);

                                    vueloMensual(dto, context, diferencia, myDate);
                                }
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

                */


    }
}
