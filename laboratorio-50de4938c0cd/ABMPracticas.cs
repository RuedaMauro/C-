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
    public partial class ABMPracticas : Form
    {
        public class Complejidad{
            public int ComplejidadID { get; set; }
            public string Descripcion { get; set; }
        }

        public List<Complejidad> ListaComplejidad;

        public ABMPracticas()
        {
            InitializeComponent();
        }

        public bool TieneSubPractica;

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btb_Borrar_Click(object sender, EventArgs e)
        {
            //Borra la practica
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Busca la practica y las subpracticas
            Limpiar();
            
            int codigo = 0;

            if (txt_CodPractica.Text != "")
            {

                try
                {
                    codigo = Convert.ToInt32(txt_CodPractica.Text);                    
                }
                catch
                {
                    MessageBox.Show("El Código ingresado no es un número", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);                    
                    return;
                }

                if (txt_CodPractica.Text.Trim().Length < 3)
                {
                    txt_CodPractica.Text = txt_CodPractica.Text.PadLeft(3, '0');
                }

                List<determinaciones> lista = new List<determinaciones>();
                DAL.HospitalDataSetTableAdapters.H2_Laboratorio_PracticasTableAdapter adapter = new DAL.HospitalDataSetTableAdapters.H2_Laboratorio_PracticasTableAdapter();
                DAL.HospitalDataSet.H2_Laboratorio_PracticasDataTable aTable = adapter.GetData(codigo, "");

                foreach (DAL.HospitalDataSet.H2_Laboratorio_PracticasRow row in aTable.Rows)
                {
                    determinaciones d = new determinaciones();
                    if (!row.IsCodNull()) d.Codigo = row.Cod;
                    if (!row.IsDescCodNull())
                    {
                        d.Practica = row.DescCod;
                        if (!row.IsDemoraNull()) { d.Demora = row.Demora; } else { d.Demora = "0"; }
                        if (!row.IsTipoMuestraNull()) { d.TipoMuestra = Convert.ToInt32(row.TipoMuestra); } else { d.TipoMuestra = 0; }
                        //if (!row.IsTipoMuestraNull()) { d.TipoMuestra = Convert.ToInt32(row.TipoMuestra); } else { d.TipoMuestra = 0; }
                        if (!row.IsMostrar_GuardiaNull()) { d.Mostrar_Guardia = row.Mostrar_Guardia; } else { d.Mostrar_Guardia = false; }
                        if (!row.Isabreviatura_codNull()) { d.Abreviatura = row.abreviatura_cod; } else { d.Abreviatura = ""; }
                        if (!row.Isdias_ultima_practicaNull()) { d.dias_ultima_practica = row.dias_ultima_practica; } else { d.dias_ultima_practica = 0; }
                        if (!row.IsGrupo_TuboNull()) { d.Tipo_Tubo = row.Grupo_Tubo; } else { d.Tipo_Tubo = 0; }
                        if (!row.IsComplejidadNull()) { d.Complejidad = row.Complejidad; } else { d.Complejidad = 0; }
                    }
                    lista.Add(d);
                }

                if (lista.Count > 0)
                {
                    txt_NPractica.Text = lista[0].Codigo;
                    cbo_mostrar_en_guardia.Checked = lista[0].Mostrar_Guardia;
                    txt_demora.Text = lista[0].Demora;
                    int TipoMuestra = lista[0].TipoMuestra;
                    if (TipoMuestra < 1) {TipoMuestra = 12;}
                    cbo_TipoMuestra.SelectedValue = TipoMuestra;
                    cbo_tipo_tubo.SelectedValue = lista[0].Tipo_Tubo;
                    txt_abreviatura.Text = lista[0].Abreviatura;
                    txt_dias_ultimo_analisis.Text = lista[0].dias_ultima_practica.ToString();
                    cbo_complejidad.SelectedValue = lista[0].Complejidad;

                    string Practica = lista[0].Practica;
                    int hasta = Practica.IndexOf('[');
                    if (hasta > 0)
                    {
                        txt_NPractica.Text = Practica.Substring(0, hasta).Trim();
                    }
                    else
                    {
                        txt_NPractica.Text = Practica.Trim();
                    }
                    CargarSubPracticas();
                }

            }

            

        }

        public void Limpiar()
        {
            
            txt_abreviatura.Text = "";
            cbo_mostrar_en_guardia.Checked = false;
            txt_NPractica.Text = "";
            lsp.Items.Clear();
            txt_scPract.Text = "";
            txt_SubPract.Text = "";
            txt_demora.Text = "";
            txt_dias_ultimo_analisis.Text = "";
            cbo_complejidad.SelectedIndex = 0;
        }

        public void CargarSubPracticas()
        {
            lsp.Items.Clear();
            DAL.HospitalDataSetTableAdapters.H2_Laboratorio_SubPracticasTableAdapter adapter = new DAL.HospitalDataSetTableAdapters.H2_Laboratorio_SubPracticasTableAdapter();

            int codigo = 0;
            if (txt_CodPractica.Text != "")
            {
                codigo = Convert.ToInt32(txt_CodPractica.Text);
            }
            DAL.HospitalDataSet.H2_Laboratorio_SubPracticasDataTable aTable = adapter.GetData(codigo);
            bool TMuestra = false;
            foreach (DAL.HospitalDataSet.H2_Laboratorio_SubPracticasRow row in aTable.Rows)
            {
                determinaciones d = new determinaciones();
                if (!row.IsSubCodNull()) d.Codigo = row.SubCod;
                if (!row.IsDemoraNull()) { d.Demora = row.Demora; } else { d.Demora = "0"; }
                if (!row.IsDescSubCodNull())
                {
                    d.Practica = row.DescSubCod;
                }

                if (!row.IsTipoMuestraNull())
                {
                    d.TipoMuestra = Convert.ToInt32(row.TipoMuestra);
                }
                else
                {
                    d.TipoMuestra = 0;
                }

                if (!row.IsDefectoNull())
                {
                    d.Defecto = row.Defecto;
                }
                else
                {
                    d.Defecto = false;
                }

                if (!row.IsGrupo_tuboNull())
                {
                    d.Tipo_Tubo = row.Grupo_tubo;
                }
                else
                {
                    d.Tipo_Tubo = 0;
                }

                lsp.Items.Add(d.Codigo.Trim() + ";" + d.Practica.Trim() + ";" + d.Defecto.ToString() + ";" + d.TipoMuestra.ToString() + ";" + d.Tipo_Tubo);
                txt_demora.Text = d.Demora.Trim();
                if (!TMuestra)
                {
                    cbo_TipoMuestra.SelectedValue = d.TipoMuestra;
                    TMuestra = true;
                }


            }
        }

        private void ABMPracticas_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'laboratorioDataSet2.grupo_tubos' table. You can move, or remove it, as needed.
            this.grupo_tubosTableAdapter.Fill(this.laboratorioDataSet2.grupo_tubos);
            // TODO: This line of code loads data into the 'laboratorioDataSet.Tipo_Muestra' table. You can move, or remove it, as needed.
            this.tipo_MuestraTableAdapter.Fill(this.laboratorioDataSet.Tipo_Muestra);
            TieneSubPractica = false;
            ListaComplejidad = new List<Complejidad>();
            Complejidad cBaja, cMedia, cAlta;
            cBaja = new Complejidad(); cBaja.ComplejidadID = 1; cBaja.Descripcion = "Baja";
            cMedia = new Complejidad(); cMedia.ComplejidadID = 5; cMedia.Descripcion = "Media";
            cAlta = new Complejidad(); cAlta.ComplejidadID = 10; cAlta.Descripcion = "Alta";

            ListaComplejidad.Add(cBaja);
            ListaComplejidad.Add(cMedia);
            ListaComplejidad.Add(cAlta);
            cbo_complejidad.DataSource = ListaComplejidad;
            cbo_complejidad.DisplayMember = "Descripcion";
            cbo_complejidad.ValueMember = "ComplejidadID";
        }

        private void lsp_Click(object sender, EventArgs e)
        {
            if (lsp.Items.Count > 0)
            {
                txt_scPract.Text = lsp.SelectedItem.ToString().Split(';')[0].Trim();
                txt_SubPract.Text = lsp.SelectedItem.ToString().Split(';')[1].Trim();
                cbo_defecto.Checked = Convert.ToBoolean(lsp.SelectedItem.ToString().Split(';')[2].Trim());
                cbo_TipoMuestra.SelectedValue = Convert.ToInt32(lsp.SelectedItem.ToString().Split(';')[3].Trim());
                cbo_tipo_tubo.SelectedValue = Convert.ToInt32(lsp.SelectedItem.ToString().Split(';')[4].Trim());                
            }
        }

        private void btb_Agregar_SP_Click(object sender, EventArgs e)
        {

            foreach (string value in lsp.Items)
            {
                if (value.Split(';')[0] == txt_scPract.Text)
                {
                    MessageBox.Show("Ya existe la subpráctica", "Ya existe", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                    
                    return;
                }
            }

            if (cbo_tipo_tubo.Text == "")
            {
                MessageBox.Show("Falta seleccionar el tipo de tubo", "¿Que tubo?", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            string scPract = null;
            string SubPract = null;
            string demora = "0";

            if (txt_scPract.Text != "") scPract = txt_scPract.Text;
            if (txt_SubPract.Text != "") SubPract = txt_SubPract.Text;
            if (txt_demora.Text != "") demora = txt_demora.Text;            

            int dias_ultimo_analisis = 0;
            if (!int.TryParse(txt_dias_ultimo_analisis.Text, out dias_ultimo_analisis)) {dias_ultimo_analisis = 0;}

            DAL.ABMPracticasDALTableAdapters.QueriesTableAdapter adapter = new DAL.ABMPracticasDALTableAdapters.QueriesTableAdapter();
            adapter.InsertarPractica(txt_CodPractica.Text.Trim(), scPract.Trim(), txt_NPractica.Text, SubPract, cbo_defecto.Checked, demora, (cbo_TipoMuestra.SelectedValue).ToString(), cbo_mostrar_en_guardia.Checked, dias_ultimo_analisis, Convert.ToInt32((cbo_tipo_tubo.SelectedValue).ToString()), ((Complejidad)cbo_complejidad.SelectedItem).ComplejidadID);
            CargarSubPracticas();
            txt_scPract.Text = "";
            txt_SubPract.Text = "";
            cbo_defecto.Checked = false;
            cbo_TipoMuestra.SelectedValue = 12;
            MessageBox.Show("Práctica guardada", "Práctica Guardada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Limpiar();
        }

        private void btn_Modificar_SP_Click(object sender, EventArgs e)
        {
            string scPract = null;
            string SubPract = null;
            string demora = "0";

            if (lsp.Items.Count > 0)
            {
                if (txt_scPract.Text != "")
                {

                    if (cbo_tipo_tubo.Text == "")
                    {
                        MessageBox.Show("Falta seleccionar el tipo de grupo", "¿Que grupo?", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    int dias_ultimo_analisis = 0;
                    if (!int.TryParse(txt_dias_ultimo_analisis.Text, out dias_ultimo_analisis)) { dias_ultimo_analisis = 0; }

                    DAL.ABMPracticasDALTableAdapters.QueriesTableAdapter adapter = new DAL.ABMPracticasDALTableAdapters.QueriesTableAdapter();
                    adapter.ActualizarPractica(txt_NPractica.Text, txt_SubPract.Text, cbo_defecto.Checked, txt_demora.Text, (cbo_TipoMuestra.SelectedValue).ToString(), dias_ultimo_analisis, Convert.ToInt32((cbo_tipo_tubo.SelectedValue).ToString()),((Complejidad)cbo_complejidad.SelectedItem).ComplejidadID, txt_CodPractica.Text, txt_scPract.Text);
                    adapter.Actualizar_Guardia(cbo_mostrar_en_guardia.Checked, txt_CodPractica.Text);
                    adapter.AMAbreviatura(txt_abreviatura.Text, txt_CodPractica.Text);
                    CargarSubPracticas();
                    //bt_cancelar_Click(null, null);
                    MessageBox.Show("Subpráctica actualizada", "Actualizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                }
                else
                {
                    int dias_ultimo_analisis = 0;
                    if (!int.TryParse(txt_dias_ultimo_analisis.Text, out dias_ultimo_analisis)) { dias_ultimo_analisis = 0; }

                    //MessageBox.Show("No se puede actualizar una práctica sin seleccionar la subpractica");
                    DAL.ABMPracticasDALTableAdapters.QueriesTableAdapter adapter = new DAL.ABMPracticasDALTableAdapters.QueriesTableAdapter();
                    adapter.Actualiar_Cabecera(txt_NPractica.Text, txt_demora.Text, cbo_mostrar_en_guardia.Checked, dias_ultimo_analisis,((Complejidad)cbo_complejidad.SelectedItem).ComplejidadID, txt_CodPractica.Text);
                    adapter.AMAbreviatura(txt_abreviatura.Text, txt_CodPractica.Text);
                    //bt_cancelar_Click(null, null);
                    MessageBox.Show("Solo se ha actualizado la práctica en general, no la(s) subpráctica(s).", "Actualizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                }
            }
            else
            {
                if (cbo_tipo_tubo.Text == "")
                {
                    MessageBox.Show("Falta seleccionar el tipo de grupo", "¿Que grupo?", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                int dias_ultimo_analisis = 0;
                if (!int.TryParse(txt_dias_ultimo_analisis.Text, out dias_ultimo_analisis)) { dias_ultimo_analisis = 0; }

                DAL.ABMPracticasDALTableAdapters.QueriesTableAdapter adapter = new DAL.ABMPracticasDALTableAdapters.QueriesTableAdapter();
                adapter.ActualizarSoloPractica(txt_NPractica.Text, SubPract, cbo_defecto.Checked, txt_demora.Text, scPract, (cbo_TipoMuestra.SelectedValue).ToString(), dias_ultimo_analisis, Convert.ToInt32((cbo_tipo_tubo.SelectedValue).ToString()),((Complejidad)cbo_complejidad.SelectedItem).ComplejidadID, txt_CodPractica.Text);
                adapter.Actualizar_Guardia(cbo_mostrar_en_guardia.Checked, txt_CodPractica.Text);                
                adapter.AMAbreviatura(txt_abreviatura.Text, txt_CodPractica.Text);
                //bt_cancelar_Click(null, null);
                MessageBox.Show("Práctica actualizada", "Actualizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }

        }

        private void btn_Quitar_SP_Click(object sender, EventArgs e)
        {
            if (lsp.Items.Count > 0)
            {
                if (txt_scPract.Text != "")
                {
                    DAL.ABMPracticasDALTableAdapters.QueriesTableAdapter adapter = new DAL.ABMPracticasDALTableAdapters.QueriesTableAdapter();
                    adapter.BorrarPractica(txt_CodPractica.Text, txt_scPract.Text);
                    CargarSubPracticas();
                    Limpiar();
                    txt_CodPractica.Text = "";
                    bt_cancelar_Click(null, null);
                    MessageBox.Show("Subpráctica eliminada", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);                    
                }
                else
                {
                    MessageBox.Show("No se puede borrar una practica sin seleccionar la subpractica", "Subpráctica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);  
                }
            }
            else
            {
                if (txt_CodPractica.Text != "")
                {
                    DAL.ABMPracticasDALTableAdapters.QueriesTableAdapter adapter = new DAL.ABMPracticasDALTableAdapters.QueriesTableAdapter();
                    adapter.BorrarSoloPractica(txt_CodPractica.Text);
                    bt_cancelar_Click(null, null);
                    MessageBox.Show("Práctica eliminada", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);                    
                }
                else
                {
                    MessageBox.Show("Falta el codigo de la práctica a eliminar", "Código de práctica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);  
                }
            }
        }

        private void btn_editar_tubo_Click(object sender, EventArgs e)
        {
            frm_t_tubo f_tubo = new frm_t_tubo();
            f_tubo.ShowDialog();
            this.grupo_tubosTableAdapter.Fill(this.laboratorioDataSet2.grupo_tubos);
        }

        private void bt_cancelar_Click(object sender, EventArgs e)
        {
            txt_CodPractica.Text = "";
            Limpiar();
        }
    }
}
