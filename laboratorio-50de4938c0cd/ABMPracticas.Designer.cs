namespace Laboratorio2
{
    partial class ABMPracticas
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_CodPractica = new System.Windows.Forms.TextBox();
            this.txt_NPractica = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lsp = new System.Windows.Forms.ListBox();
            this.btb_Agregar_SP = new System.Windows.Forms.Button();
            this.btn_Quitar_SP = new System.Windows.Forms.Button();
            this.btn_Modificar_SP = new System.Windows.Forms.Button();
            this.txt_demora = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_scPract = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_SubPract = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.cbo_defecto = new System.Windows.Forms.CheckBox();
            this.cbo_TipoMuestra = new System.Windows.Forms.ComboBox();
            this.tipoMuestraBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.laboratorioDataSet = new Laboratorio2.DAL.LaboratorioDataSet();
            this.label6 = new System.Windows.Forms.Label();
            this.tipo_MuestraTableAdapter = new Laboratorio2.DAL.LaboratorioDataSetTableAdapters.Tipo_MuestraTableAdapter();
            this.txt_abreviatura = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbo_tipo_tubo = new System.Windows.Forms.ComboBox();
            this.grupotubosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.laboratorioDataSet2 = new Laboratorio2.DAL.LaboratorioDataSet1();
            this.btn_editar_tubo = new System.Windows.Forms.Button();
            this.grupo_tubosTableAdapter = new Laboratorio2.DAL.LaboratorioDataSet1TableAdapters.grupo_tubosTableAdapter();
            this.cbo_mostrar_en_guardia = new System.Windows.Forms.CheckBox();
            this.bt_cancelar = new System.Windows.Forms.Button();
            this.txt_dias_ultimo_analisis = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbo_complejidad = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tipoMuestraBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.laboratorioDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grupotubosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.laboratorioDataSet2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cod Práctica:";
            // 
            // txt_CodPractica
            // 
            this.txt_CodPractica.Location = new System.Drawing.Point(107, 6);
            this.txt_CodPractica.MaxLength = 6;
            this.txt_CodPractica.Name = "txt_CodPractica";
            this.txt_CodPractica.Size = new System.Drawing.Size(82, 20);
            this.txt_CodPractica.TabIndex = 1;
            // 
            // txt_NPractica
            // 
            this.txt_NPractica.Location = new System.Drawing.Point(107, 32);
            this.txt_NPractica.MaxLength = 200;
            this.txt_NPractica.Name = "txt_NPractica";
            this.txt_NPractica.Size = new System.Drawing.Size(437, 20);
            this.txt_NPractica.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre Práctica:";
            // 
            // lsp
            // 
            this.lsp.FormattingEnabled = true;
            this.lsp.Location = new System.Drawing.Point(107, 123);
            this.lsp.Name = "lsp";
            this.lsp.Size = new System.Drawing.Size(433, 121);
            this.lsp.TabIndex = 4;
            this.lsp.Click += new System.EventHandler(this.lsp_Click);
            // 
            // btb_Agregar_SP
            // 
            this.btb_Agregar_SP.Location = new System.Drawing.Point(10, 347);
            this.btb_Agregar_SP.Name = "btb_Agregar_SP";
            this.btb_Agregar_SP.Size = new System.Drawing.Size(125, 23);
            this.btb_Agregar_SP.TabIndex = 5;
            this.btb_Agregar_SP.Text = "Agregar";
            this.btb_Agregar_SP.UseVisualStyleBackColor = true;
            this.btb_Agregar_SP.Click += new System.EventHandler(this.btb_Agregar_SP_Click);
            // 
            // btn_Quitar_SP
            // 
            this.btn_Quitar_SP.Location = new System.Drawing.Point(272, 347);
            this.btn_Quitar_SP.Name = "btn_Quitar_SP";
            this.btn_Quitar_SP.Size = new System.Drawing.Size(125, 23);
            this.btn_Quitar_SP.TabIndex = 6;
            this.btn_Quitar_SP.Text = "Quitar";
            this.btn_Quitar_SP.UseVisualStyleBackColor = true;
            this.btn_Quitar_SP.Click += new System.EventHandler(this.btn_Quitar_SP_Click);
            // 
            // btn_Modificar_SP
            // 
            this.btn_Modificar_SP.Location = new System.Drawing.Point(141, 347);
            this.btn_Modificar_SP.Name = "btn_Modificar_SP";
            this.btn_Modificar_SP.Size = new System.Drawing.Size(125, 23);
            this.btn_Modificar_SP.TabIndex = 7;
            this.btn_Modificar_SP.Text = "Modificar";
            this.btn_Modificar_SP.UseVisualStyleBackColor = true;
            this.btn_Modificar_SP.Click += new System.EventHandler(this.btn_Modificar_SP_Click);
            // 
            // txt_demora
            // 
            this.txt_demora.Location = new System.Drawing.Point(289, 60);
            this.txt_demora.MaxLength = 3;
            this.txt_demora.Name = "txt_demora";
            this.txt_demora.Size = new System.Drawing.Size(47, 20);
            this.txt_demora.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(217, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Día demora:";
            // 
            // txt_scPract
            // 
            this.txt_scPract.Location = new System.Drawing.Point(107, 254);
            this.txt_scPract.MaxLength = 2;
            this.txt_scPract.Name = "txt_scPract";
            this.txt_scPract.Size = new System.Drawing.Size(47, 20);
            this.txt_scPract.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 257);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Cod Sub Práctica:";
            // 
            // txt_SubPract
            // 
            this.txt_SubPract.Location = new System.Drawing.Point(248, 254);
            this.txt_SubPract.MaxLength = 200;
            this.txt_SubPract.Name = "txt_SubPract";
            this.txt_SubPract.Size = new System.Drawing.Size(292, 20);
            this.txt_SubPract.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(171, 257);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Sub Práctica:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(195, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(59, 20);
            this.button1.TabIndex = 17;
            this.button1.Text = "Buscar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbo_defecto
            // 
            this.cbo_defecto.AutoSize = true;
            this.cbo_defecto.Location = new System.Drawing.Point(174, 282);
            this.cbo_defecto.Name = "cbo_defecto";
            this.cbo_defecto.Size = new System.Drawing.Size(83, 17);
            this.cbo_defecto.TabIndex = 18;
            this.cbo_defecto.Text = "Por Defecto";
            this.cbo_defecto.UseVisualStyleBackColor = true;
            // 
            // cbo_TipoMuestra
            // 
            this.cbo_TipoMuestra.DataSource = this.tipoMuestraBindingSource;
            this.cbo_TipoMuestra.DisplayMember = "TM_Descripcion";
            this.cbo_TipoMuestra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_TipoMuestra.FormattingEnabled = true;
            this.cbo_TipoMuestra.Location = new System.Drawing.Point(353, 280);
            this.cbo_TipoMuestra.Name = "cbo_TipoMuestra";
            this.cbo_TipoMuestra.Size = new System.Drawing.Size(187, 21);
            this.cbo_TipoMuestra.TabIndex = 19;
            this.cbo_TipoMuestra.ValueMember = "TM_Id";
            // 
            // tipoMuestraBindingSource
            // 
            this.tipoMuestraBindingSource.DataMember = "Tipo_Muestra";
            this.tipoMuestraBindingSource.DataSource = this.laboratorioDataSet;
            // 
            // laboratorioDataSet
            // 
            this.laboratorioDataSet.DataSetName = "LaboratorioDataSet";
            this.laboratorioDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(286, 283);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "T. Muestra:";
            // 
            // tipo_MuestraTableAdapter
            // 
            this.tipo_MuestraTableAdapter.ClearBeforeFill = true;
            // 
            // txt_abreviatura
            // 
            this.txt_abreviatura.Location = new System.Drawing.Point(107, 58);
            this.txt_abreviatura.MaxLength = 10;
            this.txt_abreviatura.Name = "txt_abreviatura";
            this.txt_abreviatura.Size = new System.Drawing.Size(82, 20);
            this.txt_abreviatura.TabIndex = 28;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(37, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 27;
            this.label8.Text = "Abreviatura:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(37, 123);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "Subprácticas";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(269, 317);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 13);
            this.label9.TabIndex = 30;
            this.label9.Text = "Grupo de tubo:";
            // 
            // cbo_tipo_tubo
            // 
            this.cbo_tipo_tubo.DataSource = this.grupotubosBindingSource;
            this.cbo_tipo_tubo.DisplayMember = "grupo_nombre";
            this.cbo_tipo_tubo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_tipo_tubo.FormattingEnabled = true;
            this.cbo_tipo_tubo.Location = new System.Drawing.Point(353, 314);
            this.cbo_tipo_tubo.Name = "cbo_tipo_tubo";
            this.cbo_tipo_tubo.Size = new System.Drawing.Size(136, 21);
            this.cbo_tipo_tubo.TabIndex = 31;
            this.cbo_tipo_tubo.ValueMember = "grupo_id";
            // 
            // grupotubosBindingSource
            // 
            this.grupotubosBindingSource.DataMember = "grupo_tubos";
            this.grupotubosBindingSource.DataSource = this.laboratorioDataSet2;
            // 
            // laboratorioDataSet2
            // 
            this.laboratorioDataSet2.DataSetName = "LaboratorioDataSet2";
            this.laboratorioDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btn_editar_tubo
            // 
            this.btn_editar_tubo.Location = new System.Drawing.Point(495, 314);
            this.btn_editar_tubo.Name = "btn_editar_tubo";
            this.btn_editar_tubo.Size = new System.Drawing.Size(49, 23);
            this.btn_editar_tubo.TabIndex = 32;
            this.btn_editar_tubo.Text = "Editar";
            this.btn_editar_tubo.UseVisualStyleBackColor = true;
            this.btn_editar_tubo.Click += new System.EventHandler(this.btn_editar_tubo_Click);
            // 
            // grupo_tubosTableAdapter
            // 
            this.grupo_tubosTableAdapter.ClearBeforeFill = true;
            // 
            // cbo_mostrar_en_guardia
            // 
            this.cbo_mostrar_en_guardia.AutoSize = true;
            this.cbo_mostrar_en_guardia.Location = new System.Drawing.Point(426, 60);
            this.cbo_mostrar_en_guardia.Name = "cbo_mostrar_en_guardia";
            this.cbo_mostrar_en_guardia.Size = new System.Drawing.Size(114, 17);
            this.cbo_mostrar_en_guardia.TabIndex = 33;
            this.cbo_mostrar_en_guardia.Text = "Mostrar en guardia";
            this.cbo_mostrar_en_guardia.UseVisualStyleBackColor = true;
            // 
            // bt_cancelar
            // 
            this.bt_cancelar.Location = new System.Drawing.Point(403, 347);
            this.bt_cancelar.Name = "bt_cancelar";
            this.bt_cancelar.Size = new System.Drawing.Size(125, 23);
            this.bt_cancelar.TabIndex = 34;
            this.bt_cancelar.Text = "Cancelar";
            this.bt_cancelar.UseVisualStyleBackColor = true;
            this.bt_cancelar.Click += new System.EventHandler(this.bt_cancelar_Click);
            // 
            // txt_dias_ultimo_analisis
            // 
            this.txt_dias_ultimo_analisis.Location = new System.Drawing.Point(289, 86);
            this.txt_dias_ultimo_analisis.MaxLength = 3;
            this.txt_dias_ultimo_analisis.Name = "txt_dias_ultimo_analisis";
            this.txt_dias_ultimo_analisis.Size = new System.Drawing.Size(47, 20);
            this.txt_dias_ultimo_analisis.TabIndex = 36;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(153, 89);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(130, 13);
            this.label10.TabIndex = 35;
            this.label10.Text = "Dias desde último analisis:";
            // 
            // cbo_complejidad
            // 
            this.cbo_complejidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_complejidad.FormattingEnabled = true;
            this.cbo_complejidad.Items.AddRange(new object[] {
            "Baja",
            "Media",
            "Alta"});
            this.cbo_complejidad.Location = new System.Drawing.Point(448, 85);
            this.cbo_complejidad.Name = "cbo_complejidad";
            this.cbo_complejidad.Size = new System.Drawing.Size(96, 21);
            this.cbo_complejidad.TabIndex = 38;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(375, 88);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 13);
            this.label11.TabIndex = 37;
            this.label11.Text = "Complejidad:";
            // 
            // ABMPracticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 382);
            this.Controls.Add(this.cbo_complejidad);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txt_dias_ultimo_analisis);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.bt_cancelar);
            this.Controls.Add(this.cbo_mostrar_en_guardia);
            this.Controls.Add(this.btn_editar_tubo);
            this.Controls.Add(this.cbo_tipo_tubo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_abreviatura);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbo_TipoMuestra);
            this.Controls.Add(this.cbo_defecto);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt_SubPract);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_scPract);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_demora);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_Modificar_SP);
            this.Controls.Add(this.btn_Quitar_SP);
            this.Controls.Add(this.btb_Agregar_SP);
            this.Controls.Add(this.lsp);
            this.Controls.Add(this.txt_NPractica);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_CodPractica);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ABMPracticas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Prácticas";
            this.Load += new System.EventHandler(this.ABMPracticas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tipoMuestraBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.laboratorioDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grupotubosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.laboratorioDataSet2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_CodPractica;
        private System.Windows.Forms.TextBox txt_NPractica;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lsp;
        private System.Windows.Forms.Button btb_Agregar_SP;
        private System.Windows.Forms.Button btn_Quitar_SP;
        private System.Windows.Forms.Button btn_Modificar_SP;
        private System.Windows.Forms.TextBox txt_demora;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_scPract;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_SubPract;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox cbo_defecto;
        private System.Windows.Forms.ComboBox cbo_TipoMuestra;
        private System.Windows.Forms.Label label6;
        private DAL.LaboratorioDataSet laboratorioDataSet;
        private System.Windows.Forms.BindingSource tipoMuestraBindingSource;
        private DAL.LaboratorioDataSetTableAdapters.Tipo_MuestraTableAdapter tipo_MuestraTableAdapter;
        private System.Windows.Forms.TextBox txt_abreviatura;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbo_tipo_tubo;
        private System.Windows.Forms.Button btn_editar_tubo;
        private DAL.LaboratorioDataSet1 laboratorioDataSet2;
        private System.Windows.Forms.BindingSource grupotubosBindingSource;
        private DAL.LaboratorioDataSet1TableAdapters.grupo_tubosTableAdapter grupo_tubosTableAdapter;
        private System.Windows.Forms.CheckBox cbo_mostrar_en_guardia;
        private System.Windows.Forms.Button bt_cancelar;
        private System.Windows.Forms.TextBox txt_dias_ultimo_analisis;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbo_complejidad;
        private System.Windows.Forms.Label label11;
    }
}