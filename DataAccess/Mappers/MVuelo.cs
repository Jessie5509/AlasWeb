using Common.DTO;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mappers
{
    public class MVuelo
    {
        public static DtoVuelo MapToDto(Vuelo entity)
        {
            DtoVuelo dto = new DtoVuelo();

            dto.numeroVuelo = entity.numeroVuelo;
            dto.origen = entity.origen;
            dto.destino = entity.destino;
            dto.dtLlegada = entity.dtLlegada;
            dto.dtSalida = entity.dtSalida;
            dto.HorasTotales = entity.HorasTotales;
            dto.precio = entity.precio;
            dto.numeroAeronaveAsignada = entity.numeroAeronaveAsignada;
            dto.desde = entity.desde;
            dto.hasta = entity.hasta;
            dto.imagen = entity.imagen;

            return dto;
        }


       

        public static Vuelo MapToEntity(DtoVuelo dto)
        {
            Vuelo entity = new Vuelo();
            entity.numeroVuelo = dto.numeroVuelo;
            entity.origen = dto.origen;
            entity.destino = dto.destino;
            entity.dtLlegada = dto.dtLlegada;
            entity.dtSalida = dto.dtSalida;
            entity.HorasTotales = dto.HorasTotales;
            entity.precio = dto.precio;
            entity.numeroAeronaveAsignada = dto.numeroAeronaveAsignada;
            entity.desde = dto.desde;
            entity.hasta = dto.hasta;
            entity.imagen = dto.imagen;

            return entity;
        }
    }
}
