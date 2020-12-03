using Common.DTO;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mappers
{
    public class MRegional
    {

        public static DtoRegional MapToDto(Regional entity)
        {
            DtoRegional dto = new DtoRegional();

            dto.numeroVuelo = entity.numVueloR;
            dto.origen = entity.Vuelo.origen;
            dto.destino = entity.Vuelo.destino;
            dto.dtLlegada = entity.Vuelo.dtLlegada;
            dto.dtSalida = entity.Vuelo.dtSalida;
            dto.HorasTotales = entity.Vuelo.HorasTotales;
            dto.precio = entity.Vuelo.precio;
            dto.documentacion = entity.documentacion;
            dto.tasaRegional = entity.tasaRegional;
            dto.numeroAeronaveAsignada = entity.Vuelo.numeroAeronaveAsignada;
            dto.imagen = entity.Vuelo.imagen;



            return dto;
        }

        public static Regional MapToEntity(DtoRegional dto)
        {
            Regional entity = new Regional();
            entity.numVueloR = dto.numeroVuelo;
            entity.Vuelo.origen = dto.origen;
            entity.Vuelo.destino = dto.destino;
            entity.Vuelo.dtLlegada = dto.dtLlegada;
            entity.Vuelo.dtSalida = dto.dtSalida;
            entity.Vuelo.HorasTotales = dto.HorasTotales;
            entity.Vuelo.precio = dto.precio;
            entity.tasaRegional = dto.tasaRegional;
            entity.documentacion = dto.documentacion;
            entity.Vuelo.numeroAeronaveAsignada = dto.numeroAeronaveAsignada;
            entity.Vuelo.imagen = dto.imagen;

            return entity;
        }

    }
}
