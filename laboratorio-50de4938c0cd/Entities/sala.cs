using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laboratorio2.Entities
{
    public class sala
    {
        public sala()
        {

        }

        public int id { get; set; }
        public string descripcion { get; set; }
        public bool estado { get; set; }
        public int servicio { get; set; }
        public string clase { get; set; }
        public string claseD { get; set; }

    }

}
