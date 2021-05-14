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
    public partial class EdicionIndicaciones : Form
    {
        public EdicionIndicaciones()
        {
            InitializeComponent();
            CargarIndicaciones();
        }

        private void EdicionIndicaciones_Load(object sender, EventArgs e)
        {
            
        }

        public void CargarIndicaciones()
        {
            List<indicaciones> lista = new List<indicaciones>();
            DAL.HospitalDataSetTableAdapters.H2_Laboratorio_ListarIndicacionesTableAdapter adapter = new DAL.HospitalDataSetTableAdapters.H2_Laboratorio_ListarIndicacionesTableAdapter();

            DAL.HospitalDataSet.H2_Laboratorio_ListarIndicacionesDataTable aTable = adapter.GetData();
            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();

            foreach (DAL.HospitalDataSet.H2_Laboratorio_ListarIndicacionesRow row in aTable.Rows)
            {
                indicaciones i = new indicaciones();
                i.Codigo = row.Cod.ToString();
                i.Descripcion = row.Descripcion;
                lista.Add(i);
            }
            cbo_Inidicaciones.ValueMember = "Codigo";
            cbo_Inidicaciones.DisplayMember = "Descripcion";
            cbo_Inidicaciones.DataSource = lista;
            cbo_Inidicaciones.AutoCompleteCustomSource = coleccion;
            cbo_Inidicaciones.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbo_Inidicaciones.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //cbo_Diagnostico02.SelectedValue = "ZA1";
        }

        private void cbo_Inidicaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_Codigo.Text = ((indicaciones)cbo_Inidicaciones.SelectedItem).Codigo;
            txt_Detalle.Text = ((indicaciones)cbo_Inidicaciones.SelectedItem).Descripcion;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DAL.LaboratorioDataSetTableAdapters.QueriesTableAdapter adapter = new DAL.LaboratorioDataSetTableAdapters.QueriesTableAdapter();
            adapter.H2_Laboratorio_InsertarIndicaciones(Convert.ToInt32(txt_Codigo.Text), txt_Detalle.Text);
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult Resultado = MessageBox.Show("¿Realmente desea eliminar la indicación?", "Borrar Indicación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Resultado == DialogResult.Yes)
            {
                DAL.HospitalDataSetTableAdapters.QueriesTableAdapter adapter = new DAL.HospitalDataSetTableAdapters.QueriesTableAdapter();
                adapter.H2_Laboratorio_BorrarIndicaciones(Convert.ToInt32(txt_Codigo.Text));
                this.Close();
            }
        }
    }
}
