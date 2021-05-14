namespace Laboratorio2
{
    partial class Cambio_SSC
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_fecha = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.cbo_cama = new System.Windows.Forms.ComboBox();
            this.cbo_sala = new System.Windows.Forms.ComboBox();
            this.cbo_servicio = new System.Windows.Forms.ComboBox();
            this.lbl_protocolo = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbl_cama = new System.Windows.Forms.Label();
            this.lbl_sala = new System.Windows.Forms.Label();
            this.lbl_servicio = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_Edad = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_hc = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_sexo = new System.Windows.Forms.Label();
            this.lbl_Nombre = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl_fecha);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.cbo_cama);
            this.panel1.Controls.Add(this.cbo_sala);
            this.panel1.Controls.Add(this.cbo_servicio);
            this.panel1.Controls.Add(this.lbl_protocolo);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.lbl_cama);
            this.panel1.Controls.Add(this.lbl_sala);
            this.panel1.Controls.Add(this.lbl_servicio);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lbl_Edad);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lbl_hc);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lbl_sexo);
            this.panel1.Controls.Add(this.lbl_Nombre);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(530, 447);
            this.panel1.TabIndex = 0;
            // 
            // lbl_fecha
            // 
            this.lbl_fecha.AutoSize = true;
            this.lbl_fecha.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_fecha.Location = new System.Drawing.Point(370, 120);
            this.lbl_fecha.Name = "lbl_fecha";
            this.lbl_fecha.Size = new System.Drawing.Size(24, 17);
            this.lbl_fecha.TabIndex = 28;
            this.lbl_fecha.Text = "30";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(309, 119);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(55, 18);
            this.label15.TabIndex = 27;
            this.label15.Text = "Fecha:";
            // 
            // cbo_cama
            // 
            this.cbo_cama.DisplayMember = "descripcion";
            this.cbo_cama.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_cama.FormattingEnabled = true;
            this.cbo_cama.Location = new System.Drawing.Point(103, 367);
            this.cbo_cama.Name = "cbo_cama";
            this.cbo_cama.Size = new System.Drawing.Size(410, 21);
            this.cbo_cama.TabIndex = 26;
            this.cbo_cama.ValueMember = "id";
            // 
            // cbo_sala
            // 
            this.cbo_sala.DisplayMember = "descripcion";
            this.cbo_sala.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_sala.FormattingEnabled = true;
            this.cbo_sala.Location = new System.Drawing.Point(103, 344);
            this.cbo_sala.Name = "cbo_sala";
            this.cbo_sala.Size = new System.Drawing.Size(410, 21);
            this.cbo_sala.TabIndex = 25;
            this.cbo_sala.ValueMember = "id";
            this.cbo_sala.SelectedIndexChanged += new System.EventHandler(this.cbo_Sala_SelectedIndexChanged);
            // 
            // cbo_servicio
            // 
            this.cbo_servicio.DisplayMember = "descripcion";
            this.cbo_servicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_servicio.FormattingEnabled = true;
            this.cbo_servicio.Location = new System.Drawing.Point(103, 321);
            this.cbo_servicio.Name = "cbo_servicio";
            this.cbo_servicio.Size = new System.Drawing.Size(410, 21);
            this.cbo_servicio.TabIndex = 24;
            this.cbo_servicio.ValueMember = "id";
            this.cbo_servicio.SelectedIndexChanged += new System.EventHandler(this.cbo_servicio_SelectedIndexChanged_1);
            // 
            // lbl_protocolo
            // 
            this.lbl_protocolo.AutoSize = true;
            this.lbl_protocolo.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_protocolo.Location = new System.Drawing.Point(100, 120);
            this.lbl_protocolo.Name = "lbl_protocolo";
            this.lbl_protocolo.Size = new System.Drawing.Size(24, 17);
            this.lbl_protocolo.TabIndex = 23;
            this.lbl_protocolo.Text = "30";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(12, 119);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(81, 18);
            this.label14.TabIndex = 22;
            this.label14.Text = "Protocolo:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(356, 409);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 21;
            this.button2.Text = "Salir";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightGreen;
            this.button1.Location = new System.Drawing.Point(437, 409);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 20;
            this.button1.Text = "Cambiar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(12, 367);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 18);
            this.label10.TabIndex = 19;
            this.label10.Text = "Cama:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(12, 344);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 18);
            this.label11.TabIndex = 18;
            this.label11.Text = "Sala:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(12, 321);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 18);
            this.label12.TabIndex = 17;
            this.label12.Text = "Servicio:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 290);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(127, 22);
            this.label9.TabIndex = 15;
            this.label9.Text = "Nuevos datos:";
            // 
            // lbl_cama
            // 
            this.lbl_cama.AutoSize = true;
            this.lbl_cama.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cama.Location = new System.Drawing.Point(100, 238);
            this.lbl_cama.Name = "lbl_cama";
            this.lbl_cama.Size = new System.Drawing.Size(52, 17);
            this.lbl_cama.TabIndex = 14;
            this.lbl_cama.Text = "Cama:";
            // 
            // lbl_sala
            // 
            this.lbl_sala.AutoSize = true;
            this.lbl_sala.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_sala.Location = new System.Drawing.Point(100, 216);
            this.lbl_sala.Name = "lbl_sala";
            this.lbl_sala.Size = new System.Drawing.Size(41, 17);
            this.lbl_sala.TabIndex = 13;
            this.lbl_sala.Text = "Sala:";
            // 
            // lbl_servicio
            // 
            this.lbl_servicio.AutoSize = true;
            this.lbl_servicio.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_servicio.Location = new System.Drawing.Point(100, 193);
            this.lbl_servicio.Name = "lbl_servicio";
            this.lbl_servicio.Size = new System.Drawing.Size(64, 17);
            this.lbl_servicio.TabIndex = 12;
            this.lbl_servicio.Text = "Servicio:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 238);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 18);
            this.label8.TabIndex = 11;
            this.label8.Text = "Cama:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 215);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 18);
            this.label7.TabIndex = 10;
            this.label7.Text = "Sala:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 18);
            this.label6.TabIndex = 9;
            this.label6.Text = "Servicio:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 22);
            this.label5.TabIndex = 8;
            this.label5.Text = "Datos cargados:";
            // 
            // lbl_Edad
            // 
            this.lbl_Edad.AutoSize = true;
            this.lbl_Edad.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Edad.Location = new System.Drawing.Point(100, 93);
            this.lbl_Edad.Name = "lbl_Edad";
            this.lbl_Edad.Size = new System.Drawing.Size(24, 17);
            this.lbl_Edad.TabIndex = 7;
            this.lbl_Edad.Text = "30";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "Edad:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Sexo:";
            // 
            // lbl_hc
            // 
            this.lbl_hc.AutoSize = true;
            this.lbl_hc.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_hc.Location = new System.Drawing.Point(100, 41);
            this.lbl_hc.Name = "lbl_hc";
            this.lbl_hc.Size = new System.Drawing.Size(33, 17);
            this.lbl_hc.TabIndex = 4;
            this.lbl_hc.Text = "HC:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "HC:";
            // 
            // lbl_sexo
            // 
            this.lbl_sexo.AutoSize = true;
            this.lbl_sexo.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_sexo.Location = new System.Drawing.Point(100, 67);
            this.lbl_sexo.Name = "lbl_sexo";
            this.lbl_sexo.Size = new System.Drawing.Size(73, 17);
            this.lbl_sexo.TabIndex = 2;
            this.lbl_sexo.Text = "Masculino";
            // 
            // lbl_Nombre
            // 
            this.lbl_Nombre.AutoSize = true;
            this.lbl_Nombre.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Nombre.Location = new System.Drawing.Point(12, 12);
            this.lbl_Nombre.Name = "lbl_Nombre";
            this.lbl_Nombre.Size = new System.Drawing.Size(230, 22);
            this.lbl_Nombre.TabIndex = 0;
            this.lbl_Nombre.Text = "SANTA CRUZ GERARDO";
            // 
            // Cambio_SSC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 480);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Cambio_SSC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cambiar Servicio - Sala - Cama";
            this.Load += new System.EventHandler(this.Cambio_SSC_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_fecha;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cbo_cama;
        private System.Windows.Forms.ComboBox cbo_sala;
        private System.Windows.Forms.ComboBox cbo_servicio;
        private System.Windows.Forms.Label lbl_protocolo;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbl_cama;
        private System.Windows.Forms.Label lbl_sala;
        private System.Windows.Forms.Label lbl_servicio;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_Edad;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_hc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_sexo;
        private System.Windows.Forms.Label lbl_Nombre;
    }
}