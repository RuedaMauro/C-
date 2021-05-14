using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;

namespace Laboratorio2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Mutex instanceLock = new Mutex(false, "Nombre del Assembly");
            if (instanceLock.WaitOne(0, false))
            {
                try
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);

                    Application.Run(new Login());
                    //Application.Run(new Impresion_Automatica());
                }
                finally
                { instanceLock.ReleaseMutex(); }
            }
            else
            {
                //MessageBox.Show("Ha intentado ejecutar el programa más de una vez, el programa se cerrará de forma automática.");
                Application.Exit();
            }

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            //Application.Run(new Login());
            //Application.Run(new Form2());
            //Application.Run(new Perfiles());
            
        }
    }
}
