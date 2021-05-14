namespace Laboratorio2
{
    partial class ListaImpresoras
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
            this.b1 = new System.Windows.Forms.Button();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.txt_Imp_Cod_Barra = new System.Windows.Forms.TextBox();
            this.txt_Imp_Comprobante = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.b2 = new System.Windows.Forms.Button();
            this.btn_Guardar = new System.Windows.Forms.Button();
            this.b3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Imp_Bono = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // b1
            // 
            this.b1.Location = new System.Drawing.Point(278, 30);
            this.b1.Name = "b1";
            this.b1.Size = new System.Drawing.Size(69, 23);
            this.b1.TabIndex = 0;
            this.b1.Text = "Buscar...";
            this.b1.UseVisualStyleBackColor = true;
            this.b1.Click += new System.EventHandler(this.button1_Click);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // txt_Imp_Cod_Barra
            // 
            this.txt_Imp_Cod_Barra.Location = new System.Drawing.Point(12, 33);
            this.txt_Imp_Cod_Barra.Name = "txt_Imp_Cod_Barra";
            this.txt_Imp_Cod_Barra.Size = new System.Drawing.Size(260, 20);
            this.txt_Imp_Cod_Barra.TabIndex = 1;
            // 
            // txt_Imp_Comprobante
            // 
            this.txt_Imp_Comprobante.Location = new System.Drawing.Point(12, 90);
            this.txt_Imp_Comprobante.Name = "txt_Imp_Comprobante";
            this.txt_Imp_Comprobante.Size = new System.Drawing.Size(260, 20);
            this.txt_Imp_Comprobante.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Impresora Cod. Barra:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Impresora Comprobante:";
            // 
            // b2
            // 
            this.b2.Location = new System.Drawing.Point(279, 90);
            this.b2.Name = "b2";
            this.b2.Size = new System.Drawing.Size(69, 23);
            this.b2.TabIndex = 5;
            this.b2.Text = "Buscar...";
            this.b2.UseVisualStyleBackColor = true;
            this.b2.Click += new System.EventHandler(this.b2_Click);
            // 
            // btn_Guardar
            // 
            this.btn_Guardar.Location = new System.Drawing.Point(127, 182);
            this.btn_Guardar.Name = "btn_Guardar";
            this.btn_Guardar.Size = new System.Drawing.Size(75, 23);
            this.btn_Guardar.TabIndex = 6;
            this.btn_Guardar.Text = "Guardar";
            this.btn_Guardar.UseVisualStyleBackColor = true;
            this.btn_Guardar.Click += new System.EventHandler(this.btn_Guardar_Click);
            // 
            // b3
            // 
            this.b3.Location = new System.Drawing.Point(278, 147);
            this.b3.Name = "b3";
            this.b3.Size = new System.Drawing.Size(69, 23);
            this.b3.TabIndex = 9;
            this.b3.Text = "Buscar...";
            this.b3.UseVisualStyleBackColor = true;
            this.b3.Click += new System.EventHandler(this.b3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Impresora Bono:";
            // 
            // txt_Imp_Bono
            // 
            this.txt_Imp_Bono.Location = new System.Drawing.Point(11, 147);
            this.txt_Imp_Bono.Name = "txt_Imp_Bono";
            this.txt_Imp_Bono.Size = new System.Drawing.Size(260, 20);
            this.txt_Imp_Bono.TabIndex = 7;
            // 
            // ListaImpresoras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 217);
            this.Controls.Add(this.b3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_Imp_Bono);
            this.Controls.Add(this.btn_Guardar);
            this.Controls.Add(this.b2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_Imp_Comprobante);
            this.Controls.Add(this.txt_Imp_Cod_Barra);
            this.Controls.Add(this.b1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ListaImpresoras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista Impresoras";
            this.Load += new System.EventHandler(this.ListaImpresoras_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button b1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.TextBox txt_Imp_Cod_Barra;
        private System.Windows.Forms.TextBox txt_Imp_Comprobante;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button b2;
        private System.Windows.Forms.Button btn_Guardar;
        private System.Windows.Forms.Button b3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Imp_Bono;
    }
}