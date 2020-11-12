using Common.DTO;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DataAccess.Persistencia
{
    public class PAdmin
    {
        public bool existeEmpleado(DtoAdm dto)
        {
            bool existe = false;

            using (AlasPUMEntities context = new AlasPUMEntities())
            {
                existe = context.Administrador.Any(a => a.nombreUsuario == dto.NombreUsuario && a.contraseña == dto.contraseña);

            }

            return existe;
        }

        public bool RegistrarEmpleado(DtoAdm dto)
        {
            bool msg;

            using (AlasPUMEntities context = new AlasPUMEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        Administrador nuevoEmpleado = new Administrador();
                        nuevoEmpleado.documento = dto.documento;
                        nuevoEmpleado.nombreUsuario = dto.NombreUsuario;
                        nuevoEmpleado.contraseña = dto.contraseña;
                        nuevoEmpleado.email = dto.email;
                        nuevoEmpleado.nombre = dto.nombre;
                        nuevoEmpleado.apellido = dto.apellido;

                        context.Administrador.Add(nuevoEmpleado);
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

    }
}
