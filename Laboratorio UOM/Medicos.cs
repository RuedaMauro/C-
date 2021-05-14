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
    public partial class Medicos : Form
    {
        public Medicos()
        {
            InitializeComponent();
        }

        private List<especialidad> lista_especialidad = new List<especialidad>();

        private void button2_Click(object sender, EventArgs e)
        {

            if (txt_Nombre.Text.Trim() == "") { MessageBox.Show("Error en el Nro de Usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            try
            {
                DAL.HospitalDataSetTableAdapters.QueriesTableAdapter adapter = new DAL.HospitalDataSetTableAdapters.QueriesTableAdapter();
                object id;
                //id = adapter.H2_Laboratorio_Guardar_Cabecera_Internacion(cbo_TipoOrden.SelectedValue.ToString(), DateTime.Now, Convert.ToDecimal(cbo_MedicoSolicitante.SelectedValue.ToString()), Convert.ToDecimal(cbo_MedicoSolicitante.SelectedValue.ToString()), Convert.ToDateTime("01/01/1900"), Convert.ToDateTime(FUM), cbo_Diagnostico1.SelectedValue.ToString(), cbo_Diagnostico02.SelectedValue.ToString(), txt_Observacion.Text, Convert.ToDateTime(txt_FEntrega.Value), Convert.ToInt32(usuarios.id), cbo_Sala.Text, cbo_Servicio.Text, cbo_Cama.Text, Convert.ToDecimal(Documento), txt_Bono.Text, Seccional);
                int? mi_id = null;
                DateTime? fecha = null;
                if (lb_id.Text != "") mi_id = Convert.ToInt32(lb_id.Text);
                if (txt_fecha_baja.Text != "") fecha = Convert.ToDateTime(txt_fecha_baja.Text);

                id = adapter.H2_Medico_Guardar_Labo(mi_id, txt_Nombre.Text, fecha, txt_motivo_baja.Text, "", null, null, null, null, null, null, "", "0", null, "1", null, null, 0, null, "A", null, null, null, null, null);
                adapter.H2_MedicoEspecialidad_Guardar_Labo(Convert.ToInt32(id), (Int32)cbo_especialidad.SelectedValue, txt_Matricula_nac.Text, txt_Matricula_prov.Text, false, false, false, false, 0, 0, 0);
                MessageBox.Show("Los datos del médico han sido actualizados", "Médico actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                Limpiar();
                
                //30/01/2015 le quite el cerrar porque Paula necesitaba modificar muchos medicos al mismo tiempo.
                //this.Close();
            }
            catch (Exception ex) {
                MessageBox.Show("Se ha producido un error al intentar guardar el médico, intente nuevamente" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Limpiar();
            //this.Close();
        }

        private void Limpiar()
        {
            txt_fecha_baja.Text = "";
            txt_Matricula_nac.Text = "";
            txt_Matricula_prov.Text = "";
            txt_motivo_baja.Text = "";
            txt_Nombre.Text = "";            
            lb_id.Text = "0";
            Set_SIN_ESPECIALIDAD();
        }

        private void Set_SIN_ESPECIALIDAD()
        {
            cbo_especialidad.SelectedIndex = lista_especialidad.FindIndex(c => c.descripcion == "SIN ESPECIALIDAD");
        }

        private void Medicos_Load(object sender, EventArgs e)
        {
            Cargar_Especialidades();
            Cargar_Medicos(1);
            txt_Nombre.Focus();
            Limpiar();
        }

        private void Cargar_Especialidades()
        {
            cbo_especialidad.DataSource = null;
            lista_especialidad.Clear();
            
            DAL.HospitalDataSetTableAdapters.H3_Especialidad_ListaTableAdapter adapter = new DAL.HospitalDataSetTableAdapters.H3_Especialidad_ListaTableAdapter();
            DAL.HospitalDataSet.H3_Especialidad_ListaDataTable aTable = adapter.GetData();
            foreach (DAL.HospitalDataSet.H3_Especialidad_ListaRow row in aTable.Rows)
            {
                especialidad esp = new especialidad();
                esp.descripcion = row.Descripcion;
                esp.id = row.Id;
                lista_especialidad.Add(esp);
            }

            
            cbo_especialidad.DisplayMember = "descripcion";
            cbo_especialidad.ValueMember = "id";
            cbo_especialidad.DataSource = lista_especialidad;
        }

        private void Cargar_Medicos(int Mostrar_Bajas)
        {
            List<medico> lista = new List<medico>();
            DAL.HospitalDataSetTableAdapters.H2_Laboratorio_Medicos_ListarTableAdapter adapter = new DAL.HospitalDataSetTableAdapters.H2_Laboratorio_Medicos_ListarTableAdapter();

            DAL.HospitalDataSet.H2_Laboratorio_Medicos_ListarDataTable aTable = adapter.GetData(Mostrar_Bajas);

            foreach (DAL.HospitalDataSet.H2_Laboratorio_Medicos_ListarRow row in aTable.Rows)
            {
                medico d = new medico();
                d.id = row.id;
                d.nombre = row.ApellidoYNombre;
                if (!row.IsFechaBajaNull()) d.Fecha_baja = row.FechaBaja.ToShortDateString(); else d.Fecha_baja = "";
                if (!row.IsMotivoBajaNull()) d.Motivo_baja = row.MotivoBaja; else d.Motivo_baja = "";
                if (!row.IsEspecialidad_idNull()) d.Especialidad_id = row.Especialidad_id; else d.Especialidad_id = 320;
                if (!row.IsEspecialidadNull()) d.especialidad = row.Especialidad; else d.especialidad = "SIN ESPECIALIDAD";
                if (!row.IsNroMatNacionalNull()) d.MN = row.NroMatNacional; else d.MN = "";
                if (!row.IsNroMatProvincialNull()) d.MP = row.NroMatProvincial; else d.MP = "";

                lista.Add(d);
            }
            //cbo_MedicoSolicitante.ValueMember = "id";
            //cbo_MedicoSolicitante.DisplayMember = "nombre";

            gv_medicos.DataSource = lista;
            gv_medicos.Refresh();
        }

        private void txt_Nombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                cbo_especialidad.Focus();
                    e.Handled = true;
                    e.SuppressKeyPress = true;

            }
        }

        private void cbo_especialidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                txt_Matricula_nac.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;

            }
        }

        private void txt_Matricula_nac_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                //button2.Focus();
                txt_Matricula_prov.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;

            }
        }

        private void txt_Matricula_prov_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                txt_fecha_baja.Focus();                
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void gv_medicos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lb_id.Text = gv_medicos.Rows[e.RowIndex].Cells["id"].Value.ToString();
            txt_Nombre.Text = gv_medicos.Rows[e.RowIndex].Cells["nombre"].Value.ToString();
            txt_fecha_baja.Text = gv_medicos.Rows[e.RowIndex].Cells["fecha_baja"].Value.ToString();
            txt_Matricula_nac.Text = gv_medicos.Rows[e.RowIndex].Cells["mn"].Value.ToString();
            txt_Matricula_prov.Text = gv_medicos.Rows[e.RowIndex].Cells["mp"].Value.ToString();
            //lista_especialidad

            //int i = 0;
            //foreach (especialidad esp in lista_especialidad)
            //{
            //    if (esp.id == row.CodMedico)
            //    {
            //        cbo_MedicoSolicitante.SelectedIndex = i;
            //    }
            //    i++;
            //}

            cbo_especialidad.SelectedIndex = lista_especialidad.FindIndex(c => c.id == Convert.ToInt32(gv_medicos.Rows[e.RowIndex].Cells["especialidad_id"].Value.ToString()));
            //((especialidad)cbo_especialidad.SelectedItem).id = Convert.ToInt32(gv_medicos.Rows[e.RowIndex].Cells["especialidad_id"].Value.ToString());
        }

        private void txt_fecha_baja_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                txt_motivo_baja.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txt_motivo_baja_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                button2.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
