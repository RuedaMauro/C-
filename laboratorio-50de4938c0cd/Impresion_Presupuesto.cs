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
    public partial class Impresion_Presupuesto : Form
    {


        List<Presupuesto> l = new List<Presupuesto>();
        DAL.BonoDAL.PresupuestoDALDataTable ds = new DAL.BonoDAL.PresupuestoDALDataTable();
        DAL.BonoDAL.PresupuestoDALRow dtr;
        public ReportDataSource fuente = new ReportDataSource();
        public DataGridView _gv_bono;

        public Impresion_Presupuesto(DataGridView gv_bono)
        {
            _gv_bono = gv_bono;
            InitializeComponent();
        }

        private void Impresion_Presupuesto_Load(object sender, EventArgs e)
        {
            

            foreach (DataGridViewRow row in _gv_bono.Rows)
            {

                dtr = ds.NewPresupuestoDALRow();
                if (row.Cells[0].Value != "") { dtr.codPractica = Convert.ToInt32(row.Cells[0].Value).ToString(); }//int codigo
                if (row.Cells[1].Value != "") { dtr.codSbuPractica = Convert.ToInt32(row.Cells[1].Value).ToString(); }//int subcodigo
                dtr.practica = row.Cells[2].Value.ToString(); //string nombre practica
                dtr.subPractica = row.Cells[3].Value.ToString(); //string nombre subpractica
                if (row.Cells[4].Value != "") { dtr.precio = Convert.ToDecimal(row.Cells[4].Value).ToString(); }//int Precio
                ds.Rows.Add(dtr);
            }



            //29/03/2016
            //Esto es para que en Avellaneda no muestre la foto del policlinico.            
            string MostrarFoto = "0";
            if (VariablesGlobales.MiUsuarioseccional == "010")
            {
                //Con cero lo muestra!!!!
                MostrarFoto = "0";
            }


            reportViewer1.LocalReport.Refresh();

            ReportParameter[] parameters = new ReportParameter[1];
            parameters[0] = new ReportParameter("Usuario", usuarios.usuario);
            //parameters[1] = new ReportParameter("Imagen", "http://10.10.8.71/img/logoprint.jpg");
            //parameters[2] = new ReportParameter("Motivo_no_paga", Motivo_no_paga);
            //parameters[3] = new ReportParameter("Mostrar_Fondo", MostrarFoto);

            //reportViewer1.LocalReport.EnableExternalImages = true;
            //reportViewer1.LocalReport.SetParameters(parameters);





            fuente.Name = "Datos";
            fuente.Value = ds;

            reportViewer1.LocalReport.DataSources.Clear();
            //ReportDataSource reportDataSource = new ReportDataSource(fuente);
            reportViewer1.LocalReport.DataSources.Add(fuente);
            reportViewer1.LocalReport.SetParameters(parameters);
            reportViewer1.LocalReport.Refresh();
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            Export(reportViewer1.LocalReport);

            this.reportViewer1.RefreshReport();

            Print(ConfigurationManager.AppSettings["ImpresoraBono"]);
            this.Close();
        }


        private string Fecha;
        private int BonoId;
        private string Motivo_no_paga;

        private int currentPageIndex;
        private IList<Stream> pages = new List<Stream>();
        public short Copias;

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


        private void Impresion_Bono_Load(object sender, EventArgs e)
        {

            //29/03/2016
            //Esto es para que en Avellaneda no muestre la foto del policlinico.            
            string MostrarFoto = "0";
            if (VariablesGlobales.MiUsuarioseccional == "010")
            {
                //Con cero lo muestra!!!!
                MostrarFoto = "0";
            }

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


            reportViewer1.LocalReport.Refresh();

            ReportParameter[] parameters = new ReportParameter[4];
            parameters[0] = new ReportParameter("Usuario", usuarios.usuario);
            parameters[1] = new ReportParameter("Imagen", "http://10.10.8.71/img/logoprint.jpg");
            parameters[2] = new ReportParameter("Motivo_no_paga", Motivo_no_paga);
            parameters[3] = new ReportParameter("Mostrar_Fondo", MostrarFoto);

            reportViewer1.LocalReport.EnableExternalImages = true;
            reportViewer1.LocalReport.SetParameters(parameters);


            DAL.BonoDALTableAdapters.H3_Impresion_Bono_CABTableAdapter adapter_cab = new DAL.BonoDALTableAdapters.H3_Impresion_Bono_CABTableAdapter();
            DAL.BonoDAL.H3_Impresion_Bono_CABDataTable aTable_cab = adapter_cab.GetData(Fecha, BonoId);
            List<bono_cab> lista_cab = new List<bono_cab>();
            if (aTable_cab.Count > 0)
            {
                bono_cab bc = new bono_cab();
                DAL.BonoDAL.H3_Impresion_Bono_CABRow row = aTable_cab[0];
                if (!row.IsAutorizanteNull()) bc.Autorizante = row.Autorizante;
                if (!row.IsCalleNull()) bc.Calle = row.Calle;
                if (!row.IsCanceladoNull()) bc.Cancelado = row.Cancelado;
                bc.Documento = row.Documento;
                if (!row.IsEspecialidadNull()) bc.Especialidad = row.Especialidad;
                if (!row.IsF_NacNull()) bc.F_Nac = row.F_Nac;
                bc.Fecha = row.Fecha;
                if (!row.IsGente_FotoNull()) bc.Gente_Foto = row.Gente_Foto;
                if (!row.IsLocalidadNull()) bc.Localidad = row.Localidad;
                if (!row.IsMedicoNull()) bc.Medico = row.Medico;
                if (!row.IsNHCNull()) bc.NHC = row.NHC;
                if (!row.IsNroNull()) bc.Nro = row.Nro;
                bc.Nro_Bono = row.Nro_Bono;
                bc.Paciente = row.Paciente;
                if (!row.IsRazonSocialNull()) bc.RazonSocial = row.RazonSocial;
                if (!row.IsSeccionalNull()) bc.Seccional = row.Seccional;
                if (!row.IsTotalNull()) bc.Total = row.Total;
                if (!row.IsUsuarioNull()) bc.Usuario = row.Usuario;
                if (!row.IsMonotributoNull()) bc.Monotributo = row.Monotributo;
                lista_cab.Add(bc);
            }


            DAL.BonoDALTableAdapters.H3_Impresion_Bono_DETTableAdapter adapter_det = new DAL.BonoDALTableAdapters.H3_Impresion_Bono_DETTableAdapter();
            DAL.BonoDAL.H3_Impresion_Bono_DETDataTable aTable_det = adapter_det.GetData(Fecha, BonoId);
            List<bono_det> lista_det = new List<bono_det>();
            foreach (DAL.BonoDAL.H3_Impresion_Bono_DETRow row in aTable_det)
            {
                bono_det bd = new bono_det();
                bd.BonoId = row.BonoId;
                bd.Codigo = row.Codigo;
                bd.Fecha = row.Fecha;
                bd.GeneralId = row.GeneralId;
                if (!row.IsImporteNull()) bd.Importe = row.Importe;
                if (!row.IsImporteRealNull()) bd.ImporteReal = row.ImporteReal;
                bd.Practica = row.Practica;
                bd.PracticaId = row.PracticaId;
                lista_det.Add(bd);
            }

            //h3ImpresionBonoCABBindingSource.DataSource = aTable_cab;
            //h3ImpresionBonoDETBindingSource.DataSource = aTable_det;


            fuente.Name = "Datos";
            fuente.Value = ds.DataSet;

            //Reporte.ReportViewer1.LocalReport.DataSources.Clear()
            //ReportDataSource reportDataSource = new ReportDataSource(fuente);
            reportViewer1.LocalReport.DataSources.Add(fuente);
            //ReportDataSource reportDataSource_det = new ReportDataSource("DET", lista_det);
            //reportViewer1.LocalReport.DataSources.Add(reportDataSource_det);
            reportViewer1.LocalReport.SetParameters(parameters);
            reportViewer1.LocalReport.Refresh();
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            Export(reportViewer1.LocalReport);

            this.reportViewer1.RefreshReport();

            Print(ConfigurationManager.AppSettings["ImpresoraBono"]);
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
