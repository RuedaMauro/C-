using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laboratorio2
{
    class ultima_consulta
    {        
         public ultima_consulta()
        {

        }

        public long ULTIMO_PACIENTE { get; set; }
        public string tipo_orden { get; set; }
        public int medico_solicitante { get; set; }
        public string servicio { get; set; }
        public string sala { get; set; }
        public string cama { get; set; }

        public string servicio_text { get; set; }
        public string sala_text { get; set; }
        public string cama_text { get; set; }

        public bool FMU  { get; set; }
        public string fecha_FMU  { get; set; }
        public string diagnostico1  { get; set; }
        public string diagnostico2  { get; set; }
        public string obs1  { get; set; }

    }

        
}
