using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Laboratorio2.Entities;

namespace Laboratorio2
{
    public partial class ModificarUsuarios : Form
    {
        public ModificarUsuarios()
        {
            InitializeComponent();
        }

        public string Id = "";

        public ModificarUsuarios(string Ids)
        {
            InitializeComponent();

            if (Ids != "0")
            {
                Id = Ids;
                usuariosEdicion u = new usuariosEdicion();

                UsuariosDataSetTableAdapters.H3_UsuariosTableAdapter adapter = new UsuariosDataSetTableAdapters.H3_UsuariosTableAdapter();
                UsuariosDataSet.H3_UsuariosDataTable aTable = adapter.GetData(Convert.ToInt32(Id));

                if (aTable.Rows.Count > 0 && aTable.Rows.Count < 2)
                {
                    ck_bloquear.Checked = aTable[0].activo;
                    txt_Usuario.Text = aTable[0].usuario;
                    txt_Nombre.Text = aTable[0].nombre;
                    txt_pass.Text = aTable[0].password;
                    if (!aTable[0].IsPermisoGNull()) {
                        if (aTable[0].PermisoG.IndexOf("|2|") != -1)
                        {
                            cbo_Avellaneda_solo_guardia.Checked = true;
                        }
                        else
                        {
                            cbo_Avellaneda_solo_guardia.Checked = false;
                        }
                    } else { cbo_Avellaneda_solo_guardia.Checked = false; } 
                    int Tipo = 0;
                    if (aTable[0].tipo == "Administrador") { Tipo = 1; }
                    cbo_tipousuario.SelectedIndex = Tipo;
                }


            }
            else {
                Id = "0";
                ck_bloquear.Checked = true;
                cbo_tipousuario.SelectedIndex = 0;
            this.Text = "Nuevo Usuario";
            }

        }

        private void bt_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ModificarUsuarios_Load(object sender, EventArgs e)
        {

        }

        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
            //actulizo            
                UsuariosDataSetTableAdapters.QueriesTableAdapter adatper = new UsuariosDataSetTableAdapters.QueriesTableAdapter();
                long Ids = Convert.ToInt64(Id);

                

                string Perfil = "";
                string Tipo = cbo_tipousuario.Text;
                long Seccional = Convert.ToInt64(VariablesGlobales.MiUsuarioseccional);
                string Permisos = "41";
                string Interno = "999";
                int miusuario = Convert.ToInt32(VariablesGlobales.MiUsuarioid);
                DateTime Vencimiento =  DateTime.Now.AddYears(10);

                string PermisoG = "|1|";
                if (cbo_Avellaneda_solo_guardia.Checked) { PermisoG = "|1||2|"; }
                if (Ids != 0)
                {
                    adatper.UpdateQuery(txt_Usuario.Text, txt_pass.Text, txt_Nombre.Text, Tipo, ck_bloquear.Checked, PermisoG, Ids);
                    MessageBox.Show("Usuario Actualizado","Actualizado",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    adatper.InsertQuery(txt_Usuario.Text, txt_pass.Text, txt_Nombre.Text, Tipo, Permisos, Convert.ToInt32(Permisos), ck_bloquear.Checked, Seccional, Interno, Vencimiento, "|0|", "|0|", miusuario, PermisoG); 
                    MessageBox.Show("Usuario Insertado", "Nuevo Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }

            
        }



    }
}
