using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Laboratorio2.Entities;

namespace Laboratorio2
{
    public partial class Cambiar_Clave : Form
    {
        //Form1 f = new Form1();

        public Cambiar_Clave()
        {
            InitializeComponent();
        }
        
        //public Form3(Form1 ff)
        //{
        //    f = ff;
        //    InitializeComponent();
        //}

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            //lb_Usuario.Text = f.Text;
            lb_Usuario.Text = usuarios.usuario;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_CN1.Text != txt_CN2.Text)
            {
                MessageBox.Show("Las claves no coinciden","Verifique las claves", MessageBoxButtons.OK, MessageBoxIcon.Error);   
            }

            if (txt_CN1.Text.Length <= 4)
            {
                MessageBox.Show("Por seguridad ingrese una clave con un mínimo de 4 caracteres", "Clave insegura", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            DAL.HospitalDataSetTableAdapters.QueriesTableAdapter adapter = new DAL.HospitalDataSetTableAdapters.QueriesTableAdapter();
            object id;
            id = adapter.H2_Administracion_CambiarClaveUsuario((Int32)usuarios.id, txt_CAnt.Text, txt_CN1.Text);
            if (Convert.ToInt32(id) == 1)
            {
                MessageBox.Show("Clave Cambiada");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al cambiar la Clave");
            }
            
        }
    }
}
