using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Laboratorio2
{
    public partial class frm_t_tubo : Form
    {

        int Codigo = 0;

        public frm_t_tubo()
        {
            InitializeComponent();
        }

        private void frm_t_tubo_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'grupoTubosDAL.grupo_tubos' table. You can move, or remove it, as needed.
            this.grupo_tubosTableAdapter1.Fill(this.grupoTubosDAL.grupo_tubos);
            // TODO: This line of code loads data into the 'laboratorioDataSet1.grupo_tubos' table. You can move, or remove it, as needed.
            this.grupo_tubosTableAdapter.Fill(this.laboratorioDataSet1.grupo_tubos);

        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Codigo = 0;
            txt_cant_etiquetas.Text = "1";
            txt_nombre.Text = "";
        }

        private void ls_grupos_Click(object sender, EventArgs e)
        {
            if (ls_grupos.Items.Count > 0)
            {
                Codigo = (int)ls_grupos.SelectedValue;
                txt_nombre.Text = ls_grupos.Text.Split('[')[0].Trim();
                txt_cant_etiquetas.Text = ls_grupos.Text.Split('[')[1].Trim().Replace("]", "");                
            }
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            int cant_et = 0;
            if (txt_nombre.Text == "")
            {
                MessageBox.Show("Falta el nombre del grupo", "Nombre del grupo",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                cant_et = Convert.ToInt32(txt_cant_etiquetas.Text);                
            }
            catch
            {
                MessageBox.Show("Falta la cantidad de etiquetas", "Etiquetas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DAL.GrupoTubosDALTableAdapters.QueriesTableAdapter adapter = new DAL.GrupoTubosDALTableAdapters.QueriesTableAdapter();
            adapter.Grupo_tubos_AM(Codigo, txt_nombre.Text, cant_et);
            Limpiar();
            this.grupo_tubosTableAdapter1.Fill(this.grupoTubosDAL.grupo_tubos);
        }

        private void Limpiar()
        {
            Codigo = 0;
            txt_nombre.Text = "";
            txt_cant_etiquetas.Text = "";
        }
    }
}
