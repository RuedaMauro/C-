namespace Laboratorio2
{
    partial class frm_Cambiar_Doc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Cambiar_Doc));
            this.label1 = new System.Windows.Forms.Label();
            this.txt_doc_original = new System.Windows.Forms.TextBox();
            this.txt_doc_nuevo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_acepto_cambio = new System.Windows.Forms.CheckBox();
            this.lbl_apellido_actual = new System.Windows.Forms.Label();
            this.lbl_apellido_nuevo = new System.Windows.Forms.Label();
            this.btn_realizar_cambio = new System.Windows.Forms.Button();
            this.btn_salir = new System.Windows.Forms.Button();
            this.txt_sec_o = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_val1 = new System.Windows.Forms.Button();
            this.btn_val2 = new System.Windows.Forms.Button();
            this.cbo_tipo1 = new System.Windows.Forms.ComboBox();
            this.cbo_tipo2 = new System.Windows.Forms.ComboBox();
            this.genteDAL = new Laboratorio2.DAL.GenteDAL();
            this.tipodocumentoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tipo_documentoTableAdapter = new Laboratorio2.DAL.GenteDALTableAdapters.Tipo_documentoTableAdapter();
            this.genteDALBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tipodocumentoBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.genteDAL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipodocumentoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.genteDALBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipodocumentoBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 233);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "DOC. Actual";
            // 
            // txt_doc_original
            // 
            this.txt_doc_original.Enabled = false;
            this.txt_doc_original.Location = new System.Drawing.Point(173, 230);
            this.txt_doc_original.MaxLength = 8;
            this.txt_doc_original.Name = "txt_doc_original";
            this.txt_doc_original.Size = new System.Drawing.Size(64, 20);
            this.txt_doc_original.TabIndex = 1;
            this.txt_doc_original.Text = "99999999";
            this.txt_doc_original.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_doc_original_KeyDown);
            this.txt_doc_original.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_doc_original_KeyPress);
            // 
            // txt_doc_nuevo
            // 
            this.txt_doc_nuevo.Enabled = false;
            this.txt_doc_nuevo.Location = new System.Drawing.Point(173, 256);
            this.txt_doc_nuevo.MaxLength = 8;
            this.txt_doc_nuevo.Name = "txt_doc_nuevo";
            this.txt_doc_nuevo.Size = new System.Drawing.Size(64, 20);
            this.txt_doc_nuevo.TabIndex = 3;
            this.txt_doc_nuevo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_doc_nuevo_KeyDown);
            this.txt_doc_nuevo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_doc_nuevo_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 259);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "DOC. Nuevo";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(6, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(731, 159);
            this.label3.TabIndex = 4;
            this.label3.Text = resources.GetString("label3.Text");
            // 
            // cb_acepto_cambio
            // 
            this.cb_acepto_cambio.AutoSize = true;
            this.cb_acepto_cambio.Location = new System.Drawing.Point(12, 198);
            this.cb_acepto_cambio.Name = "cb_acepto_cambio";
            this.cb_acepto_cambio.Size = new System.Drawing.Size(105, 17);
            this.cb_acepto_cambio.TabIndex = 5;
            this.cb_acepto_cambio.Text = "Acepto el riesgo.";
            this.cb_acepto_cambio.UseVisualStyleBackColor = true;
            this.cb_acepto_cambio.CheckedChanged += new System.EventHandler(this.cb_acepto_cambio_CheckedChanged);
            // 
            // lbl_apellido_actual
            // 
            this.lbl_apellido_actual.Location = new System.Drawing.Point(280, 233);
            this.lbl_apellido_actual.Name = "lbl_apellido_actual";
            this.lbl_apellido_actual.Size = new System.Drawing.Size(265, 23);
            this.lbl_apellido_actual.TabIndex = 6;
            // 
            // lbl_apellido_nuevo
            // 
            this.lbl_apellido_nuevo.Location = new System.Drawing.Point(280, 259);
            this.lbl_apellido_nuevo.Name = "lbl_apellido_nuevo";
            this.lbl_apellido_nuevo.Size = new System.Drawing.Size(265, 23);
            this.lbl_apellido_nuevo.TabIndex = 7;
            // 
            // btn_realizar_cambio
            // 
            this.btn_realizar_cambio.Enabled = false;
            this.btn_realizar_cambio.Location = new System.Drawing.Point(12, 291);
            this.btn_realizar_cambio.Name = "btn_realizar_cambio";
            this.btn_realizar_cambio.Size = new System.Drawing.Size(273, 23);
            this.btn_realizar_cambio.TabIndex = 8;
            this.btn_realizar_cambio.Text = "Realizar Cambio";
            this.btn_realizar_cambio.UseVisualStyleBackColor = true;
            this.btn_realizar_cambio.Click += new System.EventHandler(this.btn_realizar_cambio_Click);
            // 
            // btn_salir
            // 
            this.btn_salir.Location = new System.Drawing.Point(445, 291);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(271, 23);
            this.btn_salir.TabIndex = 9;
            this.btn_salir.Text = "Salir";
            this.btn_salir.UseVisualStyleBackColor = true;
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // txt_sec_o
            // 
            this.txt_sec_o.Enabled = false;
            this.txt_sec_o.Location = new System.Drawing.Point(627, 230);
            this.txt_sec_o.MaxLength = 3;
            this.txt_sec_o.Name = "txt_sec_o";
            this.txt_sec_o.Size = new System.Drawing.Size(45, 20);
            this.txt_sec_o.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(564, 233);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Seccional:";
            // 
            // btn_val1
            // 
            this.btn_val1.Enabled = false;
            this.btn_val1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_val1.Image = ((System.Drawing.Image)(resources.GetObject("btn_val1.Image")));
            this.btn_val1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_val1.Location = new System.Drawing.Point(243, 228);
            this.btn_val1.Name = "btn_val1";
            this.btn_val1.Size = new System.Drawing.Size(31, 26);
            this.btn_val1.TabIndex = 13;
            this.btn_val1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_val1.UseVisualStyleBackColor = true;
            this.btn_val1.Click += new System.EventHandler(this.btn_val1_Click);
            // 
            // btn_val2
            // 
            this.btn_val2.Enabled = false;
            this.btn_val2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_val2.Image = ((System.Drawing.Image)(resources.GetObject("btn_val2.Image")));
            this.btn_val2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_val2.Location = new System.Drawing.Point(243, 254);
            this.btn_val2.Name = "btn_val2";
            this.btn_val2.Size = new System.Drawing.Size(31, 26);
            this.btn_val2.TabIndex = 14;
            this.btn_val2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_val2.UseVisualStyleBackColor = true;
            this.btn_val2.Click += new System.EventHandler(this.btn_val2_Click);
            // 
            // cbo_tipo1
            // 
            this.cbo_tipo1.DataSource = this.tipodocumentoBindingSource;
            this.cbo_tipo1.DisplayMember = "descri";
            this.cbo_tipo1.Enabled = false;
            this.cbo_tipo1.FormattingEnabled = true;
            this.cbo_tipo1.Location = new System.Drawing.Point(83, 230);
            this.cbo_tipo1.Name = "cbo_tipo1";
            this.cbo_tipo1.Size = new System.Drawing.Size(84, 21);
            this.cbo_tipo1.TabIndex = 15;
            this.cbo_tipo1.ValueMember = "cod";
            // 
            // cbo_tipo2
            // 
            this.cbo_tipo2.DataSource = this.tipodocumentoBindingSource1;
            this.cbo_tipo2.DisplayMember = "descri";
            this.cbo_tipo2.Enabled = false;
            this.cbo_tipo2.FormattingEnabled = true;
            this.cbo_tipo2.Location = new System.Drawing.Point(83, 256);
            this.cbo_tipo2.Name = "cbo_tipo2";
            this.cbo_tipo2.Size = new System.Drawing.Size(84, 21);
            this.cbo_tipo2.TabIndex = 16;
            this.cbo_tipo2.ValueMember = "cod";
            // 
            // genteDAL
            // 
            this.genteDAL.DataSetName = "GenteDAL";
            this.genteDAL.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tipodocumentoBindingSource
            // 
            this.tipodocumentoBindingSource.DataMember = "Tipo_documento";
            this.tipodocumentoBindingSource.DataSource = this.genteDAL;
            // 
            // tipo_documentoTableAdapter
            // 
            this.tipo_documentoTableAdapter.ClearBeforeFill = true;
            // 
            // genteDALBindingSource
            // 
            this.genteDALBindingSource.DataSource = this.genteDAL;
            this.genteDALBindingSource.Position = 0;
            // 
            // tipodocumentoBindingSource1
            // 
            this.tipodocumentoBindingSource1.DataMember = "Tipo_documento";
            this.tipodocumentoBindingSource1.DataSource = this.genteDALBindingSource;
            // 
            // frm_Cambiar_Doc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(749, 333);
            this.Controls.Add(this.cbo_tipo2);
            this.Controls.Add(this.cbo_tipo1);
            this.Controls.Add(this.btn_val2);
            this.Controls.Add(this.btn_val1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_sec_o);
            this.Controls.Add(this.btn_salir);
            this.Controls.Add(this.btn_realizar_cambio);
            this.Controls.Add(this.lbl_apellido_nuevo);
            this.Controls.Add(this.lbl_apellido_actual);
            this.Controls.Add(this.cb_acepto_cambio);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_doc_nuevo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_doc_original);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_Cambiar_Doc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_Cambiar_Doc";
            this.Load += new System.EventHandler(this.frm_Cambiar_Doc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.genteDAL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipodocumentoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.genteDALBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipodocumentoBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_doc_original;
        private System.Windows.Forms.TextBox txt_doc_nuevo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cb_acepto_cambio;
        private System.Windows.Forms.Label lbl_apellido_actual;
        private System.Windows.Forms.Label lbl_apellido_nuevo;
        private System.Windows.Forms.Button btn_realizar_cambio;
        private System.Windows.Forms.Button btn_salir;
        private System.Windows.Forms.TextBox txt_sec_o;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_val1;
        private System.Windows.Forms.Button btn_val2;
        private System.Windows.Forms.ComboBox cbo_tipo1;
        private System.Windows.Forms.ComboBox cbo_tipo2;
        private DAL.GenteDAL genteDAL;
        private System.Windows.Forms.BindingSource tipodocumentoBindingSource;
        private DAL.GenteDALTableAdapters.Tipo_documentoTableAdapter tipo_documentoTableAdapter;
        private System.Windows.Forms.BindingSource tipodocumentoBindingSource1;
        private System.Windows.Forms.BindingSource genteDALBindingSource;
    }
}