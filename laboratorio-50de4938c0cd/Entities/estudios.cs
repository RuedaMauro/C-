using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laboratorio2.Entities
{
    public class estudios
    {
        public estudios()
        {

        }
        public string Codigo { get; set; }
        public string SubCodigo { get; set; }
        public string Practica { get; set; }
        public string SubPractica { get; set; }
        public string Comentario { get; set; }
        public string Demora { get; set; }
        public string TipoMuestra { get; set; }
        public string Complejidad { get; set; }
    }
}
