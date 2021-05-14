namespace Laboratorio2
{
    partial class Impresion_Automatica
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
            this.lb_fingreso = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_TMuestra = new System.Windows.Forms.Label();
            this.lbl_observaciones = new System.Windows.Forms.Label();
            this.lbl_resumen = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_edad = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_cama = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_Numero = new System.Windows.Forms.Label();
            this.lbl_PacienteOculto = new System.Windows.Forms.Label();
            this.gv = new System.Windows.Forms.DataGridView();
            this.Grupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mas = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Menos = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Borrar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txt_grupo = new System.Windows.Forms.TextBox();
            this.txt_cantidad = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_Agregar = new System.Windows.Forms.Button();
            this.btn_imprimir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_fingreso
            // 
            this.lb_fingreso.AutoSize = true;
            this.lb_fingreso.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_fingreso.Location = new System.Drawing.Point(95, 100);
            this.lb_fingreso.Name = "lb_fingreso";
            this.lb_fingreso.Size = new System.Drawing.Size(122, 14);
            this.lb_fingreso.TabIndex = 37;
            this.lb_fingreso.Text = "99/99/9999 99:99";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(18, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 14);
            this.label6.TabIndex = 36;
            this.label6.Text = "F. Igreso:";
            // 
            // lbl_TMuestra
            // 
            this.lbl_TMuestra.AutoSize = true;
            this.lbl_TMuestra.Location = new System.Drawing.Point(395, 70);
            this.lbl_TMuestra.Name = "lbl_TMuestra";
            this.lbl_TMuestra.Size = new System.Drawing.Size(35, 13);
            this.lbl_TMuestra.TabIndex = 35;
            this.lbl_TMuestra.Text = "label6";
            this.lbl_TMuestra.Visible = false;
            // 
            // lbl_observaciones
            // 
            this.lbl_observaciones.AutoSize = true;
            this.lbl_observaciones.Location = new System.Drawing.Point(336, 71);
            this.lbl_observaciones.Name = "lbl_observaciones";
            this.lbl_observaciones.Size = new System.Drawing.Size(35, 13);
            this.lbl_observaciones.TabIndex = 34;
            this.lbl_observaciones.Text = "label6";
            this.lbl_observaciones.Visible = false;
            // 
            // lbl_resumen
            // 
            this.lbl_resumen.AutoSize = true;
            this.lbl_resumen.Location = new System.Drawing.Point(275, 71);
            this.lbl_resumen.Name = "lbl_resumen";
            this.lbl_resumen.Size = new System.Drawing.Size(35, 13);
            this.lbl_resumen.TabIndex = 33;
            this.lbl_resumen.Text = "label6";
            this.lbl_resumen.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(42, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 14);
            this.label5.TabIndex = 32;
            this.label5.Text = "Edad:";
            // 
            // lbl_edad
            // 
            this.lbl_edad.AutoSize = true;
            this.lbl_edad.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_edad.Location = new System.Drawing.Point(95, 70);
            this.lbl_edad.Name = "lbl_edad";
            this.lbl_edad.Size = new System.Drawing.Size(15, 14);
            this.lbl_edad.TabIndex = 31;
            this.lbl_edad.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(275, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 14);
            this.label4.TabIndex = 30;
            this.label4.Text = "Cama:";
            // 
            // lbl_cama
            // 
            this.lbl_cama.AutoSize = true;
            this.lbl_cama.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cama.Location = new System.Drawing.Point(323, 39);
            this.lbl_cama.Name = "lbl_cama";
            this.lbl_cama.Size = new System.Drawing.Size(48, 14);
            this.lbl_cama.TabIndex = 29;
            this.lbl_cama.Text = "Cama:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 14);
            this.label3.TabIndex = 28;
            this.label3.Text = "Cod. Barra:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 14);
            this.label2.TabIndex = 27;
            this.label2.Text = "Paciente:";
            // 
            // lbl_Numero
            // 
            this.lbl_Numero.AutoSize = true;
            this.lbl_Numero.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Numero.Location = new System.Drawing.Point(95, 37);
            this.lbl_Numero.Name = "lbl_Numero";
            this.lbl_Numero.Size = new System.Drawing.Size(45, 14);
            this.lbl_Numero.TabIndex = 26;
            this.lbl_Numero.Text = "label2";
            // 
            // lbl_PacienteOculto
            // 
            this.lbl_PacienteOculto.AutoSize = true;
            this.lbl_PacienteOculto.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PacienteOculto.Location = new System.Drawing.Point(95, 9);
            this.lbl_PacienteOculto.Name = "lbl_PacienteOculto";
            this.lbl_PacienteOculto.Size = new System.Drawing.Size(45, 14);
            this.lbl_PacienteOculto.TabIndex = 25;
            this.lbl_PacienteOculto.Text = "label1";
            // 
            // gv
            // 
            this.gv.AllowUserToAddRows = false;
            this.gv.AllowUserToDeleteRows = false;
            this.gv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Grupo,
            this.Cantidad,
            this.Mas,
            this.Menos,
            this.Borrar});
            this.gv.Location = new System.Drawing.Point(10, 147);
            this.gv.MultiSelect = false;
            this.gv.Name = "gv";
            this.gv.ReadOnly = true;
            this.gv.Size = new System.Drawing.Size(475, 158);
            this.gv.TabIndex = 39;
            this.gv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gv_CellContentClick);
            // 
            // Grupo
            // 
            this.Grupo.DataPropertyName = "grupo";
            this.Grupo.HeaderText = "Grupo";
            this.Grupo.Name = "Grupo";
            this.Grupo.ReadOnly = true;
            // 
            // Cantidad
            // 
            this.Cantidad.DataPropertyName = "cant_etiquetas";
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            this.Cantidad.Width = 80;
            // 
            // Mas
            // 
            this.Mas.DataPropertyName = "Mas";
            this.Mas.HeaderText = "Más";
            this.Mas.Name = "Mas";
            this.Mas.ReadOnly = true;
            this.Mas.Width = 80;
            // 
            // Menos
            // 
            this.Menos.DataPropertyName = "Menos";
            this.Menos.HeaderText = "Menos";
            this.Menos.Name = "Menos";
            this.Menos.ReadOnly = true;
            this.Menos.Width = 80;
            // 
            // Borrar
            // 
            this.Borrar.DataPropertyName = "Borrar";
            this.Borrar.HeaderText = "Borrar";
            this.Borrar.Name = "Borrar";
            this.Borrar.ReadOnly = true;
            this.Borrar.Width = 80;
            // 
            // txt_grupo
            // 
            this.txt_grupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_grupo.Location = new System.Drawing.Point(98, 323);
            this.txt_grupo.MaxLength = 15;
            this.txt_grupo.Name = "txt_grupo";
            this.txt_grupo.Size = new System.Drawing.Size(172, 35);
            this.txt_grupo.TabIndex = 41;
            // 
            // txt_cantidad
            // 
            this.txt_cantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_cantidad.Location = new System.Drawing.Point(194, 367);
            this.txt_cantidad.MaxLength = 2;
            this.txt_cantidad.Name = "txt_cantidad";
            this.txt_cantidad.Size = new System.Drawing.Size(76, 35);
            this.txt_cantidad.TabIndex = 42;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 326);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 29);
            this.label1.TabIndex = 43;
            this.label1.Text = "Grupo";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(16, 370);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 29);
            this.label7.TabIndex = 44;
            this.label7.Text = "Cantidad";
            // 
            // btn_Agregar
            // 
            this.btn_Agregar.Image = global::Laboratorio2.Properties.Resources.netvibes;
            this.btn_Agregar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_Agregar.Location = new System.Drawing.Point(305, 311);
            this.btn_Agregar.Name = "btn_Agregar";
            this.btn_Agregar.Size = new System.Drawing.Size(87, 91);
            this.btn_Agregar.TabIndex = 45;
            this.btn_Agregar.Text = "Agregar";
            this.btn_Agregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Agregar.UseVisualStyleBackColor = true;
            this.btn_Agregar.Click += new System.EventHandler(this.btn_Agregar_Click);
            // 
            // btn_imprimir
            // 
            this.btn_imprimir.Image = global::Laboratorio2.Properties.Resources.agt_print;
            this.btn_imprimir.Location = new System.Drawing.Point(398, 311);
            this.btn_imprimir.Name = "btn_imprimir";
            this.btn_imprimir.Size = new System.Drawing.Size(87, 91);
            this.btn_imprimir.TabIndex = 40;
            this.btn_imprimir.Text = "Imprimir";
            this.btn_imprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_imprimir.UseVisualStyleBackColor = true;
            this.btn_imprimir.Click += new System.EventHandler(this.btn_imprimir_Click);
            // 
            // Impresion_Automatica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 423);
            this.Controls.Add(this.btn_Agregar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_cantidad);
            this.Controls.Add(this.txt_grupo);
            this.Controls.Add(this.btn_imprimir);
            this.Controls.Add(this.gv);
            this.Controls.Add(this.lb_fingreso);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbl_TMuestra);
            this.Controls.Add(this.lbl_observaciones);
            this.Controls.Add(this.lbl_resumen);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbl_edad);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbl_cama);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_Numero);
            this.Controls.Add(this.lbl_PacienteOculto);
            this.Name = "Impresion_Automatica";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Impresion_Automatica";
            this.Load += new System.EventHandler(this.Impresion_Automatica_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lb_fingreso;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_TMuestra;
        private System.Windows.Forms.Label lbl_observaciones;
        public System.Windows.Forms.Label lbl_resumen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_edad;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_cama;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_Numero;
        private System.Windows.Forms.Label lbl_PacienteOculto;
        private System.Windows.Forms.DataGridView gv;
        private System.Windows.Forms.Button btn_imprimir;
        private System.Windows.Forms.TextBox txt_grupo;
        private System.Windows.Forms.TextBox txt_cantidad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_Agregar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewButtonColumn Mas;
        private System.Windows.Forms.DataGridViewButtonColumn Menos;
        private System.Windows.Forms.DataGridViewButtonColumn Borrar;
    }
}