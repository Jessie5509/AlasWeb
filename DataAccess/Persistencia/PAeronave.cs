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
 
            return asientos;

        }

        public List<DtoAeronave> ListadoAeronaves()
        {
            List<Aeronave> lstAeroDB = new List<Aeronave>();
            List<DtoAeronave> lstAero = new List<DtoAeronave>();

            using (AlasPUMEntities context = new AlasPUMEntities())
            {
                lstAeroDB = context.Aeronave.Select(s => s).ToList();

                foreach (Aeronave item in lstAeroDB)
                {
                    DtoAeronave aero = MAeronave.MapToDto(item);
                    lstAero.Add(aero);
                }

            }

            return lstAero;
        }

        public void removeAeronave(int id)
        {
            using (AlasPUMEntities context = new AlasPUMEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        Aeronave aero = context.Aeronave.FirstOrDefault(f => f.numeroAeronave == id);
                        List<Asiento> lstAsiento = new List<Asiento>();

                        foreach (Asiento item in aero.Asiento)
                        {
                            lstAsiento.Add(item);

                        }

                        foreach (Asiento a in lstAsiento)
                        {
                            aero.Asiento.Remove(a);
                            context.Asiento.Remove(a);

                        }

                        context.Aeronave.Remove(aero);
                        context.SaveChanges();

                        scope.Complete();
                    }
                    catch (Exception ex)
                    {
                        scope.Dispose();

                    }

                }
            }
        }
        public void ModificarAeronave(DtoAeronave dto)
        {
            using (AlasPUMEntities context = new AlasPUMEntities())
            {
                Aeronave updAero = context.Aeronave.FirstOrDefault(f => f.numeroAeronave == dto.numeroAeronave);
                updAero.anioIngreso = dto.anioIngreso;
                updAero.horasVuelo = dto.horasVuelo;
                updAero.modelo = dto.modelo;
               
                context.SaveChanges();
            }
        }

        public DtoAeronave GetAeronaveM(int id)
        {
            DtoAeronave dto = new DtoAeronave();
            using (AlasPUMEntities context = new AlasPUMEntities())
            {
                Aeronave aero = context.Aeronave.FirstOrDefault(f => f.numeroAeronave == id);

                dto = MAeronave.MapToDto(aero);
            }

            return dto;
        }



    }
}
