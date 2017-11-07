using Evaluacion2WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Evaluacion2WebApi.Controllers
{
    public class CondenasController : ApiController
    {
        private PresosDBContext context;

        public CondenasController()
        {
            this.context = new PresosDBContext();
        }

        public IEnumerable<Object> get()
        {
            return context.Condenas.Include("Presos").Select(co => new
            {
                    ID = co.Id,
                    FechaInicioCondena = co.FechaInicioCondena,
                    FechaCondena = co.FechaCondena,
                    Preso = co.Preso,
                    Delitos = co.Delitos.Select(d => new
                    {
                        CondenaMaxima = d.CondenaMaxima,
                        CondenaMinima = d.CondenaMinima,
                        NombreCondena = d.Nombre
                    }), 
                 
            });

            //return context.Condenas.ToList();
        }

        public IHttpActionResult get(int id)
        {
            Condena condena = context.Condenas.Find(id);

            if (condena == null)
            {
                return NotFound();
            }
            return Ok(condena);
        }

        public IHttpActionResult post(Condena condena)
        {
            context.Condenas.Add(condena);
            int filasAfectadas = context.SaveChanges();

            if (filasAfectadas == 0)
            {
                return InternalServerError();
            }

            return Ok(new { mensaje = "Condena Agregada Correctamente" });
        }

        public IHttpActionResult delete(int id)
        {
            Condena condena = context.Condenas.Find(id);

            if (condena == null)
            {
                return NotFound();
            }
            context.Condenas.Remove(condena);

            if (context.SaveChanges() > 0)
            {
                return Ok(new { mensaje = "Condena Eliminada Correctamente" });
            }
            return InternalServerError();
        }

        public IHttpActionResult put(Condena condena)
        {
            context.Entry(condena).State = System.Data.Entity.EntityState.Modified;

            if (context.SaveChanges() > 0)
            {
                return Ok(new { Mensaje = "Condena Modificada correctamente" });
            }

            return InternalServerError();

        }
    }
}
