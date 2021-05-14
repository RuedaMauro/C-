namespace Laboratorio2
{
    partial class frm_t_tubo
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
            this.ls_grupos = new System.Windows.Forms.ListBox();
            this.grupotubosBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.grupoTubosDAL = new Laboratorio2.DAL.GrupoTubosDAL();
            this.txt_cant_etiquetas = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_nombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.laboratorioDataSet1 = new Laboratorio2.DAL.LaboratorioDataSet1();
            this.grupotubosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grupo_tubosTableAdapter = new Laboratorio2.DAL.LaboratorioDataSet1TableAdapters.grupo_tubosTableAdapter();
            this.grupo_tubosTableAdapter1 = new Laboratorio2.DAL.GrupoTubosDALTableAdapters.grupo_tubosTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.grupotubosBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grupoTubosDAL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.laboratorioDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grupotubosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ls_grupos
            // 
            this.ls_grupos.DataSource = this.grupotubosBindingSource1;
            this.ls_grupos.DisplayMember = "descripcion";
            this.ls_grupos.FormattingEnabled = true;
            this.ls_grupos.Location = new System.Drawing.Point(12, 13);
            this.ls_grupos.Name = "ls_grupos";
            this.ls_grupos.Size = new System.Drawing.Size(337, 134);
            this.ls_grupos.TabIndex = 5;
            this.ls_grupos.ValueMember = "grupo_id";
            this.ls_grupos.Click += new System.EventHandler(this.ls_grupos_Click);
            // 
            // grupotubosBindingSource1
            // 
            this.grupotubosBindingSource1.DataMember = "grupo_tubos";
            this.grupotubosBindingSource1.DataSource = this.grupoTubosDAL;
            // 
            // grupoTubosDAL
            // 
            this.grupoTubosDAL.DataSetName = "GrupoTubosDAL";
            this.grupoTubosDAL.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txt_cant_etiquetas
            // 
            this.txt_cant_etiquetas.Location = new System.Drawing.Point(306, 163);
            this.txt_cant_etiquetas.MaxLength = 2;
            this.txt_cant_etiquetas.Name = "txt_cant_etiquetas";
            this.txt_cant_etiquetas.Size = new System.Drawing.Size(43, 20);
            this.txt_cant_etiquetas.TabIndex = 32;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(219, 167);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 13);
            this.label8.TabIndex = 31;
            this.label8.Text = "Cant. etiquetas:";
            // 
            // txt_nombre
            // 
            this.txt_nombre.Location = new System.Drawing.Point(60, 163);
            this.txt_nombre.MaxLength = 20;
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.Size = new System.Drawing.Size(138, 20);
            this.txt_nombre.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Grupo:";
            // 
            // btn_guardar
            // 
            this.btn_guardar.Location = new System.Drawing.Point(160, 202);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(90, 23);
            this.btn_guardar.TabIndex = 33;
            this.btn_guardar.Text = "Guardar";
            this.btn_guardar.UseVisualStyleBackColor = true;
            this.btn_guardar.Click += new System.EventHandler(this.btn_guardar_Click);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.Location = new System.Drawing.Point(256, 202);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(90, 23);
            this.btn_cancelar.TabIndex = 34;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // laboratorioDataSet1
            // 
            this.laboratorioDataSet1.DataSetName = "LaboratorioDataSet1";
            this.laboratorioDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // grupotubosBindingSource
            // 
            this.grupotubosBindingSource.DataMember = "grupo_tubos";
            this.grupotubosBindingSource.DataSource = this.laboratorioDataSet1;
            // 
            // grupo_tubosTableAdapter
            // 
            this.grupo_tubosTableAdapter.ClearBeforeFill = true;
            // 
            // grupo_tubosTableAdapter1
            // 
            this.grupo_tubosTableAdapter1.ClearBeforeFill = true;
            // 
            // frm_t_tubo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 237);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.btn_guardar);
            this.Controls.Add(this.txt_cant_etiquetas);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_nombre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ls_grupos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frm_t_tubo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agrupar tubos";
            this.Load += new System.EventHandler(this.frm_t_tubo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grupotubosBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grupoTubosDAL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.laboratorioDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grupotubosBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ls_grupos;
        private System.Windows.Forms.TextBox txt_cant_etiquetas;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_nombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_guardar;
        private System.Windows.Forms.Button btn_cancelar;
        private DAL.LaboratorioDataSet1 laboratorioDataSet1;
        private System.Windows.Forms.BindingSource grupotubosBindingSource;
        private DAL.LaboratorioDataSet1TableAdapters.grupo_tubosTableAdapter grupo_tubosTableAdapter;
        private DAL.GrupoTubosDAL grupoTubosDAL;
        private System.Windows.Forms.BindingSource grupotubosBindingSource1;
        private DAL.GrupoTubosDALTableAdapters.grupo_tubosTableAdapter grupo_tubosTableAdapter1;
    }
}