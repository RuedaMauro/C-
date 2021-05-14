using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Drawing.Printing;
using System.IO;
using System.Drawing.Imaging;
using System.Configuration;
using Laboratorio2.Entities;

namespace Laboratorio2
{
    public partial class Impresion_Comprobante : Form
    {
        Principal f = new Principal();

        private int currentPageIndex;
        private IList<Stream> pages = new List<Stream>();
        public short Copias;

        public Impresion_Comprobante(Principal ff)
        {
            f = ff;
            InitializeComponent();
            try
            {
                Copias = Convert.ToInt16(f.txt_CopiasComprobante.Text);
            }
            catch
            {
                Copias = 2;
            }
            
        }

        
        public Impresion_Comprobante()
        {
            InitializeComponent();
        }

        public class Indicacionesss
        {
            public string Indicaciones { get; set; }
        }

        public class Practicass
        {
            public string Practicas { get; set; }
        }


        private Stream CreateStream(string name, string fileNameExtension,
                Encoding encoding, string mimeType, bool willSeek)
        {
            // Creamos un MemoryStream para no tener que grabar en el
            // disco duro cada una de las páginas que pudiera haber
            Stream stream = new MemoryStream();

            // Se añade el stream al listado
            pages.Add(stream);

            return stream;
        }


        private void Export(LocalReport report)
        {
            string deviceInfo =
              "<DeviceInfo>" +
              "  <OutputFormat>EMF</OutputFormat>" +
              "  <PageWidth>21.56cm</PageWidth>" +
                //"  <PageHeight>15cm</PageHeight>" +
              "  <MarginTop>0.0in</MarginTop>" +
              "  <MarginLeft>0.0in</MarginLeft>" +
              "  <MarginRight>0.0in</MarginRight>" +
              "  <MarginBottom>0.0in</MarginBottom>" +
              "</DeviceInfo>";
            Warning[] warnings;

            // El método render es el encargado de crear el stream
            // (llamando a CreateStream) en el formato especificado,
            // usando el stream proveido por la funcion de callback
            // en este caso, un aun archivo EMF con ciertas medidas
            report.Render("Image", deviceInfo, CreateStream, out warnings);

            // Se encarga de resetear la posicion de
            // todos los stream al inicio de los mismos
            foreach (Stream stream in pages)
                stream.Position = 0;
        }


        public void AddPage(List<Object> objetos)
        {
            
        }





        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'impresionDAL1.Laboratorio_Impresion_Mensajes' Puede moverla o quitarla según sea necesario.
            this.laboratorio_Impresion_MensajesTableAdapter.Fill(this.impresionDAL1.Laboratorio_Impresion_Mensajes);
            // TODO: This line of code loads data into the 'ImpresionDAL.Laboratorio_Impresion_Mensajes' table. You can move, or remove it, as needed.
            //////this.laboratorio_Impresion_MensajesTableAdapter.Fill(this.ImpresionDAL.Laboratorio_Impresion_Mensajes);

            //Info del policlinico

            DAL.HospitalDataSetTableAdapters.H3_CentroTableAdapter adapter3 = new DAL.HospitalDataSetTableAdapters.H3_CentroTableAdapter();
            DAL.HospitalDataSet.H3_CentroDataTable aTable3 = adapter3.GetData();
            centro c = new centro();
            foreach (DAL.HospitalDataSet.H3_CentroRow row2 in aTable3.Rows)
            {
                if (!row2.IsTelefonoNull()) c.Telefono = row2.Telefono;
                c.Nombre = row2.RazonSocial;
                c.Direccion = row2.Calle;      
                
            }

            //VariablesGlobales
            //Inserto en el LOG
            UsuariosDataSetTableAdapters.QueriesTableAdapter adatper = new UsuariosDataSetTableAdapters.QueriesTableAdapter();
            adatper.Insert_log(DateTime.Now, VariablesGlobales.MiUsuarioid.ToString(), f.lbl_CodigoBarra.Text.Replace("*",""), Copias, 0, f.cbo_hora.Checked);
            

            ReportParameter[] par = new ReportParameter[13];
            //par[0] = new ReportParameter("Fecha", DateTime.Now.ToString());
            par[0] = new ReportParameter("Fecha", f.fechaDia.Text + " " + f.horaDia.Text);
            par[1] = new ReportParameter("Nro", f.lbl_CodigoBarra.Text.Substring(0, 4) + "-" + f.lbl_CodigoBarra.Text.Substring(4,8));
            string edad = f.lbl_edad.Text;
            edad = f.lbl_edad.Text;
            //if (edad != "")
            //{
            //    try
            //    {
            //        if (Convert.ToInt32(edad) > 105) { edad = ""; }
            //    }
            //    catch
            //    {
            //        edad = "";
            //    }

            //}
            par[2] = new ReportParameter("Paciente", f.lbl_NHCOculto.Text + "  -  " + f.lbl_PacienteOculto.Text + "("+edad+")");
            par[3] = new ReportParameter("Seccional", f.lbl_Seccional.Text);
            par[4] = new ReportParameter("Comentario", f.txt_Observacion.Text);
            par[5] = new ReportParameter("FEntrega", f.txt_FEntrega.Text);
            par[6] = new ReportParameter("Medico", f.cbo_MedicoSolicitante.Text);


            string Titulo = "";
            //if (VariablesGlobales.MiUsuarioseccional == "010") { Titulo = "POLICLINICO CENTRAL - OSUOMRA"; }
            //if (VariablesGlobales.MiUsuarioseccional == "053") { Titulo = "POLICLINICO MORON - OSUOMRA"; }
            Titulo = c.Nombre;

            par[7] = new ReportParameter("Titulo", Titulo);
            par[8] = new ReportParameter("Telefono", c.Telefono);
            par[9] = new ReportParameter("Direccion", c.Direccion);

            string Mensaje_informativo = "";

            if (VariablesGlobales.MiUsuarioseccional == "003")
            {
                Mensaje_informativo = @"
            Retiro de Lunes a Viernes<br/>
            De 11:00 a 14:00 hs en Laboratorio<br/> 
            De 15:00 a 19:00 hs en Ventanilla de informes<br/> <br/>

            Laboratorio 6345-5559 Llamar de 11 hs a 14 hs
            ";
            }

            if (VariablesGlobales.MiUsuarioseccional == "097")
            {
                Mensaje_informativo = @"
            Entrega de Resultados<br/>
            Lunes a viernes de 11:00 a 15:00 hs<br/>
            ";
            }

            if (VariablesGlobales.MiUsuarioseccional == "010" || VariablesGlobales.MiUsuarioseccional == "084")
            {
                Mensaje_informativo = "Puede visualizar el estado de este estudio en : http://www.laboratoriouom.com.ar <br/> Código seguridad: " + f.lbl_codigoseguridad.Text; 
            }


            par[10] = new ReportParameter("Mensaje_informativo", Mensaje_informativo);
            string Dato_Monto = "";

            bool error = false;
            bool Guardo_Monto = true;
            if (f.bono_datos.Monto == null)
            {
                try
                {
                    //Busco el protocolo.
                    DAL.BonoDALTableAdapters.H3_HORDENES_MONTOTableAdapter adapter = new DAL.BonoDALTableAdapters.H3_HORDENES_MONTOTableAdapter();
                    DAL.BonoDAL.H3_HORDENES_MONTODataTable aTable = adapter.GetData(f.lbl_CodigoBarra.Text.Replace("*", ""));
                    if (aTable.Count > 0)
                    {
                        f.bono_datos.Monto = aTable[0].Total.ToString();
                        Guardo_Monto = false;
                    }
                }
                catch
                {
                    f.bono_datos.Monto = null;
                }
            }

            if (f.bono_datos.Monto != null)
            {
                if (f.bono_datos.Monto != "") { Dato_Monto = "Usted pagó: $" + f.bono_datos.Monto + "(" + f.bono_datos.comentario + ")"; }
                else if (f.bono_datos.Monto != "NO PAGA") { Dato_Monto = "*** SIN CARGO *** (" + f.bono_datos.comentario + ")"; }
                else if (f.bono_datos.Monto == "") { Dato_Monto = "*** ESTE COMPROBANTE ES UNA REIMPRESION ***"; }
            }
            else
            {
                Dato_Monto = "";
            }

                        
            if (Guardo_Monto && f.bono_datos.Monto != null)
            {
                try
                {
                    DAL.LaboratorioDataSetTableAdapters.QueriesTableAdapter adapter = new DAL.LaboratorioDataSetTableAdapters.QueriesTableAdapter();
                    adapter.H3_Laboratorio_Monto_Guardar(f.lbl_CodigoBarra.Text.Replace("*", "").ToString(), 0, Convert.ToDecimal(f.bono_datos.Monto));
                }
                catch
                {
                    error = true;
                }                
            }
            
            par[11] = new ReportParameter("MontoBono", Dato_Monto);
            f.bono_datos.Monto = null; //ESTO TIENE QUE ESTAR PARA QUE LA IMPRESION DEL COMPROBANTE SE BORRE Y NO RE REPITA.
                        
            string cdocumento = f.lbl_DNI.Text.Split(':')[1].Replace("CUIL", "").Trim();
            string cprotocolo = f.lbl_CodigoBarra.Text.Replace("*","");
            string cclave = f.lbl_codigoseguridad.Text;
            //string sitio = "www.laboratoriouom.com.ar";
            string sitio = "10.10.8.76";
            string CodigoQR = "";
            if (VariablesGlobales.MiUsuarioseccional == "010")
            {
                CodigoQR = new Uri("http://" + sitio + "/web/QRGenerador.aspx?d=" + cdocumento + "&p=" + cprotocolo + "&c=" + cclave).AbsoluteUri;
            }            
            par[12] = new ReportParameter("CodigoQR", CodigoQR);

            var Comentario = "";
            List<Practicass> listap = new List<Practicass>();
            int i = 0;
            for (i = 0; i <= f.l.Count - 1; i++)
            {
                Practicass pr = new Practicass();
                //ESTO HACE QUE EL COMENTARIO APAREZCO EN LA IMPRESION
                Comentario = "";
                if (f.l[i].Comentario != null && f.l[i].Comentario != "")
                {
                    Comentario = "<br><b><i><small>COMENTARIO: " + f.l[i].Comentario + "</small></i></b>";
                }
                pr.Practicas = "(" + f.l[i].Codigo.Trim() + ") - " + f.l[i].Practica + "(" + f.l[i].SubPractica + ") " + Comentario;
                listap.Add(pr);
            }

            ReportDataSource reportDataSource1 = new ReportDataSource("DataSet1", listap);
            reportViewer1.LocalReport.SetParameters(par);
            reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            reportViewer1.LocalReport.EnableExternalImages = true;
            reportViewer1.LocalReport.Refresh();
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            Export(reportViewer1.LocalReport);

            this.reportViewer1.RefreshReport();

            Print(ConfigurationManager.AppSettings["ImpresoraComprobante"]);
            this.Close();
        }


        public void Print(string printer)
        {
            // Debe existir al menos una pagina a imprimir
            if (pages == null || pages.Count == 0)
                return;

            PrintDocument printDocument = new PrintDocument();
            printDocument.DefaultPageSettings.PrinterSettings.Copies = Copias;
            printDocument.PrinterSettings.Copies = Copias;
            printDocument.PrinterSettings.PrinterName = printer;

            if (!printDocument.PrinterSettings.IsValid)
            {
                string msg = String.Format("No se pudo encontrar la impresora \"{0}\".", printer);
                return;
            }

            printDocument.PrintPage += new PrintPageEventHandler(PrintPage);
            printDocument.Print();
        }

        public void Print(PrintDialog printDialog)
        {
            if (pages == null || pages.Count == 0)
                return;

            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += new PrintPageEventHandler(PrintPage);

            printDialog.Document = printDocument;
            printDocument.Print();
        }

        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            // Se crea un objeto Metafile que define un grafico
            // en base a la información contenida en un stream
            Metafile pageImage = new Metafile(pages[currentPageIndex]);

            // Se dibuja la página en el reporte
            ev.Graphics.DrawImage(pageImage, ev.PageBounds);

            // Se procesan las paginas siguientes
            currentPageIndex++;
            ev.HasMorePages = (currentPageIndex < pages.Count);
        }

        public void Dispose()
        {
            if (pages != null)
            {
                foreach (Stream stream in pages)
                    stream.Close();

                pages = null;
            }
        }


    }
}
