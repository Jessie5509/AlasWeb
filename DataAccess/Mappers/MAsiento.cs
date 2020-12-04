using Common.DTO;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mappers
{
    public class MAsiento
    {
        public static DtoAsiento MapToDto(Asiento entity)
        {
            DtoAsiento dto = new DtoAsiento();
            dto.numeroAsiento = entity.numeroAsiento;
            dto.desde = entity.desde;
            dto.hasta = entity.hasta;
            dto.tipo = entity.tipo;
            dto.fila = entity.fila;
            dto.cantidad = entity.cantidad;
            dto.precio = entity.precio;
            dto.seleccionado = entity.seleccionado;
        
            return dto;
        }

        public static Asiento MapToEntity(DtoAsiento dto)
        {
            Asiento entity = new Asiento();
            entity.numeroAsiento = dto.numeroAsiento;
            entity.hasta = dto.hasta;
            entity.desde = dto.desde;
            entity.tipo = dto.tipo;
            entity.fila = dto.fila;
            entity.cantidad = dto.cantidad;
            entity.precio = dto.precio;
            entity.seleccionado = dto.seleccionado;
            
            return entity;
        }
    }
}
