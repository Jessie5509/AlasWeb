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
    public class PCompra
    {
        public List<DtoAsiento> AsientosByVuelo(string id)
        { 
            List<DtoAsiento> lstAsientos = new List<DtoAsiento>();

            using (AlasPUMEntities context = new AlasPUMEntities())
            {
                Vuelo vuelo = context.Vuelo.FirstOrDefault(f => f.numeroVuelo == id);
                int? numAero = vuelo.numeroAeronaveAsignada;
                Aeronave aero = context.Aeronave.FirstOrDefault(f => f.numeroAeronave == numAero);

                foreach (Asiento item in aero.Asiento)
                {
                    if (item.seleccionado == false)
                    {
                        DtoAsiento asiento = MAsiento.MapToDto(item);
                        lstAsientos.Add(asiento);
                    }
                    
                }

            }

            return lstAsientos;
        }

        public DtoAsiento asientoComprado(int id)
        {
            DtoAsiento asientos = new DtoAsiento();

            using (AlasPUMEntities context = new AlasPUMEntities())
            {
                Asiento asiento = context.Asiento.FirstOrDefault(f => f.numeroAsiento == id);
                asiento.seleccionado = true;

                asientos = MAsiento.MapToDto(asiento);

                context.SaveChanges();

            }

            return asientos;

        }

        public bool AddClienteCompra(DtoCliente dto, string idVuelo, List<DtoAsiento> colAsientos)
        {
            bool msg;
            float precioTotal = 0;

            using (AlasPUMEntities context = new AlasPUMEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        Compra nuevaCompra = new Compra();
                        nuevaCompra.numeroVuelo = idVuelo;

                        //Precio total asientos
                        foreach (DtoAsiento item in colAsientos)
                        {
                            precioTotal = (float)(precioTotal + item.precio);
                        }
                        //------------------------------

                        nuevaCompra.precioTotal = precioTotal;
                        nuevaCompra.dtCompra = DateTime.Now;

                        //Asientos mapeados a entity

                        //foreach (DtoAsiento item in colAsientos)
                        //{
                        //    Asiento asientoDB = new Asiento();
                        //    asientoDB = MAsiento.MapToEntity(item);

                        //    nuevaCompra.Asiento.Add(asientoDB);

                        //}

                        //------------------------------
                 
                        Cliente nuevoCliente = new Cliente();
                        nuevoCliente.documento = dto.documento;
                        nuevoCliente.nombre = dto.nombre;
                        nuevoCliente.apellido = dto.apellido;
                        nuevoCliente.pasaporte = dto.pasaporte;
                        nuevoCliente.email = dto.email;
                        nuevoCliente.visa = dto.visa;

                        nuevoCliente.Compra.Add(nuevaCompra);

                  
                        context.Compra.Add(nuevaCompra);

                        context.Cliente.Add(nuevoCliente);
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
