using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Laboratorio2.Entities;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Configuration;
using System.Media;
using System.Reflection;
using System.Diagnostics;


namespace Laboratorio2
{
    public partial class Principal : Form
    {
        ultima_consulta uc = new ultima_consulta();
        Point cursorPoint;
        int minutesIdle = 0;

        private bool isIdle(int minutes)
        {
            return minutesIdle >= minutes;
        }

        private void idleTimer_Tick(object sender, EventArgs e)
        {
            if (Cursor.Position != cursorPoint)
            {
                // The mouse moved since last check
                minutesIdle = 0;
            }
            else
            {
                // Mouse still stoped
                minutesIdle++;
            }

            // Save current position
            cursorPoint = Cursor.Position;
            if (isIdle(50))
            {
                idleTimer.Enabled = false;
                MessageBox.Show("Por falta de actividad el sistema ha sido cerrado. Vuelva a cargar el mismo.", "Inactividad en el sistema.", MessageBoxButtons.OK, MessageBoxIcon.Information);                
                Application.Exit();
            }
        }

        //public long ULTIMO_PACIENTE = 0;
        //public 

        public bool Falta_Seccional = false;

        public ImpresionBono ib;

        List<abreviatura> Lista_Abreviatura = new List<abreviatura>();
        private Font printFont;
        private Font printFont2;
        private Font printFontNegrita;
        pacientes paciente = new pacientes();
        public int posiPrac = 0;
        public int posiIndi = 0;
        public bool EditandoIndicaciones = false;
        public int CualEditandoIndicaciones = -1;
        public bool Recargar_Medicos = false;
        public bool EmiteBono = false;
        public BonoPase bono_datos = new BonoPase();

        public BindingList<estudios> l = new BindingList<estudios>();
        public List<feriados> feriados_Lista = new List<feriados>();
        bool Editanto = false;
        public int PosIzquierdaBarra = 20;
        public bool TeclaEnviada = false;

        public bool Prioridad = false;

        public bool Modificado = false;
        public bool Agregado = false;

        public int TipoMuestra = 1;

        private Laboratorio2.DAL.LaboratorioDataSetTableAdapters.QueriesTableAdapter adapter_labo = new DAL.LaboratorioDataSetTableAdapters.QueriesTableAdapter();
        
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;
            if (e.CloseReason == CloseReason.ApplicationExitCall) return;

            // Confirm user wants to close
            switch (MessageBox.Show(this, "¿Está seguro que desea cerrar la aplicación?", "¿Salir?", MessageBoxButtons.YesNo,MessageBoxIcon.Question))
            {
                case DialogResult.No:
                    e.Cancel = true;
                    break;
                default:
                    {
                        Application.Exit();
                        break;
                    }                    
            }
        }






        public Principal()
        {
            InitializeComponent();
            ib = new ImpresionBono(gv_PracticasListado, bono_datos);
            
            this.lblVersion.Text = "Version: " + Global.Version;
        }

        public void CrearResumen()
        {
            lbl_resumen.Text = "";
            foreach (estudios ll in l)
            {
                ll.Practica = ll.Practica + "   ";
                lbl_resumen.Text = lbl_resumen.Text + "-" + "("+ll.Codigo+"{"+ll.SubCodigo+"})"+ll.Practica.Substring(0,3).ToUpper();             
            }

            //MessageBox.Show(lbl_resumen.Text);

        }

        public void button1_Click_1(object sender, EventArgs e)
        
        
        
        
        
        
        
        
        
        
        {


            Modificado = true;
            bool Error = false;
            if (txtCodigo.Text == "")
            {
                MessageBox.Show("Falta Carga la práctica");
                Error = true;                
            }

            
            //Verifico si el usuario tiene o no un analisis realizado en ese periodo
            if (lbl_NHCOculto.Text.Trim() != "")
            {
                int Practica_dias = 0;
                if (Int32.TryParse(txtCodigo.Text, out Practica_dias))
                {
                    DAL.HospitalDataSetTableAdapters.H2_Laboratorio_Practica_ultima_atendidaTableAdapter adapter_dias = new DAL.HospitalDataSetTableAdapters.H2_Laboratorio_Practica_ultima_atendidaTableAdapter();
                    DAL.HospitalDataSet.H2_Laboratorio_Practica_ultima_atendidaDataTable aTable = adapter_dias.GetData(lbl_NHCOculto.Text, Practica_dias);
                    if (aTable.Count > 0)
                    {
                        DialogResult dialogResult = MessageBox.Show("El paciente ya se realizó la práctica el día " + aTable[0].ultima_fecha.ToShortDateString() + ".  \n¿Desea cargar la práctica?", "Práctica dentro de los últimos días", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.No)
                        {
                            LimpiarCampos();
                            return;
                        }
                    }


                }
            }


            if (!Error)
            {
                if (!Editanto)                
                {
                    if (cbo_SubPracticas.Text == "")
                    {
                        TipoMuestra = ((determinaciones)cbo_Practicas.SelectedItem).TipoMuestra;
                    }
                    else
                    {
                        TipoMuestra = ((determinaciones)cbo_SubPracticas.SelectedItem).TipoMuestra;
                    }
                }

                if (cbo_TipoOrden.SelectedValue == "G" && !Agregado)
                {
                    estudios ll = new estudios();
                    Agregado = true;
                    ll.Codigo = "999";
                    ll.Demora = "0";
                    ll.Practica = "URGENCIA";
                    ll.SubCodigo = "";
                    ll.SubPractica = "";
                    ll.TipoMuestra = TipoMuestra.ToString();
                    l.Add(ll);
                }

                if (TipoMuestra != 0)
                {
                    AgregarTipoMuestra(TipoMuestra);
                }

                if (Editanto == false)
                {
                    estudios estudio = new estudios();
                    estudio.Codigo = txtCodigo.Text;

                    if (cbo_Practicas.Text == "")
                    {
                        MessageBox.Show("Falta Carga la práctica");
                        return;
                    }

                    estudio.TipoMuestra = TipoMuestra.ToString();
                    estudio.Practica = cbo_Practicas.Text.Substring(0, (cbo_Practicas.Text.Length - 12)); //cbo_Practicas.Text;
                    estudio.SubPractica = cbo_SubPracticas.Text;
                    estudio.Demora = ((determinaciones)cbo_Practicas.SelectedItem).Demora.Trim();
                  
                    determinaciones d = new determinaciones();
                    if (cbo_SubPracticas.Items.Count > 0)
                    {
                        estudio.SubCodigo = ((determinaciones)cbo_SubPracticas.SelectedItem).Codigo.Trim();
                    }
                    else
                    {
                        estudio.SubCodigo = "";
                    }

                    bool Encontrado = false;

                    foreach (estudios ll in l)
                    {
                        if (ll.Codigo.Trim() == txtCodigo.Text.Trim() && ( cbo_SubPracticas.SelectedValue == null || ll.SubCodigo.ToString().Trim() == cbo_SubPracticas.SelectedValue.ToString().Trim()))
                        {
                            Encontrado = true;
                            break;
                        }
                    }
                    if (!Encontrado)
                    {
                        estudio.Comentario = txtComentario.Text;
                        l.Add(estudio);

                        gv_PracticasListado.AutoGenerateColumns = false;
                        gv_PracticasListado.DataSource = "";
                        gv_PracticasListado.DataSource = l;
                        gv_PracticasListado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                        calcularFecha();

                    }
                    else
                    {
                        MessageBox.Show("La práctica ya ha sido cargada");
                    }

                }
                else
                {
                    Editanto = false;
                    string buscar = gv_PracticasListado[0, gv_PracticasListado.CurrentCell.RowIndex].Value.ToString();
                    string buscarSC = gv_PracticasListado[4, gv_PracticasListado.CurrentCell.RowIndex].Value.ToString();

                    estudios f = null;
                    //estudios f = l.Find(delegate(estudios item) { return item.Codigo == buscar && item.SubCodigo == buscarSC; });

                    foreach (estudios item in l)
                    {
                        if (item.Codigo == buscar && item.SubCodigo == buscarSC)
                        {
                            f = item;
                        }
                    }

                    if (f != null)
                    {
                        f.Comentario = txtComentario.Text;
                    }
                    gv_PracticasListado.AutoGenerateColumns = false;
                    gv_PracticasListado.DataSource = "";
                    gv_PracticasListado.DataSource = l;

                    calcularFecha();
                }
                btn_QuitarPracticas.Visible = false;
                LimpiarCampos();
                DesBloquearTodo();
                txtCodigo.Focus();
                button2_Click(null, null);
                gv_PracticasListado.Refresh();
                gv_PracticasListado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }

            //CrearResumen();

        }

        private void AgregarTipoMuestra(int TipoMuestra)
        {
            Laboratorio2.DAL.LaboratorioDataSetTableAdapters.QueriesTableAdapter adapter = new DAL.LaboratorioDataSetTableAdapters.QueriesTableAdapter(); ;
            string ElCodigo = adapter.H3_CodigoAgregar_Descartable(TipoMuestra).ToString();
            string[] Cod = ElCodigo.Split(';');
            
            
            int codigo_nro = Convert.ToInt32(Cod[0]);
            int practica_nro = Convert.ToInt32(Cod[1]);
            string descartable_desc = Cod[3];

            bool Encontrado = false;
            foreach (estudios ll in l)
            {
                if (ll.Codigo.Trim() == practica_nro.ToString())
                {
                    Encontrado = true;
                    break;
                }
            }
            if (!Encontrado)
            {
                       // aca le pone la complejidad        

                estudios ll = new estudios();
                ll.Codigo = practica_nro.ToString();
                ll.Demora = "0";
                ll.Practica = descartable_desc;
                ll.SubCodigo = "";
                ll.SubPractica = "";
                // aca le pone la complejidad
                ll.Complejidad = "Complejidad";
                l.Add(ll);
                //AGREGAR
            }

        }

        public void LimpiarCampos()
        {
            //CargarPracticas("0", "");
            txtCodigo.Text = "";
            cbo_Practicas.Text = "";
            txtComentario.Text = "";
            cbo_SubPracticas.Text = "";
            cbo_SubPracticas.DataSource = null;
            cbo_SubPracticas.Items.Clear();
            TipoMuestra = 1;

            //cbo_SubPracticas.Items.Clear();
        }



        public void CargarServicios()
        {
            List<servicios> lista = new List<servicios>();
            DAL.HospitalDataSetTableAdapters.H2_Servicio_ListaTableAdapter adapter = new DAL.HospitalDataSetTableAdapters.H2_Servicio_ListaTableAdapter();
            DAL.HospitalDataSet.H2_Servicio_ListaDataTable aTable = adapter.GetData(null, "");

            cbo_Cama.Text = "";
            cbo_Sala.Text = "";
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
            cbo_Servicio.DataSource = lista;
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void GridClic()
        {
            btn_QuitarPracticas.Visible = false;
            BloquearTodo();
            if (gv_PracticasListado.Rows.Count > 0)
            {
                Editanto = true;
                string buscar = gv_PracticasListado[0, gv_PracticasListado.CurrentCell.RowIndex].Value.ToString();
                string buscarSC = gv_PracticasListado[4, gv_PracticasListado.CurrentCell.RowIndex].Value.ToString();
                try
                {
                    TipoMuestra = Convert.ToInt32(gv_PracticasListado[6, gv_PracticasListado.CurrentCell.RowIndex].Value.ToString());
                }
                catch
                {
                    TipoMuestra = 0;
                }
                estudios f = null;
                //estudios f = l.Find(delegate(estudios item) { return item.Codigo == buscar && item.SubCodigo == buscarSC; });

                foreach (estudios item in l)
                {
                    if (item.Codigo == buscar && item.SubCodigo == buscarSC)
                    {
                        f = item;
                    }
                }
                

                if (f != null)
                {
                    txtCodigo.Text = f.Codigo;
                    cbo_Practicas.Text = f.Practica;
                    //((determinaciones)cbo_SubPracticas.SelectedItem).Codigo.Trim() = f.SubCodigo;
                    cbo_SubPracticas.Items.Add(f.SubPractica);
                    cbo_SubPracticas.Text = f.SubPractica;
                    //cbo_SubPracticas.Text = f.SubPractica;
                    txtComentario.Text = f.Comentario;
                }

                btn_QuitarPracticas.Visible = true;
                gv_PracticasListado.AutoGenerateColumns = false;
                gv_PracticasListado.DataSource = "";
                gv_PracticasListado.DataSource = l;
                gv_PracticasListado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
        }


        public void BloquearTodo()
        {
            txtCodigo.Enabled = false;
            cbo_Practicas.Enabled = false;
            cbo_SubPracticas.Enabled = false;
            txtComentario.Text = "";
        }

        public void DesBloquearTodo()
        {
            txtCodigo.Enabled = true;
            cbo_Practicas.Enabled = true;
            cbo_SubPracticas.Enabled = true;
            txtComentario.Text = "";
        }

        private void txtPractica_TextChanged(object sender, EventArgs e)
        {
            List<determinaciones> lista = new List<determinaciones>();
            DAL.HospitalDataSetTableAdapters.H2_Laboratorio_PracticasTableAdapter adapter = new DAL.HospitalDataSetTableAdapters.H2_Laboratorio_PracticasTableAdapter();
            DAL.HospitalDataSet.H2_Laboratorio_PracticasDataTable aTable = adapter.GetData(Convert.ToInt32(txtCodigo.Text), cbo_Practicas.Text);

            foreach (DAL.HospitalDataSet.H2_Laboratorio_PracticasRow row in aTable.Rows)
            {
                determinaciones d = new determinaciones();
                if (!row.IsCodNull()) d.Codigo = row.Cod;
                if (!row.IsDescCodNull()) d.Practica = row.Cod;
                lista.Add(d);
            }

            cbo_Practicas.DataSource = l;


        }




        public void CargarPracticas(string Codigo, string Descripcion)
        {
            //cbo_SubPracticas.Text = "";
            //int codigo = 0;
            //if (txtCodigo.Text != "")
            //{
            //    try
            //    {
            //        codigo = Convert.ToInt32(txtCodigo.Text);
            //    }
            //    catch
            //    {
            //        MessageBox.Show("El Código ingresado no es un número");
            //        return;
            //    }
            //}

            cbo_SubPracticas.Text = "";
            //string aaa = ""; // ((determinaciones)cbo_Practicas.SelectedItem)

            //List<determinaciones> lista = new List<determinaciones>();
            //HospitalDataSetTableAdapters.H2_Laboratorio_PracticasTableAdapter adapter = new HospitalDataSetTableAdapters.H2_Laboratorio_PracticasTableAdapter();

            int codigo = 0;
            if (txtCodigo.Text != "")
            {
                try
                {                    
                    codigo = Convert.ToInt32(txtCodigo.Text);
                    if (txtCodigo.Text.Length == 1) txtCodigo.Text = "00" + txtCodigo.Text;
                    if (txtCodigo.Text.Length == 2) txtCodigo.Text = "0" + txtCodigo.Text;
                }
                catch
                {
                    //MessageBox.Show("El Código ingresado no es un número");
                    //return;
                    abreviatura r = Lista_Abreviatura.Find(delegate(abreviatura buscar) { return buscar.abreviatura_cod.ToUpper() == txtCodigo.Text.ToUpper(); });
                    if (r != null)
                    {
                        codigo = Convert.ToInt32(r.abreviatura_practica_cod);
                        txtCodigo.Text = r.abreviatura_practica_cod;
                    }
                    else
                    {
                        MessageBox.Show("No se encontró la abreviatura ingresada");
                        TeclaEnviada = false;
                        return;
                    }
                }
                //cbo_Practicas.Text = "";
            }
            //HospitalDataSet.H2_Laboratorio_PracticasDataTable aTable = adapter.GetData(codigo, cbo_Practicas.Text);
            //AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();

            
            if (Codigo == "")
            {
                determinaciones de = new determinaciones();
                de.Codigo = "";
                de.Practica = "";
                de.Demora = "";
                de.TipoMuestra = 1;
                //lista.Add(de);
            }
            
            //foreach (HospitalDataSet.H2_Laboratorio_PracticasRow row in aTable.Rows)
            //{
            //    determinaciones d = new determinaciones();
            //    if (!row.IsCodNull()) d.Codigo = row.Cod;
            //    if (!row.IsDescCodNull())
            //    {
            //        d.Practica = row.DescCod;
            //        if (!row.IsDemoraNull()) { d.Demora = row.Demora; } else { d.Demora = "0"; }
            //        coleccion.Add(row.DescCod);

            //    }
            //    lista.Add(d);
            //}
            
            //cbo_Practicas.DataSource = lista;
            //cbo_Practicas.AutoCompleteCustomSource = coleccion;
            //cbo_Practicas.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //cbo_Practicas.AutoCompleteSource = AutoCompleteSource.CustomSource;

            bool Encontrada = true;

            if (txtCodigo.Text != "" && cbo_Practicas.Text == "")
            {
                Encontrada = false;
                foreach (determinaciones det in cbo_Practicas.Items)
                {
                    if (det.Codigo.Trim() == txtCodigo.Text.Trim() && txtCodigo.Text != "")
                    {
                        Encontrada = true;
                        cbo_Practicas.SelectedItem = det;                        
                        break;
                    }
                }
            }

            if (Encontrada)
            {

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
            else {
                MessageBox.Show("Práctica no encontrada");
            }
            TeclaEnviada = false;

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
                if (!row.IsTipoMuestraNull()) d.TipoMuestra = Convert.ToInt32(row.TipoMuestra);                
                lista.Add(d);
            }
            cbo_SubPracticas.ValueMember = "Codigo";
            cbo_SubPracticas.DisplayMember = "Practica";
            cbo_SubPracticas.DataSource = lista;
            //cbo_SubPracticas.AutoCompleteCustomSource = coleccion;
            //cbo_SubPracticas.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //cbo_SubPracticas.AutoCompleteSource = AutoCompleteSource.CustomSource;
            
        }


        public void CargarTodaslasPracticas_Guardia()
        {
            List<determinaciones> lista = new List<determinaciones>();
            DAL.HospitalDataSetTableAdapters.H2_Laboratorio_Practicas_GuardiaTableAdapter adapter = new DAL.HospitalDataSetTableAdapters.H2_Laboratorio_Practicas_GuardiaTableAdapter();

            DAL.HospitalDataSet.H2_Laboratorio_Practicas_GuardiaDataTable aTable = adapter.GetData(0, null);
            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();

            determinaciones de = new determinaciones();
            de.Codigo = "";
            de.Practica = "";
            de.Demora = "";
            lista.Add(de);

            foreach (DAL.HospitalDataSet.H2_Laboratorio_Practicas_GuardiaRow row in aTable.Rows)
            {
                determinaciones d = new determinaciones();
                if (!row.IsCodNull()) d.Codigo = row.Cod;
                if (!row.IsDescCodNull())
                {
                    d.Practica = row.DescCod;
                    if (!row.IsDemoraNull()) { d.Demora = row.Demora; } else { d.Demora = "0"; }
                    coleccion.Add(row.DescCod);
                }
                if (!row.IsTipoMuestraNull()) { d.TipoMuestra = Convert.ToInt32(row.TipoMuestra); } else { d.TipoMuestra = 1; }
                lista.Add(d);
            }

            cbo_Practicas.DataSource = lista;
            cbo_Practicas.AutoCompleteCustomSource = coleccion;
            cbo_Practicas.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbo_Practicas.AutoCompleteSource = AutoCompleteSource.CustomSource;

            foreach (determinaciones det in cbo_Practicas.Items)
            {
                if (det.Codigo.Trim() == txtCodigo.Text.Trim() && txtCodigo.Text != "")
                {
                    cbo_Practicas.SelectedItem = det;
                }
            }

            TeclaEnviada = false;
        }


        public void CargarTodaslasPracticas()
        {                        
            List<determinaciones> lista = new List<determinaciones>();
            DAL.HospitalDataSetTableAdapters.H2_Laboratorio_PracticasTableAdapter adapter = new DAL.HospitalDataSetTableAdapters.H2_Laboratorio_PracticasTableAdapter();

            DAL.HospitalDataSet.H2_Laboratorio_PracticasDataTable aTable = adapter.GetData(0, null);
            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
            
            determinaciones de = new determinaciones();
            de.Codigo = "";
            de.Practica = "";
            de.Demora = "";
            lista.Add(de);

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
                if (!row.IsTipoMuestraNull()) { d.TipoMuestra = Convert.ToInt32(row.TipoMuestra); } else { d.TipoMuestra = 1; }
                lista.Add(d);
            }

            cbo_Practicas.DataSource = lista;
            cbo_Practicas.AutoCompleteCustomSource = coleccion;
            cbo_Practicas.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbo_Practicas.AutoCompleteSource = AutoCompleteSource.CustomSource;

            foreach (determinaciones det in cbo_Practicas.Items)
            {
                if (det.Codigo.Trim() == txtCodigo.Text.Trim() && txtCodigo.Text != "")
                {
                    cbo_Practicas.SelectedItem = det;
                }
            }

            //if (Codigo != null && Codigo != "")
            //{
            //    if (cbo_Practicas.SelectedItem != null)
            //    {
            //        //button1_Click_1(null, null);
            //        cbo_SubPracticas.Focus();
            //        CargarSubPracticas();
            //    }
            //    else
            //    {
            //        //MessageBox.Show("Práctica no encontrada");
            //    }
            //}
            TeclaEnviada = false;
            

        }

        public void CargarMedicos(int Mostrar_bajas)
        {
            List<medico> lista = new List<medico>();
            DAL.HospitalDataSetTableAdapters.H2_Laboratorio_Medicos_ListarTableAdapter adapter = new DAL.HospitalDataSetTableAdapters.H2_Laboratorio_Medicos_ListarTableAdapter();
            
            //con esto mostraba todos los medicos
            //DAL.HospitalDataSetTableAdapters.H2_Medicos_ListaTotalTableAdapter adapter = new DAL.HospitalDataSetTableAdapters.H2_Medicos_ListaTotalTableAdapter();

            //DAL.HospitalDataSet.H2_Medicos_ListaTotalDataTable aTable = adapter.GetData();
            DAL.HospitalDataSet.H2_Laboratorio_Medicos_ListarDataTable aTable = adapter.GetData(Mostrar_bajas);
            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();

            //foreach (DAL.HospitalDataSet.H2_Medicos_ListaTotalRow row in aTable.Rows)
            foreach (DAL.HospitalDataSet.H2_Laboratorio_Medicos_ListarRow row in aTable.Rows)
            {
                medico d = new medico();
                d.id = row.id;
                d.nombre = row.ApellidoYNombre;
                coleccion.Add(row.ApellidoYNombre);
                //'if (!row.is IsEspecialidadNull()) d.especialidad = row.Especialidad;
                
                lista.Add(d);
            }
            cbo_MedicoSolicitante.ValueMember = "id";
            cbo_MedicoSolicitante.DisplayMember = "nombre";
            cbo_MedicoSolicitante.DataSource = lista;
            cbo_MedicoSolicitante.AutoCompleteCustomSource = coleccion;
            cbo_MedicoSolicitante.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbo_MedicoSolicitante.AutoCompleteSource = AutoCompleteSource.CustomSource; 
        }


        //public void CargarICD10()
        //{
        //    List<icd10> lista = new List<icd10>();
        //    HospitalDataSetTableAdapters.H2_DiagnosticoICD10TableAdapter adapter = new HospitalDataSetTableAdapters.H2_DiagnosticoICD10TableAdapter();

        //    HospitalDataSet.H2_DiagnosticoICD10DataTable aTable = adapter.GetData("");
        //    AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();

        //    foreach (HospitalDataSet.H2_DiagnosticoICD10Row row in aTable.Rows)
        //    {
        //        icd10 d = new icd10();
        //        d.id = row.Codigo;
        //        d.diagnostico = row.Descripcion;
        //        coleccion.Add(row.Descripcion);
        //        //'if (!row.is IsEspecialidadNull()) d.especialidad = row.Especialidad;

        //        lista.Add(d);
        //    }
        //    cbo_Diagnostico1.ValueMember = "id";
        //    cbo_Diagnostico1.DisplayMember = "diagnostico";
        //    cbo_Diagnostico1.DataSource = lista;
        //    cbo_Diagnostico1.AutoCompleteCustomSource = coleccion;
        //    cbo_Diagnostico1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        //    cbo_Diagnostico1.AutoCompleteSource = AutoCompleteSource.CustomSource;
        //    cbo_Diagnostico1.SelectedValue = "ZA1";
        //}


        //public void CargarICD102()
        //{
        //    List<icd10> lista = new List<icd10>();
        //    HospitalDataSetTableAdapters.H2_DiagnosticoICD10TableAdapter adapter = new HospitalDataSetTableAdapters.H2_DiagnosticoICD10TableAdapter();

        //    HospitalDataSet.H2_DiagnosticoICD10DataTable aTable = adapter.GetData("");
        //    AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();

        //    foreach (HospitalDataSet.H2_DiagnosticoICD10Row row in aTable.Rows)
        //    {
        //        icd10 d = new icd10();
        //        d.id = row.Codigo;
        //        d.diagnostico = row.Descripcion;
        //        coleccion.Add(row.Descripcion);

        //        lista.Add(d);
        //    }
        //    cbo_Diagnostico02.ValueMember = "id";
        //    cbo_Diagnostico02.DisplayMember = "diagnostico";
        //    cbo_Diagnostico02.DataSource = lista;
        //    cbo_Diagnostico02.AutoCompleteCustomSource = coleccion;
        //    cbo_Diagnostico02.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        //    cbo_Diagnostico02.AutoCompleteSource = AutoCompleteSource.CustomSource;
        //    cbo_Diagnostico02.SelectedValue = "ZA1";
        //}




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

        private void CargarPerfil()
        {
            bool EncontrePerfil = false;
            DAL.HospitalDataSetTableAdapters.H2_Laboratorio_CargarPerfilPorCodTableAdapter adapter = new DAL.HospitalDataSetTableAdapters.H2_Laboratorio_CargarPerfilPorCodTableAdapter();
            DAL.HospitalDataSet.H2_Laboratorio_CargarPerfilPorCodDataTable aTable = adapter.GetData(txt_Perfil.Text);
            List<estudios> lista = new List<estudios>();
            foreach (DAL.HospitalDataSet.H2_Laboratorio_CargarPerfilPorCodRow row in aTable.Rows)
            {
                EncontrePerfil = true;
                estudios estudio = new estudios();
                estudio.Codigo = row.CodPractica.ToString().Trim();
                estudio.Practica = row.IDPractica;
                estudio.TipoMuestra = row.TipoMuestra;
                if (!row.IsSubCodigoNull()) estudio.SubCodigo = row.SubCodigo; else estudio.SubCodigo = "";
                if (!row.IsDescripcion_SubcodigoNull()) estudio.SubPractica = row.Descripcion_Subcodigo; else estudio.SubPractica = "";
                estudio.Demora = row.Demora;
                bool Encontrado = false;
                foreach (estudios ll in l)
                {
                    if (ll.Codigo == row.CodPractica.ToString().Trim() && ll.SubCodigo == estudio.SubCodigo)
                    {
                        Encontrado = true;
                    }
                }
                if (!Encontrado)
                {
                    l.Add(estudio);
                    if (estudio.TipoMuestra != "")
                    {
                        AgregarTipoMuestra(Convert.ToInt32(estudio.TipoMuestra));
                    }
                }
            }

            if (EncontrePerfil && cbo_TipoOrden.SelectedValue == "G" && !Agregado)
            {
                estudios ll = new estudios();
                Agregado = true;
                ll.Codigo = "999";
                ll.Demora = "0";
                ll.Practica = "URGENCIA";
                ll.SubCodigo = "";
                ll.SubPractica = "";
                ll.TipoMuestra = TipoMuestra.ToString();
                l.Add(ll);
            }

            gv_PracticasListado.AutoGenerateColumns = false;
            gv_PracticasListado.DataSource = "";
            gv_PracticasListado.DataSource = l;
            gv_PracticasListado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            calcularFecha();  

        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            //El usuario 63 es Cristian!!!
            if (VariablesGlobales.MiUsuarioTipo == "Administrador" || VariablesGlobales.Administracion_Laboratorio) { btn_usuarios.Visible = true; } else { btn_usuarios.Visible = false; }
            if (VariablesGlobales.MiUsuarioTipo == "Supervisor" || VariablesGlobales.MiUsuarioTipo == "Administrador" || VariablesGlobales.Administracion_Laboratorio || (VariablesGlobales.MiUsuarioid == 63 && VariablesGlobales.MiUsuarioseccional == "010")) { btn_Editar.Visible = true; }

            lbl_NHCOculto.Text = "";
            txt_codordenAUX.Text = "";
            CargarMedicos(0);

            //if (VariablesGlobales.permisosG.IndexOf("|2|") != -1)
            if (cbo_TipoOrden.SelectedValue == "G" && VariablesGlobales.MiUsuarioseccional == "003")
            {
                tabControl1.TabPages.Remove(tabPage3);
                cbo_Sala.Visible = false;
                cbo_Cama.Visible = false;
                cbo_Servicio.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
            }

            CargarIndicaciones();
            CargarTipos();
            CargarPerfil();
            Listar();
            FeriadosLista();
            CargarSeccionales(true);
            //this.cbo_Practicas.GotFocus += OnFocus;

            CargarAbreviaturas();
            CargarServicios();


            this.Text = "Laboratorio - OSUOMRA       USUARIO: " + usuarios.nombre.ToUpper();
            PosIzquierdaBarra = Convert.ToInt32(ConfigurationManager.AppSettings["CodBarraPosIzq"]);
            horaDia.Text = DateTime.Now.ToString("HH:mm");
            if (horaDia.Text.Length == 4) { horaDia.Text = "0" + horaDia.Text; }

            if (ConfigurationManager.AppSettings["EB"] == "1")
            {
                EmiteBono = true;
            }

            if (ConfigurationManager.AppSettings["NoAyuda"] == "1")
            {
                button11.Visible = false;
            }

        }

        private void CargarAbreviaturas()
        {
            DAL.LaboratorioDataSetTableAdapters.Abreviatura_PracticaTableAdapter adapter = new DAL.LaboratorioDataSetTableAdapters.Abreviatura_PracticaTableAdapter();
            DAL.LaboratorioDataSet.Abreviatura_PracticaDataTable aTable = adapter.GetData();
            foreach (DAL.LaboratorioDataSet.Abreviatura_PracticaRow row in aTable)
            {
                abreviatura a = new abreviatura();
                a.abreviatura_cod = row.abreviatura_cod;
                a.abreviatura_practica_cod = row.abreviatura_practica_cod;
                Lista_Abreviatura.Add(a);
            }

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

            cbo_Perfiles.ValueMember = "Codigo";
            cbo_Perfiles.DisplayMember = "Descripcion";
            cbo_Perfiles.DataSource = lista;
        }




        public void FeriadosLista()
        {
            DAL.HospitalDataSetTableAdapters.H2_Administracion_Feriados_ListaTableAdapter adapter = new DAL.HospitalDataSetTableAdapters.H2_Administracion_Feriados_ListaTableAdapter();
            DAL.HospitalDataSet.H2_Administracion_Feriados_ListaDataTable aTable = adapter.GetData();
            List<feriados> lista = new List<feriados>();
            foreach (DAL.HospitalDataSet.H2_Administracion_Feriados_ListaRow row in aTable.Rows)
            {
                feriados p = new feriados();
                p.fecha = row.fecha;
                feriados_Lista.Add(p);
            }

            //feriados fer = new feriados(); fer.fecha = Convert.ToDateTime("23/03/2015"); feriados_Lista.Add(fer);
            //feriados fer2 = new feriados(); fer2.fecha = Convert.ToDateTime("24/03/2015"); feriados_Lista.Add(fer2);

        }




        public void EditarProtocolo(string Protocolo)
        {
            //MessageBox.Show(Protocolo);
            //this.Text = Protocolo;

            DAL.HospitalDataSetTableAdapters.H2_Laboratorio_cargarProtocoloTableAdapter adapter = new DAL.HospitalDataSetTableAdapters.H2_Laboratorio_cargarProtocoloTableAdapter();

            DAL.HospitalDataSet.H2_Laboratorio_cargarProtocoloDataTable aTable = adapter.GetData(Protocolo);

            int DOC = 0;

            foreach (DAL.HospitalDataSet.H2_Laboratorio_cargarProtocoloRow row in aTable.Rows)
            {
                if (!row.IsNumeroBono1Null()) txt_Bono.Text = row.NumeroBono1; else txt_Bono.Text = "";
                if (!row.IsSectorNull()) cbo_Servicio.Text = row.Sector; else cbo_Servicio.Text = "";
                if (!row.IsSalaNull()) cbo_Sala.Text = row.Sala; else cbo_Sala.Text = "";
                if (!row.IsCamaNull()) cbo_Cama.Text = row.Cama; else cbo_Cama.Text = "";
                if(!row.IsTipoOrdenNull()) cbo_TipoOrden.SelectedValue = row.TipoOrden.ToString();


                if (!btn_EliminarOrden.Visible && cbo_Cama.Visible)
                {
                    btn_cambiar_cama.Visible = true;
                }
                else
                {
                    btn_cambiar_cama.Visible = false;
                }


                int i = 0;
                foreach (medico m in cbo_MedicoSolicitante.Items)
                {
                    if (m.id == row.CodMedico)
                    {
                        cbo_MedicoSolicitante.SelectedIndex = i;                  
                    }
                    i++;
                }

                     

                if (!row.IsFUMNull() && row.FUM.ToShortDateString() != "01/01/1900")
                {
                    txt_FUM.Value = row.FUM;
                    ck_FUM.Checked = true;
                }

                if (!row.IsDiagnostico1Null()) cbo_Diagnostico1.Text = row.Diagnostico1;
                if (!row.IsDiagnostico2Null()) cbo_Diagnostico02.Text = row.Diagnostico2;
                if(!row.IsFechaAEntregarNull()) txt_FEntrega.Value = row.FechaAEntregar;
                if (!row.IsObservacionesNull()) txt_Observacion.Text = row.Observaciones;

                //Fecha y Hora
                if (!row.IsFechaIngresoNull()) fechaDia.Text = row.FechaIngreso.ToShortDateString();
                if (!row.IsHoraIngresoNull()) horaDia.Text = row.HoraIngreso;

                DOC = (int)row.CodPaciente;
                
            }




            List<pacientes> lista = new List<pacientes>();
            DAL.HospitalDataSetTableAdapters.H2_Afiliado_Encabezado_IDTableAdapter adapter2 = new DAL.HospitalDataSetTableAdapters.H2_Afiliado_Encabezado_IDTableAdapter();
            DAL.HospitalDataSet.H2_Afiliado_Encabezado_IDDataTable aTable2 = adapter2.GetData(DOC);

            int pos = 0;
            pacientes p = new pacientes();
            foreach (DAL.HospitalDataSet.H2_Afiliado_Encabezado_IDRow row in aTable2.Rows)
            {
                Falta_Seccional = false;
                pos++;
                p.Nro_Busqueda = pos;
                p.cuil_titu = row.cuil_titu;
                p.cuil = row.cuil;

                if (!row.IsComentarioNull()) { p.Comentario = row.Comentario; }
                
                p.documento = row.documento;
                if (!row.Isfecha_nacimientoNull()) p.fecha_nacimiento = row.fecha_nacimiento;
                if (!row.IsSeccionalNull()) p.Seccional = row.Seccional;
                if (p.Seccional == null)
                {
                    MessageBox.Show("Falta cargar la seccional del paciente", "Falta seccional", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Falta_Seccional = true;
                }

                if (!row.IssexoNull()) p.sexo = row.sexo; else p.sexo = "1";

                if (!row.IsLocalidadNull()) { p.localidad = row.Localidad; }

                p.Paciente = row.apellido;

                if (!row.IsNro_SeccionalNull()) p.Nro_Seccional = row.Nro_Seccional.ToString(); else p.Nro_Seccional = "999";

                if (!row.IstelefonoNull()) p.Telefono = row.telefono;
                p.Titular = "";

                p.ObraSocial = row.OS;
                p.OSId = row.OSId;

                if (!row.IsDiscapacidadNull())
                {
                    p.Discapacidad = Convert.ToInt32(row.Discapacidad);

                }
                else
                {
                    p.Discapacidad = 0;
                }

                p.HC_UOM = row.HC_UOM_CENTRAL;
                p.Tipo_Documento = row.Tipo_doc;
                p.Documento_real = row.documento_real;
                p.NHC = row.cuil;

                if (p.Comentario != null && p.Comentario.Trim() != "")
                {
                    MessageBox.Show(p.Comentario, "Comentario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                lista.Add(p);
            }

            paciente = lista[0];

            string sexo = "Masculino";
            if (paciente.sexo == "2") { sexo = "Femenino"; }
            
            lbl_ApellidoyNombre.Text = "HC: " + paciente.HC_UOM +  "         Paciente: " + paciente.Paciente + " (" + Edad(Convert.ToDateTime(paciente.fecha_nacimiento)) + ") - Sexo: " + sexo;
            lbl_DNI.Text = paciente.Tipo_Documento + ": " + paciente.Documento_real + "     CUIL: " + paciente.NHC + "       Teléfono: " + paciente.Telefono;
            lbl_Seccional.Text = "Seccional: " + paciente.Seccional;
            lbl_PacienteOculto.Text = paciente.Paciente;
            lbl_DNIAux.Text = paciente.documento.ToString();
            lbl_NHCOculto.Text = paciente.HC_UOM;
            paciente_id.Text = paciente.documento.ToString();
            
            //string edad = (DateTime.Now.Year - Convert.ToDateTime(paciente.fecha_nacimiento).Year).ToString();
            string edad = Edad(Convert.ToDateTime(paciente.fecha_nacimiento));
            //try
            //{
            //    if (Convert.ToInt32(edad) > 105) { edad = ""; }
            //}
            //catch {
            //    edad = "";
            //}

            lbl_edad.Text = edad;
            lbl_sexo.Text = sexo.Substring(0,1).ToUpper();
            

            List<determinaciones> det = new List<determinaciones>();
            DAL.HospitalDataSetTableAdapters.H2_Laboratorio_CargarItemsTableAdapter adapter3 = new DAL.HospitalDataSetTableAdapters.H2_Laboratorio_CargarItemsTableAdapter();
            DAL.HospitalDataSet.H2_Laboratorio_CargarItemsDataTable aTable3 = adapter3.GetData(Convert.ToDecimal(txt_codordenAUX.Text));
            l.Clear();
            Clases.Practicas prac = new Clases.Practicas();
            foreach (DAL.HospitalDataSet.H2_Laboratorio_CargarItemsRow row2 in aTable3.Rows)
            {
                estudios estudio = new estudios();
                if (!row2.IsCodPracticaNull()) estudio.Codigo = row2.CodPractica; else estudio.Codigo = "";
                if (!row2.IsIdPracticaNull()) estudio.Practica = prac.Solo_practicas(row2.IdPractica); else estudio.Practica = "";
                if (!row2.IsDescripcion_SubcodigoNull()) estudio.SubPractica = row2.Descripcion_Subcodigo; else estudio.SubPractica = "";
                if (!row2.IsSubCodPractNull()) estudio.SubCodigo = row2.SubCodPract; else estudio.SubCodigo = "";
                if (!row2.IsObservacionPracticaNull()) estudio.Comentario = row2.ObservacionPractica; else estudio.Comentario = "";
                //if (!row2.IsTipoMuestraNull()) estudio.TipoMuestra = row2.TipoMuestra;


                //Esto es para las Demoras, porque en la base no puedo hacer un join con los null.
                //Solo funciona cuando el protocolo no fue llamado
                if (btn_EliminarOrden.Visible)
                {
                    DAL.HospitalDataSetTableAdapters.H3_Consultar_DemoraTableAdapter adapter_DEMORA = new DAL.HospitalDataSetTableAdapters.H3_Consultar_DemoraTableAdapter();
                    DAL.HospitalDataSet.H3_Consultar_DemoraDataTable aTable_DEMORA = adapter_DEMORA.GetData(estudio.Codigo, estudio.SubCodigo);
                    if (aTable_DEMORA.Count > 0)
                    {
                        estudio.Demora = aTable_DEMORA[0].Demora;
                    }

                }
                l.Add(estudio);
            }

            gv_PracticasListado.AutoGenerateColumns = false;
            gv_PracticasListado.DataSource = "";
            gv_PracticasListado.DataSource = l;
            gv_PracticasListado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
                

        private void CargarTipos()
        {
            this.cbo_TipoOrden.DisplayMember = "Text";
            this.cbo_TipoOrden.ValueMember = "Value";
            List<tipodeorden> tipo = new List<tipodeorden>();
            tipodeorden c = new tipodeorden();
            tipodeorden g = new tipodeorden();
            tipodeorden i = new tipodeorden();
            tipodeorden d = new tipodeorden();
            tipodeorden u = new tipodeorden();

            //VariablesGlobales.MiUsuarioseccional == "010";
                

            //SI ES AVELLANEDA Y ES DE GUARDIA EL USUARIO QUE SOLO VEA GUARDIA
            //if (VariablesGlobales.MiUsuarioseccional == "003" && VariablesGlobales.permisosG.IndexOf("|2|") != -1)
            if (cbo_TipoOrden.SelectedValue == "G" && VariablesGlobales.MiUsuarioseccional == "003")
            {
                g.Text = "Guardia";
                g.Value = "G";
                tipo.Add(g);
            }
            else
            {
                //ESTO ES PARA EL RESTO
                c.Text = "Ambulatorio";
                c.Value = "C";
                tipo.Add(c);

                g.Text = "Guardia";
                g.Value = "G";
                tipo.Add(g);

                i.Text = "Internación";
                i.Value = "I";
                tipo.Add(i);


                //SOLO EN EL CENTRAL TIENEN UTI
                //fue quitado porque la guardia se equivocaba.
                //1.1.20150409
                //if (VariablesGlobales.MiUsuarioseccional == "010")
                //{
                //    u.Text = "U.T.I.";
                //    u.Value = "U";
                //    tipo.Add(u);
                //}



                //UTI - SAN MARTIN
                //1.1.20150601
                if (VariablesGlobales.MiUsuarioseccional == "080")
                {
                    u.Text = "U.T.I.";
                    u.Value = "U";
                    tipo.Add(u);
                }


                if (VariablesGlobales.MiUsuarioseccional == "010" || VariablesGlobales.MiUsuarioseccional == "003" || VariablesGlobales.MiUsuarioseccional == "080")
                {
                    
                    g.Text = "Guardia";
                    g.Value = "G";
                    tipo.Add(g);

                    i.Text = "Internación";
                    i.Value = "I";
                    tipo.Add(i);

                    //if (ConfigurationManager.AppSettings["Derivacion"] == "1")
                    //{
                    if (VariablesGlobales.MiUsuarioseccional == "010")
                    {
                        d.Text = "Derivación";
                        d.Value = "D";
                        tipo.Add(d);
                    }
                    //}

                }


                //GUARDIA - MERLO                
                if (VariablesGlobales.MiUsuarioseccional == "444")
                {
                    g.Text = "Guardia";
                    g.Value = "G";
                    tipo.Add(g);
                }

            }



            cbo_TipoOrden.DataSource = tipo;
                        
    //        this.cbo_TipoOrden.Items.Add(new { Text = "Ambulatorio", Value = "C" });
    //        this.cbo_TipoOrden.Items.Add(new { Text = "Guardia", Value = "G" });
    //        this.cbo_TipoOrden.Items.Add(new { Text = "Internación", Value = "I" });
            //this.cbo_TipoOrden.Items.Add(new { Text = "Derivación", Value = "D" });
        }

        //private void OnFocus(object sender, EventArgs e)
        //{
        //    if (txtCodigo.Text != "")
        //    {
        //        CargarPracticas(txtCodigo.Text, "");
        //    }
        //}

        private void cbo_Practicas_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCodigo.Text = ((determinaciones)cbo_Practicas.SelectedItem).Codigo.Trim();            
            cbo_SubPracticas.DataSource = null;
            cbo_SubPracticas.Items.Clear();
            CargarSubPracticas();
            if (((determinaciones)cbo_Practicas.SelectedItem).Codigo.Trim() != "")
            {
                cbo_SubPracticas.Focus();
            }
            else
            {
                txtCodigo.Focus();
            }
        }


        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (!TeclaEnviada)
                {
                    TeclaEnviada = true;

                    

                    CargarPracticas(txtCodigo.Text, "");
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
        }


        protected override bool IsInputKey(System.Windows.Forms.Keys keyData)
        {
            switch (keyData)
            {
                // Add the list of special keys that you want to handle 
                case Keys.Tab:
                    return true;
                default:
                    return base.IsInputKey(keyData);
            }
        }

        private void cbo_Practicas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (cbo_Practicas.SelectedValue != null)
                {
                    
                    txtCodigo.Text = ((determinaciones)cbo_Practicas.SelectedValue).Codigo.Trim();
                    CargarPracticas(txtCodigo.Text, ((determinaciones)cbo_Practicas.SelectedValue).Practica.Trim());
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }

            }
        }

        
        public void button2_Click(object sender, EventArgs e)
        {
            DesBloquearTodo();
            Editanto = false;            
            txtCodigo.Text = "";
            cbo_Practicas.Text = "";
            cbo_SubPracticas.Text = "";
            txtComentario.Text = "";
            //CargarPracticas("", "");
            btn_QuitarPracticas.Visible = false;

        }

        private void cbo_SubPracticas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                //txtComentario.Focus();
                btn_AgregarPractica.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtComentario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                btn_AgregarPractica.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Modificado = true;
            btn_QuitarPracticas.Visible = false;
            string buscar = gv_PracticasListado[0, gv_PracticasListado.CurrentCell.RowIndex].Value.ToString();
            string buscarSC = gv_PracticasListado[4, gv_PracticasListado.CurrentCell.RowIndex].Value.ToString();
            //l.ForEach(delegate(estudios item) {  });

            foreach (estudios item in l)
            {
                if (item.Codigo == buscar && item.SubCodigo == buscarSC)
                {
                    l.Remove(item);
                    break;
                }

            }

            gv_PracticasListado.DataSource = "";
            gv_PracticasListado.DataSource = l;
            gv_PracticasListado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            button2_Click(null, null);

            calcularFecha();
        }

        public void calcularFecha2()
        {
            int Max = 0;
            foreach (estudios dd in l)
            {
                if (Convert.ToInt32(dd.Demora) > Max)
                {
                    Max = Convert.ToInt32(dd.Demora);
                }
            }

            DateTime FAux = (DateTime.Now).AddDays(Max);
            if ((int)FAux.DayOfWeek == 1)
            {
                //(DateTime.Now).AddDays(Max);
                FAux = FAux.AddDays(1);
            }
            else
            {
                if ((int)FAux.DayOfWeek == 7)
                {
                    //(DateTime.Now).AddDays(Max);
                    FAux = FAux.AddDays(2);
                }
            }

            txt_FEntrega.Value = FAux;

        }

        public void calcularFecha()
        {           

            int Max = 0;
            foreach (estudios dd in l)
            {
                if (dd.Demora == "") { MessageBox.Show("ATENCION LA PRÁCTICA NO TIENE CARGADA EL TIEMPO DE DEMORA"); dd.Demora = "99"; }
                if (Convert.ToInt32(dd.Demora) > Max)
                {
                    Max = Convert.ToInt32(dd.Demora);
                }
            }

            DateTime FAux = (DateTime.Now);
            while (Max > 0)
            {
                //i = i + 1;
                FAux = FAux.AddDays(1);
                bool feriado = false;
                foreach (feriados f in feriados_Lista)
                {
                    if (f.fecha.ToShortDateString() == FAux.ToShortDateString())
                    {
                        feriado = true;
                    }
                }

                if (!feriado)
                {
                    if ((int)FAux.DayOfWeek != 0 && (int)FAux.DayOfWeek != 6)
                    {
                        Max = Max - 1;
                    }
                }
                

            }           

            txt_FEntrega.Value = FAux;

        }

        public bool Ingresado()
        {
            if (lb_NroProtocolo.Text != "")
            {                
                bool estado_ingresado = false;
                protocolos p = new protocolos();
                DAL.HospitalDataSetTableAdapters.QueriesTableAdapter adapter = new DAL.HospitalDataSetTableAdapters.QueriesTableAdapter();
                try
                {
                    if (Convert.ToInt32(adapter.H3_Estado_Orden(lb_NroProtocolo.Text.Replace("Nro. Orden: ", ""))) == 1)
                    {
                        estado_ingresado = true;
                    }
                    else
                    {
                        estado_ingresado = false;
                    }
                    return estado_ingresado;
                }
                catch
                {
                    return false;
                }
                
            }
            else
            {             
                return false;
            }
        }

//---------boton para imprimir----------------------
        private void button3_Click(object sender, EventArgs e)
        {
            minutesIdle = 0;
            if (Falta_Seccional) { MessageBox.Show(" cargar la seccional del paciente", "Falta la seccional", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            
            if (cbo_TipoOrden.SelectedValue == "C") {

                foreach (feriados f in feriados_Lista)
                {
                    if (f.fecha.ToShortDateString() == txt_FEntrega.Text)
                    {
                        DialogResult dr = new System.Windows.Forms.DialogResult();
                        //dr = MessageBox.Show("La fecha de entrega corresponde a un día feriado. ¡Cambie la fecha de entrega!", "Feriado", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        //if (dr == DialogResult.No)
                        //{
                        //    return;
                        //}

                        dr = MessageBox.Show("La fecha de entrega corresponde a un día feriado. ¡Cambie la fecha de entrega, de lo contrario no podrá continuar!", "Feriado", MessageBoxButtons.OK, MessageBoxIcon.Error);                        
                        return;                        
                    }
                }                    
                
            }

            string F1 = string.Format("{0:yyyyMMdd}", fechaDia.Value);
            string FActual = string.Format("{0:yyyyMMdd}", DateTime.Now);

            if (Convert.ToInt32(F1) < Convert.ToInt32(FActual))
            {
                DialogResult dr = new System.Windows.Forms.DialogResult();
                dr = MessageBox.Show("El día de ingreso es menor al de la fecha. ¿Quiere continuar?", "Fecha Inferior a la actual", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.No)
                {
                    return;
                }
            }

            if (Modificado)
            {
                if (Ingresado())
                {
                    MessageBox.Show("La orden ya fué ingresada en el momento que intentó modificar la orden, utilice el Labs4h para editar las prácticas, si desea imprimir etiquetas o comprobante, cargue nuevamente la orden y NO modifique nada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    NuevoPaciente();
                    return;

                }
            }
             
            if (cbo_TipoOrden.SelectedValue == "D")
            {
                if (cbo_SeccionalDerivacion.SelectedValue == null)
                {
                    MessageBox.Show("Verifique la seccional derivante", "Error Seccional Derivante", MessageBoxButtons.OK, MessageBoxIcon.Error );
                    return;
                }                
            }

            uc.cama = "";
            uc.sala = "";
            uc.servicio = "";

            if (cbo_Cama.SelectedValue != null)
            {
                //uc.cama = cbo_Cama.SelectedValue.ToString();
                uc.cama_text = cbo_Cama.Text;
            }

            if (cbo_Sala.SelectedValue != null)
            {
                //uc.sala = cbo_Sala.SelectedValue.ToString();
                uc.sala_text = cbo_Sala.Text;
            }

            if (cbo_Servicio.SelectedValue != null)
            {
                //uc.servicio = cbo_Servicio.SelectedValue.ToString();
                uc.servicio_text = cbo_Servicio.Text;
            }

            uc.obs1 = txt_Observacion.Text;            
            uc.diagnostico1 = cbo_Diagnostico1.Text;
            uc.diagnostico2 = cbo_Diagnostico02.Text;
            uc.fecha_FMU = txt_FUM.Text;
            uc.FMU = ck_FUM.Checked;
            uc.medico_solicitante = cbo_MedicoSolicitante.SelectedIndex;                        
            uc.tipo_orden = cbo_TipoOrden.SelectedValue.ToString();
            try
            {
                uc.ULTIMO_PACIENTE = Convert.ToInt64(paciente_id.Text);
            }
            catch
            {
                uc.ULTIMO_PACIENTE = 0;
            }


            //VERIFICACIONES
            if (lb_NroProtocolo.Text != "")
            {
                string NPro = "";
                NPro = lb_NroProtocolo.Text.Replace("Nro. Orden: ", "").Trim().Substring(0, 3);
                if (NPro == usuarios.seccionalnumero && cbo_TipoOrden.SelectedValue == "D")
                {
                    MessageBox.Show("No se puede seleccionar Tipo de Orden derivación", "Atención");
                    cbo_TipoOrden.Focus();
                    return;
                }
            }

            if (cbo_MedicoSolicitante.Text.Trim() == "..." || cbo_MedicoSolicitante.Text.Trim() == "") { MessageBox.Show("Atención. NO se ha ingresado el médico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            if (lbl_DNIAux.Text == "") { MessageBox.Show("Atención. NO se puede generar un comprobante de Laboratrio sin paciente cargado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (l.Count <= 0) { MessageBox.Show("Atención. NO se puede generar un comprobante de Laboratrio sin prácticas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }



            if (lb_NroProtocolo.Text == "")
            {
                //**************
                //* EMITE BONO *
                //**************
                if (EmiteBono && cbo_TipoOrden.SelectedValue.ToString() != "D" && cbo_TipoOrden.SelectedValue.ToString() != "I")
                {
                    bono_datos.Documento = Convert.ToInt32(lbl_DNIAux.Text);
                    bono_datos.EspecialidadId = 188;
                    bono_datos.MedicoId = 80000436;
                    bono_datos.Usuario = (Int32)VariablesGlobales.MiUsuarioid;
                    bono_datos.TipoOrden = cbo_TipoOrden.SelectedValue.ToString();
                    ib.ShowDialog();//llama a instancia ImprimirBono

                    //verificamos que sea presupuesto (no gurada nada) o generacion de bono (este ultimo guarda en base de datos)
                    if (bono_datos.accion == "Presupuesto")
                    {
                        return;
                    }
                    else if (bono_datos.accion == "Guardar")
                    {
                        GuardarLaboratorio();
                    }

                    /*
                    if (bono_datos.accion == "Guardar")
                    {
                        GuardarLaboratorio();
                    }
                    */

                }
                else
                {
                    //if (bono_datos.accion == "Guardar")
                    //{
                        GuardarLaboratorio();
                    //}
                }

                
            }
            else
            {
                GuardarLaboratorio();
            }
        }

        /*
//setea para poder imprimir presupuesto sin guardar
        private void PrintPresupuesto(object sender, EventArgs e)
        {

            bono_datos.accion = "Presupuesto";
            PrintBono(sender, e, bono_datos.accion);
        }
*/


        public void GuardarLaboratorio()
        {

            //Nro. Orden: 
            if (lb_NroProtocolo.Text != "")
            {
                string NPro = "";
                NPro = lb_NroProtocolo.Text.Replace("Nro. Orden: ", "").Trim().Substring(0,3);
                if (NPro == usuarios.seccionalnumero && cbo_TipoOrden.SelectedValue == "D")
                {
                    MessageBox.Show("No se puede seleccionar Tipo de Orden derivación", "Atención");
                    cbo_TipoOrden.Focus();
                    return;
                }
            }

            if (cbo_MedicoSolicitante.Text.Trim() == "..." || cbo_MedicoSolicitante.Text.Trim() == "") { MessageBox.Show("Atención. NO se ha ingresado el médico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            if (lbl_DNIAux.Text == "") { MessageBox.Show("Atención. NO se puede generar un comprobante de Laboratrio sin paciente cargado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (l.Count <= 0) { MessageBox.Show("Atención. NO se puede generar un comprobante de Laboratrio sin prácticas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            //Int32 Usuario = (Int32)((usuarios)HttpContext.Current.Session["Usuario"]).id;

            object Turno = "";
            DateTime FechadelTurno = DateTime.Now;
            string FUM = "01/01/1900";
            //string Documento = "26395277";
            //string Documento = lbl_DNIAux.Text;
            string Documento = paciente_id.Text;
            string Seccional = usuarios.seccionalnumero.ToString();
            //if (cbo_SeccionalDerivacion.Visible)
            if (cbo_TipoOrden.SelectedValue == "D")
            {
                if (cbo_SeccionalDerivacion.SelectedValue == null)
                {
                    MessageBox.Show("Falta seleccionar la seccional derivante");
                    return;
                }
                Seccional = cbo_SeccionalDerivacion.SelectedValue.ToString();
            }
            

            //string Seccional = "010";
            if (ck_FUM.Checked) FUM = txt_FUM.Value.ToShortDateString();

            Seccional = "000" + Seccional;
            Seccional = Right(Seccional,3);

            //FechaAEntregar = DateTime.Now.ToShortDateString();
            //FechaPrescripcion = DateTime.Now.ToShortDateString();

            string Hora = DateTime.Now.ToString("HH:mm");
            if (Hora.Length == 4) { Hora = "0" + Hora; }
            if (cbo_hora.Checked)
            {
                Hora = horaDia.Text;
            }

            if (cbo_TipoOrden.SelectedValue == "C")
            {
                cbo_Servicio.Text = "";
                cbo_Sala.Text = "";                
                cbo_Cama.Text = "";
            }

            DAL.HospitalDataSetTableAdapters.QueriesTableAdapter adapter = new DAL.HospitalDataSetTableAdapters.QueriesTableAdapter();
            object id;
            if (txt_codordenAUX.Text == "")
            {
                if (cbo_MedicoSolicitante.SelectedValue == null)
                {
                    MessageBox.Show("El médico que ha escrito NO está en lista de medicos, por favor ingreselo nuevamente.");
                    cbo_MedicoSolicitante.Focus();
                    return;
                }
                //id = adapter.H2_Laboratorio_Guardar_Cabecera_Internacion(cbo_TipoOrden.SelectedValue.ToString(), DateTime.Now, Convert.ToDecimal(cbo_MedicoSolicitante.SelectedValue.ToString()), Convert.ToDecimal(cbo_MedicoSolicitante.SelectedValue.ToString()), Convert.ToDateTime("01/01/1900"), Convert.ToDateTime(FUM), cbo_Diagnostico1.SelectedValue.ToString(), cbo_Diagnostico02.SelectedValue.ToString(), txt_Observacion.Text, Convert.ToDateTime(txt_FEntrega.Value), Convert.ToInt32(usuarios.id), cbo_Sala.Text, cbo_Servicio.Text, cbo_Cama.Text, Convert.ToDecimal(Documento), txt_Bono.Text, Seccional);
                id = adapter.H2_Laboratorio_Guardar_Cabecera_Internacion(cbo_TipoOrden.SelectedValue.ToString(), DateTime.Now, Convert.ToDecimal(cbo_MedicoSolicitante.SelectedValue.ToString()), Convert.ToDecimal(cbo_MedicoSolicitante.SelectedValue.ToString()), Convert.ToDateTime("01/01/1900"), Convert.ToDateTime(FUM), cbo_Diagnostico1.Text, cbo_Diagnostico02.Text, txt_Observacion.Text, Convert.ToDateTime(txt_FEntrega.Value), Convert.ToInt32(usuarios.id), cbo_Sala.Text, cbo_Servicio.Text, cbo_Cama.Text, Convert.ToDecimal(Documento), txt_Bono.Text, Seccional, Convert.ToDateTime(fechaDia.Text + " " + Hora), Hora);
                
                //ESTO ES PARA LA NUEVA VERSION
                //id = adapter.H2_Laboratorio_Guardar_Cabecera_Internacion(cbo_TipoOrden.SelectedValue.ToString(), DateTime.Now, Convert.ToDecimal(VariablesGlobales.MiUsuarioseccional), Convert.ToDecimal(cbo_MedicoSolicitante.SelectedValue.ToString()), Convert.ToDateTime("01/01/1900"), Convert.ToDateTime(FUM), cbo_Diagnostico1.Text, cbo_Diagnostico02.Text, txt_Observacion.Text, Convert.ToDateTime(txt_FEntrega.Value), Convert.ToInt32(usuarios.id), cbo_Sala.Text, cbo_Servicio.Text, cbo_Cama.Text, Convert.ToDecimal(Documento), txt_Bono.Text, Seccional, Convert.ToDateTime(fechaDia.Text), Hora);
            }
            else
            {
                //id = adapter.H2_Laboratorio_ModificarCabecera(cbo_TipoOrden.SelectedValue.ToString(), Convert.ToDecimal(cbo_MedicoSolicitante.SelectedValue.ToString()), Convert.ToDecimal(cbo_MedicoSolicitante.SelectedValue.ToString()), Convert.ToDateTime(FUM), cbo_Diagnostico1.Text, cbo_Diagnostico02.Text, txt_Observacion.Text, Convert.ToDateTime(txt_FEntrega.Value), cbo_Sala.Text, cbo_Servicio.Text, cbo_Cama.Text, txt_Bono.Text, txt_codordenAUX.Text);
                id = adapter.H2_Laboratorio_ModificarCabecera(cbo_TipoOrden.SelectedValue.ToString(), Convert.ToDecimal(cbo_MedicoSolicitante.SelectedValue.ToString()), Convert.ToDecimal(cbo_MedicoSolicitante.SelectedValue.ToString()), Convert.ToDateTime(FUM), cbo_Diagnostico1.Text, cbo_Diagnostico02.Text, txt_Observacion.Text, Convert.ToDateTime(txt_FEntrega.Value), cbo_Sala.Text, cbo_Servicio.Text, cbo_Cama.Text, txt_Bono.Text, txt_codordenAUX.Text);
                
                //ESTO ES PARA LA NUEVA VERSION
                //id = adapter.H2_Laboratorio_ModificarCabecera(cbo_TipoOrden.SelectedValue.ToString(), Convert.ToDecimal(VariablesGlobales.MiUsuarioseccional), Convert.ToDecimal(cbo_MedicoSolicitante.SelectedValue.ToString()), Convert.ToDateTime(FUM), cbo_Diagnostico1.Text, cbo_Diagnostico02.Text, txt_Observacion.Text, Convert.ToDateTime(txt_FEntrega.Value), cbo_Sala.Text, cbo_Servicio.Text, cbo_Cama.Text, txt_Bono.Text, txt_codordenAUX.Text);
                id = txt_codordenAUX.Text;

                DAL.HospitalDataSetTableAdapters.QueriesTableAdapter adapter2 = new DAL.HospitalDataSetTableAdapters.QueriesTableAdapter();
               
                //aca veo si es una modifacion ya pasado
                if (tabControl1.Visible)
                {
                    adapter2.H2_Laboratorio_BorrarPracticas(id.ToString());
                }

            }
            if (id != null)
            {

                //Creo una variable de almacenamiento para todas las practicas
                string Practicas_log = "";

                //aca veo si es una modifacion ya pasado
                if (tabControl1.Visible)
                {

                    int i = 0;
                    foreach (estudios p in l)
                    {

                        if (p.Codigo.Trim().Length < 3)
                        {
                            p.Codigo = Right(("000" + p.Codigo), 3);
                        }

                        i++;
                        Practicas_log = Practicas_log + p.Codigo.Trim() + "(" + p.SubCodigo.Trim() + ")" + "|";

                        adapter.H2_Laboratorio_Guardar_Items(Convert.ToInt64(id), i, p.Codigo, p.SubCodigo, p.Comentario, cbo_TipoOrden.SelectedValue.ToString(), usuarios.nombre);                        
                        
                        //26-01-2015
                        //Armar una lista de todos los items y enviarla a un log.                        
                    }
                }

                DAL.HospitalDataSetTableAdapters.QueriesTableAdapter adapter2 = new DAL.HospitalDataSetTableAdapters.QueriesTableAdapter();
                object NroProtocolo = adapter2.H2_Laboratorio_ObtenerNroProtocolo(Convert.ToInt32(id));

                DAL.LaboratorioDataSetTableAdapters.QueriesTableAdapter adapter_labo = new DAL.LaboratorioDataSetTableAdapters.QueriesTableAdapter();

                var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                var stringChars = new char[8];
                var random = new Random();
                
                for (int i = 0; i < stringChars.Length; i++)
                {
                    stringChars[i] = chars[random.Next(chars.Length)];
                }
                
                //var finalString = "L" + new String(stringChars);
                //lbl_codigoseguridad.Text = finalString;
                var finalString = new String(stringChars);
                lbl_codigoseguridad.Text = finalString;
                object clave = adapter_labo.H2_Laboratorio_CrearClave(NroProtocolo.ToString(), finalString);
                if (clave != null)
                {
                    lbl_codigoseguridad.Text = clave.ToString();
                }
             

                //26-01-2015
                //Actualizo la lista de las practicas
                adapter_labo.H3_Practicas_log(DateTime.Now, NroProtocolo.ToString(), Practicas_log.Trim(), usuarios.nombre);

                lbl_CodigoBarra.Text = "*" + NroProtocolo.ToString().Trim() + "*";
                
                //ImprimirComprobante();

                if (cb_Comprobante.Checked)
                {
                    Impresion_Comprobante f = new Impresion_Comprobante(this);
                    f.Show();
                }

                
                //using (Impresion childform = new Impresion())
                //{
                //    childform.ShowDialog(this);
                //}

                //CrearResumen();

                Impresion childform = new Impresion(this);
                //Impresion_Automatica childform = new Impresion_Automatica(this);
                childform.ShowDialog();



                NuevoPaciente();


            }
        }

        private void NuevoPaciente()
        {
            //verifico la version, antes de continuar
            Falta_Seccional = false;
            Verificar_Version();
            btn_cambiar_cama.Visible = false;
            Modificado = false;
            Agregado = false;
            l.Clear();
            lbl_ApellidoyNombre.Text = "Paciente: ";
            lbl_DNI.Text = "DNI: ";
            lbl_Seccional.Text = "SECCIONAL: ";
            lbl_PacienteOculto.Text = "";
            lbl_NHCOculto.Text = "";
            lbl_edad.Text = "";
            lbl_sexo.Text = "";
            lbl_CodigoBarra.Text = "";
            txt_Bono.Text = "";
            img_Error.Visible = false;
            img_Ok.Visible = false;
            lbl_msgBono.Visible = false;
            paciente_id.Text = "";
            //cbo_Diagnostico1.SelectedValue = "ZA1";
            //cbo_Diagnostico02.SelectedValue = "ZA1";
            cbo_Diagnostico1.Text = "";
            cbo_Diagnostico02.Text = "";
            
            txt_Observacion.Text = "";
            lbl_DNIAux.Text = "";
            button2_Click(null, null);
            img_Paciente.Image = null;
            gv_PracticasListado.DataSource = null;
            txt_codordenAUX.Text = "";
            btn_EliminarOrden.Visible = false;

            lk_cambiar_fecha_entrega.Visible = false;
            
            if (cbo_TipoOrden.SelectedValue != "D")
            {
                CargarSeccionales(true);
                fechaDia.Text = DateTime.Now.ToShortDateString();
                horaDia.Text = DateTime.Now.ToString("HH:mm");
                //cbo_MedicoSolicitante.SelectedIndex = 0;
                cbo_MedicoSolicitante.SelectedIndex = -1;
                cbo_MedicoSolicitante.Text = "...";
                cbo_hora.Checked = false;
                if (Recargar_Medicos == true)
                {
                    Recargar_Medicos = false;
                    CargarMedicos(0);
                }
            }
            else {
                if (cbo_SeccionalDerivacion.SelectedValue != null)
                {
                    string derActual = cbo_SeccionalDerivacion.SelectedValue.ToString();
                    CargarSeccionales(true);
                    cbo_hora.Checked = true;
                    cbo_SeccionalDerivacion.SelectedValue = derActual;
                }
            }

            if (horaDia.Text.Length == 4) { horaDia.Text = "0" + horaDia.Text; }
            cbo_Servicio.SelectedIndex = 0;
            cbo_Sala.Text = "";
            cbo_Cama.Text = "";
            lb_NroProtocolo.Text = "";
            tabControl1.Visible = true;
            gb_datos_ingreso.Enabled = true;

            ck_FUM.Checked = false;

            
            cbo_hora.Enabled = true;
            fechaDia.Enabled = true;
            horaDia.Enabled = true;
            cbo_SeccionalDerivacion.Enabled = true;            
            cbo_TipoOrden.Enabled = true;

            txt_CopiasComprobante.Text = "2";

            if (VariablesGlobales.MiUsuarioseccional == "080")
            {
                txt_CopiasComprobante.Text = "1";    
            }

        }

        public string Edad_solo_anios(DateTime FNaci)
        {
            //double edad = DateTime.Now.Subtract(FNaci).TotalDays / 365.25;
            double edad = (DateTime.Now.Year - FNaci.Year); 
            if (DateTime.Now.Month < FNaci.Month || (DateTime.Now.Month == FNaci.Month && DateTime.Now.Day < FNaci.Day))
            {
                edad--;
            }
            if (edad < 0) { edad = 0; }
            return edad.ToString();
        }

        public string Edad(DateTime nacimiento)
        {
            if (nacimiento.Year == 1 && nacimiento.Month == 1) { return ""; }
            
            // Crear fechas                   
            DateTime hoy = DateTime.Now;

            // Años
            int edadAnos = hoy.Year - nacimiento.Year;
            if (hoy.Month < nacimiento.Month || (hoy.Month == nacimiento.Month &&
            hoy.Day < nacimiento.Day))
                edadAnos--;

            // Meses
            int edadMeses = hoy.Month - nacimiento.Month;
            if (hoy.Day < nacimiento.Day)
                edadMeses--;
            if (edadMeses < 0)
                edadMeses += 12;

            // Mostrar
            return edadAnos + " años " + edadMeses + " meses";
        }
        
        public string Right(string param, int length)
        {

            int value = param.Length - length;
            string result = param.Substring(value, length);
            return result;
        }

        public void GuardarPracticas()
        {

            //string FUM = "01/01/1900";
            //if (ck_FUM.Checked) FUM = txt_FUM.Value.ToShortDateString();

            //HospitalDataSetTableAdapters.QueriesTableAdapter adapter = new HospitalDataSetTableAdapters.QueriesTableAdapter();
            //object id = adapter.H2_Laboratorio_Guardar_Cabecera(TipoOrden, Convert.ToDateTime(FechaAEntregar), MedicoId, MedicoId, Convert.ToDateTime(FechaPrescripcion), Convert.ToDateTime(FUM), Diagnostico1, Diagnostico2, ObservacionesGral, Convert.ToDateTime(FechaAEntregar), Usuario, NroBono);
            ////if (id != null)
            //{
            //    Hospital.BonosBLL B = new BonosBLL();
            //    //B.bono_UsarBono_PorId(NroBono, Usuario);
            //    int i = 0;
            //    foreach (laboratoriopracticas p in Practicas)
            //    {
            //        i++;
            //        if (p.Estado != 0)
            //        {
            //            adapter.H2_Laboratorio_Guardar_Items(Convert.ToInt64(id), i, p.PracticaId.ToString(), p.SubPracticaCodigo.ToString(), p.Comentario, "", Usuario.ToString());
            //        }
            //    }
            //}

        }

        private void cbo_Servicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            Carga_Camas(-1);
            cbo_Sala.Text = "";
            CargarSala(((servicios)(cbo_Servicio.SelectedItem)).id);
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

            cbo_Sala.DataSource = lista;
        }

        private void cbo_Sala_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbo_Cama.Text = "";
            Carga_Camas(((servicios)(cbo_Sala.SelectedItem)).id);
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

            cbo_Cama.DataSource = lista;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Impresion_Comprobante f = new Impresion_Comprobante(this);
            f.Show();
            //ImprimirComprobante();

            //using (Impresion childform = new Impresion())
            //{
            //    childform.ShowDialog(this);
            //}
        }

        private void ImprimirComprobante()
        {
            //string ImpresoraComprobante = ConfigurationManager.AppSettings["ImpresoraComprobante"];
           

            printFont = new Font("Arial", 10);
            printFont2 = new Font("IDAutomationHC39M", 12);
            printFontNegrita = new Font("Arial", 15,FontStyle.Bold);
            PrintDocument pd = new PrintDocument();
            //pd.DefaultPageSettings.PrinterSettings.PrinterName = ImpresoraComprobante;
            pd.DefaultPageSettings.PrinterSettings.Copies = 1;
            pd.PrintPage += new PrintPageEventHandler
               (this.pd_PrintPage);
            posiPrac = 0;
            posiIndi = 0;

            pd.DefaultPageSettings.PaperSize = new PaperSize("A5", 800, 1000);

            Margins margins = new Margins(0, 0, 0, 0);
            pd.DefaultPageSettings.Margins = margins;

            pd.Print();
        }



        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            string Seccional = usuarios.seccionalnumero.ToString();
            float linesPerPage = 0;
            float yPos = 0;
            int count = 0;
            float leftMargin = 0; //ev.MarginBounds.Left;
            float topMargin = ev.MarginBounds.Top;
            string line = null;

            linesPerPage = ev.MarginBounds.Height / printFont.GetHeight(ev.Graphics);

            StringFormat sf = new StringFormat();




            line = lbl_PacienteOculto.Text;
            if (line.Length > 18)
            {
                line = line.Substring(0, 17);
            }


            Rectangle recTitulo = new Rectangle(0, 0, 800, 20);
            Rectangle rectFecha = new Rectangle(0, 105, 800, 20);
            Rectangle rectOSUOMRA = new Rectangle(0, 30, 800, 20);
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            //       LABORATORIO
            //
            // Fecha: 99/99/999 99:99:99
            // NRO: *9990000000*
            // PACIENTE
            // SECCIONAL: SECCIONAL
            // 
            // Descripción de los Ánalisis
            // NUM - ANALISIS (DET)
            // NUM - ANALISIS (DET)
            // NUM - ANALISIS (DET)
            // NUM - ANALISIS (DET)
            // NUM - ANALISIS (DET)
            // NUM - ANALISIS (DET)
            //
            // COMENTARIO




            //IMPRIMIR TITULO            
            line = "POLICLINICO CENTRAL - OSUOMRA";
            ev.Graphics.DrawString(line, printFont, Brushes.Black, recTitulo, stringFormat);
            ev.Graphics.DrawRectangle(Pens.Transparent, recTitulo);

            line = "LABORATORIO";
            ev.Graphics.DrawString(line, printFont, Brushes.Black, rectOSUOMRA, stringFormat);
            ev.Graphics.DrawRectangle(Pens.Transparent, rectOSUOMRA);            

            //line = lbl_CodigoBarra.Text;
            count = 3;
            line = "FECHA: " + DateTime.Now.ToString();
            yPos = topMargin + (count * printFont.GetHeight(ev.Graphics));
            ev.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, yPos + 20, sf);
            count++;            
            line = "NRO: " + lbl_CodigoBarra.Text.Substring(0, 4) + "-" + lbl_CodigoBarra.Text.Substring(4, 8);
            yPos = topMargin + (count * printFont.GetHeight(ev.Graphics));
            ev.Graphics.DrawString(line, printFontNegrita, Brushes.Black, leftMargin, yPos + 20, sf);
            count++;
            count = count + 1;
            line = lbl_PacienteOculto.Text.ToUpper();
            yPos = topMargin + (count * printFont.GetHeight(ev.Graphics));
            ev.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, yPos + 20, sf);
            count++;

            line = lbl_Seccional.Text.ToUpper();
            yPos = topMargin + (count * printFont.GetHeight(ev.Graphics));
            ev.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, yPos + 20, sf);
            count++;
            count++;

            int TotalPracticas = 0;
            int TotalIndicaciones = 0;
            //if (count < 29)
            //{
                line = "Descripción de los Ánalisis";
                yPos = topMargin + (count * printFont.GetHeight(ev.Graphics));
                ev.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, yPos + 20, sf);
                count++;
                int i = posiPrac;
                int j = posiIndi;
                while (count <= 60 && i <= (l.Count - 1))
                {                    
                    
                    ev.HasMorePages = true;
                    TotalPracticas++;
                    if (l[i].Codigo.Trim().Length < 3)
                    {
                        l[i].Codigo = Right(("000" + l[i].Codigo), 3);
                    }

                    line = l[i].Codigo + " - " + l[i].Practica + "(" + l[i].SubPractica + ")";
                    yPos = topMargin + (count * printFont.GetHeight(ev.Graphics));
                    ev.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, yPos + 20, sf);
                    count++; 
                    i++;

                }




                posiPrac = i;
                posiIndi = j;

                if (count >= 60)
                {
                    ev.HasMorePages = true;

                }
                else
                {
                    ev.HasMorePages = false;

                    count++;
                    count++;
                    line = "COMENTARIO: " + txt_Observacion.Text.ToUpper();
                    yPos = topMargin + (count * printFont.GetHeight(ev.Graphics));
                    ev.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, yPos + 20, sf);
                    count++;

                    line = "TOTAL PRACTICAS: " + l.Count;
                    yPos = topMargin + (count * printFont.GetHeight(ev.Graphics));
                    ev.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, yPos + 20, sf);
                    count++;

                    line = "F. ENTREGA: " + txt_FEntrega.Text;
                    yPos = topMargin + (count * printFont.GetHeight(ev.Graphics));
                    ev.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, yPos + 20, sf);
                    count++;


                    //while (count <= 60 && j <= (ls_Indicaciones.Items.Count - 1))
                    while (j <= (ls_Indicaciones.Items.Count - 1))
                    {
                        line = ls_Indicaciones.Items[TotalIndicaciones].ToString();
                        TotalIndicaciones++;
                        yPos = topMargin + (count * printFont.GetHeight(ev.Graphics));
                        ev.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, yPos + 20, sf);
                        count++;
                        j++;

                    }


                }

        }
        
               

        private void button2_Click_1(object sender, EventArgs e)
        {
            minutesIdle = 0;
            NuevoPaciente();
            using (ListarPacientes childform = new ListarPacientes())
            {
                childform.ShowDialog(this);
            }
        }



        private void Form1_Resize(object sender, EventArgs e)
        {
            panel1.Location = new Point(this.ClientSize.Width / 2 - panel1.Size.Width / 2, this.ClientSize.Height / 2 - panel1.Size.Height / 2);
            panel1.Anchor = AnchorStyles.None;
        }

        private void txt_Bono_KeyDown(object sender, KeyEventArgs e)
        {
            //ACA DEBERIA REVISAR SI EL BONO ESTA O NO USADO
            //if (e.KeyValue == 13)
            //{
            //    bool verificar = false;
            //    if (verificar)
            //    {
            //        img_Ok.Visible = true;
            //    }
            //    else
            //    {
            //        img_Error.Visible = true;
            //        lbl_msgBono.Visible = true;
            //    }
            //    e.Handled = true;
            //    e.SuppressKeyPress = true;
            //}
        }

        public void button4_Click(object sender, EventArgs e)
        {
            minutesIdle = 0;
            //Verifico si puedo seguir usando esta versión

            if (cbo_TipoOrden.SelectedValue != "D")
            {
                fechaDia.Text = DateTime.Now.ToShortDateString();
                horaDia.Text = DateTime.Now.ToString("HH:mm");
                if (horaDia.Text.Length == 4) { horaDia.Text = "0" + horaDia.Text; }             
            }
            NuevoPaciente();


        }

        private void Verificar_Version()
        {
            try
            {
                DAL.LaboratorioDataSetTableAdapters.QueriesTableAdapter adapter = new DAL.LaboratorioDataSetTableAdapters.QueriesTableAdapter();
                object ver = adapter.H2_Laboratorio_Version(Global.Version);
                if (ver == null)
                {
                    MessageBox.Show("La versión del programa que está utiliando ya NO es soportada, por favor vuelva a ejecutar el programa", "Error en la versión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message + " , ¡No se pudo verificar la versión!", "Error al conectarse al servidor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            minutesIdle = 0;
            //NuevoAfiliado na = new NuevoAfiliado();
            //na.Show();

            using (NuevoAfiliado childform = new NuevoAfiliado())
            {
                childform.ShowDialog(this);
            }
        }

        private void lbl_ApellidoyNombre_Click(object sender, EventArgs e)
        {
            if (lbl_DNIAux.Text != "")
            {
                //NuevoAfiliado na = new NuevoAfiliado(lbl_DNIAux.Text);
                //na.Show();
                using (NuevoAfiliado childform = new NuevoAfiliado(paciente_id.Text))
                {
                    childform.ShowDialog(this);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            minutesIdle = 0; 
            BuscarOrdenes bo = new BuscarOrdenes(this);
            bo.ShowDialog();
        }

        private void btn_EliminarOrden_Click(object sender, EventArgs e)
        {
            minutesIdle = 0;
            DialogResult Resultado = MessageBox.Show("¿Desea Eliminar de forma definitiva el protocolo?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Resultado == DialogResult.Yes)
            {
                DAL.HospitalDataSetTableAdapters.QueriesTableAdapter adapter2 = new DAL.HospitalDataSetTableAdapters.QueriesTableAdapter();
                adapter2.H2_Laboratorio_EliminarProtocolo(Convert.ToInt64(txt_codordenAUX.Text));                               

                adapter2.H3_Borrar_Log(lb_NroProtocolo.Text.Replace("Nro. Orden: ", "").Trim(), Convert.ToInt32(VariablesGlobales.MiUsuarioid));
                NuevoPaciente();
            }

        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1 || tabControl1.SelectedIndex == 3)
            {
                ls_Indicaciones.Visible = true;
                gv_PracticasListado.Visible = false;
            }
            else
            {
                ls_Indicaciones.Visible = false;
                gv_PracticasListado.Visible = true;
            }

        }

        private void btn_agregarIndicaciones_Click(object sender, EventArgs e)
        {
            ls_Indicaciones.Items.Add(cbo_Inidicaciones.SelectedValue + " - " + cbo_Inidicaciones.Text);
        }

        private void ls_Indicaciones_Click(object sender, EventArgs e)
        {
            if (ls_Indicaciones.SelectedIndex > -1)
            {
                btn_agregarIndicaciones.Visible = false;
                EditandoIndicaciones = true;
                txt_CodIndicaciones.Enabled = false;
                cbo_Inidicaciones.Enabled = false;
                ls_Indicaciones.Enabled = false;
                CualEditandoIndicaciones = ls_Indicaciones.SelectedIndex;
                btn_quitarInidicaciones.Visible = true;
            }
        }

        private void ls_Indicaciones_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_quitarInidicaciones_Click(object sender, EventArgs e)
        {
           
            ls_Indicaciones.Items.RemoveAt(ls_Indicaciones.SelectedIndex);
            btn_cancelarInidicaciones_Click(null, null);

        }

        private void btn_cancelarInidicaciones_Click(object sender, EventArgs e)
        {
            btn_agregarIndicaciones.Visible = true;
            txt_CodIndicaciones.Enabled = true;
            cbo_Inidicaciones.Enabled = true;
            ls_Indicaciones.Enabled = true;
            btn_quitarInidicaciones.Visible = false;
        }

        private void btn_CancelarPractica_Click(object sender, EventArgs e)
        {
            Editanto = false;
            txtCodigo.Enabled = true;
            cbo_Practicas.Enabled = true;
            cbo_SubPracticas.Enabled = true;
            btn_QuitarPracticas.Visible = false;
            LimpiarCampos();
            LimpiarCampos();
        }

        private void txt_CodIndicaciones_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                CargarIndicacioness(txt_CodIndicaciones.Text);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void CargarIndicacioness(string CodInd)
        {

            //if (CodInd != null && CodInd != "")
            //{

            int pos = 0;
            bool Enc = false;
            foreach (indicaciones Indi in cbo_Inidicaciones.Items)
            {                
                if (Indi.Codigo == CodInd)
                {
                    Enc = true;
                    cbo_Inidicaciones.SelectedIndex = pos;                    
                }
                pos++;
            }

            if (Enc)
            {
                btn_agregarIndicaciones_Click(null, null);
            }
            
            //}
        }

        private void txt_Perfil_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                CargarPerfil();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txt_Perfil_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbo_Perfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_Perfil.Text = cbo_Perfiles.SelectedValue.ToString();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            Modificado = true;
            CargarPerfil();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Perfiles p = new Perfiles();
            p.ShowDialog();
            Listar();

        }


        private void gv_PracticasListado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                GridClic();
            }
        }

        private void cbo_Practicas_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //txtCodigo.Text = ((determinaciones)cbo_Practicas.SelectedValue).Codigo.Trim();
            //CargarPracticas(txtCodigo.Text, "");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //btn_ImprimirIndicaciones
            ImpresionIndicaciones f = new ImpresionIndicaciones(this);
            f.Show();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            bool pulsado = false;
        
            //F10
        if (e.KeyValue == 121)
        {
        //Form3 f3 = new Form3(this);
        Cambiar_Clave f3 = new Cambiar_Clave();
        f3.ShowDialog();
        e.Handled = true;
        e.SuppressKeyPress = true;
        return;
        }

        //F7 IMPRESORA
        if (e.KeyCode == Keys.F7)
        {
            //Form3 f3 = new Form3(this);
            ListaImpresoras f3 = new ListaImpresoras();
            f3.ShowDialog();
            e.Handled = true;
            e.SuppressKeyPress = true;
            return;
        }

        //F5 REFRESCO
        if (e.KeyCode == Keys.F5)
        {
            CargarIndicaciones();
            Listar();
            FeriadosLista();
            CargarSeccionales(true);
            CargarAbreviaturas();
            CargarServicios();
            e.Handled = true;
            e.SuppressKeyPress = true;
            return;
        }


        //Shift + F3
        if (e.Modifiers == Keys.Shift && e.KeyValue == 114)
        {

            NuevoPaciente();
            if (uc.ULTIMO_PACIENTE != 0)
            {
                using (ListarPacientes childform = new ListarPacientes(uc.ULTIMO_PACIENTE) { Owner = this })
                {
                    childform.ShowDialog(this);
                }

                //if (uc.servicio != null && uc.servicio != "-1")
                //{
                //    cbo_Servicio.SelectedValue = uc.servicio;
                //    CargarSala(((servicios)(cbo_Servicio.SelectedItem)).id);
                //    if (uc.sala != null)
                //    {
                //        cbo_Sala.SelectedValue = uc.sala;
                //        Carga_Camas(((servicios)(cbo_Sala.SelectedItem)).id);
                //        if (uc.cama != null)
                //        {
                //            cbo_Cama.SelectedValue = uc.cama;
                //        }
                //    }
                //}

                cbo_Servicio.Text = uc.servicio_text;
                cbo_Sala.Text = uc.sala_text;
                cbo_Cama.Text = uc.cama_text;

                cbo_Diagnostico1.Text = uc.diagnostico1;
                cbo_Diagnostico02.Text = uc.diagnostico2;
                txt_FUM.Text = uc.fecha_FMU;
                ck_FUM.Checked = uc.FMU;
                cbo_MedicoSolicitante.SelectedIndex = uc.medico_solicitante;
                txt_Observacion.Text = uc.obs1;
                cbo_TipoOrden.SelectedValue = uc.tipo_orden;

            }
            else
            {
                MessageBox.Show("En esta maquina no hubo un pacientes cargado anteriormente", "No se puede recargar el último paciente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            cbo_TipoOrden.Focus();
            e.Handled = true;
            e.SuppressKeyPress = true;
            return;
        }


            //F3
            if (e.KeyValue == 114)
            {
                button2_Click_1(null, null);
                cbo_TipoOrden.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
                return;
            }


            


            //F4
            if (e.KeyValue == 115)
            {
                button3_Click(null, null);
                cbo_TipoOrden.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
                return;
            }

            //F9
            if (e.KeyCode == Keys.F9)
            {


                try
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.FileName = "Impresion_Protocolos_Avellaneda.exe";
                    Process.Start(startInfo);
                }
                catch {
                    MessageBox.Show("No posee el módulo instalado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }    

                e.Handled = true;
                e.SuppressKeyPress = true;
                return;
            }

            //if (e.KeyValue == 112)
            //{
            //    //F1
            //    //Form3 f3 = new Form3(this);
            //    if (ConfigurationManager.AppSettings["RutaAyuda"] != null)
            //    {
            //        System.Diagnostics.Process.Start("http://" + ConfigurationManager.AppSettings["RutaAyuda"] + "/AyudaLaboratorio/AyudaLaboratorio.htm");
            //    }
            //    else
            //    {
            //        System.Diagnostics.Process.Start("http://10.10.8.71/AyudaLaboratorio/AyudaLaboratorio.htm");
            //    }
            //    e.Handled = true;
            //    e.SuppressKeyPress = true;
            //    return;
            //}

            

            if (e.Modifiers == Keys.Shift && e.KeyValue == 122 && !pulsado)
            {
                //Shift + F11
                //if (usuarios.nombre.ToUpper() == "ANZOVINI PAULA" || usuarios.nombre.ToUpper() == "SISTEMAS")
                if (usuarios.nombre.ToUpper() == "SISTEMAS")
                {
                    pulsado = true;
                    Assembly assembly;
                    assembly = Assembly.GetExecutingAssembly();
                    //(new SoundPlayer(@"c:\Laboratorio\quack.wav")).Play();
                    (new SoundPlayer(assembly.GetManifestResourceStream("Laboratorio2.4.wav"))).Play();
                }
                return;
            }

            if (e.Modifiers == Keys.Shift && e.KeyValue == 123 && !pulsado)
            {
                //Shift + F12
                //if (usuarios.nombre.ToUpper() == "ANZOVINI PAULA" || usuarios.nombre.ToUpper() == "SISTEMAS")
                if (usuarios.nombre.ToUpper() == "SISTEMAS")
                {
                    pulsado = true;
                    Assembly assembly;
                    assembly = Assembly.GetExecutingAssembly();
                    //(new SoundPlayer(@"c:\Laboratorio\quack.wav")).Play();
                    (new SoundPlayer(assembly.GetManifestResourceStream("Laboratorio2.3.wav"))).Play();
                }
                return;
            }

            if (e.KeyValue == 122 && !pulsado)
            {
                //F11
                //if (usuarios.nombre.ToUpper() == "ANZOVINI PAULA" || usuarios.nombre.ToUpper() == "SISTEMAS")
                if (usuarios.nombre.ToUpper() == "SISTEMAS")
                {
                    pulsado = true;
                    Assembly assembly;
                    assembly = Assembly.GetExecutingAssembly();
                    //(new SoundPlayer(@"c:\Laboratorio\quack.wav")).Play();
                    (new SoundPlayer(assembly.GetManifestResourceStream("Laboratorio2.1.wav"))).Play();
                }
                return;
            }

            if (e.KeyValue == 123 && !pulsado)
            {
                //F12
                //if (usuarios.nombre.ToUpper() == "ANZOVINI PAULA" || usuarios.nombre.ToUpper() == "SISTEMAS")
                if (usuarios.nombre.ToUpper() == "SISTEMAS")
                {
                    pulsado = true;
                    Assembly assembly;
                    assembly = Assembly.GetExecutingAssembly();
                    //(new SoundPlayer(@"c:\Laboratorio\quack.wav")).Play();
                    (new SoundPlayer(assembly.GetManifestResourceStream("Laboratorio2.2.wav"))).Play();
                }
                return;
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            //ABM Medicos
            Medicos f = new Medicos();
            f.ShowDialog();
            CargarMedicos(0);
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            EdicionIndicaciones f = new EdicionIndicaciones();
            f.ShowDialog();
            CargarIndicaciones();
        }

        private void cbo_Practicas_DropDown(object sender, EventArgs e)
        {
            cbo_Practicas.AutoCompleteMode = AutoCompleteMode.SuggestAppend;            
        }

        //private void cbo_SubPracticas_DropDown(object sender, EventArgs e)
        //{
        //    cbo_SubPracticas.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    
        //}

        private void cbo_MedicoSolicitante_DropDown(object sender, EventArgs e)
        {
            cbo_MedicoSolicitante.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    
        }

        private void cbo_TipoOrden_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbo_TipoOrden.SelectedValue == "G" && VariablesGlobales.MiUsuarioseccional == "003")
            {
                l.Clear();
                gv_PracticasListado.DataSource = null;
                CargarTodaslasPracticas_Guardia();
            }
            else
            {
                CargarTodaslasPracticas();
            }
            
            if (cbo_TipoOrden.SelectedValue == "D")
            {                
                cbo_SeccionalDerivacion.Visible = true;
                label22.Visible = true;
                cbo_hora.Checked = true;
                lb_Obs.Text = "Nro. Externo:";
            }
            else
            {
                cbo_SeccionalDerivacion.Visible = false;
                label22.Visible = false;
                cbo_hora.Checked = false;
                lb_Obs.Text = "Observación:";
            }

            if (cbo_TipoOrden.SelectedValue == "C")
            {
                cbo_Cama.Visible = false;
                cbo_Sala.Visible = false;
                cbo_Servicio.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
            }
            else
            {
                cbo_Cama.Visible = true;
                cbo_Sala.Visible = true;
                cbo_Servicio.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;

            }
        }

        public void CargarSeccionales(bool Nuevo)
        {
            
            seccionalesListas list = new seccionalesListas();
            DAL.HospitalDataSetTableAdapters.H2_Seccional_Lista_derivacionesTableAdapter adapter = new DAL.HospitalDataSetTableAdapters.H2_Seccional_Lista_derivacionesTableAdapter();
            DAL.HospitalDataSet.H2_Seccional_Lista_derivacionesDataTable aTable = adapter.GetData(null, Nuevo);
            foreach (DAL.HospitalDataSet.H2_Seccional_Lista_derivacionesRow row in aTable.Rows)
            {
                seccionales s = new seccionales();
                if (!row.IsIdNull()) s.Nro = row.Id;
                if (!row.IsDescripcionNull()) s.Seccional = row.Descripcion;
                list.Add(s);
            }
            cbo_SeccionalDerivacion.DataSource = list;
            cbo_SeccionalDerivacion.DisplayMember = "Seccional";
            cbo_SeccionalDerivacion.ValueMember = "Nro";
        }

        private void horaDia_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start("http://" + ConfigurationManager.AppSettings["RutaAyuda"] + "/AyudaLaboratorio/AyudaLaboratorio.htm");
            if (ConfigurationManager.AppSettings["RutaAyuda"] != null)
            {
                System.Diagnostics.Process.Start("http://" + ConfigurationManager.AppSettings["RutaAyuda"] + "/AyudaLaboratorio/AyudaLaboratorio.htm");
            }
            else
            {
                System.Diagnostics.Process.Start("http://10.10.8.71/AyudaLaboratorio/AyudaLaboratorio.htm");
            }
        }

        private void btn_prioridad_Click(object sender, EventArgs e)
        {
            if (Prioridad) { Prioridad = false; btn_prioridad.BackColor = Color.White; } else { Prioridad = true; btn_prioridad.BackColor = Color.ForestGreen; }
        }

        private void btn_usuarios_Click(object sender, EventArgs e)
        {
            UsuariosABM f = new UsuariosABM();
            f.ShowDialog();
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            ABMPracticas fep = new ABMPracticas();
            fep.ShowDialog();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(cbo_Servicio.Text);
            MessageBox.Show("Servicio guardado en el portapapeles");
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(cbo_Sala.Text);
            MessageBox.Show("Sala guardada en el portapapeles");
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(cbo_Cama.Text);
            MessageBox.Show("Cama guardada en el portapapeles");
        }

        private void btn_cambiar_cama_Click(object sender, EventArgs e)
        {
            Cambio_SSC cssc = new Cambio_SSC(this);
            cssc.ShowDialog();
        }

   


        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //CON ESTO CAMBIO LA FECHA DE ENTREGA....
            string value = txt_FEntrega.Text;
            if (InputBox("New document", "New document name:", ref value) == DialogResult.OK)
            {
                DateTime temp;
                if (DateTime.TryParse(value, out temp))
                {
                    txt_FEntrega.Text = value;
                    //Cambiar Fecha
                    DAL.HospitalDataSetTableAdapters.QueriesTableAdapter adapter = new DAL.HospitalDataSetTableAdapters.QueriesTableAdapter();
                    adapter.H3_Actualizar_Fecha_Entrega(Convert.ToDateTime(value), lb_NroProtocolo.Text.Replace("Nro. Orden: ", ""));
                }
                else
                {
                    MessageBox.Show("Error fecha no válida", "Verifique la fecha", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }

        private void lb_NroProtocolo_DoubleClick(object sender, EventArgs e)
        {
            Clipboard.SetText(lb_NroProtocolo.Text.Replace("Nro. Orden: ",""));
            MessageBox.Show("Nro de protocolo guardado en el portapapeles");

        }

        private void btnImpPresupuesto_Click(object sender, EventArgs e)
        {
            bono_datos.accion = "Presupuesto";
            button3_Click(sender, e);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void gb_datos_ingreso_Enter(object sender, EventArgs e)
        {

        }

    }
}
