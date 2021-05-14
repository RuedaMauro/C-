namespace Laboratorio2
{
    partial class BuscarOrdenes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BuscarOrdenes));
            this.gv_Ordenes = new System.Windows.Forms.DataGridView();
            this.Titular = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Paciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo_doc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.documento_real = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodOrden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NH_UOM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pacienteid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_AyN = new System.Windows.Forms.TextBox();
            this.txt_DNI = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_fechaI = new System.Windows.Forms.DateTimePicker();
            this.txt_FechaF = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_Protocolo = new System.Windows.Forms.TextBox();
            this.btn_Buscar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_HC = new System.Windows.Forms.TextBox();
            this.cbo_tipo_doc = new System.Windows.Forms.ComboBox();
            this.tipodocumentoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.genteDAL = new Laboratorio2.DAL.GenteDAL();
            this.tipo_documentoTableAdapter = new Laboratorio2.DAL.GenteDALTableAdapters.Tipo_documentoTableAdapter();
            this.label4 = new System.Windows.Forms.Label();
            this.gb_buscar = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Ordenes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipodocumentoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.genteDAL)).BeginInit();
            this.gb_buscar.SuspendLayout();
            this.SuspendLayout();
            // 
            // gv_Ordenes
            // 
            this.gv_Ordenes.AllowUserToAddRows = false;
            this.gv_Ordenes.AllowUserToDeleteRows = false;
            this.gv_Ordenes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gv_Ordenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv_Ordenes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Titular,
            this.Paciente,
            this.Tipo_doc,
            this.documento_real,
            this.Telefono,
            this.CodOrden,
            this.Estado,
            this.NH_UOM,
            this.Pacienteid});
            this.gv_Ordenes.Location = new System.Drawing.Point(24, 208);
            this.gv_Ordenes.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gv_Ordenes.Name = "gv_Ordenes";
            this.gv_Ordenes.ReadOnly = true;
            this.gv_Ordenes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gv_Ordenes.Size = new System.Drawing.Size(681, 321);
            this.gv_Ordenes.TabIndex = 7;
            this.gv_Ordenes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gv_Ordenes_CellClick);
            // 
            // Titular
            // 
            this.Titular.DataPropertyName = "Protocolo";
            this.Titular.HeaderText = "Protocolo";
            this.Titular.Name = "Titular";
            this.Titular.ReadOnly = true;
            // 
            // Paciente
            // 
            this.Paciente.DataPropertyName = "fecha";
            this.Paciente.HeaderText = "Fecha Ingreso";
            this.Paciente.Name = "Paciente";
            this.Paciente.ReadOnly = true;
            // 
            // Tipo_doc
            // 
            this.Tipo_doc.DataPropertyName = "Tipo_Doc";
            this.Tipo_doc.HeaderText = "Tipo";
            this.Tipo_doc.Name = "Tipo_doc";
            this.Tipo_doc.ReadOnly = true;
            this.Tipo_doc.Width = 50;
            // 
            // documento_real
            // 
            this.documento_real.DataPropertyName = "Documento";
            this.documento_real.HeaderText = "Documento";
            this.documento_real.Name = "documento_real";
            this.documento_real.ReadOnly = true;
            // 
            // Telefono
            // 
            this.Telefono.DataPropertyName = "Paciente";
            this.Telefono.HeaderText = "Paciente";
            this.Telefono.Name = "Telefono";
            this.Telefono.ReadOnly = true;
            // 
            // CodOrden
            // 
            this.CodOrden.DataPropertyName = "CodOrden";
            this.CodOrden.HeaderText = "CodOrden";
            this.CodOrden.Name = "CodOrden";
            this.CodOrden.ReadOnly = true;
            this.CodOrden.Visible = false;
            // 
            // Estado
            // 
            this.Estado.DataPropertyName = "Estado";
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            this.Estado.Visible = false;
            // 
            // NH_UOM
            // 
            this.NH_UOM.DataPropertyName = "NH_UOM";
            this.NH_UOM.HeaderText = "HC";
            this.NH_UOM.Name = "NH_UOM";
            this.NH_UOM.ReadOnly = true;
            // 
            // Pacienteid
            // 
            this.Pacienteid.DataPropertyName = "Paciente_id";
            this.Pacienteid.HeaderText = "Paciente_id";
            this.Pacienteid.Name = "Pacienteid";
            this.Pacienteid.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 165);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 14);
            this.label2.TabIndex = 56;
            this.label2.Text = "Apellido y Nombre:";
            // 
            // txt_AyN
            // 
            this.txt_AyN.Location = new System.Drawing.Point(163, 163);
            this.txt_AyN.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_AyN.MaxLength = 20;
            this.txt_AyN.Name = "txt_AyN";
            this.txt_AyN.Size = new System.Drawing.Size(271, 20);
            this.txt_AyN.TabIndex = 5;
            this.txt_AyN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_AyN_KeyDown);
            // 
            // txt_DNI
            // 
            this.txt_DNI.Location = new System.Drawing.Point(163, 106);
            this.txt_DNI.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_DNI.MaxLength = 8;
            this.txt_DNI.Name = "txt_DNI";
            this.txt_DNI.Size = new System.Drawing.Size(271, 20);
            this.txt_DNI.TabIndex = 3;
            this.txt_DNI.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_DNI_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(57, 82);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 14);
            this.label1.TabIndex = 58;
            this.label1.Text = "Fecha Desde:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(262, 82);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 14);
            this.label3.TabIndex = 60;
            this.label3.Text = "Fecha Hasta:";
            // 
            // txt_fechaI
            // 
            this.txt_fechaI.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txt_fechaI.Location = new System.Drawing.Point(163, 80);
            this.txt_fechaI.Name = "txt_fechaI";
            this.txt_fechaI.Size = new System.Drawing.Size(84, 20);
            this.txt_fechaI.TabIndex = 1;
            this.txt_fechaI.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_fechaI_KeyDown);
            // 
            // txt_FechaF
            // 
            this.txt_FechaF.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txt_FechaF.Location = new System.Drawing.Point(351, 80);
            this.txt_FechaF.Name = "txt_FechaF";
            this.txt_FechaF.Size = new System.Drawing.Size(84, 20);
            this.txt_FechaF.TabIndex = 2;
            this.txt_FechaF.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_FechaF_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(49, 53);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 14);
            this.label5.TabIndex = 64;
            this.label5.Text = "Nro. Protocolo:";
            // 
            // txt_Protocolo
            // 
            this.txt_Protocolo.Location = new System.Drawing.Point(163, 51);
            this.txt_Protocolo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_Protocolo.MaxLength = 10;
            this.txt_Protocolo.Name = "txt_Protocolo";
            this.txt_Protocolo.Size = new System.Drawing.Size(271, 20);
            this.txt_Protocolo.TabIndex = 0;
            this.txt_Protocolo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Protocolo_KeyDown);
            // 
            // btn_Buscar
            // 
            this.btn_Buscar.Image = ((System.Drawing.Image)(resources.GetObject("btn_Buscar.Image")));
            this.btn_Buscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Buscar.Location = new System.Drawing.Point(465, 152);
            this.btn_Buscar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_Buscar.Name = "btn_Buscar";
            this.btn_Buscar.Size = new System.Drawing.Size(84, 31);
            this.btn_Buscar.TabIndex = 6;
            this.btn_Buscar.Text = "Buscar";
            this.btn_Buscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Buscar.UseVisualStyleBackColor = true;
            this.btn_Buscar.Click += new System.EventHandler(this.btn_Buscar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(115, 137);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 14);
            this.label6.TabIndex = 66;
            this.label6.Text = "HC:";
            // 
            // txt_HC
            // 
            this.txt_HC.Location = new System.Drawing.Point(163, 135);
            this.txt_HC.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_HC.MaxLength = 15;
            this.txt_HC.Name = "txt_HC";
            this.txt_HC.Size = new System.Drawing.Size(271, 20);
            this.txt_HC.TabIndex = 4;
            this.txt_HC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_HC_KeyDown);
            // 
            // cbo_tipo_doc
            // 
            this.cbo_tipo_doc.DataSource = this.tipodocumentoBindingSource;
            this.cbo_tipo_doc.DisplayMember = "descri";
            this.cbo_tipo_doc.FormattingEnabled = true;
            this.cbo_tipo_doc.Location = new System.Drawing.Point(24, 105);
            this.cbo_tipo_doc.Name = "cbo_tipo_doc";
            this.cbo_tipo_doc.Size = new System.Drawing.Size(121, 21);
            this.cbo_tipo_doc.TabIndex = 67;
            this.cbo_tipo_doc.ValueMember = "cod";
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
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(693, 106);
            this.label4.TabIndex = 0;
            this.label4.Text = "Buscando....";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gb_buscar
            // 
            this.gb_buscar.Controls.Add(this.label4);
            this.gb_buscar.Location = new System.Drawing.Point(12, 196);
            this.gb_buscar.Name = "gb_buscar";
            this.gb_buscar.Size = new System.Drawing.Size(705, 361);
            this.gb_buscar.TabIndex = 68;
            this.gb_buscar.TabStop = false;
            this.gb_buscar.Visible = false;
            // 
            // BuscarOrdenes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(733, 569);
            this.Controls.Add(this.gb_buscar);
            this.Controls.Add(this.cbo_tipo_doc);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_HC);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_Protocolo);
            this.Controls.Add(this.txt_FechaF);
            this.Controls.Add(this.txt_fechaI);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gv_Ordenes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_AyN);
            this.Controls.Add(this.txt_DNI);
            this.Controls.Add(this.btn_Buscar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BuscarOrdenes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BuscarOrdenes";
            this.Load += new System.EventHandler(this.BuscarOrdenes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gv_Ordenes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipodocumentoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.genteDAL)).EndInit();
            this.gb_buscar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gv_Ordenes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_AyN;
        private System.Windows.Forms.TextBox txt_DNI;
        public System.Windows.Forms.Button btn_Buscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker txt_fechaI;
        private System.Windows.Forms.DateTimePicker txt_FechaF;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_Protocolo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_HC;
        private System.Windows.Forms.ComboBox cbo_tipo_doc;
        private DAL.GenteDAL genteDAL;
        private System.Windows.Forms.BindingSource tipodocumentoBindingSource;
        private DAL.GenteDALTableAdapters.Tipo_documentoTableAdapter tipo_documentoTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Titular;
        private System.Windows.Forms.DataGridViewTextBoxColumn Paciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo_doc;
        private System.Windows.Forms.DataGridViewTextBoxColumn documento_real;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodOrden;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn NH_UOM;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pacienteid;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gb_buscar;
    }
}