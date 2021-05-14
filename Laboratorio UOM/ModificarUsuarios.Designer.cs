namespace Laboratorio2
{
    partial class ModificarUsuarios
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Aceptar = new System.Windows.Forms.Button();
            this.bt_Cancelar = new System.Windows.Forms.Button();
            this.ck_bloquear = new System.Windows.Forms.CheckBox();
            this.txt_Nombre = new System.Windows.Forms.TextBox();
            this.txt_Usuario = new System.Windows.Forms.TextBox();
            this.txt_pass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbo_tipousuario = new System.Windows.Forms.ComboBox();
            this.cbo_Avellaneda_solo_guardia = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre de Usuario:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Usuario:";
            // 
            // btn_Aceptar
            // 
            this.btn_Aceptar.Location = new System.Drawing.Point(96, 187);
            this.btn_Aceptar.Name = "btn_Aceptar";
            this.btn_Aceptar.Size = new System.Drawing.Size(75, 23);
            this.btn_Aceptar.TabIndex = 3;
            this.btn_Aceptar.Text = "Aceptar";
            this.btn_Aceptar.UseVisualStyleBackColor = true;
            this.btn_Aceptar.Click += new System.EventHandler(this.btn_Aceptar_Click);
            // 
            // bt_Cancelar
            // 
            this.bt_Cancelar.Location = new System.Drawing.Point(177, 187);
            this.bt_Cancelar.Name = "bt_Cancelar";
            this.bt_Cancelar.Size = new System.Drawing.Size(75, 23);
            this.bt_Cancelar.TabIndex = 4;
            this.bt_Cancelar.Text = "Cancelar";
            this.bt_Cancelar.UseVisualStyleBackColor = true;
            this.bt_Cancelar.Click += new System.EventHandler(this.bt_Cancelar_Click);
            // 
            // ck_bloquear
            // 
            this.ck_bloquear.AutoSize = true;
            this.ck_bloquear.Location = new System.Drawing.Point(13, 191);
            this.ck_bloquear.Name = "ck_bloquear";
            this.ck_bloquear.Size = new System.Drawing.Size(56, 17);
            this.ck_bloquear.TabIndex = 6;
            this.ck_bloquear.Text = "Activo";
            this.ck_bloquear.UseVisualStyleBackColor = true;
            // 
            // txt_Nombre
            // 
            this.txt_Nombre.Location = new System.Drawing.Point(121, 44);
            this.txt_Nombre.Name = "txt_Nombre";
            this.txt_Nombre.Size = new System.Drawing.Size(154, 20);
            this.txt_Nombre.TabIndex = 7;
            // 
            // txt_Usuario
            // 
            this.txt_Usuario.Location = new System.Drawing.Point(121, 75);
            this.txt_Usuario.Name = "txt_Usuario";
            this.txt_Usuario.Size = new System.Drawing.Size(154, 20);
            this.txt_Usuario.TabIndex = 8;
            // 
            // txt_pass
            // 
            this.txt_pass.Location = new System.Drawing.Point(121, 101);
            this.txt_pass.Name = "txt_pass";
            this.txt_pass.PasswordChar = '*';
            this.txt_pass.Size = new System.Drawing.Size(154, 20);
            this.txt_pass.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Clave de acceso:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Tipo Usuario:";
            // 
            // cbo_tipousuario
            // 
            this.cbo_tipousuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_tipousuario.FormattingEnabled = true;
            this.cbo_tipousuario.Items.AddRange(new object[] {
            "Usuario",
            "Administrador"});
            this.cbo_tipousuario.Location = new System.Drawing.Point(121, 15);
            this.cbo_tipousuario.Name = "cbo_tipousuario";
            this.cbo_tipousuario.Size = new System.Drawing.Size(154, 21);
            this.cbo_tipousuario.TabIndex = 12;
            // 
            // cbo_Avellaneda_solo_guardia
            // 
            this.cbo_Avellaneda_solo_guardia.AutoSize = true;
            this.cbo_Avellaneda_solo_guardia.Location = new System.Drawing.Point(121, 136);
            this.cbo_Avellaneda_solo_guardia.Name = "cbo_Avellaneda_solo_guardia";
            this.cbo_Avellaneda_solo_guardia.Size = new System.Drawing.Size(161, 17);
            this.cbo_Avellaneda_solo_guardia.TabIndex = 13;
            this.cbo_Avellaneda_solo_guardia.Text = "Ve solo guardia (Avellaneda)";
            this.cbo_Avellaneda_solo_guardia.UseVisualStyleBackColor = true;
            this.cbo_Avellaneda_solo_guardia.Visible = false;
            // 
            // ModificarUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 227);
            this.Controls.Add(this.cbo_Avellaneda_solo_guardia);
            this.Controls.Add(this.cbo_tipousuario);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_pass);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_Usuario);
            this.Controls.Add(this.txt_Nombre);
            this.Controls.Add(this.ck_bloquear);
            this.Controls.Add(this.bt_Cancelar);
            this.Controls.Add(this.btn_Aceptar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ModificarUsuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ModificarUsuarios";
            this.Load += new System.EventHandler(this.ModificarUsuarios_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Aceptar;
        private System.Windows.Forms.Button bt_Cancelar;
        private System.Windows.Forms.CheckBox ck_bloquear;
        private System.Windows.Forms.TextBox txt_Nombre;
        private System.Windows.Forms.TextBox txt_Usuario;
        private System.Windows.Forms.TextBox txt_pass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbo_tipousuario;
        private System.Windows.Forms.CheckBox cbo_Avellaneda_solo_guardia;
    }
}