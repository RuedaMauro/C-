using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Laboratorio2.Entities;
using System.Configuration;
using System.Net;
using System.Net.Sockets;

namespace Laboratorio2
{
    public partial class Login : Form
    {

        public Login()
        {
            InitializeComponent();
        }        


        private void button1_Click(object sender, EventArgs e)
        {

            //29/03/2016
            //Esto es un testeo de la emisión de un bono...
            VariablesGlobales.MiUsuarioseccional = "003";
            //Impresion_Bono b = new Impresion_Bono("29/03/2016", 2, "Nada");
            //b.Show();
            //return;            

            if (Ingresar(txt_Usuario.Text, txt_Clave.Text) == "OK=54")
            {
                this.Hide();
                Principal f = new Principal();
                f.Show();
            }
            else
            {
                MessageBox.Show("Error el usuario y/o contraseña", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);                
                txt_Usuario.Text = "";
                txt_Clave.Text = "";
                txt_Usuario.Focus();
            }
        }

        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No se ha podido resolver la dirección IP");
        }


        public string Ingresar(string Usuario, string Clave)
        {

            DAL.HospitalDataSetTableAdapters.H2_Usuario_LoginTableAdapter adapter = new DAL.HospitalDataSetTableAdapters.H2_Usuario_LoginTableAdapter();
            DAL.HospitalDataSet.H2_Usuario_LoginDataTable aTable = adapter.GetData(Usuario, Clave);
                if (aTable.Rows.Count > 0)
                {

                    usuarios.activo = aTable[0].activo;
                    usuarios.vencimiento = aTable[0].fechavencimiento;

                    if (!usuarios.activo) { return "ERROR=No es un usuario en actividad.</br>Comuniquese con Sistemas"; }
                    if (usuarios.vencimiento < DateTime.Now) { return "ERROR=El usuario ha superado la fecha de vencimiento.</br>Comuniquese con Sistemas"; }

                    usuarios.id = aTable[0].id;
                    usuarios.nombre = aTable[0].nombre;
                    usuarios.usuario = aTable[0].usuario;
                    usuarios.seccional = aTable[0].Seccional;
                    if (!aTable[0].IstipoNull()) { usuarios.tipo = aTable[0].tipo; } else { usuarios.tipo = "Usuario"; }
                    if (!aTable[0].IspermisosNull()) { usuarios.permisos = aTable[0].permisos; } else { usuarios.permisos = ""; }
                    if (!aTable[0].IspermisosBNull()) { usuarios.permisosB = aTable[0].permisosB; } else { usuarios.permisosB = ""; }
                    usuarios.seccionalnumero = Right("0000" + aTable[0].seccionanumero.ToString(), 3);
                    usuarios.permisos = usuarios.permisos + usuarios.permisosB;
                    if (!aTable[0].IsPermisoGNull()) { usuarios.permisosG = aTable[0].PermisoG; } else { usuarios.permisosG = ""; }

                    //18/04/2017 - Se verifica en todos los permisos y no solo en permisosB
                    //if ((usuarios.permisosB.IndexOf("|9924|") > 0))
                    if (usuarios.permisos.IndexOf("|9924|") > 0)
                    {
                        VariablesGlobales.Administracion_Laboratorio = true;
                    }
                    else
                    {
                        VariablesGlobales.Administracion_Laboratorio = false;
                    }

                    VariablesGlobales.MiUsuarioid = usuarios.id;
                    VariablesGlobales.MiUsuarioseccional = usuarios.seccionalnumero;
                    VariablesGlobales.MiUsuarioTipo = usuarios.tipo;
                    VariablesGlobales.LinkImagenes = "10.10.8.71";
                    VariablesGlobales.permisosG = usuarios.permisosG;
                    VariablesGlobales.ip = GetLocalIPAddress();
                                      


                    if (ConfigurationManager.AppSettings["Imagenes"] != null)
                    {
                        VariablesGlobales.LinkImagenes = ConfigurationManager.AppSettings["Imagenes"];
                    }

                    try
                    {
                        //ACA AGREGO LA RUTINA DEL LOG DE INICIO DE SESION.
                        DAL.LaboratorioDataSetTableAdapters.QueriesTableAdapter query = new DAL.LaboratorioDataSetTableAdapters.QueriesTableAdapter();
                        query.H3_Laboratorio_Usuario_Log(Convert.ToInt32(usuarios.id), "Inicio Sesión (Laboratorio) // " + VariablesGlobales.ip);
                        //ACA FINALIZO LA RUTINA DEL LOG DE INICIO DE SESION.
                    }
                    catch
                    { 
                        //Error
                    }

                    return "OK=54";

                }
                
           
            return "ERROR=Usuario y/o Contraseña incorrecto";
        }

        public string Right(string param, int length)
        {

            int value = param.Length - length;
            string result = param.Substring(value, length);
            return result;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            VerificarVersion(Global.Version);
            lbl_Version.Text = "Versión: 1.0.1 ";// + Global.Version;
            lbl_Titulo.Parent = pictureBox1;
            lbl_Titulo.BackColor = Color.Transparent;        

        }

        private void VerificarVersion(string Ver)
        {
            try
            {
                DAL.LaboratorioDataSetTableAdapters.QueriesTableAdapter adapter = new DAL.LaboratorioDataSetTableAdapters.QueriesTableAdapter();
                object ver = adapter.H2_Laboratorio_Version(Ver);
                if (ver == null)
                {
                    MessageBox.Show("La versión del programa que está utiliando NO es soportada, por favor actualice la versión", "Error en la versión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //try
                    //{
                    //System.Diagnostics.Process.Start("http://10.10.8.71/Descargas/Laboratorio.zip");
                    //}
                    //catch { 

                    //}
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message + " , ¡Reinicie el servidor!", "Error al conectarse al servidor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void txt_Usuario_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_Usuario.Text != "")
                {
                    txt_Clave.Focus();
                }
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txt_Clave_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_Clave.Text != "")
                {
                    button1_Click(null, null);                    
                }
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lbl_Version_Click(object sender, EventArgs e)
        {

        }


    }
}
