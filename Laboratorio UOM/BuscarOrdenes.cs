using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Laboratorio2.Entities;
using System.Threading;

namespace Laboratorio2
{
    public partial class BuscarOrdenes : Form
    {
        public BuscarOrdenes()
        {
            InitializeComponent();
        }

        Principal formulario;

        public BuscarOrdenes(Principal f)
        {
            formulario = f;
            InitializeComponent();
        }

        private void Buscar()
        {
            List<protocolos> lista = new List<protocolos>();

            decimal? documento = null;
            if (txt_DNI.Text != "") documento = Convert.ToInt32(txt_DNI.Text);
            DateTime F1 = txt_fechaI.Value;
            DateTime F2 = txt_FechaF.Value;

            if (txt_Protocolo.Text.Length > 5)
            {
                F1 = Convert.ToDateTime("01/01/1900");
                F2 = Convert.ToDateTime("01/01/3000");
            }

            if (VariablesGlobales.permisosG.IndexOf("|2|") != -1)
            {
                DAL.HospitalDataSetTableAdapters.H2_Laboratorio_BuscarProtocolos_GuardiaTableAdapter adapter = new DAL.HospitalDataSetTableAdapters.H2_Laboratorio_BuscarProtocolos_GuardiaTableAdapter();
                DAL.HospitalDataSet.H2_Laboratorio_BuscarProtocolos_GuardiaDataTable aTable = adapter.GetData(txt_Protocolo.Text, F1, F2, txt_AyN.Text, documento, txt_HC.Text.Trim());
                int pos = 0;
                foreach (DAL.HospitalDataSet.H2_Laboratorio_BuscarProtocolos_GuardiaRow row in aTable.Rows)
                {
                    protocolos p = new protocolos();
                    p.Documento = row.documento.ToString();
                    p.fecha = row.FechaIngreso.ToShortDateString();
                    p.Paciente = row.Paciente;
                    p.Protocolo = row.Protocolo;
                    p.CodOrden = row.CodOrden.ToString();
                    p.Estado = row.Estado;
                    p.NH_UOM = row.HC_UOM_CENTRAL;
                    lista.Add(p);
                }
            }
            else
            {
                DAL.HospitalDataSetTableAdapters.H2_Laboratorio_BuscarProtocolosTableAdapter adapter = new DAL.HospitalDataSetTableAdapters.H2_Laboratorio_BuscarProtocolosTableAdapter();
                DAL.HospitalDataSet.H2_Laboratorio_BuscarProtocolosDataTable aTable = adapter.GetData(txt_Protocolo.Text, F1, F2, txt_AyN.Text, documento, txt_HC.Text.Trim(), cbo_tipo_doc.SelectedValue.ToString());
                int pos = 0;
                foreach (DAL.HospitalDataSet.H2_Laboratorio_BuscarProtocolosRow row in aTable.Rows)
                {
                    protocolos p = new protocolos();
                    p.Paciente_id = row.documento.ToString();
                    p.fecha = row.FechaIngreso.ToShortDateString();
                    p.Paciente = row.Paciente;
                    p.Protocolo = row.Protocolo;
                    p.CodOrden = row.CodOrden.ToString();
                    p.Estado = row.Estado;
                    p.NH_UOM = row.HC_UOM_CENTRAL;
                    p.Tipo_Doc = row.Tipo_doc;
                    p.Documento = row.documento_real.ToString();

                    lista.Add(p);
                }
            }


            gv_Ordenes.DataSource = lista;
            gv_Ordenes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;            
        }


        public void btn_Buscar_Click(object sender, EventArgs e)
        {
            gb_buscar.Visible = true;
            this.Refresh();
            Buscar();
            gb_buscar.Visible = false;
        }


        private void gv_Ordenes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            gb_buscar.Visible = true;
            label4.Text = "Cargando Protocolo...";
            this.Refresh();

            if (e.RowIndex != -1)
            {
                if (gv_Ordenes.Rows.Count > 0)
                {
                    //formulario.Recargar_Medicos = true;
                    //formulario.CargarMedicos(1);

                    string buscar = gv_Ordenes[1, gv_Ordenes.CurrentCell.RowIndex].Value.ToString();
                    formulario.txt_codordenAUX.Text = gv_Ordenes[0, gv_Ordenes.CurrentCell.RowIndex].Value.ToString();
                    formulario.lb_NroProtocolo.Text = "Nro. Orden: " + gv_Ordenes[1, gv_Ordenes.CurrentCell.RowIndex].Value.ToString();
                    formulario.cbo_hora.Checked = true;
                    formulario.cbo_hora.Enabled = false;
                    formulario.fechaDia.Enabled = false;
                    formulario.horaDia.Enabled = false;
                    //if (gv_Ordenes[5, gv_Ordenes.CurrentCell.RowIndex].Value.ToString() == "1" || gv_Ordenes[5, gv_Ordenes.CurrentCell.RowIndex].Value.ToString() == "0")
                    if (gv_Ordenes[5, gv_Ordenes.CurrentCell.RowIndex].Value.ToString() == "0")
                    {
                        formulario.btn_EliminarOrden.Visible = true;
                        formulario.tabControl1.Visible = true;
                        formulario.gb_datos_ingreso.Enabled = true;                        
                    }
                    else
                    {
                        formulario.lk_cambiar_fecha_entrega.Visible = true;
                        formulario.btn_EliminarOrden.Visible = false;
                        formulario.tabControl1.Visible = false;
                        formulario.gb_datos_ingreso.Enabled = false;                        
                    }

                    formulario.CargarSeccionales(false);
                    formulario.cbo_SeccionalDerivacion.SelectedValue = (Convert.ToInt32(gv_Ordenes[1, gv_Ordenes.CurrentCell.RowIndex].Value.ToString().Substring(0, 3))).ToString();

                    string Seccional = usuarios.seccionalnumero.ToString();
                    if (Seccional != gv_Ordenes[1, gv_Ordenes.CurrentCell.RowIndex].Value.ToString().Substring(0, 3))
                    {
                        //Derivacion
                        formulario.cbo_TipoOrden.Enabled = false;
                    }
                    else { 
                        //Misma seccional
                        formulario.cbo_TipoOrden.Enabled = true;
                    }

                    

                    formulario.cbo_SeccionalDerivacion.Enabled = false;

                    
                    formulario.EditarProtocolo(buscar);                    
                    this.Close();
                    //button1_Click(null, null);
                }
            }
        }


        private void txt_Protocolo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                btn_Buscar_Click(null, null);
            }
        }

        private void txt_DNI_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                btn_Buscar_Click(null, null);
            }
        }

        private void txt_AyN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                btn_Buscar_Click(null, null);
            }
        }

        private void txt_fechaI_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                btn_Buscar_Click(null, null);
            }
        }

        private void txt_FechaF_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                btn_Buscar_Click(null, null);
            }
        }

        private void txt_HC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                btn_Buscar_Click(null, null);
            }
        }

        private void BuscarOrdenes_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'genteDAL.Tipo_documento' table. You can move, or remove it, as needed.
            this.tipo_documentoTableAdapter.Fill(this.genteDAL.Tipo_documento);

        }
        

    }
}
