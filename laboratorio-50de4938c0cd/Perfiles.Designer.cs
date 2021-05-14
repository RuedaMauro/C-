namespace Laboratorio2
{
    partial class Perfiles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Perfiles));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ls_Perfil = new System.Windows.Forms.ListBox();
            this.btn_BPerfil = new System.Windows.Forms.Button();
            this.btn_Agregar = new System.Windows.Forms.Button();
            this.btn_Quitar = new System.Windows.Forms.Button();
            this.txt_NPerfil = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.cbo_SubPracticas = new System.Windows.Forms.ComboBox();
            this.cbo_Practicas = new System.Windows.Forms.ComboBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cbo_Perfil = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(17, 3);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(568, 554);
            this.pictureBox1.TabIndex = 54;
            this.pictureBox1.TabStop = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(234)))), ((int)(((byte)(246)))));
            this.label15.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(25, 7);
            this.label15.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 14);
            this.label15.TabIndex = 55;
            this.label15.Text = "Perfiles";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(32, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 14);
            this.label4.TabIndex = 57;
            this.label4.Text = "Nro. Perfil";
            // 
            // ls_Perfil
            // 
            this.ls_Perfil.FormattingEnabled = true;
            this.ls_Perfil.ItemHeight = 14;
            this.ls_Perfil.Location = new System.Drawing.Point(276, 157);
            this.ls_Perfil.Name = "ls_Perfil";
            this.ls_Perfil.Size = new System.Drawing.Size(281, 354);
            this.ls_Perfil.TabIndex = 58;
            // 
            // btn_BPerfil
            // 
            this.btn_BPerfil.Location = new System.Drawing.Point(432, 58);
            this.btn_BPerfil.Name = "btn_BPerfil";
            this.btn_BPerfil.Size = new System.Drawing.Size(125, 23);
            this.btn_BPerfil.TabIndex = 4;
            this.btn_BPerfil.Text = "Eliminar";
            this.btn_BPerfil.UseVisualStyleBackColor = true;
            this.btn_BPerfil.Click += new System.EventHandler(this.btn_BPerfil_Click);
            // 
            // btn_Agregar
            // 
            this.btn_Agregar.Location = new System.Drawing.Point(199, 157);
            this.btn_Agregar.Name = "btn_Agregar";
            this.btn_Agregar.Size = new System.Drawing.Size(71, 23);
            this.btn_Agregar.TabIndex = 8;
            this.btn_Agregar.Text = "Agregar";
            this.btn_Agregar.UseVisualStyleBackColor = true;
            this.btn_Agregar.Click += new System.EventHandler(this.btn_Agregar_Click);
            // 
            // btn_Quitar
            // 
            this.btn_Quitar.Location = new System.Drawing.Point(199, 186);
            this.btn_Quitar.Name = "btn_Quitar";
            this.btn_Quitar.Size = new System.Drawing.Size(71, 23);
            this.btn_Quitar.TabIndex = 9;
            this.btn_Quitar.Text = "Quitar";
            this.btn_Quitar.UseVisualStyleBackColor = true;
            this.btn_Quitar.Click += new System.EventHandler(this.btn_Quitar_Click);
            // 
            // txt_NPerfil
            // 
            this.txt_NPerfil.FormattingEnabled = true;
            this.txt_NPerfil.Location = new System.Drawing.Point(106, 29);
            this.txt_NPerfil.Name = "txt_NPerfil";
            this.txt_NPerfil.Size = new System.Drawing.Size(87, 22);
            this.txt_NPerfil.TabIndex = 0;
            this.txt_NPerfil.SelectedIndexChanged += new System.EventHandler(this.txt_NPerfil_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(301, 58);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(125, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(170, 58);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(125, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Guardar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // cbo_SubPracticas
            // 
            this.cbo_SubPracticas.DisplayMember = "Practica";
            this.cbo_SubPracticas.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_SubPracticas.FormattingEnabled = true;
            this.cbo_SubPracticas.Location = new System.Drawing.Point(127, 116);
            this.cbo_SubPracticas.Name = "cbo_SubPracticas";
            this.cbo_SubPracticas.Size = new System.Drawing.Size(430, 22);
            this.cbo_SubPracticas.TabIndex = 7;
            this.cbo_SubPracticas.ValueMember = "Cod";
            this.cbo_SubPracticas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbo_SubPracticas_KeyDown);
            // 
            // cbo_Practicas
            // 
            this.cbo_Practicas.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbo_Practicas.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbo_Practicas.DisplayMember = "Practica";
            this.cbo_Practicas.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_Practicas.FormattingEnabled = true;
            this.cbo_Practicas.Location = new System.Drawing.Point(221, 87);
            this.cbo_Practicas.Name = "cbo_Practicas";
            this.cbo_Practicas.Size = new System.Drawing.Size(336, 22);
            this.cbo_Practicas.TabIndex = 6;
            this.cbo_Practicas.ValueMember = "Cod";
            this.cbo_Practicas.SelectedIndexChanged += new System.EventHandler(this.cbo_Practicas_SelectedIndexChanged);
            // 
            // txtCodigo
            // 
            this.txtCodigo.AcceptsTab = true;
            this.txtCodigo.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(127, 87);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(88, 22);
            this.txtCodigo.TabIndex = 5;
            this.txtCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigo_KeyDown);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(31, 122);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(80, 14);
            this.label13.TabIndex = 73;
            this.label13.Text = "SubPráctica";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(31, 90);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 14);
            this.label12.TabIndex = 72;
            this.label12.Text = "Práctica";
            // 
            // cbo_Perfil
            // 
            this.cbo_Perfil.FormattingEnabled = true;
            this.cbo_Perfil.Location = new System.Drawing.Point(199, 29);
            this.cbo_Perfil.Name = "cbo_Perfil";
            this.cbo_Perfil.Size = new System.Drawing.Size(358, 22);
            this.cbo_Perfil.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(89, 57);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 74;
            this.button1.Text = "Nuevo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(170, 215);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 23);
            this.button4.TabIndex = 75;
            this.button4.Text = "Limpiar Lista";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Perfiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 567);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbo_SubPracticas);
            this.Controls.Add(this.cbo_Practicas);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cbo_Perfil);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txt_NPerfil);
            this.Controls.Add(this.btn_Quitar);
            this.Controls.Add(this.btn_Agregar);
            this.Controls.Add(this.btn_BPerfil);
            this.Controls.Add(this.ls_Perfil);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Verdana", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Perfiles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificar Perfiles";
            this.Load += new System.EventHandler(this.Perfiles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox ls_Perfil;
        private System.Windows.Forms.Button btn_BPerfil;
        private System.Windows.Forms.Button btn_Agregar;
        private System.Windows.Forms.Button btn_Quitar;
        private System.Windows.Forms.ComboBox txt_NPerfil;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox cbo_SubPracticas;
        private System.Windows.Forms.ComboBox cbo_Practicas;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbo_Perfil;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
    }
}