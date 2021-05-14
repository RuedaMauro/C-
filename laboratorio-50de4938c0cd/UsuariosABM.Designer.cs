namespace Laboratorio2
{
    partial class UsuariosABM
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
            this.gv_Usuarios = new System.Windows.Forms.DataGridView();
            this.usuarioid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.activo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_Agregar = new System.Windows.Forms.Button();
            this.btn_cambiar = new System.Windows.Forms.Button();
            this.btn_borrar = new System.Windows.Forms.Button();
            this.btn_cerrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Usuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // gv_Usuarios
            // 
            this.gv_Usuarios.AllowUserToAddRows = false;
            this.gv_Usuarios.AllowUserToDeleteRows = false;
            this.gv_Usuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv_Usuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.usuarioid,
            this.nombre,
            this.usuario,
            this.activo,
            this.clave});
            this.gv_Usuarios.Location = new System.Drawing.Point(12, 11);
            this.gv_Usuarios.Name = "gv_Usuarios";
            this.gv_Usuarios.ReadOnly = true;
            this.gv_Usuarios.Size = new System.Drawing.Size(560, 395);
            this.gv_Usuarios.TabIndex = 0;
            this.gv_Usuarios.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gv_Usuarios_CellMouseClick);
            // 
            // usuarioid
            // 
            this.usuarioid.DataPropertyName = "id";
            this.usuarioid.HeaderText = "id";
            this.usuarioid.Name = "usuarioid";
            this.usuarioid.ReadOnly = true;
            this.usuarioid.Visible = false;
            // 
            // nombre
            // 
            this.nombre.DataPropertyName = "nombre";
            this.nombre.HeaderText = "nombre";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            this.nombre.Visible = false;
            // 
            // usuario
            // 
            this.usuario.DataPropertyName = "usuario";
            this.usuario.HeaderText = "usuario";
            this.usuario.Name = "usuario";
            this.usuario.ReadOnly = true;
            // 
            // activo
            // 
            this.activo.DataPropertyName = "activo";
            this.activo.HeaderText = "activo";
            this.activo.Name = "activo";
            this.activo.ReadOnly = true;
            this.activo.Visible = false;
            // 
            // clave
            // 
            this.clave.DataPropertyName = "clave";
            this.clave.HeaderText = "clave";
            this.clave.Name = "clave";
            this.clave.ReadOnly = true;
            this.clave.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clave.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clave.Visible = false;
            // 
            // btn_Agregar
            // 
            this.btn_Agregar.Location = new System.Drawing.Point(335, 426);
            this.btn_Agregar.Name = "btn_Agregar";
            this.btn_Agregar.Size = new System.Drawing.Size(75, 23);
            this.btn_Agregar.TabIndex = 1;
            this.btn_Agregar.Text = "Agregar";
            this.btn_Agregar.UseVisualStyleBackColor = true;
            this.btn_Agregar.Click += new System.EventHandler(this.btn_Agregar_Click);
            // 
            // btn_cambiar
            // 
            this.btn_cambiar.Location = new System.Drawing.Point(416, 426);
            this.btn_cambiar.Name = "btn_cambiar";
            this.btn_cambiar.Size = new System.Drawing.Size(75, 23);
            this.btn_cambiar.TabIndex = 2;
            this.btn_cambiar.Text = "Cambiar";
            this.btn_cambiar.UseVisualStyleBackColor = true;
            this.btn_cambiar.Click += new System.EventHandler(this.btn_cambiar_Click);
            // 
            // btn_borrar
            // 
            this.btn_borrar.Location = new System.Drawing.Point(497, 426);
            this.btn_borrar.Name = "btn_borrar";
            this.btn_borrar.Size = new System.Drawing.Size(75, 23);
            this.btn_borrar.TabIndex = 3;
            this.btn_borrar.Text = "Borrar";
            this.btn_borrar.UseVisualStyleBackColor = true;
            this.btn_borrar.Click += new System.EventHandler(this.btn_borrar_Click);
            // 
            // btn_cerrar
            // 
            this.btn_cerrar.Location = new System.Drawing.Point(497, 480);
            this.btn_cerrar.Name = "btn_cerrar";
            this.btn_cerrar.Size = new System.Drawing.Size(75, 23);
            this.btn_cerrar.TabIndex = 4;
            this.btn_cerrar.Text = "Cerrar";
            this.btn_cerrar.UseVisualStyleBackColor = true;
            this.btn_cerrar.Click += new System.EventHandler(this.btn_cerrar_Click);
            // 
            // UsuariosABM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 515);
            this.Controls.Add(this.btn_cerrar);
            this.Controls.Add(this.btn_borrar);
            this.Controls.Add(this.btn_cambiar);
            this.Controls.Add(this.btn_Agregar);
            this.Controls.Add(this.gv_Usuarios);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "UsuariosABM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Usuarios del Sistema";
            this.Load += new System.EventHandler(this.UsuariosABM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gv_Usuarios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gv_Usuarios;
        private System.Windows.Forms.Button btn_Agregar;
        private System.Windows.Forms.Button btn_cambiar;
        private System.Windows.Forms.Button btn_borrar;
        private System.Windows.Forms.Button btn_cerrar;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioid;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuario;
        private System.Windows.Forms.DataGridViewCheckBoxColumn activo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clave;
    }
}