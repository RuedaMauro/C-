using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Laboratorio2.Entities;
using System.Net;
using System.Configuration;

namespace Laboratorio2
{
    public partial class ListarPacientes : Form
    {
        private Principal m_form = null;
        private long Cargar_automaticamente = 0;

        //public ListarPacientes(Form1 f)
        //{
        //    m_form = f;
        //}

        public ListarPacientes()
        {
            InitializeComponent();
        }

        public ListarPacientes(long id)
        {
            InitializeComponent();
            txt_paciente_id.Text = id.ToString();
            Cargar_automaticamente = id;            
        }

        private void ListarPacientes_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'genteDAL.Tipo_documento' table. You can move, or remove it, as needed.
            this.tipo_documentoTableAdapter.Fill(this.genteDAL.Tipo_documento);
            // TODO: This line of code loads data into the 'genteDAL.Tipo_documento' table. You can move, or remove it, as needed.
            this.tipo_documentoTableAdapter.Fill(this.genteDAL.Tipo_documento);

            if (Cargar_automaticamente != 0)
            {
                CargarPacienteID(Cargar_automaticamente);
            }

        }

        public List<pacientes> CargarPacienteDOC(int Documento, string TDoc)
        {
            List<pacientes> p = Paciente_DOC(Documento, TDoc);
            if (p != null)
            {
                //MessageBox.Show("Ya encontro paciente ahora lo devuelvo");
                return p;
            }
            else
            {
                return null;
            }
        }

        public pacientes CargarPacienteHC_UOM_Solouno(string HC)
        {
            pacientes p = Paciente_NHC_OUM_Solouno(HC);
            if (p != null)
            {
                //MessageBox.Show("Ya encontro paciente ahora lo devuelvo");
                return p;
            }
            else
            {
                return null;
            }
        }

        public List<pacientes> CargarPacienteHC_UOM(string HC)
        {
            List<pacientes> p = Paciente_NHC_OUM(HC);
            if (p != null)
            {
                //MessageBox.Show("Ya encontro paciente ahora lo devuelvo");
                return p;
            }
            else
            {
                return null;
            }
        }

        public List<pacientes> CargarPacienteNHC(long NHC)
        {
            List<pacientes> p = Paciente_NHC(NHC);
            if (p != null)
            {
                return p;
            }
            else
            {
                return null;
            }
        }

        public void CargarPacienteID(long Id)
        {
            pacientes p = Paciente_ID(Id);
            if (p != null)
            {
                CargarPaciente_id();
            }
        }

        public List<pacientes> CargarPacienteAyN(string AyN)
        {
            return Paciente_Apellido(AyN);
        }


        public List<pacientes> Paciente_DOC(Int32 DOC, string T_Doc)
        {
            List<pacientes> lista = new List<pacientes>();
            DAL.HospitalDataSetTableAdapters.H2_Afiliado_Encabezado_DOCTableAdapter adapter = new DAL.HospitalDataSetTableAdapters.H2_Afiliado_Encabezado_DOCTableAdapter();
            DAL.HospitalDataSet.H2_Afiliado_Encabezado_DOCDataTable aTable = adapter.GetData(DOC, T_Doc);

            int pos = 0;
            foreach (DAL.HospitalDataSet.H2_Afiliado_Encabezado_DOCRow row in aTable.Rows)
            {
                pacientes p = new pacientes();
                pos++;
                p.Nro_Busqueda = pos;
                p.cuil_titu = row.cuil_titu;
                p.cuil = row.cuil;
                p.Documento_real = row.documento_real;
                //if (!row.IssexoNull()) p.sexo = row.sexo; else p.sexo = "1";
                if (!row.IssexoNull()) p.sexo = row.sexo; else p.sexo = "1";
                p.documento = row.documento;
                p.Documento = row.documento;
                p.Tipo_Documento = row.Tipo_doc;
                p.cod_tipo_documento = row.cod_tipo;
                if (!row.Isfecha_nacimientoNull()) p.fecha_nacimiento = row.fecha_nacimiento;
                if (!row.IsSeccionalNull()) p.Seccional = row.Seccional;

                if (!row.IsLocalidadNull()) { p.localidad = row.Localidad; }

                p.Paciente = row.apellido;

                if (!row.IsNro_SeccionalNull()) p.Nro_Seccional = row.Nro_Seccional.ToString(); else p.Nro_Seccional = "999";

                if (!row.IstelefonoNull()) p.Telefono = row.telefono;
                p.Titular = "";

                if (!row.IsOSNull()) p.ObraSocial = row.OS; else p.ObraSocial = "Sin Seccionalizar";
                if (!row.IsOSIdNull()) p.OSId = row.OSId; else p.OSId = 999;
                

                if (!row.IsDiscapacidadNull())
                {
                    p.Discapacidad = Convert.ToInt32(row.Discapacidad);

                }
                else
                {
                    p.Discapacidad = 0;
                }
                p.HC_UOM = row.HC_UOM_CENTRAL;
                p.NHC = row.cuil;

                if (!row.IsComentarioNull()) { p.Comentario = row.Comentario; }



                lista.Add(p);
            }

            if (lista.Count > 0)
            {                
                //return lista[0];
                return lista;
            }
            else
            {
                MessageBox.Show("No se encontró paciente con el criterio de busqueda ingresado", "Paciente no encontado",MessageBoxButtons.OK, MessageBoxIcon.Exclamation );                
            }
            return null;
        }


        public List<pacientes> Paciente_NHC_OUM(string HC)
        {
            List<pacientes> lista = new List<pacientes>();
            DAL.HospitalDataSetTableAdapters.H2_Afiliado_Encabezado_HC_UOMTableAdapter adapter = new DAL.HospitalDataSetTableAdapters.H2_Afiliado_Encabezado_HC_UOMTableAdapter();
            DAL.HospitalDataSet.H2_Afiliado_Encabezado_HC_UOMDataTable aTable = adapter.GetData(HC);

            int pos = 0;

            foreach (DAL.HospitalDataSet.H2_Afiliado_Encabezado_HC_UOMRow row in aTable.Rows)
            {
                pacientes p = new pacientes();
                pos++;
                p.Nro_Busqueda = pos;
                p.cuil_titu = row.cuil_titu;
                p.cuil = row.cuil;
                if (!row.IssexoNull()) p.sexo = row.sexo; else p.sexo = "1";
                p.documento = row.documento;
                p.Documento = row.documento;
                p.Documento_real = row.documento_real;
                p.Tipo_Documento = row.Tipo_doc;
                if (!row.Isfecha_nacimientoNull()) p.fecha_nacimiento = row.fecha_nacimiento;
                if (!row.IsSeccionalNull()) p.Seccional = row.Seccional;

                if (!row.IsLocalidadNull()) { p.localidad = row.Localidad; }

                p.Paciente = row.apellido;

                if (!row.IsNro_SeccionalNull()) p.Nro_Seccional = row.Nro_Seccional.ToString(); else p.Nro_Seccional = "999";

                if (!row.IstelefonoNull()) p.Telefono = row.telefono;
                p.Titular = "";

                if (!row.IsOSNull()) p.ObraSocial = row.OS; else p.ObraSocial = "Sin Seccionalizar";
                if (!row.IsOSIdNull()) p.OSId = row.OSId; else p.OSId = 999;
                p.HC_UOM = row.HC_UOM_CENTRAL;

                if (!row.IsDiscapacidadNull())
                {
                    p.Discapacidad = Convert.ToInt32(row.Discapacidad);

                }
                else
                {
                    p.Discapacidad = 0;
                }

                if (!row.IsComentarioNull()) { p.Comentario = row.Comentario; }

                p.NHC = row.cuil;
                lista.Add(p);
            }
            if (lista.Count > 0)
            {
                return lista;
            }
            else
            {
                //MessageBox.Show("No se encontraron pacientes con ese nro de documento", "Paciente no encontado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                
                MessageBox.Show("No se encontró paciente con el criterio de busqueda ingresado", "Paciente no encontado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                
                
            }
            return null;
        }


        public pacientes Paciente_ID(long ID)
        {
            List<pacientes> lista = new List<pacientes>();
            DAL.HospitalDataSetTableAdapters.H2_Afiliado_Encabezado_IDTableAdapter adapter = new DAL.HospitalDataSetTableAdapters.H2_Afiliado_Encabezado_IDTableAdapter();
            DAL.HospitalDataSet.H2_Afiliado_Encabezado_IDDataTable aTable = adapter.GetData(ID);

            int pos = 0;

            foreach (DAL.HospitalDataSet.H2_Afiliado_Encabezado_IDRow row in aTable.Rows)
            {
                pacientes p = new pacientes();
                pos++;
                p.Nro_Busqueda = pos;
                p.cuil_titu = row.cuil_titu;
                p.cuil = row.cuil;
                if (!row.IssexoNull()) p.sexo = row.sexo; else p.sexo = "1";
                p.documento = row.documento;
                p.Documento = row.documento;
                if (!row.Isfecha_nacimientoNull()) p.fecha_nacimiento = row.fecha_nacimiento;
                if (!row.IsSeccionalNull()) p.Seccional = row.Seccional;

                if (!row.IsLocalidadNull()) { p.localidad = row.Localidad; }

                p.Paciente = row.apellido;

                if (!row.IsNro_SeccionalNull()) p.Nro_Seccional = row.Nro_Seccional.ToString(); else p.Nro_Seccional = "999";

                if (!row.IstelefonoNull()) p.Telefono = row.telefono;
                p.Titular = "";

                if (!row.IsOSNull()) p.ObraSocial = row.OS; else p.ObraSocial = "Sin Seccionalizar";
                if (!row.IsOSIdNull()) p.OSId = row.OSId; else p.OSId = 999;
                p.HC_UOM = row.HC_UOM_CENTRAL;

                if (!row.IsDiscapacidadNull())
                {
                    p.Discapacidad = Convert.ToInt32(row.Discapacidad);

                }
                else
                {
                    p.Discapacidad = 0;
                }

                if (!row.IsComentarioNull()) { p.Comentario = row.Comentario; }

                p.Documento_real = row.documento_real;
                p.Tipo_Documento = row.Tipo_doc;

                p.NHC = row.cuil;
                lista.Add(p);
            }
            if (lista.Count > 0)
            {
                return lista[0];
            }
            else
            {
                //MessageBox.Show("No se encontraron pacientes con ese nro de documento", "Paciente no encontado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                
                MessageBox.Show("No se encontró paciente con el criterio de busqueda ingresado", "Paciente no encontado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            return null;
        }



        public pacientes Paciente_NHC_OUM_Solouno(string HC)
        {
            List<pacientes> lista = new List<pacientes>();
            DAL.HospitalDataSetTableAdapters.H2_Afiliado_Encabezado_HC_UOMTableAdapter adapter = new DAL.HospitalDataSetTableAdapters.H2_Afiliado_Encabezado_HC_UOMTableAdapter();
            DAL.HospitalDataSet.H2_Afiliado_Encabezado_HC_UOMDataTable aTable = adapter.GetData(HC);

            int pos = 0;

            foreach (DAL.HospitalDataSet.H2_Afiliado_Encabezado_HC_UOMRow row in aTable.Rows)
            {
                pacientes p = new pacientes();
                pos++;
                p.Nro_Busqueda = pos;
                p.cuil_titu = row.cuil_titu;
                p.cuil = row.cuil;
                if (!row.IssexoNull()) p.sexo = row.sexo; else p.sexo = "1";

                p.documento = row.documento;
                if (!row.Isfecha_nacimientoNull()) p.fecha_nacimiento = row.fecha_nacimiento;
                if (!row.IsSeccionalNull()) p.Seccional = row.Seccional;

                if (!row.IsLocalidadNull()) { p.localidad = row.Localidad; }

                p.Paciente = row.apellido;

                if (!row.IsNro_SeccionalNull()) p.Nro_Seccional = row.Nro_Seccional.ToString(); else p.Nro_Seccional = "999";

                if (!row.IstelefonoNull()) p.Telefono = row.telefono;
                p.Titular = "";

                if (!row.IsOSNull()) p.ObraSocial = row.OS; else p.ObraSocial = "Sin Seccionalizar";
                if (!row.IsOSIdNull()) p.OSId = row.OSId; else p.OSId = 999;
                p.HC_UOM = row.HC_UOM_CENTRAL;

                if (!row.IsDiscapacidadNull())
                {
                    p.Discapacidad = Convert.ToInt32(row.Discapacidad);

                }
                else
                {
                    p.Discapacidad = 0;
                }

                if (!row.IsComentarioNull()) { p.Comentario = row.Comentario; }

                p.NHC = row.cuil;
                lista.Add(p);
            }
            if (lista.Count > 0)
            {
                return lista[0];
            }
            else
            {
                //MessageBox.Show("No se encontraron pacientes con ese nro de documento", "Paciente no encontado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                MessageBox.Show("No se encontró paciente con el criterio de busqueda ingresado", "Paciente no encontado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                
            }
            return null;
        }


        public List<pacientes> Paciente_NHC(long NHC)
        {
            List<pacientes> lista = new List<pacientes>();
            DAL.HospitalDataSetTableAdapters.H2_Afiliado_Encabezado_NHCTableAdapter adapter = new DAL.HospitalDataSetTableAdapters.H2_Afiliado_Encabezado_NHCTableAdapter();
            DAL.HospitalDataSet.H2_Afiliado_Encabezado_NHCDataTable aTable = adapter.GetData(NHC);

            int pos = 0;

            foreach (DAL.HospitalDataSet.H2_Afiliado_Encabezado_NHCRow row in aTable.Rows)
            {
                pacientes p = new pacientes();
                pos++;
                p.Nro_Busqueda = pos;
                p.cuil_titu = row.cuil_titu;
                p.cuil = row.cuil;
                if (!row.IssexoNull()) p.sexo = row.sexo; else p.sexo = "1";

                p.documento = row.documento;
                if (!row.Isfecha_nacimientoNull()) p.fecha_nacimiento = row.fecha_nacimiento;
                if (!row.IsSeccionalNull()) p.Seccional = row.Seccional;

                if (!row.IsLocalidadNull()) { p.localidad = row.Localidad; }

                p.Paciente = row.apellido;

                if (!row.IsNro_SeccionalNull()) p.Nro_Seccional = row.Nro_Seccional.ToString(); else p.Nro_Seccional = "999";

                if (!row.IstelefonoNull()) p.Telefono = row.telefono;
                p.Titular = "";

                if (!row.IsOSNull()) p.ObraSocial = row.OS; else p.ObraSocial = "Sin Seccionalizar";
                if (!row.IsOSIdNull()) p.OSId = row.OSId; else p.OSId = 999;

                p.HC_UOM = row.HC_UOM_CENTRAL;
                if (!row.IsDiscapacidadNull())
                {
                    p.Discapacidad = Convert.ToInt32(row.Discapacidad);

                }
                else
                {
                    p.Discapacidad = 0;
                }

                p.NHC = row.cuil;
                p.Documento = row.documento;
                p.Documento_real = row.documento_real;
                p.Tipo_Documento = row.Tipo_doc;

                if (!row.IsComentarioNull()) { p.Comentario = row.Comentario; }

                lista.Add(p);
            }

            if (lista.Count > 0)
            {
                return lista;
            }
            else
            {
                MessageBox.Show("No se encontraron pacientes con ese nro de HC", "Paciente no encontado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null;
        }



        public List<pacientes> Paciente_Apellido(string Apellido)
        {
            List<pacientes> lista = new List<pacientes>();
            DAL.HospitalDataSetTableAdapters.H2_Gente_BuscarPacientes_ApellidoTableAdapter adapter = new DAL.HospitalDataSetTableAdapters.H2_Gente_BuscarPacientes_ApellidoTableAdapter();
            DAL.HospitalDataSet.H2_Gente_BuscarPacientes_ApellidoDataTable aTable = adapter.GetData(Apellido);

            int pos = 0;
            foreach (DAL.HospitalDataSet.H2_Gente_BuscarPacientes_ApellidoRow row in aTable.Rows)
            {
                pacientes p = new pacientes();
                pos++;
                p.Nro_Busqueda = pos;
                p.Paciente = row.apellido;
                p.Documento = row.documento;
                if (!row.IstelefonoNull() && row.telefono.Length > 5) p.Telefono = row.telefono; else p.Telefono = "";
                p.HC_UOM = row.HC_UOM_CENTRAL;
                //if (!row.IsApellidoTitularNull()) p.Titular = row.ApellidoTitular; else p.Titular = "";
                p.NHC = row.cuil;
                p.Documento_real = row.documento_real;
                p.Tipo_Documento = row.Tipo_doc;
                lista.Add(p);

                if (!row.IsComentarioNull()) { p.Comentario = row.Comentario; }
            }

            return lista;
        }

        //public string Edad(DateTime FNaci)
        //{
        //    //double edad = DateTime.Now.Subtract(FNaci).TotalDays / 365.25;
        //    double edad = (DateTime.Now.Year - FNaci.Year);
        //    if (DateTime.Now.Month < FNaci.Month || (DateTime.Now.Month == FNaci.Month && DateTime.Now.Day < FNaci.Day))
        //    {
        //        edad--;
        //    }
        //    if (edad < 0) { edad = 0; }
        //    return edad.ToString();
        //}

        public string Edad(DateTime nacimiento)
        {
            // Crear fechas     
            if (nacimiento.Year == 1 && nacimiento.Month == 1) {return "";}

            DateTime hoy = DateTime.Now;

            // Años
            int edadAnos = hoy.Year - nacimiento.Year;
            if (hoy.Month < nacimiento.Month || (hoy.Month == nacimiento.Month &&
            hoy.Day < nacimiento.Day))
                edadAnos--;

            // Meses
            int edadMeses = hoy.Month - nacimiento.Month;
            if (hoy.Day < nacimiento.Day)
                edadMeses--;
            if (edadMeses < 0)
                edadMeses += 12;

            // Mostrar
            return edadAnos + " años " + edadMeses + " meses";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gb_buscar.Visible = true;
            this.Refresh();
            Buscar();
            gb_buscar.Visible = false;
        }


        private void Buscar()
        {
            Principal parent = (Principal)this.Owner;
            //pacientes paciente = new pacientes();
            List<pacientes> pp = new List<pacientes>();
            gv_Pacientes.DataSource = null;
            if (txt_DNI.Text != "")
            {
                //List<pacientes> pp = new List<pacientes>();      
                //paciente = (Convert.ToInt32(txt_DNI.Text));
                //MessageBox.Show("Ya devolvio al paciente");
                //List<pacientes> pp = new List<pacientes>();
                pp = CargarPacienteDOC(Convert.ToInt32(txt_DNI.Text), cbo_Tipo_Doc.SelectedValue.ToString());
                gv_Pacientes.AutoGenerateColumns = false;
                gv_Pacientes.DataSource = pp;
                //if (pp != null && pp.Count.ToString() == "1")
                //{
                //    string buscar = pp[0].documento.ToString();
                //    txt_paciente_id.Text = "";
                //    txt_paciente_id.Text = buscar;
                //    CargarPaciente_id();
                //}

                ////////////////////if (paciente.Nro_Seccional == "1") { MessageBox.Show("Revise la seccional del paciente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }

                ////////////////////string sexo = "Masculino";
                ////////////////////if (paciente.sexo == "2") { sexo = "Femenino"; }

                ////////////////////parent.lbl_ApellidoyNombre.Text = "HC: " + paciente.HC_UOM + "         Paciente: " + paciente.Paciente + " (" + Edad(Convert.ToDateTime(paciente.fecha_nacimiento)) + ") - Sexo: " + sexo;
                ////////////////////parent.lbl_DNI.Text = "DNI: " + paciente.Documento_real + "     CUIL: " + paciente.NHC + "       Teléfono: " + paciente.Telefono;
                ////////////////////parent.lbl_Seccional.Text = "Seccional: " + paciente.Seccional;
                ////////////////////parent.lbl_PacienteOculto.Text = paciente.Paciente;
                ////////////////////parent.lbl_DNIAux.Text = paciente.documento.ToString();
                ////////////////////parent.lbl_NHCOculto.Text = paciente.HC_UOM;
                ////////////////////parent.paciente_id.Text = paciente.documento.ToString();

                //////////////////////string edad = (DateTime.Now.Year - Convert.ToDateTime(paciente.fecha_nacimiento).Year).ToString();
                ////////////////////string edad = Edad(Convert.ToDateTime(paciente.fecha_nacimiento));
                ////////////////////try
                ////////////////////{
                ////////////////////    if (Convert.ToInt32(edad) > 100) { edad = ""; }
                ////////////////////}
                ////////////////////catch
                ////////////////////{
                ////////////////////    edad = "";
                ////////////////////}

                ////////////////////parent.lbl_edad.Text = edad;

                //ESTO ES PARA QUE CARGUE LA IMAGEN DEL PACIENTE
                //try
                //{
                //    //var request = WebRequest.Create("http://10.10.8.71/Hospitales/img/Pacientes/" + paciente.NHC + ".jpg");
                //    var request = WebRequest.Create(VariablesGlobales.LinkImagenes + paciente.NHC + ".jpg");

                //    using (var response = request.GetResponse())
                //    using (var stream = response.GetResponseStream())
                //    {
                //        parent.img_Paciente.Image = Bitmap.FromStream(stream);
                //    }
                //}
                //catch
                //{ 

                //}

                ////////////////////////this.Close();                
            }
            else if (txt_HC_UOM.Text != "")
            {
                pp = CargarPacienteHC_UOM(txt_HC_UOM.Text);
                gv_Pacientes.AutoGenerateColumns = false;
                gv_Pacientes.DataSource = pp;
                //if (pp != null && pp.Count.ToString() == "1")
                //{
                //    string buscar = pp[0].documento.ToString();
                //    txt_paciente_id.Text = "";
                //    txt_paciente_id.Text = buscar;
                //    CargarPaciente_id();
                //}


                //paciente = CargarPacienteHC_UOM(txt_HC_UOM.Text);
                ////MessageBox.Show("Ya devolvio al paciente");
                //if (paciente != null)
                //{
                //    parent.lbl_ApellidoyNombre.Text = "HC: " + paciente.HC_UOM + "         Paciente: " + paciente.Paciente + " (" + Edad(Convert.ToDateTime(paciente.fecha_nacimiento)) + ")";
                //    parent.lbl_DNI.Text = "DNI: " + paciente.documento + "     CUIL: " + paciente.NHC + "       Teléfono: " + paciente.Telefono;
                //    parent.lbl_Seccional.Text = "Seccional: " + paciente.Seccional;
                //    parent.lbl_PacienteOculto.Text = paciente.Paciente;
                //    parent.lbl_DNIAux.Text = paciente.documento.ToString();
                //    parent.lbl_NHCOculto.Text = paciente.HC_UOM;
                //    //string edad = (DateTime.Now.Year - Convert.ToDateTime(paciente.fecha_nacimiento).Year).ToString();
                //    string edad = Edad(Convert.ToDateTime(paciente.fecha_nacimiento));
                //    try
                //    {
                //        if (Convert.ToInt32(edad) > 105) { edad = ""; }
                //    }
                //    catch
                //    {
                //        edad = "";
                //    }

                //    parent.lbl_edad.Text = edad;

                //    try
                //    {
                //        //var request = WebRequest.Create("http://10.10.8.71/Hospitales/img/Pacientes/" + paciente.NHC + ".jpg");
                //        var request = WebRequest.Create(VariablesGlobales.LinkImagenes + paciente.NHC + ".jpg");

                //        using (var response = request.GetResponse())
                //        using (var stream = response.GetResponseStream())
                //        {
                //            parent.img_Paciente.Image = Bitmap.FromStream(stream);
                //        }
                //    }
                //    catch
                //    {

                //    }

                //    //this.Close();
                //}
            }
            else
            {
                if (txt_NHC.Text != "" && txt_NHC.Text.Length > 8)
                {
                    pp = CargarPacienteNHC(Convert.ToInt64(txt_NHC.Text.Replace("-", "")));
                    gv_Pacientes.AutoGenerateColumns = false;
                    gv_Pacientes.DataSource = pp;
                    //if (pp != null)
                    //{
                    //    string buscar = pp.documento.ToString();
                    //    txt_paciente_id.Text = "";
                    //    txt_paciente_id.Text = buscar;
                    //    //CargarPaciente_id();
                    //}

                    ////////////////////////////paciente = CargarPacienteNHC(Convert.ToInt64(txt_NHC.Text.Replace("-","")));

                    ////////////////////////////if (paciente.Nro_Seccional == "1") { MessageBox.Show("Revise la seccional del paciente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }

                    ////////////////////////////string sexo = "Masculino";
                    ////////////////////////////if (paciente.sexo == "2") { sexo = "Femenino"; }

                    ////////////////////////////parent.lbl_ApellidoyNombre.Text = "HC: " + paciente.HC_UOM + "         Paciente: " + paciente.Paciente + " (" + Edad(Convert.ToDateTime(paciente.fecha_nacimiento)) + ") - Sexo: " + sexo;
                    ////////////////////////////parent.lbl_DNI.Text = "DNI: " + paciente.Documento_real + "     CUIL: " + paciente.NHC + "       Teléfono: " + paciente.Telefono;
                    ////////////////////////////parent.lbl_Seccional.Text = "Seccional: " + paciente.Seccional;
                    ////////////////////////////parent.lbl_PacienteOculto.Text = paciente.Paciente;
                    ////////////////////////////parent.lbl_DNIAux.Text = paciente.documento.ToString();
                    ////////////////////////////parent.lbl_NHCOculto.Text = paciente.HC_UOM;
                    ////////////////////////////parent.paciente_id.Text = paciente.documento.ToString();
                    //////////////////////////////string edad = (DateTime.Now.Year - Convert.ToDateTime(paciente.fecha_nacimiento).Year).ToString();
                    ////////////////////////////string edad = Edad(Convert.ToDateTime(paciente.fecha_nacimiento));
                    ////////////////////////////try
                    ////////////////////////////{
                    ////////////////////////////    if (Convert.ToInt32(edad) > 105) { edad = ""; }
                    ////////////////////////////}
                    ////////////////////////////catch
                    ////////////////////////////{
                    ////////////////////////////    edad = "";
                    ////////////////////////////}

                    ////////////////////////////parent.lbl_edad.Text = edad;

                    //////////////////////////////CARGA LA IMAGEN DEL PACIENTE
                    //////////////////////////////try
                    //////////////////////////////{
                    //////////////////////////////    var request = WebRequest.Create("http://" + VariablesGlobales.LinkImagenes + "/Hospitales/img/Pacientes/" + paciente.NHC + ".jpg");

                    //////////////////////////////    using (var response = request.GetResponse())
                    //////////////////////////////    using (var stream = response.GetResponseStream())
                    //////////////////////////////    {
                    //////////////////////////////        parent.img_Paciente.Image = Bitmap.FromStream(stream);
                    //////////////////////////////    }
                    //////////////////////////////}
                    //////////////////////////////catch
                    //////////////////////////////{

                    //////////////////////////////}

                    ////////////////////////////this.Close();
                }
                else
                {
                    if (txt_AyN.Text != "")
                    {
                        //List<pacientes> pp = new List<pacientes>();
                        pp = CargarPacienteAyN(txt_AyN.Text);
                        gv_Pacientes.AutoGenerateColumns = false;
                        gv_Pacientes.DataSource = pp;
                    }
                }

            }
            gv_Pacientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void CargarPaciente_id()
        {
            Principal parent = (Principal)this.Owner;
            pacientes paciente = new pacientes();
            paciente = Paciente_ID(Convert.ToInt64(txt_paciente_id.Text.Replace("-", "")));
            if (paciente.Nro_Seccional == "1" || paciente.Nro_Seccional == "0") { MessageBox.Show("Revise la seccional del paciente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }

            string sexo = "Masculino";
            if (paciente.sexo == "2") { sexo = "Femenino"; }

            parent.lbl_ApellidoyNombre.Text = "HC: " + paciente.HC_UOM + "         Paciente: " + paciente.Paciente + " (" + Edad(Convert.ToDateTime(paciente.fecha_nacimiento)) + ") - Sexo: " + sexo;
            parent.lbl_DNI.Text = paciente.Tipo_Documento + ": " + paciente.Documento_real + "     CUIL: " + paciente.NHC + "       Teléfono: " + paciente.Telefono;
            parent.lbl_Seccional.Text = "Seccional: " + paciente.Seccional;
            parent.lbl_PacienteOculto.Text = paciente.Paciente;
            parent.lbl_DNIAux.Text = paciente.documento.ToString();
            parent.lbl_NHCOculto.Text = paciente.HC_UOM;
            parent.paciente_id.Text = paciente.documento.ToString();

            parent.Falta_Seccional = false;

            if (paciente.Seccional == "" || paciente.Seccional == null ) { parent.Falta_Seccional = true; }

            //string edad = (DateTime.Now.Year - Convert.ToDateTime(paciente.fecha_nacimiento).Year).ToString();
            string edad = Edad(Convert.ToDateTime(paciente.fecha_nacimiento));
            //try
            //{
            //    if (Convert.ToInt32(edad) > 100) { edad = ""; }
            //}
            //catch
            //{
            //    edad = "";
            //}

            parent.lbl_sexo.Text = sexo.Substring(0, 1).ToUpper();
            parent.lbl_edad.Text = edad;

            if (paciente.Comentario != null && paciente.Comentario.Trim() != "")
            {
                MessageBox.Show(paciente.Comentario, "Comentario", MessageBoxButtons.OK, MessageBoxIcon.Information); 
            }

            DAL.BonoDALTableAdapters.H3_BONO_COBRA_BONO_PACIENTETableAdapter adapter_bono_cobra = new DAL.BonoDALTableAdapters.H3_BONO_COBRA_BONO_PACIENTETableAdapter();
            DAL.BonoDAL.H3_BONO_COBRA_BONO_PACIENTEDataTable aTable_bono_cobra = adapter_bono_cobra.GetData(Convert.ToInt32(paciente.documento));
            if (aTable_bono_cobra.Count > 0)
            {
                if (!aTable_bono_cobra[0].IsDiscapacidadNull())
                {
                    if (!aTable_bono_cobra[0].IsPagaBonoNull())
                    {
                        if (aTable_bono_cobra[0].PagaBono == "S")
                        {
                            try
                            {
                                TimeSpan span = DateTime.Now - aTable_bono_cobra[0].Fecha_Discapacidad;
                                if (span.TotalDays > 0)
                                {
                                    MessageBox.Show(aTable_bono_cobra[0].Discapacidad + "- (CERT. VENCIDO) -", "¡¡ATENCION!!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                }
                            }
                            catch {
                                MessageBox.Show("¡¡¡EL PACIENTE NO POSEE FECHA DE VENCIMIENTO DEL CERTIFICADO DE DISCAPACIDAD!!!", "¡¡ATENCION!!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            }
                            
                        }
                    }
                }

                if (!aTable_bono_cobra[0].IsFV_PMINull())
                {
                    TimeSpan span = DateTime.Now - aTable_bono_cobra[0].FV_PMI;
                    if (span.TotalDays > 0)                    
                    {
                        MessageBox.Show("¡¡¡¡PLAN MATERNO INFANTIL VENCIDO!!!!", "¡¡ATENCION!!", MessageBoxButtons.OK, MessageBoxIcon.Stop);                        
                    }
                }

            }

            this.Close();
        }

        private void gv_Pacientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            gb_buscar.Visible = true;
            label4.Text = "Cargando Paciente....";
            this.Refresh();

            if (gv_Pacientes.Rows.Count > 0)
            {
                if (e.RowIndex != -1)
                {
                    string buscar = gv_Pacientes[6, gv_Pacientes.CurrentCell.RowIndex].Value.ToString();
                    //txt_DNI.Text = buscar;
                    //button1_Click(null, null);                    
                    txt_paciente_id.Text = buscar;
                    CargarPacienteID(Convert.ToInt64(buscar));
                }
            }
        }

        private void txt_DNI_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13 && txt_DNI.Text != "")
            {
                button1_Click(null, null);
            }
        }

        private void txt_NHC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13 && txt_NHC.Text != "")
            {
                button1_Click(null, null);
            }
        }

        private void txt_AyN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13 && txt_AyN.Text != "")
            {
                button1_Click(null, null);
            }
        }

        private void txt_HC_UOM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13 && txt_HC_UOM.Text != "")
            {
                button1_Click(null, null);
            }
        }




    }
}
