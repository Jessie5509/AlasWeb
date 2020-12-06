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
                        vc.imagen = dto.imagen;

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

        public DtoVuelo GetVueloInfo(string id)
        {
            DtoVuelo dto = new DtoVuelo();

            using (AlasPUMEntities context = new AlasPUMEntities())
            {
                Vuelo vuelo = context.Vuelo.FirstOrDefault(f => f.numeroVuelo == id);
                
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
                    dto.imagen = vuelo.imagen;

                }
                else if (vuelo.Intercontinental != null)
                {
                    Intercontinental inter = context.Intercontinental.FirstOrDefault(f => f.numVueloI == id);

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
                    dto.imagen = vuelo.imagen;

                }
                else if (vuelo.Regional != null)
                {
                    Regional re = context.Regional.FirstOrDefault(f => f.numVueloR == id);

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
                    dto.imagen = vuelo.imagen;


                }

            }

            return dto;

        }

        public List<DtoVuelo> GetVuelo()
        {
            List<DtoVuelo> colDtoVuelo = new List<DtoVuelo>();

            using (AlasPUMEntities context = new AlasPUMEntities())
            {

                List<Vuelo> colVuelos = context.Vuelo.Select(s => s).ToList();

                foreach (Vuelo vue in colVuelos)
                {
                    DtoVuelo dto = MVuelo.MapToDto(vue);
                    colDtoVuelo.Add(dto);
                }
            }

            return colDtoVuelo;
        }


        public List<DtoVuelo> Getcant(int cant, List<DtoVuelo> colVuelo)
        {
            using(AlasPUMEntities context = new AlasPUMEntities())
                {
                List<Vuelo> vuel = new List<Vuelo>();
                DtoVuelo dto = new DtoVuelo();
                
                colVuelo.Clear();

                vuel = context.Vuelo.Where(w => w.Aeronave.cantAsientos >= cant).ToList();
                foreach (Vuelo item in vuel)
                {
                    dto = MVuelo.MapToDto(item);
                    colVuelo.Add(dto);
                }

            }

            return colVuelo;
        }

        public List<DtoVuelo> GetTodos(int cant, List<DtoVuelo> colVuelo, string Origen, string Destino, string FechaSalida, string Fechallegada)
        {
            using (AlasPUMEntities context = new AlasPUMEntities())
            {
                List<Vuelo> vuel = new List<Vuelo>();
                DtoVuelo dto = new DtoVuelo();

                colVuelo.Clear();
                DateTime llegada = DateTime.Parse(Fechallegada);
                DateTime salida = DateTime.Parse(FechaSalida);
                vuel = context.Vuelo.Where(w => w.Aeronave.cantAsientos >= cant && w.origen == Origen && w.destino == Destino && w.dtSalida == salida && w.dtLlegada == llegada).ToList();
                foreach (Vuelo item in vuel)
                {
                    dto = MVuelo.MapToDto(item);
                    colVuelo.Add(dto);
                }

            }

            return colVuelo;
        }

    }
}
