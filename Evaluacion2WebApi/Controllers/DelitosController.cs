using Evaluacion2WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Evaluacion2WebApi.Controllers
{
    public class DelitosController : ApiController
    {
        private PresosDBContext context;

        public DelitosController()
        {
            this.context = new PresosDBContext();
        }

        public IEnumerable<Object> get()
        {
            return context.Delitos.ToList();
        }

        public IHttpActionResult get(int id)
        {
            Delito delitos = context.Delitos.Find(id);

            if (delitos == null)
            {
                return NotFound();
            }
            return Ok(delitos);
        }

        public IHttpActionResult post(Delito delito)
        {
            context.Delitos.Add(delito);
            int filasAfectadas = context.SaveChanges(); 

            if(filasAfectadas == 0 )
            {
                return InternalServerError();
            }

            return Ok(new { mensaje = "Delito Agregado Correctamente"});
        }

        public IHttpActionResult delete(int id)
        {
            Delito delito = context.Delitos.Find(id);

            if(delito == null)
            {
                return NotFound();
            }
            context.Delitos.Remove(delito);

            if(context.SaveChanges()>0)
            {
                return Ok(new { mensaje = "Delito Eliminado Correctamente" });
            }
            return InternalServerError();
        }

        public IHttpActionResult put(Delito delito)
        {
            context.Entry(delito).State = System.Data.Entity.EntityState.Modified;

            if (context.SaveChanges() > 0)
            {
                return Ok(new { Mensaje = "Delito Modificado correctamente" });
            }

            return InternalServerError();

        }

    }
}
