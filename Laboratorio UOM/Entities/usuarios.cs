using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laboratorio2.Entities
{
    public static class usuarios
    {
        public static long id { get; set; }
        public static string nombre { get; set; }
        public static string usuario { get; set; }
        public static bool activo { get; set; }
        public static DateTime vencimiento { get; set; }
        public static string seccional { get; set; }
        public static  string seccionalnumero { get; set; }
        public static string permisos { get; set; }
        public static string permisosB { get; set; }
        public static string tipo { get; set; }
        public static string permisosG { get; set; }        
    }

    public class usuariosEdicion
    {
        public  long id { get; set; }
        public  string nombre { get; set; }
        public  string usuario { get; set; }
        public  bool activo { get; set; }
        //public  DateTime vencimiento { get; set; }
        //public  string seccional { get; set; }
        //public  string seccionalnumero { get; set; }
        //public  string permisos { get; set; }
        //public  string permisosB { get; set; }
        //public  string tipo { get; set; }
        public  string clave { get; set; }
    }
}
