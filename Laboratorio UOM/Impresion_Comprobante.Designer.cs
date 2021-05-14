namespace Laboratorio2
{
    partial class Impresion_Comprobante
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Impresion_Comprobante));
            this.laboratorioImpresionMensajesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.impresionDAL1 = new Laboratorio2.DAL.ImpresionDAL();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.laboratorio_Impresion_MensajesTableAdapter = new Laboratorio2.DAL.ImpresionDALTableAdapters.Laboratorio_Impresion_MensajesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.laboratorioImpresionMensajesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.impresionDAL1)).BeginInit();
            this.SuspendLayout();
            // 
            // laboratorioImpresionMensajesBindingSource
            // 
            this.laboratorioImpresionMensajesBindingSource.DataMember = "Laboratorio_Impresion_Mensajes";
            this.laboratorioImpresionMensajesBindingSource.DataSource = this.impresionDAL1;
            // 
            // impresionDAL1
            // 
            this.impresionDAL1.DataSetName = "ImpresionDAL";
            this.impresionDAL1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet2";
            reportDataSource1.Value = this.laboratorioImpresionMensajesBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.EnableExternalImages = true;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Laboratorio2.ImpresionComprobante.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(762, 526);
            this.reportViewer1.TabIndex = 0;
            // 
            // laboratorio_Impresion_MensajesTableAdapter
            // 
            this.laboratorio_Impresion_MensajesTableAdapter.ClearBeforeFill = true;
            // 
            // Impresion_Comprobante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 550);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Impresion_Comprobante";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.laboratorioImpresionMensajesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.impresionDAL1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private ImpresionDAL ImpresionDAL;
        private DAL.ImpresionDAL impresionDAL1;
        private System.Windows.Forms.BindingSource laboratorioImpresionMensajesBindingSource;
        private DAL.ImpresionDALTableAdapters.Laboratorio_Impresion_MensajesTableAdapter laboratorio_Impresion_MensajesTableAdapter;
    }
}