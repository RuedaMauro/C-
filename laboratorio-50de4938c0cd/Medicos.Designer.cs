namespace Laboratorio2
{
    partial class Medicos
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Nombre = new System.Windows.Forms.TextBox();
            this.txt_Matricula_nac = new System.Windows.Forms.TextBox();
            this.gv_medicos = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_baja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.especialidad_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.especialidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_Matricula_prov = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbo_especialidad = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_motivo_baja = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_fecha_baja = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lb_id = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gv_medicos)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(434, 376);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(353, 376);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(78, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Guardar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 182);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre Medico:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 243);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Matricula Nacional:";
            // 
            // txt_Nombre
            // 
            this.txt_Nombre.Location = new System.Drawing.Point(114, 180);
            this.txt_Nombre.MaxLength = 50;
            this.txt_Nombre.Name = "txt_Nombre";
            this.txt_Nombre.Size = new System.Drawing.Size(479, 20);
            this.txt_Nombre.TabIndex = 1;
            this.txt_Nombre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Nombre_KeyDown);
            // 
            // txt_Matricula_nac
            // 
            this.txt_Matricula_nac.Location = new System.Drawing.Point(114, 243);
            this.txt_Matricula_nac.MaxLength = 10;
            this.txt_Matricula_nac.Name = "txt_Matricula_nac";
            this.txt_Matricula_nac.Size = new System.Drawing.Size(479, 20);
            this.txt_Matricula_nac.TabIndex = 3;
            this.txt_Matricula_nac.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Matricula_nac_KeyDown);
            // 
            // gv_medicos
            // 
            this.gv_medicos.AllowUserToAddRows = false;
            this.gv_medicos.AllowUserToDeleteRows = false;
            this.gv_medicos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv_medicos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.nombre,
            this.fecha_baja,
            this.especialidad_id,
            this.especialidad,
            this.mn,
            this.mp,
            this.estado});
            this.gv_medicos.Location = new System.Drawing.Point(12, 12);
            this.gv_medicos.Name = "gv_medicos";
            this.gv_medicos.ReadOnly = true;
            this.gv_medicos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gv_medicos.Size = new System.Drawing.Size(581, 150);
            this.gv_medicos.TabIndex = 0;
            this.gv_medicos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gv_medicos_CellClick);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // nombre
            // 
            this.nombre.DataPropertyName = "nombre";
            this.nombre.HeaderText = "Medico";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            // 
            // fecha_baja
            // 
            this.fecha_baja.DataPropertyName = "Fecha_baja";
            this.fecha_baja.HeaderText = "Fecha Baja";
            this.fecha_baja.Name = "fecha_baja";
            this.fecha_baja.ReadOnly = true;
            // 
            // especialidad_id
            // 
            this.especialidad_id.DataPropertyName = "Especialidad_id";
            this.especialidad_id.HeaderText = "especialidad_id";
            this.especialidad_id.Name = "especialidad_id";
            this.especialidad_id.ReadOnly = true;
            this.especialidad_id.Visible = false;
            // 
            // especialidad
            // 
            this.especialidad.DataPropertyName = "especialidad";
            this.especialidad.HeaderText = "Especialidad";
            this.especialidad.Name = "especialidad";
            this.especialidad.ReadOnly = true;
            // 
            // mn
            // 
            this.mn.DataPropertyName = "MN";
            this.mn.HeaderText = "Mat. Nac";
            this.mn.Name = "mn";
            this.mn.ReadOnly = true;
            // 
            // mp
            // 
            this.mp.DataPropertyName = "MP";
            this.mp.HeaderText = "Mat. Prov";
            this.mp.Name = "mp";
            this.mp.ReadOnly = true;
            // 
            // estado
            // 
            this.estado.DataPropertyName = "estado";
            this.estado.HeaderText = "estado";
            this.estado.Name = "estado";
            this.estado.ReadOnly = true;
            this.estado.Visible = false;
            // 
            // txt_Matricula_prov
            // 
            this.txt_Matricula_prov.Location = new System.Drawing.Point(114, 269);
            this.txt_Matricula_prov.MaxLength = 10;
            this.txt_Matricula_prov.Name = "txt_Matricula_prov";
            this.txt_Matricula_prov.Size = new System.Drawing.Size(479, 20);
            this.txt_Matricula_prov.TabIndex = 4;
            this.txt_Matricula_prov.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Matricula_prov_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 269);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Matricula Provincial:";
            // 
            // cbo_especialidad
            // 
            this.cbo_especialidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_especialidad.FormattingEnabled = true;
            this.cbo_especialidad.Location = new System.Drawing.Point(114, 206);
            this.cbo_especialidad.Name = "cbo_especialidad";
            this.cbo_especialidad.Size = new System.Drawing.Size(479, 21);
            this.cbo_especialidad.TabIndex = 2;
            this.cbo_especialidad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbo_especialidad_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Especialidad:";
            // 
            // txt_motivo_baja
            // 
            this.txt_motivo_baja.Location = new System.Drawing.Point(114, 337);
            this.txt_motivo_baja.MaxLength = 100;
            this.txt_motivo_baja.Name = "txt_motivo_baja";
            this.txt_motivo_baja.Size = new System.Drawing.Size(479, 20);
            this.txt_motivo_baja.TabIndex = 6;
            this.txt_motivo_baja.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_motivo_baja_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 337);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Motivo Baja:";
            // 
            // txt_fecha_baja
            // 
            this.txt_fecha_baja.Location = new System.Drawing.Point(114, 311);
            this.txt_fecha_baja.MaxLength = 10;
            this.txt_fecha_baja.Name = "txt_fecha_baja";
            this.txt_fecha_baja.Size = new System.Drawing.Size(479, 20);
            this.txt_fecha_baja.TabIndex = 5;
            this.txt_fecha_baja.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_fecha_baja_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(44, 311);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Fecha Baja:";
            // 
            // lb_id
            // 
            this.lb_id.AutoSize = true;
            this.lb_id.Location = new System.Drawing.Point(111, 376);
            this.lb_id.Name = "lb_id";
            this.lb_id.Size = new System.Drawing.Size(35, 13);
            this.lb_id.TabIndex = 14;
            this.lb_id.Text = "label7";
            this.lb_id.Visible = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(515, 376);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(78, 23);
            this.button3.TabIndex = 15;
            this.button3.Text = "Salir";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Medicos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 411);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.lb_id);
            this.Controls.Add(this.txt_motivo_baja);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_fecha_baja);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbo_especialidad);
            this.Controls.Add(this.txt_Matricula_prov);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gv_medicos);
            this.Controls.Add(this.txt_Matricula_nac);
            this.Controls.Add(this.txt_Nombre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Medicos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Medicos";
            this.Load += new System.EventHandler(this.Medicos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gv_medicos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Nombre;
        private System.Windows.Forms.TextBox txt_Matricula_nac;
        private System.Windows.Forms.DataGridView gv_medicos;
        private System.Windows.Forms.TextBox txt_Matricula_prov;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbo_especialidad;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_baja;
        private System.Windows.Forms.DataGridViewTextBoxColumn especialidad_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn especialidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn mn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mp;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado;
        private System.Windows.Forms.TextBox txt_motivo_baja;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_fecha_baja;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lb_id;
        private System.Windows.Forms.Button button3;
    }
}