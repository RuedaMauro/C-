namespace Laboratorio2
{
    partial class ListarPacientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListarPacientes));
            this.btn_Buscar = new System.Windows.Forms.Button();
            this.txt_DNI = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_NHC = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_AyN = new System.Windows.Forms.TextBox();
            this.gv_Pacientes = new System.Windows.Forms.DataGridView();
            this.Nro_Busqueda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NHC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Paciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo_doc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Documento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PacienteID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_HC_UOM = new System.Windows.Forms.TextBox();
            this.cbo_Tipo_Doc = new System.Windows.Forms.ComboBox();
            this.tipodocumentoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.genteDAL = new Laboratorio2.DAL.GenteDAL();
            this.tipo_documentoTableAdapter = new Laboratorio2.DAL.GenteDALTableAdapters.Tipo_documentoTableAdapter();
            this.txt_paciente_id = new System.Windows.Forms.TextBox();
            this.gb_buscar = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Pacientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipodocumentoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.genteDAL)).BeginInit();
            this.gb_buscar.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Buscar
            // 
            this.btn_Buscar.Image = ((System.Drawing.Image)(resources.GetObject("btn_Buscar.Image")));
            this.btn_Buscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Buscar.Location = new System.Drawing.Point(571, 123);
            this.btn_Buscar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_Buscar.Name = "btn_Buscar";
            this.btn_Buscar.Size = new System.Drawing.Size(84, 31);
            this.btn_Buscar.TabIndex = 4;
            this.btn_Buscar.Text = "Buscar";
            this.btn_Buscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Buscar.UseVisualStyleBackColor = true;
            this.btn_Buscar.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_DNI
            // 
            this.txt_DNI.Location = new System.Drawing.Point(160, 73);
            this.txt_DNI.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_DNI.MaxLength = 8;
            this.txt_DNI.Name = "txt_DNI";
            this.txt_DNI.Size = new System.Drawing.Size(271, 22);
            this.txt_DNI.TabIndex = 1;
            this.txt_DNI.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_DNI_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(105, 103);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 14);
            this.label1.TabIndex = 45;
            this.label1.Text = "CUIL:";
            // 
            // txt_NHC
            // 
            this.txt_NHC.Location = new System.Drawing.Point(160, 103);
            this.txt_NHC.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_NHC.MaxLength = 11;
            this.txt_NHC.Name = "txt_NHC";
            this.txt_NHC.Size = new System.Drawing.Size(271, 22);
            this.txt_NHC.TabIndex = 2;
            this.txt_NHC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_NHC_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 131);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 14);
            this.label2.TabIndex = 47;
            this.label2.Text = "Apellido y Nombre:";
            // 
            // txt_AyN
            // 
            this.txt_AyN.Location = new System.Drawing.Point(160, 129);
            this.txt_AyN.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_AyN.MaxLength = 20;
            this.txt_AyN.Name = "txt_AyN";
            this.txt_AyN.Size = new System.Drawing.Size(271, 22);
            this.txt_AyN.TabIndex = 3;
            this.txt_AyN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_AyN_KeyDown);
            // 
            // gv_Pacientes
            // 
            this.gv_Pacientes.AllowUserToAddRows = false;
            this.gv_Pacientes.AllowUserToDeleteRows = false;
            this.gv_Pacientes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gv_Pacientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv_Pacientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nro_Busqueda,
            this.NHC,
            this.Paciente,
            this.tipo_doc,
            this.Documento,
            this.Telefono,
            this.PacienteID});
            this.gv_Pacientes.Location = new System.Drawing.Point(21, 180);
            this.gv_Pacientes.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gv_Pacientes.Name = "gv_Pacientes";
            this.gv_Pacientes.ReadOnly = true;
            this.gv_Pacientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gv_Pacientes.Size = new System.Drawing.Size(634, 350);
            this.gv_Pacientes.TabIndex = 5;
            this.gv_Pacientes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gv_Pacientes_CellClick);
            // 
            // Nro_Busqueda
            // 
            this.Nro_Busqueda.DataPropertyName = "Nro_Busqueda";
            this.Nro_Busqueda.HeaderText = "#";
            this.Nro_Busqueda.Name = "Nro_Busqueda";
            this.Nro_Busqueda.ReadOnly = true;
            this.Nro_Busqueda.Visible = false;
            // 
            // NHC
            // 
            this.NHC.DataPropertyName = "HC_UOM";
            this.NHC.HeaderText = "NHC";
            this.NHC.Name = "NHC";
            this.NHC.ReadOnly = true;
            // 
            // Paciente
            // 
            this.Paciente.DataPropertyName = "Paciente";
            this.Paciente.HeaderText = "Paciente";
            this.Paciente.Name = "Paciente";
            this.Paciente.ReadOnly = true;
            // 
            // tipo_doc
            // 
            this.tipo_doc.DataPropertyName = "Tipo_Documento";
            this.tipo_doc.HeaderText = "Tipo Doc";
            this.tipo_doc.Name = "tipo_doc";
            this.tipo_doc.ReadOnly = true;
            // 
            // Documento
            // 
            this.Documento.DataPropertyName = "documento_real";
            this.Documento.HeaderText = "Documento";
            this.Documento.Name = "Documento";
            this.Documento.ReadOnly = true;
            // 
            // Telefono
            // 
            this.Telefono.DataPropertyName = "Telefono";
            this.Telefono.HeaderText = "Teléfono";
            this.Telefono.Name = "Telefono";
            this.Telefono.ReadOnly = true;
            // 
            // PacienteID
            // 
            this.PacienteID.DataPropertyName = "documento";
            this.PacienteID.HeaderText = "paciente_id";
            this.PacienteID.Name = "PacienteID";
            this.PacienteID.ReadOnly = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(115, 44);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 14);
            this.label3.TabIndex = 49;
            this.label3.Text = "HC:";
            // 
            // txt_HC_UOM
            // 
            this.txt_HC_UOM.Location = new System.Drawing.Point(160, 42);
            this.txt_HC_UOM.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_HC_UOM.MaxLength = 15;
            this.txt_HC_UOM.Name = "txt_HC_UOM";
            this.txt_HC_UOM.Size = new System.Drawing.Size(271, 22);
            this.txt_HC_UOM.TabIndex = 0;
            this.txt_HC_UOM.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_HC_UOM_KeyDown);
            // 
            // cbo_Tipo_Doc
            // 
            this.cbo_Tipo_Doc.DataSource = this.tipodocumentoBindingSource;
            this.cbo_Tipo_Doc.DisplayMember = "descri";
            this.cbo_Tipo_Doc.FormattingEnabled = true;
            this.cbo_Tipo_Doc.Location = new System.Drawing.Point(26, 73);
            this.cbo_Tipo_Doc.Name = "cbo_Tipo_Doc";
            this.cbo_Tipo_Doc.Size = new System.Drawing.Size(121, 22);
            this.cbo_Tipo_Doc.TabIndex = 68;
            this.cbo_Tipo_Doc.ValueMember = "cod";
            // 
            // tipodocumentoBindingSource
            // 
            this.tipodocumentoBindingSource.DataMember = "Tipo_documento";
            this.tipodocumentoBindingSource.DataSource = this.genteDAL;
            // 
            // genteDAL
            // 
            this.genteDAL.DataSetName = "GenteDAL";
            this.genteDAL.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tipo_documentoTableAdapter
            // 
            this.tipo_documentoTableAdapter.ClearBeforeFill = true;
            // 
            // txt_paciente_id
            // 
            this.txt_paciente_id.Location = new System.Drawing.Point(160, 14);
            this.txt_paciente_id.Name = "txt_paciente_id";
            this.txt_paciente_id.Size = new System.Drawing.Size(271, 22);
            this.txt_paciente_id.TabIndex = 69;
            this.txt_paciente_id.Visible = false;
            // 
            // gb_buscar
            // 
            this.gb_buscar.Controls.Add(this.label4);
            this.gb_buscar.Location = new System.Drawing.Point(12, 169);
            this.gb_buscar.Name = "gb_buscar";
            this.gb_buscar.Size = new System.Drawing.Size(653, 381);
            this.gb_buscar.TabIndex = 70;
            this.gb_buscar.TabStop = false;
            this.gb_buscar.Visible = false;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(653, 176);
            this.label4.TabIndex = 0;
            this.label4.Text = "Buscando....";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ListarPacientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(677, 562);
            this.Controls.Add(this.gb_buscar);
            this.Controls.Add(this.txt_paciente_id);
            this.Controls.Add(this.cbo_Tipo_Doc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_HC_UOM);
            this.Controls.Add(this.gv_Pacientes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_AyN);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_NHC);
            this.Controls.Add(this.txt_DNI);
            this.Controls.Add(this.btn_Buscar);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ListarPacientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar Paciente";
            this.Load += new System.EventHandler(this.ListarPacientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gv_Pacientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipodocumentoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.genteDAL)).EndInit();
            this.gb_buscar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_DNI;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_NHC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_AyN;
        private System.Windows.Forms.DataGridView gv_Pacientes;
        public System.Windows.Forms.Button btn_Buscar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_HC_UOM;
        private System.Windows.Forms.ComboBox cbo_Tipo_Doc;
        private DAL.GenteDAL genteDAL;
        private System.Windows.Forms.BindingSource tipodocumentoBindingSource;
        private DAL.GenteDALTableAdapters.Tipo_documentoTableAdapter tipo_documentoTableAdapter;
        private System.Windows.Forms.TextBox txt_paciente_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nro_Busqueda;
        private System.Windows.Forms.DataGridViewTextBoxColumn NHC;
        private System.Windows.Forms.DataGridViewTextBoxColumn Paciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo_doc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Documento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn PacienteID;
        private System.Windows.Forms.GroupBox gb_buscar;
        private System.Windows.Forms.Label label4;
    }
}