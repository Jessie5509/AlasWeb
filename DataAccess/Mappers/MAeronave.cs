using Common.DTO;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mappers
{
    public class MAeronave
    {
        public static DtoAeronave MapToDto(Aeronave entity)
        {
            DtoAeronave dto = new DtoAeronave();
            dto.numeroAeronave = entity.numeroAeronave;
            dto.modelo = entity.modelo;
            dto.horasVuelo = entity.horasVuelo;
            dto.anioIngreso = entity.anioIngreso;
            dto.cantAsientos = entity.cantAsientos;

            return dto;
        }

        public static Aeronave MapToEntity(DtoAeronave dto)
        {
            Aeronave entity = new Aeronave();
            entity.numeroAeronave = dto.numeroAeronave;
            entity.modelo = dto.modelo;
            entity.horasVuelo = dto.horasVuelo;
            entity.anioIngreso = dto.anioIngreso;
            entity.cantAsientos = dto.cantAsientos;

            return entity;
        }
    }
}
