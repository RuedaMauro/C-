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
    public partial class buscar_empresas : Form
    {
        public buscar_empresas()
        {
            InitializeComponent();
        }

        NuevoAfiliado formulario;

        public buscar_empresas(NuevoAfiliado f)
        {
            formulario = f;
            InitializeComponent();
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            if (txt_AyN.Text != "")
            {
                List<empresas> pp = new List<empresas>();
                pp = CargarPacienteAyN(txt_AyN.Text);
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = pp;
            }
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        public List<empresas> CargarPacienteAyN(string AyN)
        {
            return Paciente_Apellido(AyN);
        }

        public List<empresas> Paciente_Apellido(string Apellido)
        {
            List<empresas> lista = new List<empresas>();
            DAL.HospitalDataSetTableAdapters.H3_Buscar_EmpresaTableAdapter adapter = new DAL.HospitalDataSetTableAdapters.H3_Buscar_EmpresaTableAdapter();
            DAL.HospitalDataSet.H3_Buscar_EmpresaDataTable aTable = adapter.GetData(Apellido);

            int pos = 0;
            foreach (DAL.HospitalDataSet.H3_Buscar_EmpresaRow row in aTable.Rows)
            {
                empresas ee = new empresas();
                ee.cuit = row.Cuit.ToString();
                if (!row.IsRazon_SocialNull()) ee.nombre = row.Razon_Social;                
                lista.Add(ee);
            }

            return lista;
        }


        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {                
                if (e.RowIndex != -1)
                {
                formulario.txt_cuilempresas.Text = dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString();                
                this.Close();             
                }
            }
        }

        private void txt_AyN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                btn_Buscar_Click(null, null);
            }
        }
    }
}
