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

        public static DtoVuelo MapToDto(Vuelo entity)
        {
            DtoVuelo dto = new DtoVuelo();

            dto.numeroVuelo = entity.numeroVuelo;
            dto.origen = entity.origen;
            dto.destino = entity.destino;
            dto.dtLlegada = entity.dtLlegada;
            dto.dtSalida = entity.dtSalida;
            dto.HorasTotales = entity.HorasTotales;
            dto.numeroAeronaveAsignada = entity.numeroAeronaveAsignada;
            


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
            entity.numeroAeronaveAsignada = dto.numeroAeronaveAsignada;

            return entity;
        }

    }
}
