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
    public partial class ImpresionIndicaciones : Form
    {
        Principal f = new Principal();

        private int currentPageIndex;
        private IList<Stream> pages = new List<Stream>();

        public ImpresionIndicaciones()
        {
            InitializeComponent();
        }

        public ImpresionIndicaciones(Principal ff)
        {
            f = ff;
            InitializeComponent();
        }

        private void ImpresionIndicaciones_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'impresionDAL1.Laboratorio_Impresion_Mensajes' Puede moverla o quitarla según sea necesario.
            this.laboratorio_Impresion_MensajesTableAdapter.Fill(this.impresionDAL1.Laboratorio_Impresion_Mensajes);
            // TODO: This line of code loads data into the 'ImpresionDAL.Laboratorio_Impresion_Mensajes' table. You can move, or remove it, as needed.
            ///////////this.laboratorio_Impresion_MensajesTableAdapter.Fill(this.ImpresionDAL.Laboratorio_Impresion_Mensajes);

            
            //Info del policlinico

            DAL.HospitalDataSetTableAdapters.H3_CentroTableAdapter adapter3 = new DAL.HospitalDataSetTableAdapters.H3_CentroTableAdapter();
            DAL.HospitalDataSet.H3_CentroDataTable aTable3 = adapter3.GetData();
            centro c = new centro();
            foreach (DAL.HospitalDataSet.H3_CentroRow row2 in aTable3.Rows)
            {
                if (!row2.IsTelefonoNull()) c.Telefono = row2.Telefono;
                c.Nombre = row2.RazonSocial;
            }

            List<Indicacionesss> lista = new List<Indicacionesss>();
            int i = 0;
            string LasIndicaciones = "";
            for (i = 0; i <= f.ls_Indicaciones.Items.Count - 1; i++)
            {
                Indicacionesss ind = new Indicacionesss();
                ind.Indicaciones = f.ls_Indicaciones.Items[i].ToString();
                LasIndicaciones = LasIndicaciones + " <br> " + f.ls_Indicaciones.Items[i].ToString().Replace("\r\n", "<br>");
                lista.Add(ind);
            }

            string apellidoynombre = "";
            if (f.lbl_PacienteOculto.Text != "")
            {
                apellidoynombre = f.lbl_PacienteOculto.Text;
            }
            else {
                apellidoynombre = "";
            }


            ReportParameter[] par = new ReportParameter[6];            
            par[0] = new ReportParameter("Indicaciones", LasIndicaciones);
            par[1] = new ReportParameter("Paciente", apellidoynombre);
            
            string Titulo = "";
            //if (VariablesGlobales.MiUsuarioseccional == "010") { Titulo = "POLICLINICO CENTRAL - OSUOMRA"; }
            //if (VariablesGlobales.MiUsuarioseccional == "053") { Titulo = "POLICLINICO MORON - OSUOMRA"; }
            Titulo = c.Nombre;
            par[2] = new ReportParameter("Titulo", Titulo);
            par[3] = new ReportParameter("Telefono", c.Telefono);

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

            par[4] = new ReportParameter("Mensaje_informativo", Mensaje_informativo);

            par[5] = new ReportParameter("Usuario", usuarios.usuario);
                      

            //

            //par[1] = new ReportParameter("Nro", f.lbl_CodigoBarra.Text.Substring(0, 4) + "-" + f.lbl_CodigoBarra.Text.Substring(4, 8));
            //par[2] = new ReportParameter("Paciente", f.lbl_PacienteOculto.Text);
            //par[3] = new ReportParameter("Seccional", f.lbl_Seccional.Text);
            //par[4] = new ReportParameter("Comentario", f.txt_Observacion.Text);
            //par[5] = new ReportParameter("FEntrega", f.txt_FEntrega.Text);



            //ReportDataSource reportDataSource = new ReportDataSource("DataSet1", lista);
            reportViewer1.LocalReport.SetParameters(par);
            this.reportViewer1.RefreshReport();
            //reportViewer1.LocalReport.DataSources.Add(reportDataSource);

            reportViewer1.ProcessingMode = ProcessingMode.Local;
            Export(reportViewer1.LocalReport);
                        
            Print(ConfigurationManager.AppSettings["ImpresoraComprobante"]);
            this.reportViewer1.RefreshReport();
            this.Close();

            
        }


        public class Indicacionesss
        {
            public string Indicaciones { get; set; }
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

        public void Print(string printer)
        {
            // Debe existir al menos una pagina a imprimir
            if (pages == null || pages.Count == 0)
                return;

            PrintDocument printDocument = new PrintDocument();
            printDocument.PrinterSettings.PrinterName = printer;

            if (!printDocument.PrinterSettings.IsValid)
            {
                string msg = String.Format("Can't find printer \"{0}\".", printer);
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
