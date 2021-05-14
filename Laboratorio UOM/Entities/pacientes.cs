using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laboratorio2.Entities
{
    public class pacientes
    {
        public int Nro_Busqueda { get; set; }
        public string Paciente { get; set; }
        public string Titular { get; set; }
        public string Telefono { get; set; }
        public long Documento { get; set; }
        public long NHC { get; set; }
        public long cuil_titu { get; set; }
        public string cod_pariente { get; set; }
        public long cuil { get; set; }
        public long documento { get; set; }
        public string sexo { get; set; }
        public int estado_civil { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public string nacionalidad { get; set; }
        public string calle { get; set; }
        public string numero { get; set; }
        public string piso { get; set; }
        public string dpto { get; set; }
        public string localidad { get; set; }
        public string cod_pos { get; set; }
        public string provincia { get; set; }
        public string tipo_domi { get; set; }
        public string tipo_titular { get; set; }
        public DateTime Fecha_Atualizacion { get; set; }
        public DateTime Fecha_Baja { get; set; }
        public string Seccional { get; set; }
        public string Nro_Seccional { get; set; }
        public int Titular_ID { get; set; }
        public string ObraSocial { get; set; }
        public int OSId { get; set; }
        public int Discapacidad { get; set; }
        public bool PMI { get; set; }
        public bool PI { get; set; }
        public string HC_UOM { get; set; }
        public string Comentario { get; set; }

        public long Documento_real { get; set; }
        public string Tipo_Documento { get; set; }
        public string cod_tipo_documento { get; set; }
    }

}
