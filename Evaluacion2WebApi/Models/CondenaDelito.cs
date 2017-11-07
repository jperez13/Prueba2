using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Evaluacion2WebApi.Models
{
    public class CondenaDelito
    {
        public int Id { get; set; }
        public int CondenaId { get; set; }
        public int DelitoId { get; set; }
        public int AniosCondena { get; set; }
    }
}