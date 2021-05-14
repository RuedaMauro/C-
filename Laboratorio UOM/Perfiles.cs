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
    public partial class Perfiles : Form
    {
        List<estudios> l = new List<estudios>();

        public Perfiles()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            DAL.HospitalDataSetTableAdapters.QueriesTableAdapter adapter_Borrar = new DAL.HospitalDataSetTableAdapters.QueriesTableAdapter();
            adapter_Borrar.H2_Laboratorio_EliminarPerfil(Convert.ToInt32(txt_NPerfil.Text));

            DAL.HospitalDataSetTableAdapters.QueriesTableAdapter adapter2 = new DAL.HospitalDataSetTableAdapters.QueriesTableAdapter();
            adapter2.H2_Laboratorio_AgregarPerfil(Convert.ToInt32(txt_NPerfil.Text), cbo_Perfil.Text);

            DAL.HospitalDataSetTableAdapters.QueriesTableAdapter adapter_Insert = new DAL.HospitalDataSetTableAdapters.QueriesTableAdapter();

            foreach (estudios es in l)
            {

                string SubPrac = "0";

                if (es.SubCodigo != "" && es.SubCodigo != null)
                {
                    SubPrac = es.SubCodigo;
                }

                adapter_Insert.H2_Laboratorio_InsertarDetPerfil(Convert.ToInt32(txt_NPerfil.Text), es.Codigo, SubPrac);                
            }

        }

        private void btn_BPerfil_Click(object sender, EventArgs e)
        {
            DAL.HospitalDataSetTableAdapters.QueriesTableAdapter adapter2 = new DAL.HospitalDataSetTableAdapters.QueriesTableAdapter();
            adapter2.H2_Laboratorio_EliminarPerfil(Convert.ToInt32(txt_NPerfil.Text));
        }

        private void Perfiles_Load(object sender, EventArgs e)
        {
            CargarPracticas("", "");
            Listar();
            CargarPerfil();            
        }

        private void CargarPerfil()
        {
            l.Clear();
            DAL.HospitalDataSetTableAdapters.H2_Laboratorio_CargarPerfilPorCodTableAdapter adapter = new DAL.HospitalDataSetTableAdapters.H2_Laboratorio_CargarPerfilPorCodTableAdapter();
            DAL.HospitalDataSet.H2_Laboratorio_CargarPerfilPorCodDataTable aTable = adapter.GetData(txt_NPerfil.Text);
            List<estudios> lista = new List<estudios>();
            foreach (DAL.HospitalDataSet.H2_Laboratorio_CargarPerfilPorCodRow row in aTable.Rows)
            {
                estudios estudio = new estudios();
                estudio.Codigo = row.CodPractica.ToString().Trim();
                estudio.Practica = row.IDPractica;
                if (!row.IsSubCodigoNull()) estudio.SubCodigo = row.SubCodigo; else estudio.SubCodigo = "";
                if (!row.IsDescripcion_SubcodigoNull()) estudio.SubPractica = row.Descripcion_Subcodigo; else estudio.SubPractica = "";
                l.Add(estudio);
            }
            RecargarLista();
        }

        public void Listar()
        {
            DAL.HospitalDataSetTableAdapters.H2_Laboratorio_ListarPerfilTableAdapter adapter = new DAL.HospitalDataSetTableAdapters.H2_Laboratorio_ListarPerfilTableAdapter();
            DAL.HospitalDataSet.H2_Laboratorio_ListarPerfilDataTable aTable = adapter.GetData();
            List<perfiles> lista = new List<perfiles>();
            foreach (DAL.HospitalDataSet.H2_Laboratorio_ListarPerfilRow row in aTable.Rows)
            {
                perfiles p = new perfiles();
                p.Codigo = row.Cod.ToString();
                p.Descripcion = row.Descripcion;
                lista.Add(p);               
            }
            txt_NPerfil.ValueMember = "Codigo";
            txt_NPerfil.DisplayMember = "Codigo";
            txt_NPerfil.DataSource = lista;

            cbo_Perfil.ValueMember = "Codigo";
            cbo_Perfil.DisplayMember = "Descripcion";
            cbo_Perfil.DataSource = lista;
        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "")
            {
                ls_Perfil.Items.Add("(" + txtCodigo.Text + ") - " + cbo_Practicas.Text + "(" + cbo_SubPracticas.Text + ")");
                estudios estudio = new estudios();
                estudio.Codigo = txtCodigo.Text;
                estudio.Practica = cbo_Practicas.Text;
                string SP = "";
                if (cbo_SubPracticas.SelectedValue != null)
                {
                    SP = cbo_SubPracticas.SelectedValue.ToString();
                }
                estudio.SubCodigo = SP;
                estudio.SubPractica = cbo_SubPracticas.SelectedText;
                l.Add(estudio);

                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("No se puede insertar una practica vacía");
            }
        }

        private void LimpiarCampos()
        {
            txtCodigo.Text = "";
            cbo_Practicas.Text = "";
            cbo_SubPracticas.Text = "";
        }









        public void CargarPracticas(string Codigo, string Descripcion)
        {
            List<determinaciones> lista = new List<determinaciones>();
            DAL.HospitalDataSetTableAdapters.H2_Laboratorio_PracticasTableAdapter adapter = new DAL.HospitalDataSetTableAdapters.H2_Laboratorio_PracticasTableAdapter();

            int codigo = 0;
            if (txtCodigo.Text != "")
            {
                codigo = Convert.ToInt32(txtCodigo.Text);
                cbo_Practicas.Text = "";
            }
            DAL.HospitalDataSet.H2_Laboratorio_PracticasDataTable aTable = adapter.GetData(codigo, cbo_Practicas.Text);
            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();

            if (Codigo == "")
            {
                determinaciones de = new determinaciones();
                de.Codigo = "";
                de.Practica = "";
                de.Demora = "";
                lista.Add(de);
            }

            foreach (DAL.HospitalDataSet.H2_Laboratorio_PracticasRow row in aTable.Rows)
            {
                determinaciones d = new determinaciones();
                if (!row.IsCodNull()) d.Codigo = row.Cod;
                if (!row.IsDescCodNull())
                {
                    d.Practica = row.DescCod;
                    if (!row.IsDemoraNull()) { d.Demora = row.Demora; } else { d.Demora = "0"; }
                    coleccion.Add(row.DescCod);

                }
                lista.Add(d);
            }

            cbo_Practicas.DataSource = lista;
            cbo_Practicas.AutoCompleteCustomSource = coleccion;
            cbo_Practicas.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbo_Practicas.AutoCompleteSource = AutoCompleteSource.CustomSource;

            if (Codigo != null && Codigo != "")
            {
                if (cbo_Practicas.SelectedItem != null)
                {
                    //button1_Click_1(null, null);
                    cbo_SubPracticas.Focus();
                    CargarSubPracticas();
                }
                else
                {
                    //MessageBox.Show("Práctica no encontrada");
                }
            }

        }







        public void CargarSubPracticas()
        {
            List<determinaciones> lista = new List<determinaciones>();
            DAL.HospitalDataSetTableAdapters.H2_Laboratorio_SubPracticasTableAdapter adapter = new DAL.HospitalDataSetTableAdapters.H2_Laboratorio_SubPracticasTableAdapter();

            int codigo = 0;
            if (txtCodigo.Text != "")
            {
                codigo = Convert.ToInt32(txtCodigo.Text);
            }
            DAL.HospitalDataSet.H2_Laboratorio_SubPracticasDataTable aTable = adapter.GetData(codigo);
            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();

            foreach (DAL.HospitalDataSet.H2_Laboratorio_SubPracticasRow row in aTable.Rows)
            {
                determinaciones d = new determinaciones();
                if (!row.IsSubCodNull()) d.Codigo = row.SubCod;
                if (!row.IsDescSubCodNull())
                {
                    d.Practica = row.DescSubCod;
                    coleccion.Add(row.DescSubCod);
                }
                lista.Add(d);
            }
            cbo_SubPracticas.ValueMember = "Codigo";
            cbo_SubPracticas.DisplayMember = "Practica";
            cbo_SubPracticas.DataSource = lista;
            cbo_SubPracticas.AutoCompleteCustomSource = coleccion;
            cbo_SubPracticas.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbo_SubPracticas.AutoCompleteSource = AutoCompleteSource.CustomSource;

        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                CargarPracticas(txtCodigo.Text, "");
            }
        }

        private void btn_Quitar_Click(object sender, EventArgs e)
        {
            if (ls_Perfil.SelectedIndex > -1)
            {
                l.RemoveAt(ls_Perfil.SelectedIndex);
                RecargarLista();
            }
            else
            {
                MessageBox.Show("Falta seleccionar la práctica a eliminar","Falta seleccionar");
            }
        }

        private void RecargarLista()
        {
            ls_Perfil.Items.Clear();
            foreach (estudios es in l)
            {
                ls_Perfil.Items.Add("(" + es.Codigo + ") - " + es.Practica + "(" + es.SubPractica + ")");
            }     
        }

        private void cbo_SubPracticas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                btn_Agregar_Click(null, null);
                txtCodigo.Focus();
            }
        }

        private void txt_NPerfil_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarPerfil(); 
        }

        private void cbo_Practicas_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCodigo.Text = ((determinaciones)cbo_Practicas.SelectedValue).Codigo.Trim();
            cbo_SubPracticas.Text = "";
            CargarSubPracticas();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            l.Clear();
            ls_Perfil.Items.Clear();
            txt_NPerfil.Text = "";
            cbo_Perfil.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            l.Clear();
            RecargarLista();
        }













    }
}
