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
    public partial class frm_Cambiar_Doc : Form
    {
        public frm_Cambiar_Doc(string Documento, string TipoDoc)
        {
            InitializeComponent();
            txt_doc_original.Text = Documento;
            cbo_tipo1.SelectedValue = TipoDoc;
            doc_original();
        }

        private DAL.GenteDALTableAdapters.GenteTableAdapter adapter = new DAL.GenteDALTableAdapters.GenteTableAdapter();
        private DAL.GenteDAL.GenteDataTable aTable;

        private void cb_acepto_cambio_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_acepto_cambio.Checked)
            {
                txt_doc_nuevo.Enabled = true;
                txt_doc_original.Enabled = true;
                txt_sec_o.Enabled = true;
                btn_realizar_cambio.Enabled = true;
                btn_val1.Enabled = true;
                btn_val2.Enabled = true;
                cbo_tipo1.Enabled = true;
                cbo_tipo2.Enabled = true;
            }
            else
            {
                txt_doc_nuevo.Enabled = false;
                txt_doc_original.Enabled = false;
                txt_sec_o.Enabled = false;
                btn_realizar_cambio.Enabled = false;
                btn_val1.Enabled = false;
                btn_val2.Enabled = false;
                cbo_tipo1.Enabled = false;
                cbo_tipo2.Enabled = false;
            }
        }


        private void TraerDatos(Label label, TextBox doc, bool advertir, bool limpiar, bool limpiar_seccional)
        {
            if (doc.Text.Trim() == "")
            {
                MessageBox.Show("Falta cargar el documento", "¿Documento?", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                int a = Convert.ToInt32(doc.Text.Trim());
            }
            catch
            {
                MessageBox.Show("Verifique el documento ingresado", "¿Documento?", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            aTable = adapter.GetData(Convert.ToInt32(doc.Text));
            if (aTable.Count > 0)
            {
                if (aTable.Count > 1)
                {
                    label.Text = "";
                    if (limpiar)
                    {
                        doc.Text = "";
                    }
                    MessageBox.Show("ATENCION ESE DOCUMENTO EXISTE MAS DE UNA VEZ, COMUNIQUESE CON SISTEMAS.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                label.Text = "(" + aTable[0].HC_UOM_CENTRAL + ") " + aTable[0].apellido;
                if (doc == txt_doc_original && limpiar_seccional)
                {
                    txt_sec_o.Text = aTable[0].Seccional.ToString();
                }

            }
            else
            {
                label.Text = "";
                if (limpiar)
                {
                    doc.Text = "";
                }
                if (advertir)
                {
                    MessageBox.Show("No se encuentra paciente con ese nro de documento", "Documento no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                return;
            }
        }


        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_doc_original_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                doc_original();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }            
        }

        private void doc_original()
        {
            TraerDatos(lbl_apellido_actual, txt_doc_original, true, true, true);
        }

        private void txt_doc_nuevo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                TraerDatos(lbl_apellido_nuevo, txt_doc_nuevo, true, false, true);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void btn_realizar_cambio_Click(object sender, EventArgs e)
        {

            if (txt_doc_original.Text.Trim() != "")
            {
                TraerDatos(lbl_apellido_actual, txt_doc_original, false, true, false);
            }
            else
            {
                MessageBox.Show("Falta cargar el documento original", "¿Documento?", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            if (txt_doc_nuevo.Text.Trim() != "")
            {
                TraerDatos(lbl_apellido_nuevo, txt_doc_nuevo, false, false, true);
            }
            else
            {
                MessageBox.Show("Falta cargar el documento nuevo", "¿Documento?", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (lbl_apellido_nuevo.Text != "")
            { 
                //Quiere decir que existe el paciente.
                DialogResult Resultado = MessageBox.Show("Se va a unir los protocolos del paciente " + lbl_apellido_actual.Text + " con el del paciente " + lbl_apellido_nuevo.Text + ". ¿Está seguro de continuar?", "Unir documentos", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (Resultado == DialogResult.Yes)
                {
                    HacerCambios();
                }
                return;
            }
            HacerCambios();
        }

        private void HacerCambios()
        {
            DAL.GenteDALTableAdapters.QueriesTableAdapter adapter = new DAL.GenteDALTableAdapters.QueriesTableAdapter();
            //Borrar pacientes con Nro de doc.
            if (txt_doc_nuevo.Text.Trim() != txt_doc_original.Text.Trim())
            {                                
                adapter.BorrarDocumento(Convert.ToInt32(txt_doc_nuevo.Text), cbo_tipo1.SelectedValue.ToString());
            }

            //Actualizo el actual co nel nuevo nro de documento.
            adapter.Actualizar_Doc_y_Seccional(Convert.ToInt64(txt_doc_nuevo.Text),Convert.ToInt64(txt_sec_o.Text) ,Convert.ToInt64(txt_doc_original.Text));

            //Actualizo Gente
            adapter.Actualizar_Gente(Convert.ToInt32(txt_doc_nuevo.Text), Convert.ToInt32(txt_sec_o.Text), cbo_tipo1.SelectedValue.ToString(), Convert.ToInt32(txt_doc_original.Text));

            MessageBox.Show("Cambio realizado", "Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();

        }

        private void btn_val1_Click(object sender, EventArgs e)
        {
            doc_original();
        }

        private void btn_val2_Click(object sender, EventArgs e)
        {
            TraerDatos(lbl_apellido_nuevo, txt_doc_nuevo, true, false, true);
        }

        private void txt_doc_original_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_doc_nuevo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void frm_Cambiar_Doc_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'genteDAL.Tipo_documento' table. You can move, or remove it, as needed.
            this.tipo_documentoTableAdapter.Fill(this.genteDAL.Tipo_documento);

        }

    }
}
