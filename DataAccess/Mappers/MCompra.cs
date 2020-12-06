using Common.DTO;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mappers
{
    public class MCompra
    {
        public static DtoCompra MapToDto(Compra entity)
        {
            DtoCompra dto = new DtoCompra();
            dto.idCompra = entity.idCompra;
            dto.dtCompra = entity.dtCompra;
            dto.numeroVuelo = entity.numeroVuelo;
            dto.precioTotal = entity.precioTotal;
            dto.DocumentoCli = entity.DocumentoCli;
        
            return dto;
        }

        public static Compra MapToEntity(DtoCompra dto)
        {
            Compra entity = new Compra();
            entity.idCompra = dto.idCompra;
            entity.dtCompra = dto.dtCompra;
            entity.numeroVuelo = dto.numeroVuelo;
            entity.precioTotal = dto.precioTotal;
            entity.DocumentoCli = dto.DocumentoCli;
       
            return entity;
        }
    }
}
