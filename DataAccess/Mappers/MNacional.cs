
using Common.DTO;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mappers
{
    public class MNacional
    {
        public static DtoNacional MapToDto(Nacional entity)
        {
            DtoNacional dto = new DtoNacional();

            dto.numeroVuelo = entity.numVuelo;
            dto.origen = entity.Vuelo.origen;
            dto.destino = entity.Vuelo.destino;
            dto.dtLlegada = entity.Vuelo.dtLlegada;
            dto.dtSalida = entity.Vuelo.dtSalida;
            dto.HorasTotales = entity.Vuelo.HorasTotales;
            dto.precio = entity.Vuelo.precio;
            dto.numeroAeronaveAsignada = entity.Vuelo.numeroAeronaveAsignada;
            dto.imagen = entity.Vuelo.imagen;

            return dto;
        }

        public static Nacional MapToEntity(DtoNacional dto)
        {
            Nacional entity = new Nacional();
            entity.numVuelo = dto.numeroVuelo;
            entity.Vuelo.origen = dto.origen;
            entity.Vuelo.destino = dto.destino;
            entity.Vuelo.dtLlegada = dto.dtLlegada;
            entity.Vuelo.dtSalida = dto.dtSalida;
            entity.Vuelo.HorasTotales = dto.HorasTotales;
            entity.Vuelo.precio = dto.precio;
            entity.Vuelo.numeroAeronaveAsignada = dto.numeroAeronaveAsignada;
            entity.Vuelo.imagen = dto.imagen;

            return entity;
        }

    }
}
