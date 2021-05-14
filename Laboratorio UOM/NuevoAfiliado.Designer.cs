namespace Laboratorio2
{
    partial class NuevoAfiliado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NuevoAfiliado));
            this.label1 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.cbo_pariente = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_apellidoynombre = new System.Windows.Forms.TextBox();
            this.cbo_seccional = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txt_Celular = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.cbo_Provincia = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txt_Localidad = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txt_CP = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_dpto = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_piso = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_numero = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_calle = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cbo_tipo_documento = new System.Windows.Forms.ComboBox();
            this.tipodocumentoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.genteDAL = new Laboratorio2.DAL.GenteDAL();
            this.btn_Editar = new System.Windows.Forms.Button();
            this.btn_BuscarEmpresa = new System.Windows.Forms.Button();
            this.btn_BuscarTitular = new System.Windows.Forms.Button();
            this.cbo_discapacidad = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txt_fechanacimiento = new System.Windows.Forms.DateTimePicker();
            this.txt_telefono = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_cuilempresas = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_cuiltitu = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_cuil = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbo_sexof = new System.Windows.Forms.RadioButton();
            this.cbo_sexom = new System.Windows.Forms.RadioButton();
            this.txt_Documento = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.bt_Actualizar = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.txt_NroHC_UOM = new System.Windows.Forms.TextBox();
            this.btn_VerificarHC = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tipo_documentoTableAdapter = new Laboratorio2.DAL.GenteDALTableAdapters.Tipo_documentoTableAdapter();
            this.txt_paciente_id = new System.Windows.Forms.TextBox();
            this.txt_Correo = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tipodocumentoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.genteDAL)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(45, 45);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 14);
            this.label1.TabIndex = 42;
            this.label1.Text = "Código Pariente:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(234)))), ((int)(((byte)(246)))));
            this.label15.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(31, 17);
            this.label15.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(143, 14);
            this.label15.TabIndex = 43;
            this.label15.Text = "Nueva Historia Clínica";
            // 
            // cbo_pariente
            // 
            this.cbo_pariente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_pariente.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_pariente.FormattingEnabled = true;
            this.cbo_pariente.Location = new System.Drawing.Point(164, 43);
            this.cbo_pariente.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbo_pariente.Name = "cbo_pariente";
            this.cbo_pariente.Size = new System.Drawing.Size(160, 22);
            this.cbo_pariente.TabIndex = 0;
            this.cbo_pariente.SelectedIndexChanged += new System.EventHandler(this.cbo_pariente_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(33, 74);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 14);
            this.label2.TabIndex = 45;
            this.label2.Text = "Apellido y Nombre:";
            // 
            // txt_apellidoynombre
            // 
            this.txt_apellidoynombre.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_apellidoynombre.Location = new System.Drawing.Point(164, 72);
            this.txt_apellidoynombre.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_apellidoynombre.MaxLength = 60;
            this.txt_apellidoynombre.Name = "txt_apellidoynombre";
            this.txt_apellidoynombre.Size = new System.Drawing.Size(299, 22);
            this.txt_apellidoynombre.TabIndex = 1;
            // 
            // cbo_seccional
            // 
            this.cbo_seccional.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_seccional.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_seccional.FormattingEnabled = true;
            this.cbo_seccional.Location = new System.Drawing.Point(471, 72);
            this.cbo_seccional.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbo_seccional.Name = "cbo_seccional";
            this.cbo_seccional.Size = new System.Drawing.Size(160, 22);
            this.cbo_seccional.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txt_Celular);
            this.tabPage2.Controls.Add(this.label18);
            this.tabPage2.Controls.Add(this.cbo_Provincia);
            this.tabPage2.Controls.Add(this.label16);
            this.tabPage2.Controls.Add(this.txt_Localidad);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.txt_CP);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.txt_dpto);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.txt_piso);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.txt_numero);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.txt_calle);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage2.Size = new System.Drawing.Size(685, 237);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Domicilio y Contacto";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txt_Celular
            // 
            this.txt_Celular.Location = new System.Drawing.Point(92, 112);
            this.txt_Celular.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_Celular.MaxLength = 20;
            this.txt_Celular.Name = "txt_Celular";
            this.txt_Celular.Size = new System.Drawing.Size(157, 22);
            this.txt_Celular.TabIndex = 16;
            this.txt_Celular.Visible = false;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.White;
            this.label18.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(28, 115);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(56, 14);
            this.label18.TabIndex = 63;
            this.label18.Text = "Celular:";
            this.label18.Visible = false;
            // 
            // cbo_Provincia
            // 
            this.cbo_Provincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_Provincia.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_Provincia.FormattingEnabled = true;
            this.cbo_Provincia.Location = new System.Drawing.Point(420, 84);
            this.cbo_Provincia.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbo_Provincia.Name = "cbo_Provincia";
            this.cbo_Provincia.Size = new System.Drawing.Size(160, 22);
            this.cbo_Provincia.TabIndex = 15;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.White;
            this.label16.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(344, 87);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(68, 14);
            this.label16.TabIndex = 61;
            this.label16.Text = "Provincia:";
            // 
            // txt_Localidad
            // 
            this.txt_Localidad.Location = new System.Drawing.Point(92, 82);
            this.txt_Localidad.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_Localidad.MaxLength = 15;
            this.txt_Localidad.Name = "txt_Localidad";
            this.txt_Localidad.Size = new System.Drawing.Size(157, 22);
            this.txt_Localidad.TabIndex = 14;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.White;
            this.label14.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(13, 85);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(71, 14);
            this.label14.TabIndex = 59;
            this.label14.Text = "Localidad:";
            // 
            // txt_CP
            // 
            this.txt_CP.Location = new System.Drawing.Point(578, 52);
            this.txt_CP.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_CP.MaxLength = 15;
            this.txt_CP.Name = "txt_CP";
            this.txt_CP.Size = new System.Drawing.Size(92, 22);
            this.txt_CP.TabIndex = 13;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.White;
            this.label13.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(535, 55);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 14);
            this.label13.TabIndex = 57;
            this.label13.Text = "CP:";
            // 
            // txt_dpto
            // 
            this.txt_dpto.Location = new System.Drawing.Point(435, 52);
            this.txt_dpto.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_dpto.MaxLength = 8;
            this.txt_dpto.Name = "txt_dpto";
            this.txt_dpto.Size = new System.Drawing.Size(69, 22);
            this.txt_dpto.TabIndex = 12;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.White;
            this.label12.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(388, 55);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 14);
            this.label12.TabIndex = 55;
            this.label12.Text = "DPTO:";
            // 
            // txt_piso
            // 
            this.txt_piso.Location = new System.Drawing.Point(288, 52);
            this.txt_piso.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_piso.MaxLength = 8;
            this.txt_piso.Name = "txt_piso";
            this.txt_piso.Size = new System.Drawing.Size(59, 22);
            this.txt_piso.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(248, 55);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 14);
            this.label11.TabIndex = 53;
            this.label11.Text = "Piso:";
            // 
            // txt_numero
            // 
            this.txt_numero.Location = new System.Drawing.Point(92, 52);
            this.txt_numero.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_numero.MaxLength = 8;
            this.txt_numero.Name = "txt_numero";
            this.txt_numero.Size = new System.Drawing.Size(92, 22);
            this.txt_numero.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(50, 55);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 14);
            this.label10.TabIndex = 51;
            this.label10.Text = "Nro:";
            // 
            // txt_calle
            // 
            this.txt_calle.Location = new System.Drawing.Point(92, 22);
            this.txt_calle.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_calle.MaxLength = 60;
            this.txt_calle.Name = "txt_calle";
            this.txt_calle.Size = new System.Drawing.Size(255, 22);
            this.txt_calle.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(41, 25);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 14);
            this.label9.TabIndex = 49;
            this.label9.Text = "Calle:";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txt_Correo);
            this.tabPage1.Controls.Add(this.label17);
            this.tabPage1.Controls.Add(this.cbo_tipo_documento);
            this.tabPage1.Controls.Add(this.btn_Editar);
            this.tabPage1.Controls.Add(this.btn_BuscarEmpresa);
            this.tabPage1.Controls.Add(this.btn_BuscarTitular);
            this.tabPage1.Controls.Add(this.cbo_discapacidad);
            this.tabPage1.Controls.Add(this.label19);
            this.tabPage1.Controls.Add(this.txt_fechanacimiento);
            this.tabPage1.Controls.Add(this.txt_telefono);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.txt_cuilempresas);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.txt_cuiltitu);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txt_cuil);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.txt_Documento);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage1.Size = new System.Drawing.Size(685, 237);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Datos Principales";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cbo_tipo_documento
            // 
            this.cbo_tipo_documento.DataSource = this.tipodocumentoBindingSource;
            this.cbo_tipo_documento.DisplayMember = "descri";
            this.cbo_tipo_documento.FormattingEnabled = true;
            this.cbo_tipo_documento.Location = new System.Drawing.Point(23, 18);
            this.cbo_tipo_documento.Name = "cbo_tipo_documento";
            this.cbo_tipo_documento.Size = new System.Drawing.Size(98, 22);
            this.cbo_tipo_documento.TabIndex = 67;
            this.cbo_tipo_documento.ValueMember = "cod";
            // 
            // tipodocumentoBindingSource
            // 
            this.tipodocumentoBindingSource.DataMember = "Tipo_documento";
            this.tipodocumentoBindingSource.DataSource = this.genteDAL;
            // 
            // genteDAL
            // 
            this.genteDAL.DataSetName = "GenteDAL";
            this.genteDAL.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btn_Editar
            // 
            this.btn_Editar.Image = ((System.Drawing.Image)(resources.GetObject("btn_Editar.Image")));
            this.btn_Editar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Editar.Location = new System.Drawing.Point(286, 16);
            this.btn_Editar.Name = "btn_Editar";
            this.btn_Editar.Size = new System.Drawing.Size(35, 29);
            this.btn_Editar.TabIndex = 66;
            this.btn_Editar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Editar.UseVisualStyleBackColor = true;
            this.btn_Editar.Visible = false;
            this.btn_Editar.Click += new System.EventHandler(this.btn_Editar_Click);
            // 
            // btn_BuscarEmpresa
            // 
            this.btn_BuscarEmpresa.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_BuscarEmpresa.Image = ((System.Drawing.Image)(resources.GetObject("btn_BuscarEmpresa.Image")));
            this.btn_BuscarEmpresa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_BuscarEmpresa.Location = new System.Drawing.Point(640, 131);
            this.btn_BuscarEmpresa.Name = "btn_BuscarEmpresa";
            this.btn_BuscarEmpresa.Size = new System.Drawing.Size(31, 26);
            this.btn_BuscarEmpresa.TabIndex = 9;
            this.btn_BuscarEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_BuscarEmpresa.UseVisualStyleBackColor = true;
            this.btn_BuscarEmpresa.Click += new System.EventHandler(this.btn_BuscarEmpresa_Click);
            // 
            // btn_BuscarTitular
            // 
            this.btn_BuscarTitular.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_BuscarTitular.Image = ((System.Drawing.Image)(resources.GetObject("btn_BuscarTitular.Image")));
            this.btn_BuscarTitular.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_BuscarTitular.Location = new System.Drawing.Point(290, 134);
            this.btn_BuscarTitular.Name = "btn_BuscarTitular";
            this.btn_BuscarTitular.Size = new System.Drawing.Size(31, 26);
            this.btn_BuscarTitular.TabIndex = 7;
            this.btn_BuscarTitular.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_BuscarTitular.UseVisualStyleBackColor = true;
            this.btn_BuscarTitular.Click += new System.EventHandler(this.btn_BuscarTitular_Click);
            // 
            // cbo_discapacidad
            // 
            this.cbo_discapacidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_discapacidad.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_discapacidad.FormattingEnabled = true;
            this.cbo_discapacidad.Location = new System.Drawing.Point(486, 106);
            this.cbo_discapacidad.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbo_discapacidad.Name = "cbo_discapacidad";
            this.cbo_discapacidad.Size = new System.Drawing.Size(190, 22);
            this.cbo_discapacidad.TabIndex = 3;
            this.cbo_discapacidad.Visible = false;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.White;
            this.label19.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(376, 109);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(94, 14);
            this.label19.TabIndex = 64;
            this.label19.Text = "Discapacidad:";
            this.label19.Visible = false;
            // 
            // txt_fechanacimiento
            // 
            this.txt_fechanacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txt_fechanacimiento.Location = new System.Drawing.Point(483, 19);
            this.txt_fechanacimiento.Name = "txt_fechanacimiento";
            this.txt_fechanacimiento.Size = new System.Drawing.Size(123, 22);
            this.txt_fechanacimiento.TabIndex = 1;
            // 
            // txt_telefono
            // 
            this.txt_telefono.Location = new System.Drawing.Point(486, 78);
            this.txt_telefono.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_telefono.MaxLength = 60;
            this.txt_telefono.Name = "txt_telefono";
            this.txt_telefono.Size = new System.Drawing.Size(190, 22);
            this.txt_telefono.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(404, 81);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 14);
            this.label8.TabIndex = 61;
            this.label8.Text = "Teléfono:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(345, 26);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 14);
            this.label7.TabIndex = 59;
            this.label7.Text = "Fecha Nacimiento:";
            // 
            // txt_cuilempresas
            // 
            this.txt_cuilempresas.Location = new System.Drawing.Point(483, 134);
            this.txt_cuilempresas.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_cuilempresas.MaxLength = 11;
            this.txt_cuilempresas.Name = "txt_cuilempresas";
            this.txt_cuilempresas.Size = new System.Drawing.Size(150, 22);
            this.txt_cuilempresas.TabIndex = 8;
            this.txt_cuilempresas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_cuilempresas_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(370, 137);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 14);
            this.label6.TabIndex = 57;
            this.label6.Text = "CUIT Empresa:";
            // 
            // txt_cuiltitu
            // 
            this.txt_cuiltitu.Location = new System.Drawing.Point(133, 136);
            this.txt_cuiltitu.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_cuiltitu.MaxLength = 11;
            this.txt_cuiltitu.Name = "txt_cuiltitu";
            this.txt_cuiltitu.Size = new System.Drawing.Size(150, 22);
            this.txt_cuiltitu.TabIndex = 6;
            this.txt_cuiltitu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_cuiltitu_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(36, 139);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 14);
            this.label5.TabIndex = 55;
            this.label5.Text = "CUIL Titular:";
            // 
            // txt_cuil
            // 
            this.txt_cuil.Location = new System.Drawing.Point(133, 106);
            this.txt_cuil.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_cuil.MaxLength = 11;
            this.txt_cuil.Name = "txt_cuil";
            this.txt_cuil.Size = new System.Drawing.Size(188, 22);
            this.txt_cuil.TabIndex = 4;
            this.txt_cuil.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_cuil_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(79, 109);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 14);
            this.label4.TabIndex = 53;
            this.label4.Text = "CUIL:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbo_sexof);
            this.groupBox1.Controls.Add(this.cbo_sexom);
            this.groupBox1.Location = new System.Drawing.Point(48, 50);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(273, 50);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sexo:";
            // 
            // cbo_sexof
            // 
            this.cbo_sexof.Location = new System.Drawing.Point(131, 23);
            this.cbo_sexof.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbo_sexof.Name = "cbo_sexof";
            this.cbo_sexof.Size = new System.Drawing.Size(104, 19);
            this.cbo_sexof.TabIndex = 1;
            this.cbo_sexof.TabStop = true;
            this.cbo_sexof.Text = "Femenino";
            this.cbo_sexof.UseVisualStyleBackColor = true;
            this.cbo_sexof.Click += new System.EventHandler(this.cbo_sexof_Click);
            // 
            // cbo_sexom
            // 
            this.cbo_sexom.Location = new System.Drawing.Point(8, 23);
            this.cbo_sexom.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbo_sexom.Name = "cbo_sexom";
            this.cbo_sexom.Size = new System.Drawing.Size(86, 18);
            this.cbo_sexom.TabIndex = 0;
            this.cbo_sexom.TabStop = true;
            this.cbo_sexom.Text = "Masculino";
            this.cbo_sexom.UseVisualStyleBackColor = true;
            this.cbo_sexom.CheckedChanged += new System.EventHandler(this.cbo_sexom_CheckedChanged);
            this.cbo_sexom.Click += new System.EventHandler(this.cbo_sexom_Click);
            // 
            // txt_Documento
            // 
            this.txt_Documento.Location = new System.Drawing.Point(133, 19);
            this.txt_Documento.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_Documento.MaxLength = 8;
            this.txt_Documento.Name = "txt_Documento";
            this.txt_Documento.Size = new System.Drawing.Size(150, 22);
            this.txt_Documento.TabIndex = 0;
            this.txt_Documento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Documento_KeyPress);
            this.txt_Documento.Leave += new System.EventHandler(this.txt_Documento_Leave);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(37, 147);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(693, 264);
            this.tabControl1.TabIndex = 4;
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.Location = new System.Drawing.Point(34, 417);
            this.btn_Cancelar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(100, 25);
            this.btn_Cancelar.TabIndex = 10;
            this.btn_Cancelar.Text = "Cancelar";
            this.btn_Cancelar.UseVisualStyleBackColor = true;
            this.btn_Cancelar.Click += new System.EventHandler(this.button1_Click);
            // 
            // bt_Actualizar
            // 
            this.bt_Actualizar.BackColor = System.Drawing.Color.Lime;
            this.bt_Actualizar.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Actualizar.Location = new System.Drawing.Point(631, 417);
            this.bt_Actualizar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.bt_Actualizar.Name = "bt_Actualizar";
            this.bt_Actualizar.Size = new System.Drawing.Size(100, 25);
            this.bt_Actualizar.TabIndex = 9;
            this.bt_Actualizar.Text = "Actualizar";
            this.bt_Actualizar.UseVisualStyleBackColor = false;
            this.bt_Actualizar.Click += new System.EventHandler(this.button2_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.White;
            this.label20.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(101, 105);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(56, 14);
            this.label20.TabIndex = 51;
            this.label20.Text = "Nro HC:";
            // 
            // txt_NroHC_UOM
            // 
            this.txt_NroHC_UOM.Location = new System.Drawing.Point(164, 100);
            this.txt_NroHC_UOM.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_NroHC_UOM.MaxLength = 15;
            this.txt_NroHC_UOM.Name = "txt_NroHC_UOM";
            this.txt_NroHC_UOM.Size = new System.Drawing.Size(188, 22);
            this.txt_NroHC_UOM.TabIndex = 3;
            // 
            // btn_VerificarHC
            // 
            this.btn_VerificarHC.Location = new System.Drawing.Point(359, 99);
            this.btn_VerificarHC.Name = "btn_VerificarHC";
            this.btn_VerificarHC.Size = new System.Drawing.Size(69, 23);
            this.btn_VerificarHC.TabIndex = 52;
            this.btn_VerificarHC.Text = "Verificar";
            this.btn_VerificarHC.UseVisualStyleBackColor = true;
            this.btn_VerificarHC.Click += new System.EventHandler(this.btn_VerificarHC_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(17, 13);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(753, 453);
            this.pictureBox1.TabIndex = 41;
            this.pictureBox1.TabStop = false;
            // 
            // tipo_documentoTableAdapter
            // 
            this.tipo_documentoTableAdapter.ClearBeforeFill = true;
            // 
            // txt_paciente_id
            // 
            this.txt_paciente_id.Location = new System.Drawing.Point(670, 37);
            this.txt_paciente_id.Name = "txt_paciente_id";
            this.txt_paciente_id.Size = new System.Drawing.Size(100, 22);
            this.txt_paciente_id.TabIndex = 53;
            this.txt_paciente_id.Text = "0";
            this.txt_paciente_id.Visible = false;
            // 
            // txt_Correo
            // 
            this.txt_Correo.Location = new System.Drawing.Point(131, 165);
            this.txt_Correo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_Correo.MaxLength = 350;
            this.txt_Correo.Multiline = true;
            this.txt_Correo.Name = "txt_Correo";
            this.txt_Correo.Size = new System.Drawing.Size(545, 66);
            this.txt_Correo.TabIndex = 68;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.White;
            this.label17.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(33, 169);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(90, 14);
            this.label17.TabIndex = 69;
            this.label17.Text = "Observación:";
            // 
            // NuevoAfiliado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(780, 474);
            this.Controls.Add(this.txt_paciente_id);
            this.Controls.Add(this.btn_VerificarHC);
            this.Controls.Add(this.txt_NroHC_UOM);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.bt_Actualizar);
            this.Controls.Add(this.btn_Cancelar);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.cbo_seccional);
            this.Controls.Add(this.txt_apellidoynombre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbo_pariente);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NuevoAfiliado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nueva Historia Clínica";
            this.Load += new System.EventHandler(this.NuevoAfiliado_Load);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tipodocumentoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.genteDAL)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cbo_pariente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_apellidoynombre;
        private System.Windows.Forms.ComboBox cbo_seccional;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TextBox txt_Documento;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton cbo_sexof;
        private System.Windows.Forms.RadioButton cbo_sexom;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_cuil;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_telefono;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_Celular;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cbo_Provincia;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txt_Localidad;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txt_CP;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_dpto;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_piso;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_numero;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_calle;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btn_Cancelar;
        private System.Windows.Forms.Button bt_Actualizar;
        private System.Windows.Forms.DateTimePicker txt_fechanacimiento;
        private System.Windows.Forms.ComboBox cbo_discapacidad;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txt_NroHC_UOM;
        private System.Windows.Forms.Button btn_BuscarEmpresa;
        private System.Windows.Forms.Button btn_BuscarTitular;
        public System.Windows.Forms.TextBox txt_cuiltitu;
        public System.Windows.Forms.TextBox txt_cuilempresas;
        private System.Windows.Forms.Button btn_VerificarHC;
        private System.Windows.Forms.Button btn_Editar;
        private System.Windows.Forms.ComboBox cbo_tipo_documento;
        private DAL.GenteDAL genteDAL;
        private System.Windows.Forms.BindingSource tipodocumentoBindingSource;
        private DAL.GenteDALTableAdapters.Tipo_documentoTableAdapter tipo_documentoTableAdapter;
        private System.Windows.Forms.TextBox txt_paciente_id;
        private System.Windows.Forms.TextBox txt_Correo;
        private System.Windows.Forms.Label label17;
    }
}