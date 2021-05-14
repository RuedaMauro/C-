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
    public partial class Cambio_SSC : Form
    {
        private Principal princ = null;
        //private DAL.HospitalDataSetTableAdapters.H2_Servicio_ListaTableAdapter adapter_servicio = new DAL.HospitalDataSetTableAdapters.H2_Servicio_ListaTableAdapter();
        //private DAL.HospitalDataSetTableAdapters.H2_Sala_ListaTableAdapter adapter_sala = new DAL.HospitalDataSetTableAdapters.H2_Sala_ListaTableAdapter();
        //private DAL.HospitalDataSetTableAdapters.H2_Cama_ListaTableAdapter adapter_cama = new DAL.HospitalDataSetTableAdapters.H2_Cama_ListaTableAdapter();


        public Cambio_SSC(Principal f)
        {
            InitializeComponent();
            princ = f;
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Cargar()
        {
            lbl_hc.Text = princ.lbl_NHCOculto.Text;
            lbl_Nombre.Text = princ.lbl_PacienteOculto.Text;
            lbl_Edad.Text = princ.lbl_edad.Text;

            if (princ.lbl_sexo.Text.ToUpper() == "F")
            {
                lbl_sexo.Text = "Femenino";
            }
            else
            {
                if (princ.lbl_sexo.Text.ToUpper() == "M")
                {
                lbl_sexo.Text = "Masculino";
                }
                else
                {
                lbl_sexo.Text = "--";
                }
            }
            
            lbl_protocolo.Text = princ.lb_NroProtocolo.Text.Replace("Nro. Orden: ", "");
            lbl_fecha.Text = princ.fechaDia.Text + " " + princ.horaDia.Text;

            lbl_cama.Text = princ.cbo_Cama.Text;
            lbl_servicio.Text = princ.cbo_Servicio.Text;
            lbl_sala.Text = princ.cbo_Sala.Text;

            cbo_servicio.Text = princ.cbo_Servicio.Text;
            cbo_sala.Text = princ.cbo_Sala.Text;
            cbo_cama.Text = princ.cbo_Cama.Text;
        }

        private void Cambio_SSC_Load(object sender, EventArgs e)
        {
            CargarServicios();
            Cargar();
        }

        private void cbo_Servicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            Carga_Camas(-1);
            cbo_sala.Text = "";
            CargarSala(((servicios)(cbo_servicio.SelectedItem)).id);
        }

        private void cbo_Sala_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbo_cama.Text = "";
            Carga_Camas(((servicios)(cbo_sala.SelectedItem)).id);
        }

        public void Carga_Camas(int Salas)
        {
            List<cama> lista = new List<cama>();
            DAL.HospitalDataSetTableAdapters.H2_Cama_ListaTableAdapter adapter = new DAL.HospitalDataSetTableAdapters.H2_Cama_ListaTableAdapter();
            DAL.HospitalDataSet.H2_Cama_ListaDataTable aTable = adapter.GetData(null, Salas);

            foreach (DAL.HospitalDataSet.H2_Cama_ListaRow row in aTable.Rows)
            {
                cama d = new cama();
                d.id = row.Id;
                d.descripcion = row.Descripcion;
                if (row.state_id == 1)
                {
                    lista.Add(d);
                }

            }
            cbo_cama.DataSource = lista;
        }



        public void CargarSala(int Servicio)
        {
            List<servicios> lista = new List<servicios>();
            DAL.HospitalDataSetTableAdapters.H2_Sala_ListaTableAdapter adapter = new DAL.HospitalDataSetTableAdapters.H2_Sala_ListaTableAdapter();
            DAL.HospitalDataSet.H2_Sala_ListaDataTable aTable = adapter.GetData(null, Servicio);

            foreach (DAL.HospitalDataSet.H2_Sala_ListaRow row in aTable.Rows)
            {
                servicios d = new servicios();
                d.id = row.Id;
                d.descripcion = row.Descripcion;
                if (row.state_id == 1)
                {
                    lista.Add(d);
                }

            }

            cbo_sala.DataSource = lista;
        }


        public void CargarServicios()
        {
            List<servicios> lista = new List<servicios>();
            DAL.HospitalDataSetTableAdapters.H2_Servicio_ListaTableAdapter adapter = new DAL.HospitalDataSetTableAdapters.H2_Servicio_ListaTableAdapter();
            DAL.HospitalDataSet.H2_Servicio_ListaDataTable aTable = adapter.GetData(null, "");

            cbo_cama.Text = "";
            cbo_sala.Text = "";
            lista.Add(new servicios { id = -1, descripcion = "" });

            foreach (DAL.HospitalDataSet.H2_Servicio_ListaRow row in aTable.Rows)
            {
                servicios d = new servicios();
                d.id = row.Id;
                d.descripcion = row.Descripcion;
                if (row.state_id == 1)
                {
                    lista.Add(d);
                }

            }
            cbo_servicio.DataSource = lista;
        }

        private void cbo_servicio_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Carga_Camas(-1);
            cbo_sala.Text = "";
            CargarSala(((servicios)(cbo_servicio.SelectedItem)).id);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cbo_servicio.Text == "") { MessageBox.Show("Falta cargar el servicio", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (cbo_sala.Text == "") { MessageBox.Show("Falta cargar la sala", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (cbo_cama.Text == "") { MessageBox.Show("Falta cargar la cama", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            princ.cbo_Servicio.Text = cbo_servicio.Text;
            princ.CargarSala((Int32)cbo_servicio.SelectedValue);
            princ.Carga_Camas((Int32)cbo_sala.SelectedValue);

            princ.cbo_Sala.Text = cbo_sala.Text;
            princ.cbo_Cama.Text = cbo_cama.Text;                        

            DAL.LaboratorioDataSetTableAdapters.QueriesTableAdapter adapter = new DAL.LaboratorioDataSetTableAdapters.QueriesTableAdapter();
            adapter.H3_Actualizar_SSC(cbo_sala.Text, cbo_cama.Text, cbo_servicio.Text, lbl_protocolo.Text);
            MessageBox.Show("Datos Actualizados");
            this.Close();

        }

    }
}
