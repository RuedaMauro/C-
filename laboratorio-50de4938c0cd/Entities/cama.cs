using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laboratorio2.Entities
{
    public class cama
    {
        public cama()
        {

        }

        public int id { get; set; }
        public string descripcion { get; set; }
        public bool estado { get; set; }
        public int sala { get; set; }
        public string clase { get; set; }
        public string claseD { get; set; }

    }
}
