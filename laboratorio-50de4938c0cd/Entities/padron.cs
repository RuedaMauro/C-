using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laboratorio2.Entities
{
    public class padron
    {
    }

    public class codpariente
    {
        public int codigo { get; set; }
        public string descripcion { get; set; }
    }

    public class seccionales
    {
        public string Seccional { get; set; }
        public int Id { get; set; }
        public string Nro { get; set; }
    }

    public class seccionalesListas : List<seccionales>
    { }

    public class codprovincias
    {
        public int codigo { get; set; }
        public string descripcion { get; set; }
    }


    public class personas
    {
        public Int64 cuil_titu { get; set; }
        public int cod_pariente { get; set; }
        public Int64 cuil { get; set; }
        public int documento { get; set; }
        public string apellido { get; set; }
        public int sexo { get; set; }
        public string fecha_nacimiento { get; set; }
        public string calle { get; set; }
        public string numero { get; set; }
        public string piso { get; set; }
        public string depto { get; set; }
        public string localidad { get; set; }
        public string cod_pos { get; set; }
        public int provincia { get; set; }
        public string telefono { get; set; }
        public string fechaalta { get; set; }
        public string fechaactualizacion { get; set; }
        public string fechabaja { get; set; }
        public string fechaaltapadron { get; set; }
        public string usuario { get; set; }
        public string titular { get; set; }
        public string email { get; set; }
        public int discapacidad { get; set; }
        public string FVDiscapacidad { get; set; }
        public string AnioCertificado { get; set; }
        public bool C1 { get; set; }
        public bool C2 { get; set; }
        public bool EsEstudiante { get; set; }
        public bool PMI { get; set; }
        public bool PI { get; set; }
        public Int64 Nro_HC_UOM { get; set; }
        public int seccional { get; set; }

        public string tipo_doc { get; set; }
        public string doc_descripcion { get; set; }

        public string cuit { get; set; }

    }

    public class titular
    {
        public int cod_os { get; set; }
        public Int64 cuit { get; set; }
        public int seccional { get; set; }
        public Int64 cuil_titu { get; set; }
        public string fechaalta { get; set; }
        public string fechaactualizacion { get; set; }
        public string fechabaja { get; set; }
        public int documento { get; set; }
        public string SeccionalNombre { get; set; }
        public string apellido { get; set; }
        public string RazonSocial { get; set; }
    }

    public class discapacidad
    {
        public int cod { get; set; }
        public string descripcion { get; set; }
    }

}
