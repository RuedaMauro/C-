using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laboratorio2.Clases
{
    class Practicas
    {
        public string Solo_practicas(string Practicas)
        { 
            int inicio = 0;

            if ((inicio = Practicas.IndexOf('[')) > 0)           
            {
                return Practicas.Substring(0, inicio-1);
            }
            else
            {
                return Practicas;
            }
        }
    }
}
