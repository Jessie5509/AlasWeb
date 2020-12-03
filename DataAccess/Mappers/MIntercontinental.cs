using Common.DTO;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mappers
{
    public class MIntercontinental
    {

        public static DtoIntercontinental MapToDto(Intercontinental entity)
        {
            DtoIntercontinental dto = new DtoIntercontinental();

            dto.numeroVuelo = entity.numVueloI;
            dto.origen = entity.Vuelo.origen;
            dto.destino = entity.Vuelo.destino;
            dto.dtLlegada = entity.Vuelo.dtLlegada;
            dto.dtSalida = entity.Vuelo.dtSalida;
            dto.HorasTotales = entity.Vuelo.HorasTotales;
            dto.precio = entity.Vuelo.precio;
            dto.documentacion = entity.documentacion;
            dto.tasaIntercontinental = entity.tasaInter;
            dto.visa = entity.visa;
            dto.numeroAeronaveAsignada = entity.Vuelo.numeroAeronaveAsignada;
            dto.imagen = entity.Vuelo.imagen;

            return dto;
        }

        public static Intercontinental MapToEntity(DtoIntercontinental dto)
        {
            Intercontinental entity = new Intercontinental();
            entity.numVueloI = dto.numeroVuelo;
            entity.Vuelo.origen = dto.origen;
            entity.Vuelo.destino = dto.destino;
            entity.Vuelo.dtLlegada = dto.dtLlegada;
            entity.Vuelo.dtSalida = dto.dtSalida;
            entity.Vuelo.HorasTotales = dto.HorasTotales;
            entity.Vuelo.precio = dto.precio;
            entity.documentacion = dto.documentacion;
            entity.tasaInter = dto.tasaIntercontinental;
            entity.visa = dto.visa;
            entity.Vuelo.numeroAeronaveAsignada = dto.numeroAeronaveAsignada;
            entity.Vuelo.imagen = dto.imagen;

            return entity;
        }

    }
}
