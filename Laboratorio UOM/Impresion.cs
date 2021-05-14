using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using Laboratorio2.Entities;
using System.Configuration;

namespace Laboratorio2
{
    public partial class Impresion : Form
    {
        private Font printFont;
        private Font printFont2;
        public short Copias = 1;
        Principal parent;
        

        public Impresion()
        {
            InitializeComponent();
        }

        public Impresion(Principal f)
        {
            parent = f;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int Salida = 0;
            if (int.TryParse(txt_CantCopias.Text, out Salida))
            {
                Copias = Convert.ToInt16(Salida);
                if (Copias > 0)
                {
                    Imprimir();
                }
                else
                {
                    Actualizar_Log();
                    this.Close();                    
                }
            }
            else
            {
                //Copias = Convert.ToInt16(Salida);
                MessageBox.Show("Error en la cantidad de copias", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_CantCopias.Focus();
            }
            
        }

        public void Imprimir()
        {

            //ImprimirResumen();

            string ImpresoraCodigoBarra = ConfigurationManager.AppSettings["ImpresoraCodBarra"];

            printFont = new Font("Arial", 8);
            printFont2 = new Font("IDAutomationHC39M", 12); 
            PrintDocument pd = new PrintDocument();
            pd.DefaultPageSettings.PrinterSettings.PrinterName = ImpresoraCodigoBarra;
            pd.DefaultPageSettings.PrinterSettings.Copies = Copias;

            //Esto estaba antes del pd.print() 11/02/2014
            Margins margins = new Margins(0, 0, 0, 0);
            pd.DefaultPageSettings.Margins = margins;

            pd.PrintPage += new PrintPageEventHandler
               (this.pd_PrintPage);
            //pd.DefaultPageSettings.PaperSize = new PaperSize("A5", 210, 140);
            //pd.DefaultPageSettings.PaperSize = new PaperSize("A5", 210, 140);
                                 

            pd.Print();
            Actualizar_Log();
            this.Close();
        }

        private void ImprimirResumen()
        {


            string ImpresoraCodigoBarra = ConfigurationManager.AppSettings["ImpresoraCodBarra"];

            printFont = new Font("Arial", 8);
            printFont2 = new Font("Arial", 6);
            PrintDocument pd = new PrintDocument();
            pd.DefaultPageSettings.PrinterSettings.PrinterName = ImpresoraCodigoBarra;
            pd.DefaultPageSettings.PrinterSettings.Copies = 1;

            //Esto estaba antes del pd.print() 11/02/2014
            Margins margins = new Margins(0, 0, 0, 0);
            pd.DefaultPageSettings.Margins = margins;

            pd.PrintPage += new PrintPageEventHandler
               (this.pd_PrintPage_resumen);
            //pd.DefaultPageSettings.PaperSize = new PaperSize("A5", 210, 140);
            //pd.DefaultPageSettings.PaperSize = new PaperSize("A5", 210, 140);


            pd.Print();
            Actualizar_Log();
            this.Close();

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

            // Calculate the number of lines per page.
            linesPerPage = ev.MarginBounds.Height / printFont.GetHeight(ev.Graphics);

            StringFormat sf = new StringFormat();

            line = lbl_PacienteOculto.Text;
            if (line.Length > 18)
            {
                line = line.Substring(0, 17);
            }

            string Edad_Corta = lbl_edad.Text.ToUpper().Replace("MESES", "m").Replace("AÑOS", "a").Replace(" ", "").Trim(); 
            try
            {
                if (Convert.ToInt32(Edad_Corta.Split('a')[0]) == 0)
                {
                    Edad_Corta = lbl_edad.Text.ToUpper().Replace("MESES", "m").Replace("AÑOS", "a").Replace(" ", "").Trim().Split('a')[1];
                }
                else
                {
                    Edad_Corta = lbl_edad.Text.ToUpper().Replace("MESES", "m").Replace("AÑOS", "a").Replace(" ", "").Trim().Split('a')[0] + "a";
                }
            }
            catch (Exception ex)
            {
                Edad_Corta = lbl_edad.Text.ToUpper().Replace("MESES", "m").Replace("AÑOS", "a").Replace(" ", "").Trim(); 
            }
            line = line + "(" + Edad_Corta + "" + lbl_sexo.Text + ")";

            //Rectangle rectNombre = new Rectangle(0, 60, 220, 20);
            Rectangle rectNombre = new Rectangle((0-5), (0-5), 220, 20);
            Rectangle rectFecha = new Rectangle((0-5), (80-5), 220, 20);
            Rectangle minitexto = new Rectangle((0-5), (0-5), 220, 20);
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            
            //yPos = topMargin + (count * printFont.GetHeight(ev.Graphics));
            //ev.Graphics.DrawString(line.ToUpper(), printFont, Brushes.Black, leftMargin, yPos + 70, stringFormat);
            ev.Graphics.DrawString(line, printFont, Brushes.Black, rectNombre, stringFormat);
            ev.Graphics.DrawRectangle(Pens.Transparent, rectNombre);


            

            string CCamas = "";
            if (lbl_cama.Text.Trim() != "")
            {
                CCamas = " - Cama:" + lbl_cama.Text;
            }

            //line = DateTime.Now.ToString("dd/MM/yyyy HH:mm") + CCamas;

            if (lbl_TMuestra.Text == "D" || lbl_observaciones.Text != "")
            {
                //line = DateTime.Now.ToString("dd/MM/yyyy HH:mm") + " - N.Ext: " + lbl_observaciones.Text;
                line = Convert.ToDateTime(lb_fingreso.Text).ToString("dd/MM/yyyy HH:mm") + " - N.Ext: " + lbl_observaciones.Text;
            }
            else
            {
                line = Convert.ToDateTime(lb_fingreso.Text).ToString("dd/MM/yyyy HH:mm") + CCamas;
                
            }


            //yPos = topMargin + (count * printFont.GetHeight(ev.Graphics));
            //ev.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, yPos + 90, sf);
            ev.Graphics.DrawString(line, printFont, Brushes.Black, rectFecha, stringFormat);
            ev.Graphics.DrawRectangle(Pens.Transparent, rectFecha);
                                                
            //CODIGO BARRA
            line = lbl_Numero.Text;
            //yPos = topMargin + (count * printFont.GetHeight(ev.Graphics));
            yPos = topMargin + (count * printFont.GetHeight(ev.Graphics))+10-5;
            ev.Graphics.DrawString(line, printFont2, Brushes.Black, leftMargin + parent.PosIzquierdaBarra - 5, yPos + 10, sf);
            
            
            
            //Ejemplo rotando un texto            
            ////Aca va el tipo de muestra
            //line = "QUI";
            //ev.Graphics.TranslateTransform(300, -80);
            //ev.Graphics.RotateTransform(90);
            //ev.Graphics.DrawString(line, printFont, Brushes.Black, rectFecha, stringFormat);
            //ev.Graphics.DrawRectangle(Pens.Transparent, rectFecha);

            count++;

            if (line != null)
                ev.HasMorePages = true;
            else
                ev.HasMorePages = false;
            ev.HasMorePages = false;
        }


        private void pd_PrintPage_resumen(object sender, PrintPageEventArgs ev)
        {
            string Seccional = usuarios.seccionalnumero.ToString();
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

            line = line + "(" + lbl_edad.Text.Replace("años","a").Replace("meses","m") + ")";

            //Rectangle rectNombre = new Rectangle(0, 60, 220, 20);
            Rectangle rectNombre = new Rectangle(0, 0, 220, 20);
            Rectangle rectFecha = new Rectangle(0, 73, 220, 20);
            Rectangle minitexto = new Rectangle(0, 0, 220, 20);
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;


            //yPos = topMargin + (count * printFont.GetHeight(ev.Graphics));
            //ev.Graphics.DrawString(line.ToUpper(), printFont, Brushes.Black, leftMargin, yPos + 70, stringFormat);
            ev.Graphics.DrawString(line, printFont, Brushes.Black, rectNombre, stringFormat);
            ev.Graphics.DrawRectangle(Pens.Transparent, rectNombre);


            string CCamas = "";
            if (lbl_cama.Text.Trim() != "")
            {
                CCamas = " - Cama:" + lbl_cama.Text;
            }

            

            // lbl_observaciones.Text = parent.txt_Observacion.Text.Substring(0,8);
            //lbl_TMuestra.Text = parent.

            if (lbl_TMuestra.Text == "D")
            {
                line = DateTime.Now.ToString("dd/MM/yyyy HH:mm") + "N.Ext: " + lbl_observaciones.Text;
            }
            else
            {
                line = DateTime.Now.ToString("dd/MM/yyyy HH:mm") + CCamas;
            }

            //yPos = topMargin + (count * printFont.GetHeight(ev.Graphics));
            //ev.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, yPos + 90, sf);
            ev.Graphics.DrawString(line, printFont, Brushes.Black, rectFecha, stringFormat);
            ev.Graphics.DrawRectangle(Pens.Transparent, rectFecha);

            
            //CODIGO BARRA
            //line = lbl_Numero.Text;
            //yPos = topMargin + (count * printFont.GetHeight(ev.Graphics));
            //yPos = topMargin + (count * printFont.GetHeight(ev.Graphics)) + 10;
            //ev.Graphics.DrawString(line, printFont2, Brushes.Black, leftMargin + parent.PosIzquierdaBarra, yPos + 10, sf);


            Font trFont = new Font("Arial", 6);
            Rectangle rect = new Rectangle(0, 10, 220, 60);
            ev.Graphics.DrawRectangle(Pens.White, rect);

            String longString = lbl_resumen.Text;
            
            ev.Graphics.DrawString(longString, trFont, Brushes.Black, rect);



            ev.HasMorePages = false;
        }

        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        private void Impresion_Load(object sender, EventArgs e)
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
            lbl_sexo.Text = parent.lbl_sexo.Text;
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Copias = 1;
            Imprimir();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Copias = 2;
            Imprimir();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Copias = 3;
            Imprimir();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Copias = 4;
            Imprimir();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Copias = 5;
            Imprimir();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Copias = 6;
            Imprimir();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Copias = 0;
            Actualizar_Log();
            this.Close();
        }

        private void Impresion_FormClosing(object sender, FormClosingEventArgs e)
        {
            Actualizar_Log();
        }

        private void Actualizar_Log()
        {
            UsuariosDataSetTableAdapters.QueriesTableAdapter adatper = new UsuariosDataSetTableAdapters.QueriesTableAdapter();
            adatper.Insert_log(DateTime.Now, VariablesGlobales.MiUsuarioid.ToString(), lbl_Numero.Text.Replace("*", ""), 0, Copias, parent.cbo_hora.Checked);
        }
        
    }
}
