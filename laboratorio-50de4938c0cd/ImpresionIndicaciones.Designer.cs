namespace Laboratorio2
{
    partial class ImpresionIndicaciones
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.impresionDAL1 = new Laboratorio2.DAL.ImpresionDAL();
            this.listaIndicacionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.laboratorioImpresionMensajesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.laboratorio_Impresion_MensajesTableAdapter = new Laboratorio2.DAL.ImpresionDALTableAdapters.Laboratorio_Impresion_MensajesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.impresionDAL1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listaIndicacionesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.laboratorioImpresionMensajesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.listaIndicacionesBindingSource;
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = this.laboratorioImpresionMensajesBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Laboratorio2.ImpresionIndicaciones.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(839, 382);
            this.reportViewer1.TabIndex = 0;
            // 
            // impresionDAL1
            // 
            this.impresionDAL1.DataSetName = "ImpresionDAL";
            this.impresionDAL1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // listaIndicacionesBindingSource
            // 
            this.listaIndicacionesBindingSource.DataMember = "Lista_Indicaciones";
            this.listaIndicacionesBindingSource.DataSource = this.impresionDAL1;
            // 
            // laboratorioImpresionMensajesBindingSource
            // 
            this.laboratorioImpresionMensajesBindingSource.DataMember = "Laboratorio_Impresion_Mensajes";
            this.laboratorioImpresionMensajesBindingSource.DataSource = this.impresionDAL1;
            // 
            // laboratorio_Impresion_MensajesTableAdapter
            // 
            this.laboratorio_Impresion_MensajesTableAdapter.ClearBeforeFill = true;
            // 
            // ImpresionIndicaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 417);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ImpresionIndicaciones";
            this.Text = "ImpresionIndicaciones";
            this.Load += new System.EventHandler(this.ImpresionIndicaciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.impresionDAL1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listaIndicacionesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.laboratorioImpresionMensajesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ImpresionDAL ImpresionDAL;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DAL.ImpresionDAL impresionDAL1;
        private System.Windows.Forms.BindingSource listaIndicacionesBindingSource;
        private System.Windows.Forms.BindingSource laboratorioImpresionMensajesBindingSource;
        private DAL.ImpresionDALTableAdapters.Laboratorio_Impresion_MensajesTableAdapter laboratorio_Impresion_MensajesTableAdapter;
    }
}