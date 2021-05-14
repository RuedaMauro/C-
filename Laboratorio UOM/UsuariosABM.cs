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
    public partial class UsuariosABM : Form
    {

        public string Id = "0";

        public UsuariosABM()
        {
            InitializeComponent();
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UsuariosABM_Load(object sender, EventArgs e)
        {
            CargarTodosLosPacientes();
            gv_Usuarios.Columns[2].Width = gv_Usuarios.Width-50;
        }

        private void CargarTodosLosPacientes()
        {
            List<usuariosEdicion> l = new List<usuariosEdicion>();

            UsuariosDataSetTableAdapters.H3_UsuariosTableAdapter adapter = new UsuariosDataSetTableAdapters.H3_UsuariosTableAdapter();
            UsuariosDataSet.H3_UsuariosDataTable aTable = adapter.GetData(0);

            foreach (UsuariosDataSet.H3_UsuariosRow row in aTable.Rows)
            {
                usuariosEdicion u = new usuariosEdicion();
                u.activo = row.activo;
                u.id = row.id;
                u.usuario = row.usuario;
                u.nombre = row.nombre;
                u.clave = row.password;
                l.Add(u);
            }

            gv_Usuarios.DataSource = l;
        }




        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            ModificarUsuarios mu = new ModificarUsuarios("0");
            mu.ShowDialog();
        }

        private void gv_Usuarios_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = gv_Usuarios.Rows[e.RowIndex];            
            Id = row.Cells[0].Value.ToString();

        }

        private void btn_cambiar_Click(object sender, EventArgs e)
        {
            ModificarUsuarios mu = new ModificarUsuarios(Id);
            mu.ShowDialog();
        }

        private void btn_borrar_Click(object sender, EventArgs e)
        {
            DialogResult Mensaje = MessageBox.Show("¿Desea eliminar permanentemente el usuario?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Mensaje == DialogResult.Yes)
            { 
                //Borro el Id                
                UsuariosDataSetTableAdapters.QueriesTableAdapter adatper = new UsuariosDataSetTableAdapters.QueriesTableAdapter();
                adatper.DeleteQuery(Convert.ToInt32(Id));
                CargarTodosLosPacientes();
            }
        }
    }
}
