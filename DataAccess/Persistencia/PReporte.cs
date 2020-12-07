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
            int contador = 0;

            using (AlasPUMEntities context = new AlasPUMEntities())
            {
                List<Compra> compraDT = context.Compra.Where(w => w.dtCompra >= dto.fechaInicio && w.dtCompra <= dto.fechaFin).ToList();
                
                foreach (Compra item in compraDT)
                {
                    Cliente cliente = context.Cliente.Where(s => s.documento == item.Cliente.documento).Max();

                }

            }


           return getCliente;
        }

        public int PorcentajeVuelos(DtoRPorcentaje dto)
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

            return getCliente;
        }

        public List<DtoVuelo> getVuelosMasAsientos(DtoVuelosMasAsientosVacios dto)
        {
            List<DtoVuelo> colVuelos = new List<DtoVuelo>();
          
            using (AlasPUMEntities context = new AlasPUMEntities())
            {
                List<Vuelo> vuelos = context.Vuelo.Where(w => w.dtSalida >= dto.fechaInicio && w.dtSalida <= dto.fechaFin).ToList();
                List<Aeronave> colAeronave = new List<Aeronave>();

                foreach (Vuelo item in vuelos)
                {
                    colAeronave.Add(item.Aeronave);

                }

                



            }


            return colVuelos;
        }


    }
}
