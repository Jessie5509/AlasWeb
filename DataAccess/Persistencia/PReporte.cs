using Common.DTO;
using DataAccess.Model;
using NPOI.SS.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Persistencia
{
    public class PReporte
    {
        public DtoCliente getClienteMasReservas(DtoClienteMasReservas dto)
        {
            DtoCliente getCliente = new DtoCliente();
            int cantidad = 0;
            string doc = null;

            using (AlasPUMEntities context = new AlasPUMEntities())
            {
                List<Compra> compraDT = context.Compra.Where(w => w.dtCompra >= dto.fechaInicio && w.dtCompra <= dto.fechaFin).ToList();
                List<Cliente> colClientes = new List<Cliente>();
             
                foreach (Compra item in compraDT)
                {
                    colClientes.Add(item.Cliente);
                }


                foreach (Cliente cli in colClientes)
                {
                    if (cantidad < cli.Compra.Count())
                    {
                        cantidad = cli.Compra.Count();
                        doc = cli.documento;
                    }
         
                }

                Cliente cliente = context.Cliente.FirstOrDefault(f => f.documento == doc);
                getCliente.documento = cliente.documento;
                getCliente.nombre = cliente.nombre;
                getCliente.apellido = cliente.apellido;
           


            }


           return getCliente;
        }

        public double PorcentajeVuelos(DtoRPorcentaje dto)
        {

            double porcentaje = 0;

            using (AlasPUMEntities context = new AlasPUMEntities())
            {
                int vuelos = context.Vuelo.Select(s => s).Count();

                List<Vuelo> colVuelo = context.Vuelo.Where(w => w.dtLlegada == dto.fechaInicio && w.dtSalida == dto.fechaFin).ToList();
                int eso = colVuelo.Count();

                porcentaje = (vuelos * eso) / 100;

            }

            DecimalFormat df = new DecimalFormat("#.00");

            string total = df.Format(porcentaje);
            porcentaje = double.Parse(total);

            return porcentaje;
        }

        public List<DtoVuelosMasAsientosVacios> getVuelosMasAsientos(DtoVuelosMasAsientosVacios dto)
        {
            
            List<DtoVuelosMasAsientosVacios> colDto = new List<DtoVuelosMasAsientosVacios>();
            int cantidad = 0;
          
            using (AlasPUMEntities context = new AlasPUMEntities())
            {
                List<Vuelo> vuelos = context.Vuelo.Where(w => w.dtSalida >= dto.fechaInicio && w.dtSalida <= dto.fechaFin).ToList();
                List<Aeronave> colAeronave = new List<Aeronave>();
                DtoVuelosMasAsientosVacios vuelosMas = new DtoVuelosMasAsientosVacios();

                foreach (Vuelo item in vuelos)
                {
                    colAeronave.Add(item.Aeronave);

                }

                colAeronave.OrderByDescending(o => o.cantAsientos);

                foreach (Aeronave aero in colAeronave)
                {
                    foreach (Asiento asiento in aero.Asiento)
                    {
                        if (asiento.seleccionado == false)
                        {
                            cantidad++;

                        }

                    }

                    int asientosVacios = cantidad - aero.cantAsientos;
             
                    vuelosMas.cantidad = asientosVacios;
                  
                    Vuelo vuelo = context.Vuelo.FirstOrDefault(f => f.numeroAeronaveAsignada == aero.numeroAeronave);
                    vuelosMas.numeroVuelo = vuelo.numeroVuelo;

                    colDto.Add(vuelosMas);
                  
                    colDto.OrderByDescending(o => o.cantidad);
                    vuelosMas.mas = colDto.First().cantidad;
                    vuelosMas.menos = colDto.Last().cantidad;




                }

            }


            return colDto;
        }


    }
}
