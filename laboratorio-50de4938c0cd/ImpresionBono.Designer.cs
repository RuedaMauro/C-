namespace Laboratorio2
{
    partial class ImpresionBono
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImpresionBono));
            this.btn_imprimir = new System.Windows.Forms.Button();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.lTotal = new System.Windows.Forms.Label();
            this.gb1 = new System.Windows.Forms.GroupBox();
            this.gv_bono = new System.Windows.Forms.DataGridView();
            this.Practica_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubPractica_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Practica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubPractica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gb2 = new System.Windows.Forms.GroupBox();
            this.txt_comentario = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbo_motivo = new System.Windows.Forms.ComboBox();
            this.h2BONOSAUTORIZAMOTIVOSLISTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bonoDAL = new Laboratorio2.DAL.BonoDAL();
            this.cbo_autorizante = new System.Windows.Forms.ComboBox();
            this.h2BONOSAUTORIZANTELISTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ck_nopaga = new System.Windows.Forms.CheckBox();
            this.h2_BONOS_AUTORIZANTE_LISTTableAdapter = new Laboratorio2.DAL.BonoDALTableAdapters.H2_BONOS_AUTORIZANTE_LISTTableAdapter();
            this.h2_BONOS_AUTORIZA_MOTIVOS_LISTTableAdapter = new Laboratorio2.DAL.BonoDALTableAdapters.H2_BONOS_AUTORIZA_MOTIVOS_LISTTableAdapter();
            this.label_info = new System.Windows.Forms.Label();
            this.LNopaga = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.gb1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv_bono)).BeginInit();
            this.gb2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.h2BONOSAUTORIZAMOTIVOSLISTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bonoDAL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.h2BONOSAUTORIZANTELISTBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_imprimir
            // 
            this.btn_imprimir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_imprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_imprimir.Location = new System.Drawing.Point(12, 421);
            this.btn_imprimir.Name = "btn_imprimir";
            this.btn_imprimir.Size = new System.Drawing.Size(75, 23);
            this.btn_imprimir.TabIndex = 1;
            this.btn_imprimir.Text = "Imprimir";
            this.btn_imprimir.UseVisualStyleBackColor = false;
            this.btn_imprimir.Click += new System.EventHandler(this.btn_imprimir_Click);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancelar.ForeColor = System.Drawing.Color.White;
            this.btn_cancelar.Location = new System.Drawing.Point(93, 421);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(75, 23);
            this.btn_cancelar.TabIndex = 2;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.UseVisualStyleBackColor = false;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // lTotal
            // 
            this.lTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTotal.Location = new System.Drawing.Point(190, 421);
            this.lTotal.Name = "lTotal";
            this.lTotal.Size = new System.Drawing.Size(415, 23);
            this.lTotal.TabIndex = 3;
            this.lTotal.Text = "Total: $00,00";
            this.lTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gb1
            // 
            this.gb1.Controls.Add(this.gv_bono);
            this.gb1.Location = new System.Drawing.Point(12, 54);
            this.gb1.Name = "gb1";
            this.gb1.Size = new System.Drawing.Size(599, 288);
            this.gb1.TabIndex = 5;
            this.gb1.TabStop = false;
            // 
            // gv_bono
            // 
            this.gv_bono.AllowUserToAddRows = false;
            this.gv_bono.AllowUserToDeleteRows = false;
            this.gv_bono.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv_bono.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Practica_Id,
            this.SubPractica_Id,
            this.Practica,
            this.SubPractica,
            this.Precio});
            this.gv_bono.Location = new System.Drawing.Point(6, 19);
            this.gv_bono.Name = "gv_bono";
            this.gv_bono.ReadOnly = true;
            this.gv_bono.Size = new System.Drawing.Size(587, 263);
            this.gv_bono.TabIndex = 1;
            // 
            // Practica_Id
            // 
            this.Practica_Id.HeaderText = "Código Práctica";
            this.Practica_Id.Name = "Practica_Id";
            this.Practica_Id.ReadOnly = true;
            // 
            // SubPractica_Id
            // 
            this.SubPractica_Id.HeaderText = "Código SubPráctica";
            this.SubPractica_Id.Name = "SubPractica_Id";
            this.SubPractica_Id.ReadOnly = true;
            // 
            // Practica
            // 
            this.Practica.HeaderText = "Práctica";
            this.Practica.Name = "Practica";
            this.Practica.ReadOnly = true;
            // 
            // SubPractica
            // 
            this.SubPractica.HeaderText = "Sub-Práctica";
            this.SubPractica.Name = "SubPractica";
            this.SubPractica.ReadOnly = true;
            // 
            // Precio
            // 
            this.Precio.HeaderText = "Precio";
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
            // 
            // gb2
            // 
            this.gb2.Controls.Add(this.txt_comentario);
            this.gb2.Controls.Add(this.label4);
            this.gb2.Controls.Add(this.cbo_motivo);
            this.gb2.Controls.Add(this.cbo_autorizante);
            this.gb2.Controls.Add(this.label3);
            this.gb2.Controls.Add(this.label2);
            this.gb2.Controls.Add(this.ck_nopaga);
            this.gb2.Location = new System.Drawing.Point(12, 348);
            this.gb2.Name = "gb2";
            this.gb2.Size = new System.Drawing.Size(599, 69);
            this.gb2.TabIndex = 6;
            this.gb2.TabStop = false;
            // 
            // txt_comentario
            // 
            this.txt_comentario.Location = new System.Drawing.Point(176, 42);
            this.txt_comentario.Name = "txt_comentario";
            this.txt_comentario.Size = new System.Drawing.Size(417, 20);
            this.txt_comentario.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(109, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Comentario:";
            // 
            // cbo_motivo
            // 
            this.cbo_motivo.DataSource = this.h2BONOSAUTORIZAMOTIVOSLISTBindingSource;
            this.cbo_motivo.DisplayMember = "Motivo";
            this.cbo_motivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_motivo.Enabled = false;
            this.cbo_motivo.FormattingEnabled = true;
            this.cbo_motivo.Location = new System.Drawing.Point(418, 17);
            this.cbo_motivo.Name = "cbo_motivo";
            this.cbo_motivo.Size = new System.Drawing.Size(175, 21);
            this.cbo_motivo.TabIndex = 9;
            this.cbo_motivo.ValueMember = "IdMotivoAutoriza";
            // 
            // h2BONOSAUTORIZAMOTIVOSLISTBindingSource
            // 
            this.h2BONOSAUTORIZAMOTIVOSLISTBindingSource.DataMember = "H2_BONOS_AUTORIZA_MOTIVOS_LIST";
            this.h2BONOSAUTORIZAMOTIVOSLISTBindingSource.DataSource = this.bonoDAL;
            // 
            // bonoDAL
            // 
            this.bonoDAL.DataSetName = "BonoDAL";
            this.bonoDAL.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cbo_autorizante
            // 
            this.cbo_autorizante.DataSource = this.h2BONOSAUTORIZANTELISTBindingSource;
            this.cbo_autorizante.DisplayMember = "Autorizante";
            this.cbo_autorizante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_autorizante.Enabled = false;
            this.cbo_autorizante.FormattingEnabled = true;
            this.cbo_autorizante.Location = new System.Drawing.Point(176, 17);
            this.cbo_autorizante.Name = "cbo_autorizante";
            this.cbo_autorizante.Size = new System.Drawing.Size(190, 21);
            this.cbo_autorizante.TabIndex = 8;
            this.cbo_autorizante.ValueMember = "Id_AutorizanteBono";
            // 
            // h2BONOSAUTORIZANTELISTBindingSource
            // 
            this.h2BONOSAUTORIZANTELISTBindingSource.DataMember = "H2_BONOS_AUTORIZANTE_LIST";
            this.h2BONOSAUTORIZANTELISTBindingSource.DataSource = this.bonoDAL;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(372, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Motivo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(109, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Autorizante:";
            // 
            // ck_nopaga
            // 
            this.ck_nopaga.AutoSize = true;
            this.ck_nopaga.Location = new System.Drawing.Point(7, 19);
            this.ck_nopaga.Name = "ck_nopaga";
            this.ck_nopaga.Size = new System.Drawing.Size(68, 17);
            this.ck_nopaga.TabIndex = 5;
            this.ck_nopaga.Text = "No Paga";
            this.ck_nopaga.UseVisualStyleBackColor = true;
            this.ck_nopaga.CheckedChanged += new System.EventHandler(this.ck_nopaga_CheckedChanged);
            // 
            // h2_BONOS_AUTORIZANTE_LISTTableAdapter
            // 
            this.h2_BONOS_AUTORIZANTE_LISTTableAdapter.ClearBeforeFill = true;
            // 
            // h2_BONOS_AUTORIZA_MOTIVOS_LISTTableAdapter
            // 
            this.h2_BONOS_AUTORIZA_MOTIVOS_LISTTableAdapter.ClearBeforeFill = true;
            // 
            // label_info
            // 
            this.label_info.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_info.ForeColor = System.Drawing.Color.Red;
            this.label_info.Location = new System.Drawing.Point(377, 9);
            this.label_info.Name = "label_info";
            this.label_info.Size = new System.Drawing.Size(228, 42);
            this.label_info.TabIndex = 7;
            this.label_info.Text = "Afiliado";
            this.label_info.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LNopaga
            // 
            this.LNopaga.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LNopaga.Location = new System.Drawing.Point(185, 420);
            this.LNopaga.Name = "LNopaga";
            this.LNopaga.Size = new System.Drawing.Size(426, 27);
            this.LNopaga.TabIndex = 8;
            this.LNopaga.Text = "NO PAGA";
            this.LNopaga.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LNopaga.Visible = false;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(12, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(116, 29);
            this.lblTitulo.TabIndex = 9;
            this.lblTitulo.Text = "TxtTitulo";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ImpresionBono
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 456);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.LNopaga);
            this.Controls.Add(this.label_info);
            this.Controls.Add(this.gb2);
            this.Controls.Add(this.gb1);
            this.Controls.Add(this.lTotal);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.btn_imprimir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImpresionBono";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ImpresionBono";
            this.Load += new System.EventHandler(this.ImpresionBono_Load);
            this.gb1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gv_bono)).EndInit();
            this.gb2.ResumeLayout(false);
            this.gb2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.h2BONOSAUTORIZAMOTIVOSLISTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bonoDAL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.h2BONOSAUTORIZANTELISTBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_imprimir;
        private System.Windows.Forms.Button btn_cancelar;
        private System.Windows.Forms.Label lTotal;
        private System.Windows.Forms.GroupBox gb1;
        private System.Windows.Forms.DataGridView gv_bono;
        private System.Windows.Forms.GroupBox gb2;
        private System.Windows.Forms.ComboBox cbo_motivo;
        private System.Windows.Forms.ComboBox cbo_autorizante;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ck_nopaga;
        private System.Windows.Forms.TextBox txt_comentario;
        private System.Windows.Forms.Label label4;
        private DAL.BonoDAL bonoDAL;
        private System.Windows.Forms.BindingSource h2BONOSAUTORIZANTELISTBindingSource;
        private DAL.BonoDALTableAdapters.H2_BONOS_AUTORIZANTE_LISTTableAdapter h2_BONOS_AUTORIZANTE_LISTTableAdapter;
        private System.Windows.Forms.BindingSource h2BONOSAUTORIZAMOTIVOSLISTBindingSource;
        private DAL.BonoDALTableAdapters.H2_BONOS_AUTORIZA_MOTIVOS_LISTTableAdapter h2_BONOS_AUTORIZA_MOTIVOS_LISTTableAdapter;
        private System.Windows.Forms.Label label_info;
        private System.Windows.Forms.Label LNopaga;
        private System.Windows.Forms.DataGridViewTextBoxColumn Practica_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubPractica_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Practica;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubPractica;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.Label lblTitulo;
    }
}