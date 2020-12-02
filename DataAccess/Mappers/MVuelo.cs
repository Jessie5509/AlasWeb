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
            dto.documentacion = entity.documentacion;
            dto.tasaRegional = entity.tasaRegional;
            dto.tasaIntercontinental = entity.tasaIntercontinental;

            return dto;
        }

        public static Vuelo MapToEntity(DtoVuelo dto)
        {
            Vuelo entity = new Vuelo();
            entity.numVuelo = dto.numeroVuelo;
            entity.Vuelo.origen = dto.origen;
            entity.Vuelo.destino = dto.destino;
            entity.Vuelo.dtLlegada = dto.dtLlegada;
            entity.Vuelo.dtSalida = dto.dtSalida;
            entity.Vuelo.HorasTotales = dto.HorasTotales;
            entity.Vuelo.precio = dto.precio;
            entity.Vuelo.numeroAeronaveAsignada = dto.numeroAeronaveAsignada;

            return entity;
        }
    }
}
