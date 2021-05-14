using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laboratorio2.Entities
{
    public class determinaciones
    {
        public determinaciones()
        {
        }

        public string Codigo { get; set; }
        public string Practica { get; set; }
        public bool Defecto { get; set; }
        public string Demora { get; set; }
        public int TipoMuestra { get; set; }
        public bool Mostrar_Guardia { get; set; }
        public string Abreviatura { get; set; }
        public int dias_ultima_practica { get; set; }
        public int Tipo_Tubo { get; set; }
        public int Complejidad { get; set; }
    }
}
