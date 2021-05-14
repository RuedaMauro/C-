using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Drawing.Printing;
using Laboratorio2.Entities;
using Laboratorio2.Clases;

namespace Laboratorio2
{
    public partial class Impresion_Automatica : Form
    {
        private Font printFont;
        private Font printFont2;
        private Font printFont3;
        public short Copias = 1;
        private int Pract_nro = 0;
        Principal parent;
        private List<etiquetas_laboratorio> lista = new List<etiquetas_laboratorio>();
        private List<etiquetas_laboratorio> lista_impresion = new List<etiquetas_laboratorio>();

        public Impresion_Automatica(Principal f)
        {
            parent = f;
            InitializeComponent();
        }

        public Impresion_Automatica()
        {
            InitializeComponent();
        }

        private void Impresion_Automatica_Load(object sender, EventArgs e)
        {
            //Form1 parent = (Form1)this.Owner;

            //Deberia crear una tabla que relacione Nro de practica y subpractica, con un una lista de cantidad de tubos necesarios, 
            //Como del tipo de tubo, si este tubo o tubos se pueden mezclar o si son tubos separados, ejemplo

            //Hemograma 1 tubo EDTA (Se puede juntar)
            //Electroforesis de hg 4 tubos EDTA (No se pueden juntar)
            //Hematocrito 1 tubo EDTA (Se puede juntar)
            //Glucosa 1 tubo suero (Se puede juntar)
            //Glocusa Curva 4 tubos (El primero se puede juntar pero los otros 3 NO)


            pacientes paciente = new pacientes();

            lbl_PacienteOculto.Text = parent.lbl_PacienteOculto.Text;
            lbl_Numero.Text = parent.lbl_CodigoBarra.Text;
            lbl_cama.Text = parent.cbo_Cama.Text;
            lbl_edad.Text = parent.lbl_edad.Text;
            lbl_resumen.Text = parent.lbl_resumen.Text;
            if (parent.txt_Observacion.Text.Length > 8)
            {
                lbl_observaciones.Text = parent.txt_Observacion.Text.Substring(0, 8);
            }
            else
            {
                lbl_observaciones.Text = parent.txt_Observacion.Text;
            }
            lbl_TMuestra.Text = parent.cbo_TipoOrden.SelectedValue.ToString();
            lb_fingreso.Text = parent.fechaDia.Text + " " + parent.horaDia.Text;


            //lbl_PacienteOculto.Text = "IMPRESION DE PRUEBA";
            //lbl_Numero.Text = "*0100030109*";
            //lbl_cama.Text = "1";
            //lbl_edad.Text = "30";
            //lbl_resumen.Text = "SIN RESUMEN";
            //lbl_observaciones.Text = "OBS...";
            //lbl_TMuestra.Text = "D";
            //lb_fingreso.Text = "29/10/2014 15:41";

            
            DAL.Impresion_AutomaticaDALTableAdapters.H2_Laboratorio_Impresion_Grupo_etiquetasTableAdapter adapter = new DAL.Impresion_AutomaticaDALTableAdapters.H2_Laboratorio_Impresion_Grupo_etiquetasTableAdapter();
            DAL.Impresion_AutomaticaDAL.H2_Laboratorio_Impresion_Grupo_etiquetasDataTable aTable = adapter.GetData(lbl_Numero.Text.Replace("*",""));
            foreach (DAL.Impresion_AutomaticaDAL.H2_Laboratorio_Impresion_Grupo_etiquetasRow row in aTable)
            { 
                etiquetas_laboratorio el = new etiquetas_laboratorio();
                el.cant_etiquetas = row.grupo_cant_etiqueta;
                el.grupo = row.grupo_nombre;
                lista.Add(el);

                string[] rows = new string[] { el.grupo.ToString(), el.cant_etiquetas.ToString(), "Más", "Menos", "Borrar" };
                gv.Rows.Add(rows);
            }

            //gv.DataSource = lista;
            }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            Imprimir();
        }

        public void Imprimir()
        {

            foreach (DataGridViewRow dr in gv.Rows)
            {
                for (int i = 1; i <= Convert.ToInt32(dr.Cells[1].Value); i++)
                { 
                    etiquetas_laboratorio et = new etiquetas_laboratorio();
                    et.grupo = (dr.Cells[0].Value + "    ").Substring(0,4) + " - " + i.ToString();
                    lista_impresion.Add(et);
                }
            }

            //for (int i = 0; i <= lista_impresion.Count-1; i++)
            //{
            //    MessageBox.Show(lista_impresion[i].grupo);
            //}

            //return;
            string ImpresoraCodigoBarra = ConfigurationManager.AppSettings["ImpresoraCodBarra"];

            printFont = new Font("Arial", 8);
            printFont2 = new Font("IDAutomationHC39M", 12);
            printFont3 = new Font("Arial", 10, FontStyle.Bold);
            PrintDocument pd = new PrintDocument();
            pd.DefaultPageSettings.PrinterSettings.PrinterName = ImpresoraCodigoBarra;
            //pd.DefaultPageSettings.PrinterSettings.Copies = Copias;
                
            //Esto estaba antes del pd.print() 11/02/2014
            Margins margins = new Margins(0, 0, 0, 0);
            pd.DefaultPageSettings.Margins = margins;

            pd.PrintPage += new PrintPageEventHandler
               (this.pd_PrintPage);
          

            pd.Print();
            Actualizar_Log();
            this.Close();
        }


        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            string Seccional = usuarios.seccionalnumero.ToString();
            //string Seccional = "010";
            float linesPerPage = 0;
            float yPos = 0;
            int count = 0;
            float leftMargin = 0; //ev.MarginBounds.Left;
            float topMargin = ev.MarginBounds.Top;
            string line = null;

            // Calculate the number of lines per page.
            linesPerPage = ev.MarginBounds.Height / printFont.GetHeight(ev.Graphics);

            StringFormat sf = new StringFormat();

            line = lbl_PacienteOculto.Text;
            if (line.Length > 21)
            {
                line = line.Substring(0, 20);
            }

            line = line + "(" + lbl_edad.Text + ")";

            //Rectangle rectNombre = new Rectangle(0, 60, 220, 20);
            Rectangle rectNombre = new Rectangle((0 - 5), (0 - 5), 220, 20);
            Rectangle rectFecha = new Rectangle((0 - 5), (80 - 5), 220, 20);
            Rectangle minitexto = new Rectangle((0 - 5), (0 - 5), 220, 20);
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            ev.Graphics.DrawString(line, printFont, Brushes.Black, rectNombre, stringFormat);
            ev.Graphics.DrawRectangle(Pens.Transparent, rectNombre);


            string CCamas = "";
            if (lbl_cama.Text.Trim() != "")
            {
                CCamas = " - Cama:" + lbl_cama.Text;
            }

            if (lbl_TMuestra.Text == "D" || lbl_observaciones.Text != "")
            {
                line = Convert.ToDateTime(lb_fingreso.Text).ToString("dd/MM/yyyy HH:mm") + " - N.Ext: " + lbl_observaciones.Text;
            }
            else
            {
                line = Convert.ToDateTime(lb_fingreso.Text).ToString("dd/MM/yyyy HH:mm") + CCamas;
            }

            ev.Graphics.DrawString(line, printFont, Brushes.Black, rectFecha, stringFormat);
            ev.Graphics.DrawRectangle(Pens.Transparent, rectFecha);

            //CODIGO BARRA
            line = lbl_Numero.Text;
            yPos = topMargin + (count * printFont.GetHeight(ev.Graphics)) + 10 - 5;
            ev.Graphics.DrawString(line, printFont2, Brushes.Black, leftMargin + 5, yPos + 10, sf);
            

            //Ejemplo rotando un texto            
            ////Aca va el tipo de muestra
            line = lista_impresion[Pract_nro].grupo;
            ev.Graphics.TranslateTransform(300, -70);
            ev.Graphics.RotateTransform(90);
            ev.Graphics.DrawString(line, printFont3, Brushes.Black, rectFecha, stringFormat);
            ev.Graphics.DrawRectangle(Pens.Transparent, rectFecha);

            count++;
            Pract_nro++;

            if (Pract_nro == lista_impresion.Count)
                ev.HasMorePages = false;
            else
                ev.HasMorePages = true;
                //ev.HasMorePages = false;
                //ev.HasMorePages = false;
        }

        private void Actualizar_Log()
        {
            UsuariosDataSetTableAdapters.QueriesTableAdapter adatper = new UsuariosDataSetTableAdapters.QueriesTableAdapter();
            adatper.Insert_log(DateTime.Now, VariablesGlobales.MiUsuarioid.ToString(), lbl_Numero.Text.Replace("*", ""), 0, lista_impresion.Count, parent.cbo_hora.Checked);
        }

        private void gv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                if (senderGrid.Columns[e.ColumnIndex].HeaderText == "Más")
                {
                    gv.Rows[e.RowIndex].Cells[1].Value = Convert.ToInt32(gv.Rows[e.RowIndex].Cells[1].Value) + 1;
                    if (Convert.ToInt32(gv.Rows[e.RowIndex].Cells[1].Value) > 10) { gv.Rows[e.RowIndex].Cells[1].Value = 10; }
                }

                if (senderGrid.Columns[e.ColumnIndex].HeaderText == "Menos")
                {
                    gv.Rows[e.RowIndex].Cells[1].Value = Convert.ToInt32(gv.Rows[e.RowIndex].Cells[1].Value) - 1;
                    if (Convert.ToInt32(gv.Rows[e.RowIndex].Cells[1].Value) < 1) { gv.Rows[e.RowIndex].Cells[1].Value = 1; }
                }

                if (senderGrid.Columns[e.ColumnIndex].HeaderText == "Borrar")
                {
                    gv.Rows.RemoveAt(e.RowIndex);
                }

                //TODO - Button Clicked - Execute Code Here
            }
        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            if (txt_grupo.Text.Trim() == "") {
                MessageBox.Show("Falta cargar el nombre de la etiqueta");
                return;
            }

            if (txt_cantidad.Text.Trim() == "")
            {
                MessageBox.Show("Falta cargar la cantidad de la etiqueta");
                return;
            }

            try
            {
                if (Convert.ToInt32(txt_cantidad.Text) < 1)
                {
                    MessageBox.Show("Falta cargar la cantidad de la etiqueta");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Error al cargar la cantidad de la etiqueta");
                return;
            }

            string[] rows = new string[] { txt_grupo.Text, txt_cantidad.Text, "Más", "Menos", "Borrar" };
            gv.Rows.Add(rows);

            txt_cantidad.Text = "";
            txt_grupo.Text = "";
        }

    }
}
