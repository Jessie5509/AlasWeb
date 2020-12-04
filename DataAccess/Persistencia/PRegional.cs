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


        public bool Frecuencia(DtoVuelo dto, List<string> days)
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
                        for (int i = 0; i < 10; i++)
                        {
                            fechaS = fechaS.AddHours(24);
                            colDate.Add(fechaS);
                        }

                        if (days.Contains("Diario")) // Diario Para tres Meses
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





        private void vueloDiario(List<DateTime> colDate, DtoVuelo dto, AlasPUMEntities context, TimeSpan diferencia)
        {

            for (int i = 1; i <= 30; i++)
            {
                
               

                Regional Reg = new Regional();
                Reg.tasaRegional = dto.Regional.tasaRegional;
                Reg.documentacion = dto.Regional.documentacion;

                int numero = Int32.Parse(dto.numeroVuelo) + i;
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


                vuel.dtSalida = (colDate[i]);
                vuel.dtLlegada = (colDate[i] + diferencia);

                context.Vuelo.Add(vuel);

            }
            context.SaveChanges();
        }

        private void vueloSemanal(List<string> days, List<DateTime> colDate, DtoVuelo dto, AlasPUMEntities context, TimeSpan diferencia)
        {

            foreach (string item in days)
            {
                for (int i = 1; i <= 5; i++)
                {
                    if (item == colDate[i].DayOfWeek.ToString())
                    {
                        Regional Reg = new Regional();
                        Reg.tasaRegional = dto.Regional.tasaRegional;
                        Reg.documentacion = dto.Regional.documentacion;

                        int numero = Int32.Parse(dto.numeroVuelo) + i;
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


                        vuel.dtSalida = (colDate[i]);
                        vuel.dtLlegada = (colDate[i] + diferencia);

                        context.Vuelo.Add(vuel);

                    }
                }
                context.SaveChanges();
            }

        }

        private void vueloMensual(DtoVuelo dto, AlasPUMEntities context, TimeSpan diferencia, DateTime myDate)
        {
            for (int i = 0; i < 3; i++)
            {

                Regional Reg = new Regional();
                Reg.tasaRegional = dto.Regional.tasaRegional;
                Reg.documentacion = dto.Regional.documentacion;

                int numero = Int32.Parse(dto.numeroVuelo) + i;
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

                vuel.dtSalida = myDate.AddMonths(i);
                vuel.dtLlegada = (myDate.AddMonths(i) + diferencia);

                context.Vuelo.Add(vuel);



            }
            context.SaveChanges();
        }

    }
}
