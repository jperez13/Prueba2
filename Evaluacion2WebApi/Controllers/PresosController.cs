using Evaluacion2WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Evaluacion2WebApi.Controllers
{
    public class PresosController : ApiController
    {
        private PresosDBContext context;

        public PresosController()
        {
            this.context = new PresosDBContext();
        }

        public IEnumerable<object> get()
        {
            return context.Presos.Select(c => new
            {
                Id = c.Id,
                Rut = c.Rut,
                Nombre = c.Nombre,
                FechaNacimiento = c.FechaNacimiento,
                Domicilio = c.Domicilio,
                Sexo = c.Sexo,
                Condenas = c.condenas.Select(co => new
                {
                    ID = co.Id,
                    FechaInicioCondena = co.FechaInicioCondena,
                    FechaCondena = co.FechaCondena,
                    Delitos = co.Delitos.Select(d => new
                    {
                        CondenaMaxima = d.CondenaMaxima,
                        CondenaMinima = d.CondenaMinima,
                        NombreCondena = d.Nombre
                    }),
                }),
            });
        }

        public IHttpActionResult get(int id)
        {
            Preso preso = context.Presos.Find(id);
            if (preso == null)
            {
                return NotFound();
            }
            return Ok(preso);
        }

        public IHttpActionResult post(Preso preso)
        {
            context.Presos.Add(preso);
            int filasAfectadas = context.SaveChanges();

            if (filasAfectadas == 0)
            {
                return InternalServerError();
            }
            return Ok(new { mensaje = "Preso Agregado Correctamente" });
        }

        public IHttpActionResult delete(int id)
        {
            Preso preso = context.Presos.Find(id);

            if (preso == null)
            {
                return NotFound();
            }
            context.Presos.Remove(preso);

            int filasAfectadas = context.SaveChanges();

            if (filasAfectadas > 0)
            {
                return Ok(new { mensaje = "Preso Eliminado Correctamente" });
            }

            return InternalServerError();
        }

        public IHttpActionResult put(Preso preso)
        {
            context.Entry(preso).State = System.Data.Entity.EntityState.Modified;

            if (context.SaveChanges() > 0)
            {
                return Ok(new { mensaje = "Preso Modificado Correctamente" });
            }
            return InternalServerError();

        }
    }
}
