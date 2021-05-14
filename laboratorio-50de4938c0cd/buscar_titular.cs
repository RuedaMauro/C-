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
    public partial class buscar_titular : Form
    {
        public buscar_titular()
        {
            InitializeComponent();
        }

        NuevoAfiliado formulario;

        public buscar_titular(NuevoAfiliado f)
        {
            formulario = f;
            InitializeComponent();
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            if (txt_AyN.Text != "")
            {
                List<pacientes> pp = new List<pacientes>();
                pp = CargarPacienteAyN(txt_AyN.Text);
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = pp;
            }
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        public List<pacientes> CargarPacienteAyN(string AyN)
        {
            return Paciente_Apellido(AyN);
        }

        public List<pacientes> Paciente_Apellido(string Apellido)
        {
            List<pacientes> lista = new List<pacientes>();
            DAL.HospitalDataSetTableAdapters.H3_Buscar_TitularTableAdapter adapter = new DAL.HospitalDataSetTableAdapters.H3_Buscar_TitularTableAdapter();
            DAL.HospitalDataSet.H3_Buscar_TitularDataTable aTable = adapter.GetData(Apellido);

            int pos = 0;
            foreach (DAL.HospitalDataSet.H3_Buscar_TitularRow row in aTable.Rows)
            {
                pacientes p = new pacientes();
                pos++;
                p.Nro_Busqueda = pos;
                p.Paciente = row.apellido;
                p.Documento = row.documento;
                if (!row.IstelefonoNull() && row.telefono.Length > 5) p.Telefono = row.telefono; else p.Telefono = "";
                p.NHC = row.cuil;
                p.HC_UOM = row.HC_UOM_CENTRAL;
                lista.Add(p);
            }

            return lista;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {                
                if (e.RowIndex != -1)
                {
                formulario.txt_cuiltitu.Text = dataGridView1[1, dataGridView1.CurrentCell.RowIndex].Value.ToString();                
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
