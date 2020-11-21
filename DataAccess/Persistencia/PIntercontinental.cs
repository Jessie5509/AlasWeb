using Common.DTO;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DataAccess.Persistencia
{
    public class PIntercontinental
    {
        
      public bool VueloInternacional(DtoVuelo dto)
        {
            bool msg = true;

            using (AlasPUMEntities context = new AlasPUMEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {

                        Intercontinental Inter = new Intercontinental();
                        Inter.numVueloI = dto.Intercontinental.numeroVuelo;
                        Inter.Vuelo.origen = dto.origen;
                        Inter.Vuelo.destino = dto.destino;
                        Inter.Vuelo.dtLlegada = dto.dtLlegada;
                        Inter.Vuelo.dtSalida = dto.dtSalida;
                        Inter.Vuelo.HorasTotales = dto.HorasTotales;
                        Inter.Vuelo.numeroAeronaveAsignada = dto.numeroAeronaveAsignada;
                        Inter.NumAeroI = dto.NumAero;
                        Inter.tasaInter = dto.Regional.tasaRegional;
                        Inter.documentacion = dto.Regional.documentacion;
                        Inter.visa = dto.Intercontinental.visa;

                        context.Intercontinental.Add(Inter);
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
