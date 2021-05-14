using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Laboratorio2.Entities;
using System.Configuration;
using System.Net;

namespace Laboratorio2
{
    public partial class NuevoAfiliado : Form
    {

        int Documento = 0;

        public NuevoAfiliado()
        {
            InitializeComponent();
        }


        public NuevoAfiliado(string Documentos)
        {
            if (Documentos != "Paciente")
            {
                InitializeComponent();
                Documento = Convert.ToInt32(Documentos);
                txt_paciente_id.Text = Documento.ToString(); 
                //txt_Documento.Enabled = false;
                //cbo_tipo_documento.Enabled = false;
                //CargarDiscapacidad();
                //CargarParentesco();
                //CargarSeccionales();
                //CargarProvincias();
                //EditarPaciente();
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void button2_Click(object sender, EventArgs e)
        {

            if (txt_NroHC_UOM.Text.Trim() == ""){
                MessageBox.Show("Falta cargar la HC del paciente", "Falta Hc del paciente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            
                DAL.HospitalDataSetTableAdapters.H3_Persona_DNITableAdapter dniadapter = new DAL.HospitalDataSetTableAdapters.H3_Persona_DNITableAdapter();
                DAL.HospitalDataSet.H3_Persona_DNIDataTable aTableDNI = dniadapter.GetData(int.Parse(txt_Documento.Text), Documento);

                if (aTableDNI.Count > 0)
                {
                    MessageBox.Show("El nro de documento ya existe en el sistema, no se guardar el paciente", "DNI Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_NroHC_UOM.Text = "";
                    txt_NroHC_UOM.Focus();
                    button1_Click(null, null);
                    return;
                }
            



            if (Documento == 0)
            {
                List<empresas> lista = new List<empresas>();
                DAL.HospitalDataSetTableAdapters.H3_Datos_NHCTableAdapter adapter = new DAL.HospitalDataSetTableAdapters.H3_Datos_NHCTableAdapter();
                DAL.HospitalDataSet.H3_Datos_NHCDataTable aTable = adapter.GetData(txt_NroHC_UOM.Text);

                int pos = 0;
                if (aTable.Count > 0)
                {
                    MessageBox.Show("El nro de HC: " + aTable[0].HC_UOM_CENTRAL + " ya se ha utilizado en el paciente " + aTable[0].apellido, "HC en uso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_NroHC_UOM.Text = "";
                    txt_NroHC_UOM.Focus();
                    return;
                }
            }




            if (Documento == 0)
            {
                List<empresas> lista = new List<empresas>();
                DAL.HospitalDataSetTableAdapters.H2_Afiliado_Encabezado_DOCTableAdapter adapter_DOC = new DAL.HospitalDataSetTableAdapters.H2_Afiliado_Encabezado_DOCTableAdapter();
                DAL.HospitalDataSet.H2_Afiliado_Encabezado_DOCDataTable aTable_dOC = adapter_DOC.GetData(int.Parse(txt_Documento.Text), "0");
                if (aTable_dOC.Count > 0)
                {
                    if (aTable_dOC[0].IsFecha_BajaNull())
                    {
                        MessageBox.Show("El nro de documento ya se ha utilizado en otro paciente", "Documento en uso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txt_Documento.Focus();
                        return;
                    }
                }
            }



            if (Convert.ToInt32(cbo_seccional.SelectedValue) == 0)
            {                
                MessageBox.Show("Falta cargar la seccional del paciente", "Falta seccional", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool error = false;

            //if (txt_telefono.Text.Trim() == "")
            //{
            //    MessageBox.Show("Falta ingresar el nro de teléfono", "Teléfono",MessageBoxButtons.OK,MessageBoxIcon.Error);
            //    txt_telefono.Focus();
            //    error = true;
            //}


            if (cbo_discapacidad.SelectedValue == "0")
            {
                //MessageBox.Show("Falta indicar discapacidad", "Discapacidad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //cbo_discapacidad.Focus();
                //error = true;
                cbo_discapacidad.SelectedValue = "0";
            }


            if (txt_Documento.Text.Trim() == "")
            {
                MessageBox.Show("Falta ingresar Nro de Documento", "Documento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_Documento.Focus();
                error = true;
            }

            if (cbo_sexof.Checked == false && cbo_sexom.Checked == false)
            {
                MessageBox.Show("Falta indicar el sexo", "Sexo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                error = true;
            }


            if (txt_cuil.Text.Trim() == "")
            {
                MessageBox.Show("Falta el nro de cuil", "CUIL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_cuil.Focus();
                error = true;
            }


            if (txt_cuiltitu.Text.Trim() == "")
            {
                txt_cuiltitu.Text = "0";
                //error = true;
            }

            if (txt_cuilempresas.Text.Trim() == "")
            {
                //MessageBox.Show("Falta el nro de cuit empresas", "CUIT EMPRESAS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //txt_cuilempresas.Focus();
                //error = true;
                txt_cuilempresas.Text = "0";
            }


            if (!error)
            {
                long pac_id = GuardarAfiliado();
                
                MessageBox.Show("Paciente Actualizado", "Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                //this.Close();


                Principal parent = (Principal)this.Owner;
                pacientes paciente = new pacientes();

                paciente = CargarPacienteID(pac_id);
                //MessageBox.Show("Ya devolvio al paciente");
                if (paciente != null)
                {
                    string sexo = "Masculino";
                    if (paciente.sexo == "2") { sexo = "Femenino"; }
                    parent.paciente_id.Text = pac_id.ToString();
                    parent.lbl_ApellidoyNombre.Text = "HC: " + paciente.HC_UOM + "         Paciente: " + paciente.Paciente + " (" + Edad(Convert.ToDateTime(paciente.fecha_nacimiento)) + ") - Sexo: " + sexo;
                    parent.lbl_DNI.Text = paciente.Tipo_Documento + ": " + paciente.Documento_real + "     CUIL: " + paciente.NHC + "       Teléfono: " + paciente.Telefono;
                    parent.lbl_Seccional.Text = "Seccional: " + paciente.Seccional;
                    parent.lbl_PacienteOculto.Text = paciente.Paciente;
                    parent.lbl_DNIAux.Text = paciente.documento.ToString();
                    parent.lbl_NHCOculto.Text = paciente.HC_UOM;

                    //string edad = (DateTime.Now.Year - Convert.ToDateTime(paciente.fecha_nacimiento).Year).ToString();
                    string edad = Edad(Convert.ToDateTime(paciente.fecha_nacimiento));
                    //try
                    //{
                    //    if (Convert.ToInt32(edad) > 105) { edad = ""; }
                    //}
                    //catch
                    //{
                    //    edad = "";
                    //}
                                        
                    parent.lbl_edad.Text = edad;
                    parent.lbl_sexo.Text = sexo.Substring(0, 1).ToUpper();

                    //CARGA LA IMAGEN DEL PACIENTE
                    //try
                    //{                        
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

                    this.Close();
                }


            }
        }


        public string Edad(DateTime nacimiento)
        {
            if (nacimiento.Year == 1 && nacimiento.Month == 1) { return ""; }

            // Crear fechas            
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
            return edadAnos + " años " + edadMeses + " meses" ;
        }


        public pacientes Paciente_ID(Int64 ID, bool MostrarMensaje)
        {
            List<pacientes> lista = new List<pacientes>();
            DAL.HospitalDataSetTableAdapters.H2_Afiliado_Encabezado_IDTableAdapter adapter = new DAL.HospitalDataSetTableAdapters.H2_Afiliado_Encabezado_IDTableAdapter();
            DAL.HospitalDataSet.H2_Afiliado_Encabezado_IDDataTable aTable = adapter.GetData(ID);

            int pos = 0;
            pacientes p = new pacientes();
            foreach (DAL.HospitalDataSet.H2_Afiliado_Encabezado_IDRow row in aTable.Rows)
            {
                pos++;
                p.Nro_Busqueda = pos;
                p.cuil_titu = row.cuil_titu;
                p.cuil = row.cuil;

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

                p.Tipo_Documento = row.Tipo_doc;
                p.Documento_real = row.documento_real;

                if (!row.IsDiscapacidadNull())
                {
                    p.Discapacidad = Convert.ToInt32(row.Discapacidad);

                }
                else
                {
                    p.Discapacidad = 0;
                }
                p.sexo = row.sexo;
                p.HC_UOM = row.HC_UOM_CENTRAL;
                p.NHC = row.cuil;
                lista.Add(p);
            }
            if (lista.Count > 0)
            {
                return lista[0];
            }
            else
            {
                if (MostrarMensaje)
                {
                    MessageBox.Show("No se encontraron pacientes con ese nro de documento", "Paciente no encontado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            return null;
        }



        public pacientes Paciente_DOC(Int32 DOC, bool MostrarMensaje, string T_Doc)
        {
            List<pacientes> lista = new List<pacientes>();
            DAL.HospitalDataSetTableAdapters.H2_Afiliado_Encabezado_DOCTableAdapter adapter = new DAL.HospitalDataSetTableAdapters.H2_Afiliado_Encabezado_DOCTableAdapter();
            DAL.HospitalDataSet.H2_Afiliado_Encabezado_DOCDataTable aTable = adapter.GetData(DOC, T_Doc);

            int pos = 0;
            pacientes p = new pacientes();
            foreach (DAL.HospitalDataSet.H2_Afiliado_Encabezado_DOCRow row in aTable.Rows)
            {
                pos++;
                p.Nro_Busqueda = pos;
                p.cuil_titu = row.cuil_titu;
                p.cuil = row.cuil;

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
                lista.Add(p);
            }
            if (lista.Count > 0)
            {
                return lista[0];
            }
            else
            {
                if (MostrarMensaje)
                {
                    MessageBox.Show("No se encontraron pacientes con ese nro de documento", "Paciente no encontado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            return null;
        }

        public pacientes CargarPacienteID(long Documento)
        {
            pacientes p = Paciente_ID(Documento, true);
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

        private void NuevoAfiliado_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'genteDAL.Tipo_documento' table. You can move, or remove it, as needed.
            this.tipo_documentoTableAdapter.Fill(this.genteDAL.Tipo_documento);
            CargarDiscapacidad();
            CargarParentesco();
            CargarSeccionales();
            CargarProvincias();
            if (Documento > 0)
            {
                //if (VariablesGlobales.MiUsuarioTipo == "Supervisor" || VariablesGlobales.MiUsuarioTipo == "Administrador") { btn_Editar.Visible = true; }
                EditarPaciente();
            }
            else
            {
                cbo_seccional.SelectedValue = Convert.ToInt32(VariablesGlobales.MiUsuarioseccional).ToString();
                btn_Editar.Visible = false;
            }

        }

        private void CargarDiscapacidad()
        {
            List<discapacidad> Lista = new List<discapacidad>();
            Lista.Clear();
            Lista.Add(new discapacidad() { cod = 0, descripcion = "Seleccione" });
            Lista.Add(new discapacidad() { cod = 1, descripcion = "NO" });
            Lista.Add(new discapacidad() { cod = 2, descripcion = "Psíquica" });
            Lista.Add(new discapacidad() { cod = 3, descripcion = "Física" });
            Lista.Add(new discapacidad() { cod = 4, descripcion = "Auditiva" });
            Lista.Add(new discapacidad() { cod = 5, descripcion = "Visual" });
            Lista.Add(new discapacidad() { cod = 6, descripcion = "Multisensorial" });

            cbo_discapacidad.DataSource = Lista;
            cbo_discapacidad.DisplayMember = "descripcion";
            cbo_discapacidad.ValueMember = "cod";

        }

        private void EditarPaciente()
        {
            DAL.HospitalDataSetTableAdapters.H2_Personas_Gente_Local_LaboTableAdapter adapter = new DAL.HospitalDataSetTableAdapters.H2_Personas_Gente_Local_LaboTableAdapter();
            DAL.HospitalDataSet.H2_Personas_Gente_Local_LaboDataTable aTable = adapter.GetData(Documento);
            personas p = new personas();
            if (aTable.Rows.Count > 0)
            {
                p.cuil_titu = Convert.ToInt64(aTable[0].cuil_titu);
                if (!aTable[0].IsCod_ParienteNull()) { p.cod_pariente = Convert.ToInt32(aTable[0].Cod_Pariente); }
                p.cuil = Convert.ToInt64(aTable[0].cuil);
                p.documento = Convert.ToInt32(aTable[0].documento_real);
                p.apellido = aTable[0].apellido;
                if (!aTable[0].IssexoNull()) { p.sexo = Convert.ToInt32(aTable[0].sexo); }
                if (!aTable[0].Isfecha_nacimientoNull()) { p.fecha_nacimiento = aTable[0].fecha_nacimiento.ToShortDateString(); }
                if (!aTable[0].IscalleNull()) { p.calle = aTable[0].calle; }
                if (!aTable[0].IsnumeroNull()) { p.numero = aTable[0].numero; }
                if (!aTable[0].IspisoNull()) { p.piso = aTable[0].piso; }
                if (!aTable[0].IsdeptoNull()) { p.depto = aTable[0].depto; }
                if (!aTable[0].IslocalidadNull()) { p.localidad = aTable[0].localidad; }
                if (!aTable[0].IsCodPostalNull()) { p.cod_pos = aTable[0].CodPostal; }
                if (!aTable[0].IsprovinciaNull()) { p.provincia = Convert.ToInt32(aTable[0].provincia); }
                if (!aTable[0].IstelefonoNull()) { p.telefono = aTable[0].telefono; }
                if (!aTable[0].IsFecha_AltaNull()) { p.fechaalta = aTable[0].Fecha_Alta.ToShortDateString(); }
                if (!aTable[0].IsFecha_ActualizacionNull()) { p.fechaactualizacion = aTable[0].Fecha_Actualizacion.ToShortDateString(); }
                if (!aTable[0].IsFecha_BajaNull()) { p.fechabaja = aTable[0].Fecha_Baja.ToShortDateString(); }
                if (!aTable[0].IsFecha_AltaNull()) { p.fechaaltapadron = aTable[0].Fecha_Alta.ToShortDateString(); }
                if (!aTable[0].IsusuarioNull()) { p.usuario = aTable[0].usuario; }
                if (!aTable[0].IsemailNull()) { p.email = aTable[0].email; }
                if (!aTable[0].IsSeccionalNull()) { p.seccional = aTable[0].Seccional; } else { p.seccional = 1; }

                if (!aTable[0].IsTipo_doc_codigoNull()) p.tipo_doc = aTable[0].tipo_doc; else p.tipo_doc = "DU";
                if (!aTable[0].IsTipo_doc_descripcionNull()) p.doc_descripcion = aTable[0].Tipo_doc_descripcion; else p.doc_descripcion = "DU";
                if (!aTable[0].IscuitNull()) p.cuit = aTable[0].cuit.ToString(); else p.cuit = "0";
                
                //cbo_seccional

                if (!aTable[0].IsHC_UOM_CENTRALNull()) p.Nro_HC_UOM = Convert.ToInt64( aTable[0].HC_UOM_CENTRAL);
                

                if (!aTable[0].IsDiscapacidadNull())
                {
                    p.discapacidad = Convert.ToInt32(aTable[0].Discapacidad);
                }
                else
                {
                    p.discapacidad = 0;
                }
                if (!aTable[0].IsFVDiscapacidadNull()) { p.FVDiscapacidad = aTable[0].FVDiscapacidad.ToShortDateString(); }

                if (!aTable[0].IsCertificadoEstudianteAnioNull()) { p.AnioCertificado = aTable[0].CertificadoEstudianteAnio.ToString(); }



                if (!aTable[0].IsCertificadoEstudiante1Null())
                {
                    p.C1 = aTable[0].CertificadoEstudiante1;
                }
                else
                {
                    p.C1 = false;
                }

                if (!aTable[0].IsCertificadoEstudiante2Null())
                {
                    p.C2 = aTable[0].CertificadoEstudiante2;
                }
                else
                {
                    p.C2 = false;
                }


                if (!aTable[0].IsEsEstudianteNull())
                {
                    p.EsEstudiante = aTable[0].EsEstudiante;
                }
                else
                {
                    p.EsEstudiante = false;
                }


                if (!aTable[0].IsCertificadoEstudianteAnioNull()) { p.AnioCertificado = aTable[0].CertificadoEstudianteAnio.ToString(); }


                if (!aTable[0].IsPINull())
                {
                    p.PI = aTable[0].PI;
                }
                else
                {
                    p.PI = false;
                }

                if (!aTable[0].IsPMINull())
                {
                    p.PMI = aTable[0].PMI;
                }
                else
                {
                    p.PMI = false;
                }
            }


            CargarPaciente(p);
            //CargarTitularLocal(p.cuil_titu, p.cuil);
            
        }

        private void CargarTitularLocal(long cuil, long cuil_paciente)
        {
            DAL.HospitalDataSetTableAdapters.H2_Padron_Gente_Local_LaboTableAdapter adapter = new DAL.HospitalDataSetTableAdapters.H2_Padron_Gente_Local_LaboTableAdapter();
            DAL.HospitalDataSet.H2_Padron_Gente_Local_LaboDataTable aTable = adapter.GetData(cuil);
            titular t = new titular();
            if (aTable.Rows.Count > 0)
            {
                if (!aTable[0].IsCodOSNull()) { t.cod_os = Convert.ToInt32(aTable[0].CodOS); }
                if (!aTable[0].IscuitNull()) { t.cuit = Convert.ToInt64(aTable[0].cuit); }
                if (!aTable[0].IsSeccionalNull()) { t.seccional = Convert.ToInt32(aTable[0].Seccional); }
                t.cuil_titu = Convert.ToInt64(aTable[0].cuil_titu);
                if (!aTable[0].IsFecha_AltaNull()) { t.fechaalta = aTable[0].Fecha_Alta.ToShortDateString(); }
                if (!aTable[0].IsFecha_ActualizacionNull()) { t.fechaactualizacion = aTable[0].Fecha_Actualizacion.ToShortDateString(); }
                if (!aTable[0].IsFecha_BajaNull()) { t.fechabaja = aTable[0].Fecha_Baja.ToShortDateString(); }
                t.documento = Convert.ToInt32(aTable[0].documento);
                t.apellido = aTable[0].apellido;
                if (!aTable[0].IsRazon_SocialNull()) { t.RazonSocial = aTable[0].Razon_Social; }

            }
            else
            {

                if (cuil_paciente != 0)
                {
                    adapter = new DAL.HospitalDataSetTableAdapters.H2_Padron_Gente_Local_LaboTableAdapter();
                    aTable = adapter.GetData(cuil_paciente);
                    t = new titular();
                    if (aTable.Rows.Count > 0)
                    {
                        if (!aTable[0].IsCodOSNull()) { t.cod_os = Convert.ToInt32(aTable[0].CodOS); }
                        if (!aTable[0].IscuitNull()) { t.cuit = Convert.ToInt64(aTable[0].cuit); }
                        if (!aTable[0].IsSeccionalNull()) { t.seccional = Convert.ToInt32(aTable[0].Seccional); }
                        t.cuil_titu = Convert.ToInt64(aTable[0].cuil_titu);
                        if (!aTable[0].IsFecha_AltaNull()) { t.fechaalta = aTable[0].Fecha_Alta.ToShortDateString(); }
                        if (!aTable[0].IsFecha_ActualizacionNull()) { t.fechaactualizacion = aTable[0].Fecha_Actualizacion.ToShortDateString(); }
                        if (!aTable[0].IsFecha_BajaNull()) { t.fechabaja = aTable[0].Fecha_Baja.ToShortDateString(); }
                        t.documento = Convert.ToInt32(aTable[0].documento);
                        t.apellido = aTable[0].apellido;
                        if (!aTable[0].IsRazon_SocialNull()) { t.RazonSocial = aTable[0].Razon_Social; }
                    }
                }
            }
            
            CargarTitularLocal2(t);
        }

        private void CargarTitularLocal2(titular t)
        {
            cbo_seccional.SelectedValue = t.seccional.ToString();
            txt_cuilempresas.Text = t.cuit.ToString();
            txt_cuiltitu.Text = t.cuil_titu.ToString();
            
        }

        private void CargarPaciente(personas p)
        {
            cbo_pariente.SelectedValue = p.cod_pariente;            
            txt_apellidoynombre.Text = p.apellido;
            txt_Documento.Text = p.documento.ToString();
            txt_fechanacimiento.Text = p.fecha_nacimiento;
            if (p.sexo == 2)
            {
                cbo_sexof.Checked = true;
            }
            else
            {
                cbo_sexom.Checked = true;
            }
            txt_cuiltitu.Text = p.cuil_titu.ToString();
            txt_cuil.Text = p.cuil.ToString();
            txt_telefono.Text = p.telefono;
            txt_calle.Text = p.calle;
            txt_numero.Text = p.numero;
            txt_piso.Text = p.piso;
            txt_dpto.Text = p.depto;
            txt_CP.Text = p.cod_pos;
            txt_Localidad.Text = p.localidad;
            cbo_Provincia.SelectedItem = p.provincia;
            txt_Correo.Text = p.email;
            cbo_discapacidad.SelectedValue = p.discapacidad;
            txt_NroHC_UOM.Text = p.Nro_HC_UOM.ToString();
            if (p.tipo_doc == null)
            {
                p.tipo_doc = "DU";
                cbo_tipo_documento.SelectedValue = p.tipo_doc;
            }
            cbo_seccional.SelectedValue = p.seccional.ToString();
            txt_cuilempresas.Text = p.cuit;
        }

        private void CargarProvincias()
        {
            List<codprovincias> Lista = new List<codprovincias>();

            DAL.HospitalDataSetTableAdapters.H2_Padron_ProvinciaTableAdapter adapter = new DAL.HospitalDataSetTableAdapters.H2_Padron_ProvinciaTableAdapter();
            DAL.HospitalDataSet.H2_Padron_ProvinciaDataTable aTable = adapter.GetData(0);

            foreach (DAL.HospitalDataSet.H2_Padron_ProvinciaRow row in aTable.Rows)
            {
                codprovincias c = new codprovincias();
                c.codigo = Convert.ToInt32(row.cod);
                c.descripcion = row.descri;
                Lista.Add(c);
            }

            cbo_Provincia.DataSource = Lista;
            cbo_Provincia.DisplayMember = "descripcion";
            cbo_Provincia.ValueMember = "codigo";
        }

        private void CargarSeccionales()
        {
            seccionalesListas list = new seccionalesListas();
            DAL.HospitalDataSetTableAdapters.Seccional_ListTableAdapter adapter = new DAL.HospitalDataSetTableAdapters.Seccional_ListTableAdapter();
            DAL.HospitalDataSet.Seccional_ListDataTable aTable = adapter.GetData(null);
            foreach (DAL.HospitalDataSet.Seccional_ListRow row in aTable.Rows)
            {
                seccionales s = new seccionales();
                if (!row.IsIdNull()) s.Nro = row.Id;
                if (!row.IsDescripcionNull()) s.Seccional = row.Descripcion;
                list.Add(s);
            }
            cbo_seccional.DataSource = list;
            cbo_seccional.DisplayMember = "Seccional";
            cbo_seccional.ValueMember = "Nro";
        }

        public void CargarParentesco()
        {
            List<codpariente> Lista = new List<codpariente>();

            DAL.HospitalDataSetTableAdapters.H2_Padron_ParentescoTableAdapter adapter = new DAL.HospitalDataSetTableAdapters.H2_Padron_ParentescoTableAdapter();
            DAL.HospitalDataSet.H2_Padron_ParentescoDataTable aTable = adapter.GetData(0);

            foreach (DAL.HospitalDataSet.H2_Padron_ParentescoRow row in aTable.Rows)
            {
                codpariente c = new codpariente();
                c.codigo = Convert.ToInt32(row.cod);
                c.descripcion = row.descri;
                Lista.Add(c);
            }

            cbo_pariente.DataSource = Lista;
            cbo_pariente.DisplayMember = "descripcion";
            cbo_pariente.ValueMember = "codigo";
        }

        public long GuardarAfiliado()
        {
            DAL.HospitalDataSetTableAdapters.QueriesTableAdapter adapter = new DAL.HospitalDataSetTableAdapters.QueriesTableAdapter();

            bool error = false;
            long cuil;
            int documento;
            string apellido;
            string sexo;
            string telefono;
            int Seccional;
            long cuit;
            string calle;
            string numero;
            string piso;
            string depto;
            string localidad;
            int provincia;
            DateTime fecha_nacimiento;
            bool Provisorio = false;
            long cuil_titu;
            DateTime FechaRevisado;
            DateTime FechaActualizacion;
            DateTime FechaAlta;
            int CodOS = 112103;
            int Cod_Pariente;
            string email;
            string celular;
            string Usuario;
            DateTime FechaBaja;
            string Comentario;
            string CodPos;
            int Discapacidad;
            DateTime FechaDiscapacidad;
            int AnioEstudiante;
            bool Certificado1 = false;
            bool Certificado2 = false;
            bool EsEstudiante = false;
            bool PMI = false;
            bool PI = false;
            string NHC_UOM = "0";
            string TipoDoc = "DU";

            cuil = Convert.ToInt64(txt_cuil.Text);
            documento = Convert.ToInt32(txt_Documento.Text);
            apellido = txt_apellidoynombre.Text;
            sexo = null;
            if (cbo_sexof.Checked) {sexo = "2";}
            if (cbo_sexom.Checked) {sexo = "1";}
            telefono = txt_telefono.Text;
            Seccional = Convert.ToInt32(cbo_seccional.SelectedValue);            
            cuit = Convert.ToInt64(txt_cuilempresas.Text);
            calle = txt_calle.Text;
            numero = txt_numero.Text;
            piso = txt_piso.Text;
            depto = txt_dpto.Text;
            localidad = txt_Localidad.Text;
            provincia = Convert.ToInt32(cbo_Provincia.SelectedValue);
            fecha_nacimiento = Convert.ToDateTime(txt_fechanacimiento.Text);
            cuil_titu = Convert.ToInt64(txt_cuiltitu.Text);
            FechaRevisado = DateTime.Now;
            FechaActualizacion = DateTime.Now;
            FechaAlta = DateTime.Now;
            Cod_Pariente = Convert.ToInt32(cbo_pariente.SelectedValue);
            email = txt_Correo.Text;
            celular = "";
            Usuario = "LABORATORIO";
            FechaBaja = Convert.ToDateTime("01/01/1900");
            Comentario = "";
            CodPos = txt_CP.Text;
            Discapacidad = Convert.ToInt32(cbo_discapacidad.SelectedValue);
            FechaDiscapacidad = Convert.ToDateTime("01/01/1900");
            AnioEstudiante = 0;
            if (txt_NroHC_UOM.Text != "")
            {
                NHC_UOM = txt_NroHC_UOM.Text;
            }
            else
            {
                NHC_UOM = txt_Documento.Text;
            }

            TipoDoc = cbo_tipo_documento.SelectedValue.ToString();

            if (cuil_titu == 0)
            {
                cuil_titu = cuil;
            }

            //EN ALTA DE MEDICO TAMBIEN, OJO!!!
            //CAMBIO SE AGREGO UN NUEVO PARAMETRO, OJO!!!!
            
            //original 14-01-2014
            //object r = adapter.H2_Padron_Alta(cuil, documento, apellido, sexo, telefono, Seccional, cuit, calle, numero, piso, depto, localidad, provincia, fecha_nacimiento, Provisorio,
            //    cuil_titu, FechaRevisado, FechaActualizacion, FechaAlta, CodOS, Cod_Pariente, email, celular, Usuario, FechaBaja, Comentario, CodPos, Discapacidad, FechaDiscapacidad, AnioEstudiante, Certificado1, Certificado2, EsEstudiante, PMI, PI, Convert.ToInt64(NHC_UOM), TipoDoc, Convert.ToInt64(txt_paciente_id.Text);
                object r = adapter.H2_Padron_Alta_Labo(
                    cuil, documento, apellido, sexo, telefono, Seccional, cuit, calle, numero, piso,
                    depto, localidad, provincia, fecha_nacimiento, Provisorio, cuil_titu, FechaRevisado, FechaActualizacion, FechaAlta, CodOS,
                    Cod_Pariente, email, celular, Usuario, FechaBaja, Comentario, CodPos, NHC_UOM, TipoDoc, Convert.ToInt64(txt_paciente_id.Text), "SOLTERO",
                    "ARGENTINO", null
                    );

                return Convert.ToInt64(r);            
        }

        private void cbo_sexom_CheckedChanged(object sender, EventArgs e)
        {
            
        }

             /// <summary>
             /// Calcula el dígito verificador dado un CUIT completo o sin él.
             /// </summary>
             /// <param name="cuit">El CUIT como String sin guiones</param>
             /// <returns>El valor del dígito verificador calculado.</returns>
             public static string CalcularDigitoCuit(string cuit, int genero)
             {
                 string documento = cuit;
                 string AB = "";
                 if (genero == 1)
                 {
                 AB = "20";
                 }

                 if (genero == 2)
                 {
                 AB = "27";
                 }

                 documento = documento.PadLeft(8, '0');

                 cuit = AB + documento;

                int[] mult = new int[] { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };
                char[] nums = cuit.ToCharArray();
                int total = 0;
                for (int i = 0; i < mult.Length; i++)
                {
                    total += int.Parse(nums[i].ToString()) * mult[i];
                }
                var resto = total % 11;

                string C = "";
                if ((genero != 3) && (resto <= 1)) {
                if (resto == 0) {
                    C = "0";
                } else {
                if (genero == 1) {
                    C = "9";
                } else {
                    C = "4";
                }
                }
                AB = "23";
                } else {
                C = (11 - resto).ToString();
                }

                return AB + documento + C;
                 //return resto == 0 ? 0 : resto == 1 ? 9 : 11 - resto;

            }

             private void cbo_sexof_Click(object sender, EventArgs e)
             {
                 //if (txt_Documento.Text.Trim().Length > 5)
                 //{
                 //   txt_cuil.Text = CalcularDigitoCuit(txt_Documento.Text, 2);
                 //}
             }

             private void cbo_sexom_Click(object sender, EventArgs e)
             {
                 //if (txt_Documento.Text.Trim().Length > 5)
                 //{
                 //    txt_cuil.Text = CalcularDigitoCuit(txt_Documento.Text, 1);
                 //}
             }

             private void btn_BuscarTitular_Click(object sender, EventArgs e)
             {
                 buscar_titular bt = new buscar_titular(this);
                 bt.ShowDialog();
             }

             private void btn_BuscarEmpresa_Click(object sender, EventArgs e)
             {
                 buscar_empresas be = new buscar_empresas(this);
                 be.ShowDialog();
             }

             private void cbo_pariente_SelectedIndexChanged(object sender, EventArgs e)
             {
                 if (cbo_pariente.SelectedValue.ToString() == "99")
                 {
                     txt_cuilempresas.Text = "99999999999";
                     txt_cuiltitu.Text = "99999999999";
                     cbo_seccional.SelectedValue = "997";
                     txt_telefono.Text = "Derivación";
                 }
             }

             private void txt_Documento_KeyPress(object sender, KeyPressEventArgs e)
             {
                 if (Char.IsDigit(e.KeyChar))
                 {
                     e.Handled = false;
                 }
                 else
                     if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
                     {
                         e.Handled = false;
                     }
                     else
                     {
                         //el resto de teclas pulsadas se desactivan 
                         e.Handled = true;
                     } 
             }

             private void txt_cuil_KeyPress(object sender, KeyPressEventArgs e)
             {
                 if (Char.IsDigit(e.KeyChar))
                 {
                     e.Handled = false;
                 }
                 else
                     if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
                     {
                         e.Handled = false;
                     }
                     else
                     {
                         //el resto de teclas pulsadas se desactivan 
                         e.Handled = true;
                     } 
             }

             private void txt_cuiltitu_KeyPress(object sender, KeyPressEventArgs e)
             {
                 if (Char.IsDigit(e.KeyChar))
                 {
                     e.Handled = false;
                 }
                 else
                     if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
                     {
                         e.Handled = false;
                     }
                     else
                     {
                         //el resto de teclas pulsadas se desactivan 
                         e.Handled = true;
                     } 
             }

             private void txt_cuilempresas_KeyPress(object sender, KeyPressEventArgs e)
             {
                 if (Char.IsDigit(e.KeyChar))
                 {
                     e.Handled = false;
                 }
                 else
                     if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
                     {
                         e.Handled = false;
                     }
                     else
                     {
                         //el resto de teclas pulsadas se desactivan 
                         e.Handled = true;
                     } 
             }

             private void btn_VerificarHC_Click(object sender, EventArgs e)
             {
                 //Verifico si existe o no el Nro de HC                 

                 List<empresas> lista = new List<empresas>();
                 DAL.HospitalDataSetTableAdapters.H3_Datos_NHCTableAdapter adapter = new DAL.HospitalDataSetTableAdapters.H3_Datos_NHCTableAdapter();
                 DAL.HospitalDataSet.H3_Datos_NHCDataTable aTable = adapter.GetData(txt_NroHC_UOM.Text);

                 int pos = 0;
                 if (aTable.Count > 0)
                 {
                     MessageBox.Show("El nro de HC: " + aTable[0].HC_UOM_CENTRAL + " ya se ha utilizado en el paciente " + aTable[0].apellido, "HC en uso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                     txt_NroHC_UOM.Text = "";
                 }
                 else
                 {
                     { MessageBox.Show("El nro de HC se encuentra disponible para usar","HC Libre", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                 }

                 

             }

             private void txt_Documento_Leave(object sender, EventArgs e)
             {
                 int doc = 0;
                 
                 if (int.TryParse(txt_Documento.Text, out doc))
                 {
                     if (doc != 0)
                     {
                         pacientes p = Paciente_DOC(doc, false, cbo_tipo_documento.Text);
                         if (p != null)
                         {
                             MessageBox.Show("Se encontró un paciente cargado con ese documento \n\n Nombre: " + p.Paciente + "\n\n CUIT: " + p.cuil );

                         }
                     }
                 }
                 
             }

             private void btn_Editar_Click(object sender, EventArgs e)
             {
                 //frm_Cambiar_Doc cdoc = new frm_Cambiar_Doc(txt_Documento.Text, cbo_tipo_documento.SelectedValue.ToString());
                 //cdoc.ShowDialog();
                 //Principal parent = (Principal)this.Owner;
                 //parent.button4_Click(null, null);
                 //this.Close();
             }



    }
}
