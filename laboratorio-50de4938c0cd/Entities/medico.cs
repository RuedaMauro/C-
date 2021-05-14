using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laboratorio2.Entities
{
    public class medico
    {
        public medico()
        {

        }

        public int id { get; set; }
        public string nombre { get; set; }
        public string especialidad { get; set; }
        public bool estado { get; set; }
        public string Fecha_baja { get; set; }
        public string Motivo_baja { get; set; }
        public string MN { get; set; }
        public string MP { get; set; }
        public int Especialidad_id { get; set; } 
              
    }
}
