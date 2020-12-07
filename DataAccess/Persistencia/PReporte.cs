using Common.DTO;
using DataAccess.Model;
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
                

                }

            }


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
