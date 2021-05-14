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
    public partial class ImpresionBono : Form
    {

        private DataGridView gridview = new DataGridView();
        private List<Confirmarturnos> lista_practias = new List<Confirmarturnos>();
        private BonoPase datos = new BonoPase();
        private string Motivo_no_paga = "";
        private bool monotributista = false;


        //cantidad total de practicas de cada complejidad en el protocolo
        int cantidadBajas = 0;
        int cantidadMedias = 0;
        int cantidadAltas = 0;
        int cantidadInventadas = 0;
        //lista de practicas del protocolo
        string PracticasProtocolo = "";
        //contador de la iteracion actual de cada practica
        int contBajas = 0;
        int contBajasTotal = 0;
        int contMedias = 0;
        int contMediasTotal = 0;
        int contAltas = 0;
        int contAltasTotal = 0;
        int contInventadas = 0;
        int contInventadasTotal = 0;

        public ImpresionBono(DataGridView f_dg, BonoPase f_datos)
        {
            InitializeComponent();
            gridview = f_dg;
            datos = f_datos;
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            datos.accion = "Cancelado";
            this.Close();
        }

        private void ImpresionBono_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'bonoDAL.H2_BONOS_AUTORIZA_MOTIVOS_LIST' Puede moverla o quitarla según sea necesario.
            this.h2_BONOS_AUTORIZA_MOTIVOS_LISTTableAdapter.Fill(this.bonoDAL.H2_BONOS_AUTORIZA_MOTIVOS_LIST);
            // TODO: esta línea de código carga datos en la tabla 'bonoDAL.H2_BONOS_AUTORIZANTE_LIST' Puede moverla o quitarla según sea necesario.
            this.h2_BONOS_AUTORIZANTE_LISTTableAdapter.Fill(this.bonoDAL.H2_BONOS_AUTORIZANTE_LIST);
            //Inicio



            //Cambio los estado a Falso
            cbo_autorizante.Enabled = false;
            cbo_autorizante.Text = "";
            cbo_autorizante.SelectedIndex = -1;
            cbo_motivo.Enabled = false;
            cbo_motivo.Text = "";
            cbo_motivo.SelectedIndex = -1;
            //txt_comentario.Enabled = false;
            txt_comentario.Text = "";
            ck_nopaga.Checked = false;
            ck_nopaga.Enabled = true;
            label_info.Text = "";
            lTotal.Visible = true;
            lista_practias.Clear();
            Motivo_no_paga = "";
            monotributista = false;

            DAL.BonoDALTableAdapters.H3_BONO_COBRA_BONO_PACIENTETableAdapter adapter_bono_cobra = new DAL.BonoDALTableAdapters.H3_BONO_COBRA_BONO_PACIENTETableAdapter();
            DAL.BonoDAL.H3_BONO_COBRA_BONO_PACIENTEDataTable aTable_bono_cobra = adapter_bono_cobra.GetData(datos.Documento);
            if (aTable_bono_cobra.Count > 0)
            {
                label_info.ForeColor = Color.Green;
                label_info.Text = "Afiliado";
                //ESTO ES PARA SABER SI ES O NO MONOTRIBUTISTA!!!!
                //29/03/2016
                if (!aTable_bono_cobra[0].IscuitNull())
                {
                    if (aTable_bono_cobra[0].cuit.ToString() == "88888888888")
                    {
                        monotributista = true;
                        label_info.Text = "Monotributista";
                    }
                }


                //VERIFICO DISCAPACIDAD
                if (!aTable_bono_cobra[0].IsDiscapacidadNull())
                {

                    //Verifico si esa discapacidad se cobra
                    if (!aTable_bono_cobra[0].IsPagaBonoNull())
                    {
                        if (aTable_bono_cobra[0].PagaBono == "N")
                        {
                            Motivo_no_paga = "PATOLOGIA";
                            label_info.Text = label_info.Text + "- " + aTable_bono_cobra[0].Discapacidad.ToUpper() + " -"; ck_nopaga.Enabled = false; ck_nopaga.Checked = true; NoPaga();
                        }
                        else
                        {
                            //ESTO ES PORQUE LA DISCAPACIDAD SE COBRA
                            //TENGO QUE VER SI LA FECHA ESTA VENCIDA
                            if (!aTable_bono_cobra[0].IsFecha_DiscapacidadNull())
                            {
                                Motivo_no_paga = "PATOLOGIA";
                                label_info.Text = label_info.Text + "- " + aTable_bono_cobra[0].Discapacidad.ToUpper() + " -"; ck_nopaga.Enabled = false; ck_nopaga.Checked = true; NoPaga();
                                TimeSpan span = DateTime.Now - aTable_bono_cobra[0].Fecha_Discapacidad;
                                if (span.TotalDays > 0)
                                {
                                    label_info.ForeColor = Color.Red;
                                    label_info.Text = label_info.Text + "- (CERT. VENCIDO) -";
                                    ck_nopaga.Enabled = true; ck_nopaga.Checked = true; NoPaga();
                                    Motivo_no_paga = "PATOLOGIA (CET. VENCIDO)";
                                }
                                else
                                {
                                    Motivo_no_paga = "PATOLOGIA";
                                    label_info.Text = label_info.Text + "- " + aTable_bono_cobra[0].Discapacidad.ToUpper() + " -"; ck_nopaga.Enabled = false; ck_nopaga.Checked = true; NoPaga();
                                }
                            }
                        }
                    }

                }

                //Verifico EDAD
                if (!aTable_bono_cobra[0].IsEdadNull()) { if (aTable_bono_cobra[0].Edad < 1) { Motivo_no_paga = "MENOR A UN AÑO"; label_info.Text = label_info.Text + "- MENOR A UN AÑO -"; ck_nopaga.Enabled = false; ck_nopaga.Checked = true; NoPaga(); } }

                //Verifico PMI
                if (!aTable_bono_cobra[0].IsFV_PMINull())
                {
                    TimeSpan span = DateTime.Now - aTable_bono_cobra[0].FV_PMI;
                    if (span.TotalDays < 0)
                    {
                        Motivo_no_paga = "PMI";
                        label_info.Text = label_info.Text + "- PLAN MATERNO INFANTIL -";
                        ck_nopaga.Enabled = false; ck_nopaga.Checked = true; NoPaga();
                    }
                    else
                    {
                        label_info.ForeColor = Color.Red;
                        label_info.Text = "¡¡¡¡PLAN MATERNO INFANTIL VENCIDO!!!!";
                        Motivo_no_paga = "PMI (VENCIDO)";
                    }
                }

                //Verifico si es presupuesto o impresion de bono
                if (datos.accion == "Presupuesto")
                {
                    this.lblTitulo.Text = "Presupuesto";
                    this.ck_nopaga.Visible = false;
                    this.label2.Visible = false;
                    this.cbo_autorizante.Visible = false;
                    this.label3.Visible = false;
                    this.cbo_motivo.Visible = false;
                    this.label4.Visible = false;
                    this.txt_comentario.Visible = false;
                    this.gb2.Visible = false;

                }else {
                    this.lblTitulo.Text = "Bono";
                    this.ck_nopaga.Visible = true;
                    this.label2.Visible = true;
                    this.cbo_autorizante.Visible = true;
                    this.label3.Visible = true;
                    this.cbo_motivo.Visible = true;
                    this.label4.Visible = true;
                    this.txt_comentario.Visible = true;
                    this.gb2.Visible = true;
                }


            }




            DAL.BonoDALTableAdapters.H3_ValorBono_x_PracticaTableAdapter adapter = new DAL.BonoDALTableAdapters.H3_ValorBono_x_PracticaTableAdapter();

            //Leo todos los estudios...            
            gv_bono.Rows.Clear();
            gv_bono.Refresh();
            float Total = 0;
            float Total_Final = 0;

            int TotalPracticas = 0;
            int resto = 0;
             
            int cant_practicas = 0;

            if (datos.TipoOrden == "G")
            {
                //Total de practicas...
                TotalPracticas = gridview.Rows.Count;
                resto = (TotalPracticas % 5);
                cant_practicas = (Int32)(TotalPracticas / 5);
                if (resto != 0) { cant_practicas++; }

                //29/03/2016
                //Para MONOTRIBUTISTA...
                //50% MAS
                //float Porcentaje = 1.50F;
                //if (!monotributista) Porcentaje = 1;

                //ESTO ES ANTES DEL AUMENTO //Aumento de 20% - Autorizado Calo - 01/09/2017
                //Total_Final = (10 * Porcentaje) * cant_practicas;

                //ESTO ES CON EL AUMENTO //Aumento de 20% - Autorizado Calo - 01/09/2017
                //Total_Final = (15 * Porcentaje) * cant_practicas;//se saca esta forma de hacer los bonos
                
                //Se modifica la tabla ([Hospital].[dbo].[ValoresMonotributoLabo] para costo monotributo)
                //y ([Hospital].[dbo].[ValoresRGLabo] para el costo afiliado comun)
                //Se hace consulta webservice para sacar valor de tabla si es monotributista o afiliado comun
                // para el valor de las atenciones en guardia. 14-01-2020

                //para el monotributista
                
                DAL.BonoDALTableAdapters.ValoresMonotributoLaboTableAdapter monoAdapter = new DAL.BonoDALTableAdapters.ValoresMonotributoLaboTableAdapter();
                DAL.BonoDAL.ValoresMonotributoLaboDataTable monoTable = monoAdapter.GetData();

                //para el afiliado comun
                DAL.BonoDALTableAdapters.H3_valoresGeneralLaboTableAdapter GeneralAdapter = new DAL.BonoDALTableAdapters.H3_valoresGeneralLaboTableAdapter();
                DAL.BonoDAL.H3_valoresGeneralLaboDataTable GeneralTable = GeneralAdapter.GetData();

                //numero de referencia para traer el ultimo valor de complejidad de la tabla
                //[Hospital].[dbo].[ValoresMonotributoLabo] y de la tabla
                //[Hospital].[dbo].[ValoresRGLabo]
                int indiceComplejidadGeneral = 0;

                for (int i = 0; i < GeneralTable.Count; i++) 
                {
                    if (GeneralTable[i].complejidad > indiceComplejidadGeneral)
                    {
                        indiceComplejidadGeneral = GeneralTable[i].complejidad;
                    }
                }

                Total_Final = (Convert.ToSingle(GeneralTable[indiceComplejidadGeneral - 1].valorGuardia)) * cant_practicas;

                if (monotributista)
                {
                    //ValoresMonotributoLabo
                    //14-01-2020 ahora se busca en tabla el valor del bono
                    //Total_Final = (25) * cant_practicas;

                    int indiceComplejidadMonotributista = 0;

                    for (int i = 0; i < monoTable.Count; i++)
                    {
                        if (monoTable[i].complejidad > indiceComplejidadMonotributista)
                        {
                            indiceComplejidadMonotributista = monoTable[i].complejidad;
                        }
                    }

                    //el valor 3 del array hace referencia al ultimo valor de la tabla
                    Total_Final = (Convert.ToSingle(monoTable[indiceComplejidadGeneral - 1].valorGuardia)) * cant_practicas;
                }

            }


//---se realiza el cambio para modularizar la solucion de bug que no trae la cantidad correcta de subpracticas cuando se repiten
            //InicializacionVariables();
            
            //cantidad total de practicas de cada complejidad en el protocolo
            int cantidadBajas = 0;
            int cantidadMedias = 0;
            int cantidadAltas = 0;
            int cantidadInventadas = 0;
            int cantidadCinco = 0;
            //lista de practicas del protocolo
            string PracticasProtocolo = "";
            //contador de la iteracion actual de cada practica
            int contBajas = 0;
            int contBajasTotal = 0;
            int contMedias = 0;
            int contMediasTotal = 0;
            int contAltas = 0;
            int contAltasTotal = 0;
            int contInventadas = 0;
            int contInventadasTotal = 0;
            int contCinco = 0;
            int contCincoTotal = 0;
            //cantidad de grupos que s epueden formar y el grupo actual que se esta iterando en cada complejidad
            var gruposBajas = 0;
            var actualBajas = 0;
            var gruposMedias = 0;
            var actualMedias = 0;
            var gruposAltas = 0;
            var actualAltas = 0;
            var gruposInventadas = 0;
            var actualInventadas = 0;
            var gruposCinco = 0;
            var actualCinco = 0;

            //obtengo la lista de ids de las practicas que componen el protocolo
            foreach (DataGridViewRow row in gridview.Rows)
            { PracticasProtocolo = PracticasProtocolo + "," + row.Cells[0].Value.ToString(); }

            //con la lista de los ids consulto cual es el total de practicas de cada complejidad del protocolo
            DAL.BonoDALTableAdapters.QueriesTableAdapter queri = new DAL.BonoDALTableAdapters.QueriesTableAdapter();

            object objBajas = queri.H2_Contar_Baja_Complejidad(PracticasProtocolo, 3);
            cantidadBajas = Convert.ToInt32(objBajas);

            object objMedias = queri.H2_Contar_Baja_Complejidad(PracticasProtocolo, 2);
            cantidadMedias = Convert.ToInt32(objMedias);

            object objAltas = queri.H2_Contar_Baja_Complejidad(PracticasProtocolo, 1);
            cantidadAltas = Convert.ToInt32(objAltas);

            object objInventdas = queri.H2_Contar_Baja_Complejidad(PracticasProtocolo, 4);
            cantidadInventadas = Convert.ToInt32(objInventdas);

            object objCinco = queri.H2_Contar_Baja_Complejidad(PracticasProtocolo, 5);
            cantidadCinco = Convert.ToInt32(objCinco);
            //

            foreach (DataGridViewRow row in gridview.Rows)
            {
                Confirmarturnos prac = new Confirmarturnos();
                float valor = 0;


//si es atencion por GUARDIA
                //if (datos.TipoOrden == "G")
                //{
                //    //Total de practicas...
                //    valor = float.Parse((Total_Final / TotalPracticas).ToString("##.##"));
                //}
                //else
                //{
// Si es OTRO TIPO de atencion
                    try
                    {
                        DAL.BonoDALTableAdapters.ValoresMonotributoLaboTableAdapter monoAdapter = new DAL.BonoDALTableAdapters.ValoresMonotributoLaboTableAdapter();
                        DAL.BonoDAL.ValoresMonotributoLaboDataTable monoTable = monoAdapter.GetData();


                        DAL.BonoDALTableAdapters.H3_valoresGeneralLaboTableAdapter GeneralAdapter = new DAL.BonoDALTableAdapters.H3_valoresGeneralLaboTableAdapter();
                        DAL.BonoDAL.H3_valoresGeneralLaboDataTable GeneralTable = GeneralAdapter.GetData();

                        DAL.BonoDAL.H3_ValorBono_x_PracticaDataTable aTable = adapter.GetData(1, 188, Convert.ToInt64(row.Cells[0].Value));
                        //Acá coloco el valor según corresponda...
                        //Si es monotributista o no.
                        //29/03/2016
                        if (monotributista)
                        {
                            float valorSegunTipoMono;
                            switch (aTable[0].complejidad)
                            {                         
                                 //si es complejidad cinco
                                case 5:
                                    //-----------------------arreglo BUG para el calculo de de subpracticas duplicadas que no se tenian en cuenta-----
                                    //iniciamos array para guardar los codigos a consultar

                                    string[] separadasCinco;
                                    //guardamos los datos dentro del array
                                    separadasCinco = PracticasProtocolo.Split(',');

                                    int _countCinco = 0;
                                    for (int i = 1; i < separadasCinco.Length; i++)
                                    {
                                        DAL.BonoDAL.H3_ValorBono_x_PracticaDataTable mio = adapter.GetData(1, 188, Convert.ToInt64(separadasCinco[i]));

                                        //Console.WriteLine("MIO: "+GeneralTable[mio[0].complejidad].complejidad);
                                        //Console.WriteLine("0:  " + GeneralTable[aTable[0].complejidad]);
                                        //Console.WriteLine("-1: " + GeneralTable[aTable[0].complejidad-1].complejidad);

                                        if (monoTable[aTable[0].complejidad - 1].complejidad == monoTable[mio[0].complejidad - 1].complejidad)
                                        {
                                            _countCinco++;
                                        }
                                    }
                                    cantidadCinco = _countCinco;
//------------------------------------- 
                                
                                     // para los que son de guardia

                                    if (datos.TipoOrden == "G") { valorSegunTipoMono = float.Parse(monoTable[aTable[0].complejidad - 1].valorGuardia.ToString()); }
                                    else { valorSegunTipoMono = float.Parse(monoTable[aTable[0].complejidad - 1].valorInicial.ToString()); }
                                    // para los que son de guardia
                                    
                                    //si es complejidad inventada y NO superan el limite de agrupado. divide el valor por la cantidad de inventadas
                                    if (cantidadCinco <= monoTable[aTable[0].complejidad - 1].cantidadBreak) 
                                    {
                                        valor = valorSegunTipoMono / cantidadCinco; 
                                    }
                                    else
                                    {
                                        //va contando cuantas practicas inventadas que hay en el protocolo
                                        contCinco += 1;
                                        //el contador que no se resetea
                                        contCincoTotal += 1;
                                        //calcula cuantos grupos se pueden formar con la cantidad de inventadas que hay en el protocolo
                                        gruposCinco = cantidadCinco / monoTable[aTable[0].complejidad - 1].cantidadBreak;

                                        //si la cantidad de inventadas que se esta iterando es igual al break pasa a un nuevo grupo y se empieza a contar desde cero
                                        if (contCinco == monoTable[aTable[0].complejidad - 1].cantidadBreak) 
                                        { 
                                            actualCinco += 1; 
                                            //contInventadas = 0; se comenta por que quieren que a partir de la cantidad break la practica valga el valor unitario de valor exedente
                                        }

                                        //la cantidad de practicas que no entran en ningun grupo
                                        int p = cantidadCinco - (monoTable[aTable[0].complejidad - 1].cantidadBreak * gruposCinco);

                                        //si el grupo actual es menor-igual al total de grupos que se pueden formar, se reseta el valor y se le asigna el valor dividido por el breack
                                        //if (actualInventadas <= gruposInventadas)
                                        if (contCinco <= monoTable[aTable[0].complejidad - 1].cantidadBreak)
                                        { 
                                            valor = float.Parse("0.0"); 
                                            valor = valorSegunTipoMono / monoTable[aTable[0].complejidad - 1].cantidadBreak; 
                                        }
                                        //si las practicas restantes son menores o iguales a 1, es la primera de las excliudas y vale el total, sino se divide por la cantidad de practicas excuidas
                                        else /*if (p <= 1)*/ 
                                        { 
                                            valor = float.Parse(valor + monoTable[aTable[0].complejidad - 1].valorExedente.ToString()); 
                                        }
                                        /*
                                        else 
                                        { valor = float.Parse("0.0"); 
                                            valor = float.Parse(monoTable[aTable[0].complejidad - 1].valorInicial.ToString()) / p; 
                                        }
                                         * */
                                        //si el grupo actual es igual al total de grupos quiere decir que llego al limite y se incremeta el grupo para calcular las practicas que quedan excluidas 
                                        //de los grupos y se resetea el contador de bajas
                                        if (actualCinco == gruposCinco) 
                                        { actualInventadas += 1; 
                                            //contInventadas = 0; //se comenta por que quieren que a partir de la cantidad break la practica valga el valor unitario de valor exedente  
                                        }
                                    }
                                    break;
                                
                                break;
                                //si es complejidad cinco
                                
                                //si es complejidad inventada
                                case 4:
//-----------------------arreglo BUG para el calculo de de subpracticas duplicadas que no se tenian en cuenta-----
                                    //iniciamos array para guardar los codigos a consultar

                                    string[] separadasInventada;
                                    //guardamos los datos dentro del array
                                    separadasInventada = PracticasProtocolo.Split(',');

                                    int _countInventada = 0;
                                    for (int i = 1; i < separadasInventada.Length; i++)
                                    {
                                        DAL.BonoDAL.H3_ValorBono_x_PracticaDataTable mio = adapter.GetData(1, 188, Convert.ToInt64(separadasInventada[i]));

                                        //Console.WriteLine("MIO: "+GeneralTable[mio[0].complejidad].complejidad);
                                        //Console.WriteLine("0:  " + GeneralTable[aTable[0].complejidad]);
                                        //Console.WriteLine("-1: " + GeneralTable[aTable[0].complejidad-1].complejidad);

                                        if (monoTable[aTable[0].complejidad - 1].complejidad == monoTable[mio[0].complejidad - 1].complejidad)
                                        {
                                            _countInventada++;
                                        }
                                    }
                                    cantidadInventadas = _countInventada;
//------------------------------------- 


                                    // para los que son de guardia

                                    if (datos.TipoOrden == "G") { valorSegunTipoMono = float.Parse(monoTable[aTable[0].complejidad - 1].valorGuardia.ToString()); }
                                    else { valorSegunTipoMono = float.Parse(monoTable[aTable[0].complejidad - 1].valorInicial.ToString()); }
                                    // para los que son de guardia

                                    //si es complejidad inventada y NO superan el limite de agrupado. divide el valor por la cantidad de inventadas
                                    if (cantidadInventadas <= monoTable[aTable[0].complejidad - 1].cantidadBreak) 
                                    {
                                        valor = valorSegunTipoMono / cantidadInventadas; 
                                    }
                                    else
                                    {
                                        //va contando cuantas practicas inventadas que hay en el protocolo
                                        contInventadas += 1;
                                        //el contador que no se resetea
                                        contInventadasTotal += 1;
                                        //calcula cuantos grupos se pueden formar con la cantidad de inventadas que hay en el protocolo
                                        gruposInventadas = cantidadInventadas / monoTable[aTable[0].complejidad - 1].cantidadBreak;

                                        //si la cantidad de inventadas que se esta iterando es igual al break pasa a un nuevo grupo y se empieza a contar desde cero
                                        if (contInventadas == monoTable[aTable[0].complejidad - 1].cantidadBreak) 
                                        { 
                                            actualInventadas += 1; 
                                            //contInventadas = 0; se comenta por que quieren que a partir de la cantidad break la practica valga el valor unitario de valor exedente
                                        }

                                        //la cantidad de practicas que no entran en ningun grupo
                                        int p = cantidadInventadas - (monoTable[aTable[0].complejidad - 1].cantidadBreak * gruposInventadas);

                                        //si el grupo actual es menor-igual al total de grupos que se pueden formar, se reseta el valor y se le asigna el valor dividido por el breack
                                        //if (actualInventadas <= gruposInventadas)
                                        if (contInventadas <= monoTable[aTable[0].complejidad - 1].cantidadBreak)
                                        { 
                                            valor = float.Parse("0.0"); 
                                            valor = valorSegunTipoMono / monoTable[aTable[0].complejidad - 1].cantidadBreak; 
                                        }
                                        //si las practicas restantes son menores o iguales a 1, es la primera de las excliudas y vale el total, sino se divide por la cantidad de practicas excuidas
                                        else /*if (p <= 1)*/ 
                                        { 
                                            valor = float.Parse(valor + monoTable[aTable[0].complejidad - 1].valorExedente.ToString()); 
                                        }
                                        /*
                                        else 
                                        { valor = float.Parse("0.0"); 
                                            valor = float.Parse(monoTable[aTable[0].complejidad - 1].valorInicial.ToString()) / p; 
                                        }
                                         * */
                                        //si el grupo actual es igual al total de grupos quiere decir que llego al limite y se incremeta el grupo para calcular las practicas que quedan excluidas 
                                        //de los grupos y se resetea el contador de bajas
                                        if (actualInventadas == gruposInventadas) 
                                        { actualInventadas += 1; 
                                            //contInventadas = 0; //se comenta por que quieren que a partir de la cantidad break la practica valga el valor unitario de valor exedente  
                                        }
                                    }
                                    break;


                                    //switch (aTable[0].complejidad)
                                    //{  //si es baja complejidad
                                        case 3:
//-----------------------arreglo BUG para el calculo de de subpracticas duplicadas que no se tenian en cuenta-----
                                            //iniciamos array para guardar los codigos a consultar
                                            string[] separadasBaja;
                                            //guardamos los datos dentro del array
                                            separadasBaja = PracticasProtocolo.Split(',');

                                            int _countBaja = 0;
                                            for (int i = 1; i < separadasBaja.Length; i++)
                                            {
                                                DAL.BonoDAL.H3_ValorBono_x_PracticaDataTable mio = adapter.GetData(1, 188, Convert.ToInt64(separadasBaja[i]));

                                                if (monoTable[aTable[0].complejidad - 1].complejidad == monoTable[mio[0].complejidad - 1].complejidad)
                                                {
                                                    _countBaja++;
                                                }
                                            }
                                            cantidadBajas = _countBaja;
//-------------------------------------


                                    // para los que son de guardia

                                    if (datos.TipoOrden == "G") { valorSegunTipoMono = float.Parse(monoTable[aTable[0].complejidad - 1].valorGuardia.ToString()); }
                                    else { valorSegunTipoMono = float.Parse(monoTable[aTable[0].complejidad - 1].valorInicial.ToString()); }
                                    // para los que son de guardia

                                            //si es baja complejidad y NO superan el limite de agrupado. divide el valor por la cantidad de bajas
                                            if (cantidadBajas <= monoTable[aTable[0].complejidad - 1].cantidadBreak) 
                                            {
                                                valor = valorSegunTipoMono / cantidadBajas; 
                                            }
                                            else
                                            {
                                                //va contando cuantas practicas de baja hay en el protocolo
                                                contBajas += 1;
                                                //el contador que no se resetea
                                                contBajasTotal += 1;
                                                //calcula cuantos grupos se pueden formar con la cantidad de bajas que hay en el protocolo
                                                gruposBajas = cantidadBajas / monoTable[aTable[0].complejidad - 1].cantidadBreak;

                                                //si la cantidad de bajas que se esta iterando es igual al break pasa a un nuevo grupo y se empieza a contar desde cero
                                                if (contBajas == monoTable[aTable[0].complejidad - 1].cantidadBreak) 
                                                { actualBajas += 1; 
                                                    //contBajas = 0; //se comenta por que quieren que a partir de la cantidad break la practica valga el valor unitario de valor exedente 
                                                }

                                                //la cantidad de practicas que no entran en ningun grupo
                                                int p = cantidadBajas - (monoTable[aTable[0].complejidad - 1].cantidadBreak * gruposBajas);

                                                //si el grupo actual es menor-igual al total de grupos que se pueden formar, se reseta el valor y se le asigna el valor dividido por el breack
                                                //if (actualBajas <= gruposBajas)
                                                if (contBajas <= monoTable[aTable[0].complejidad - 1].cantidadBreak)
                                                { 
                                                    valor = float.Parse("0.0"); 
                                                    valor = valorSegunTipoMono / monoTable[aTable[0].complejidad - 1].cantidadBreak; 
                                                }
                                                //si las practicas restantes son menores o iguales a 1, es la primera de las excliudas y vale el total, sino se divide por la cantidad de practicas excuidas
                                                else /*if (p <= 1)*/ 
                                                { 
                                                    //valor = float.Parse(valor + monoTable[aTable[aTable[0].complejidad - 1].complejidad].valorExedente.ToString());
                                                    valor = float.Parse(valor + monoTable[aTable[0].complejidad - 1].valorExedente.ToString());
                                                }
                                                /*
                                                else 
                                                { 
                                                    valor = float.Parse("0.0"); valor = float.Parse(monoTable[aTable[0].complejidad - 1].valorInicial.ToString()) / p; 
                                                }
                                                 * */
                                                //si el grupo actual es igual al total de grupos quiere decir que llego al limite y se incremeta el grupo para calcular las practicas que quedan excluidas 
                                                //de los grupos y se resetea el contador de bajas
                                                if (actualBajas == gruposBajas) 
                                                { 
                                                    actualBajas += 1; 
                                                    //contBajas = 0; //se comenta por que quieren que a partir de la cantidad break la practica valga el valor unitario de valor exedente 
                                                }
                                            }

                                            break;

                                        //si es de media complejidad
                                        case 2:
//-----------------------arreglo BUG para el calculo de de subpracticas duplicadas que no se tenian en cuenta-----
                                            //iniciamos array para guardar los codigos a consultar
                                            string[] separadasMedia;
                                            //guardamos los datos dentro del array
                                            separadasMedia = PracticasProtocolo.Split(',');

                                            int _countMedia = 0;
                                            for (int i = 1; i < separadasMedia.Length; i++)
                                            {
                                                DAL.BonoDAL.H3_ValorBono_x_PracticaDataTable mio = adapter.GetData(1, 188, Convert.ToInt64(separadasMedia[i]));

                                                if (monoTable[aTable[0].complejidad-1].complejidad == monoTable[mio[0].complejidad-1].complejidad)
                                                {
                                                    _countMedia++;
                                                }
                                            }
                                            cantidadMedias = _countMedia;
//------------------------------------- 

                                    // para los que son de guardia

                                    if (datos.TipoOrden == "G") { valorSegunTipoMono = float.Parse(monoTable[aTable[0].complejidad - 1].valorGuardia.ToString()); }
                                    else { valorSegunTipoMono = float.Parse(monoTable[aTable[0].complejidad - 1].valorInicial.ToString()); }
                                    // para los que son de guardia

                                            //si es media complejidad y NO superan el limite de agrupado. divide el valor por la cantidad de medias
                                            if (cantidadMedias <= monoTable[aTable[0].complejidad - 1].cantidadBreak) 
                                            {
                                                valor = valorSegunTipoMono / cantidadMedias; 
                                            }
                                            else
                                            {
                                                //va contando cuantas practicas de media hay en el protocolo
                                                contMedias += 1;
                                                //el contador que no se resetea
                                                contMediasTotal += 1;
                                                //calcula cuantos grupos se pueden formar con la cantidad de medias que hay en el protocolo
                                                gruposMedias = cantidadMedias / monoTable[aTable[0].complejidad - 1].cantidadBreak;

                                                //si la cantidad de medias que se esta iterando es igual al break pasa a un nuevo grupo y se empieza a contar desde cero
                                                if (contMedias == monoTable[aTable[0].complejidad - 1].cantidadBreak) 
                                                { 
                                                    actualMedias += 1;
                                                    //contMedias = 0; //se comenta por que quieren que a partir de la cantidad break la practica valga el valor unitario de valor exedente 
                                                }

                                                //la cantidad de practicas que no entran en ningun grupo
                                                int p = cantidadMedias - (monoTable[aTable[0].complejidad - 1].cantidadBreak * gruposMedias);


                                                //si el grupo actual es menor-igual al total de grupos que se pueden formar, se reseta el valor y se le asigna el valor dividido por el breack
                                                //if (actualMedias <= gruposMedias)
                                                if (contMedias <= monoTable[aTable[0].complejidad - 1].cantidadBreak)
                                                {
                                                    valor = float.Parse("0.0"); 
                                                    valor = valorSegunTipoMono / monoTable[aTable[0].complejidad - 1].cantidadBreak; 
                                                }
                                                //si las practicas restantes son menores o iguales a 1, es la primera de las excliudas y vale el total, sino se divide por la cantidad de practicas excuidas
                                                else /*if (p <= 1) */
                                                { 
                                                    valor = float.Parse(valor + monoTable[aTable[0].complejidad - 1].valorExedente.ToString()); 
                                                } 
                                                /*
                                                else 
                                                { 
                                                    valor = float.Parse("0.0"); 
                                                    valor = float.Parse(monoTable[aTable[0].complejidad - 1].valorInicial.ToString()) / p; 
                                                }
                                                 * */
                                                //si el grupo actual es igual al total de grupos quiere decir que llego al limite y se incremeta el grupo para calcular las practicas que quedan excluidas 
                                                //de los grupos y se resetea el contador de medias
                                                if (actualMedias == gruposMedias) 
                                                { 
                                                    actualMedias += 1;
                                                    //contMedias = 0; ////se comenta por que quieren que a partir de la cantidad break la practica valga el valor unitario de valor exedente 
                                                }
                                            }
                                            break;
                                        //si es alta complejidad
                                        case 1:

//-----------------------arreglo BUG para el calculo de de subpracticas duplicadas que no se tenian en cuenta-----
                                            //iniciamos array para guardar los codigos a consultar
                                            string[] separadasAlta;
                                            //guardamos los datos dentro del array
                                            separadasAlta = PracticasProtocolo.Split(',');

                                            int _countAlta = 0;
                                            for (int i = 1; i < separadasAlta.Length; i++)
                                            {
                                                DAL.BonoDAL.H3_ValorBono_x_PracticaDataTable mio = adapter.GetData(1, 188, Convert.ToInt64(separadasAlta[i]));

                                                if (monoTable[aTable[0].complejidad-1].complejidad == monoTable[mio[0].complejidad-1].complejidad)
                                                {
                                                    _countAlta++;
                                                }
                                            }
                                            cantidadAltas = _countAlta;
//------------------------------------- 

                                   // para los que son de guardia

                                    if (datos.TipoOrden == "G") { valorSegunTipoMono = float.Parse(monoTable[aTable[0].complejidad - 1].valorGuardia.ToString()); }
                                    else { valorSegunTipoMono = float.Parse(monoTable[aTable[0].complejidad - 1].valorInicial.ToString()); }
                                    // para los que son de guardia

                                            //si es alta complejidad y NO superan el limite de agrupado. divide el valor por la cantidad de altas
                                            if (cantidadAltas <= monoTable[aTable[0].complejidad - 1].cantidadBreak) 
                                            {
                                                valor = valorSegunTipoMono / cantidadAltas; 
                                            }
                                            else
                                            {
                                                //va contando cuantas practicas de alta hay en el protocolo
                                                contAltas += 1;
                                                //el contador que no se resetea
                                                contAltasTotal += 1;
                                                //calcula cuantos grupos se pueden formar con la cantidad de altas que hay en el protocolo
                                                gruposAltas = cantidadAltas / monoTable[aTable[0].complejidad - 1].cantidadBreak;

                                                //si la cantidad de altas que se esta iterando es igual al break pasa a un nuevo grupo y se empieza a contar desde cero
                                                if (contAltas == monoTable[aTable[0].complejidad - 1].cantidadBreak) 
                                                { actualAltas += 1;
                                                    //contAltas = 0; //se comenta por que quieren que a partir de la cantidad break la practica valga el valor unitario de valor exedente 
                                                }

                                                //la cantidad de practicas que no entran en ningun grupo
                                                int p = cantidadAltas - (monoTable[aTable[0].complejidad - 1].cantidadBreak * gruposAltas);

                                                //si el grupo actual es menor-igual al total de grupos que se pueden formar, se reseta el valor y se le asigna el valor dividido por el breack
                                                //if (actualAltas <= gruposAltas) 
                                                if (contAltas <= monoTable[aTable[0].complejidad - 1].cantidadBreak)
                                                { 
                                                    valor = float.Parse("0.0"); 
                                                    valor = valorSegunTipoMono / monoTable[aTable[0].complejidad - 1].cantidadBreak; 
                                                }
                                                //si las practicas restantes son menores o iguales a 1, es la primera de las excliudas y vale el total, sino se divide por la cantidad de practicas excuidas
                                                else /*if (p <= 1)*/ 
                                                { 
                                                    valor = float.Parse(valor + monoTable[aTable[0].complejidad - 1].valorExedente.ToString()); 
                                                } 
                                                /*else 
                                                { valor = float.Parse("0.0"); 
                                                    valor = float.Parse(monoTable[aTable[0].complejidad - 1].valorInicial.ToString()) / p; 
                                                }*/
                                                //si el grupo actual es igual al total de grupos quiere decir que llego al limite y se incremeta el grupo para calcular las practicas que quedan excluidas 
                                                //de los grupos y se resetea el contador de altas
                                                if (actualAltas == gruposAltas) 
                                                { 
                                                    actualAltas += 1;
                                                    //contAltas = 0; //se comenta por que quieren que a partir de la cantidad break la practica valga el valor unitario de valor exedente 
                                                }
                                            }

                                            break;
                                    }
                            }
                       // }
                        else
                        {// si NO es monotributista
                            //valor = Convert.ToInt64(aTable[0].vbono);



                            float valorSegunTipo;
                            switch (aTable[0].complejidad)
                            {
                                 //si es complejidad cinco
                                case 5:
//-----------------------arreglo BUG para el calculo de de subpracticas duplicadas que no se tenian en cuenta-----
                                    //iniciamos array para guardar los codigos a consultar
                                    
                                    string[] separadasCinco;
                                    //guardamos los datos dentro del array
                                    separadasCinco = PracticasProtocolo.Split(',');

                                    int _countCinco = 0;
                                    for (int i = 1; i < separadasCinco.Length; i++)
                                    {
                                        DAL.BonoDAL.H3_ValorBono_x_PracticaDataTable mio = adapter.GetData(1, 188, Convert.ToInt64(separadasCinco[i]));

                                        //Console.WriteLine("MIO: "+GeneralTable[mio[0].complejidad].complejidad);
                                        //Console.WriteLine("0:  " + GeneralTable[aTable[0].complejidad]);
                                        //Console.WriteLine("-1: " + GeneralTable[aTable[0].complejidad-1].complejidad);

                                        if (GeneralTable[aTable[0].complejidad-1].complejidad == GeneralTable[mio[0].complejidad - 1].complejidad)
                                        {
                                            _countCinco++;
                                        }
                                    }
                                    cantidadCinco = _countCinco;
//------------------------------------- 

                                    // para los que son de guardia
                                    if (datos.TipoOrden == "G") { valorSegunTipo = float.Parse(GeneralTable[aTable[0].complejidad - 1].valorGuardia.ToString()); }
                                    else { valorSegunTipo = float.Parse(GeneralTable[aTable[0].complejidad - 1].valorInicial.ToString()); }
                                    // para los que son de guardia


                                                                       //si es complejidad inventada y NO superan el limite de agrupado. divide el valor por la cantidad de inventada
                                    if (cantidadCinco <= GeneralTable[aTable[0].complejidad - 1].cantidadBreak) 
                                    {
                                        valor = valorSegunTipo / cantidadCinco; 
                                    }
                                    else
                                    {
                                        //va contando cuantas practicas inventadas que hay en el protocolo
                                        contCinco += 1;
                                        //el contador que no se resetea
                                        contCincoTotal += 1;
                                        //calcula cuantos grupos se pueden formar con la cantidad de inventadas que hay en el protocolo
                                        gruposCinco = cantidadCinco / GeneralTable[aTable[0].complejidad - 1].cantidadBreak;

                                        //si la cantidad de inventadas que se esta iterando es igual al break pasa a un nuevo grupo y se empieza a contar desde cero
                                        if (contCinco == GeneralTable[aTable[0].complejidad - 1].cantidadBreak) 
                                        { 
                                            actualCinco += 1;
                                            //contInventadas = 0; se comenta por que quieren que a partir de la cantidad break la practica valga el valor unitario de valor exedente
                                        }

                                        //la cantidad de practicas que no entran en ningun grupo
                                        int p = cantidadCinco - (GeneralTable[aTable[0].complejidad - 1].cantidadBreak * gruposCinco);

                                        //si el grupo actual es menor-igual al total de grupos que se pueden formar, se reseta el valor y se le asigna el valor dividido por el breack
                                        //if (actualInventadas <= gruposInventadas) 
                                        if (contCinco <= GeneralTable[aTable[0].complejidad - 1].cantidadBreak) 
                                        { 
                                            valor = float.Parse("0.0"); 
                                            valor = valorSegunTipo / GeneralTable[aTable[0].complejidad - 1].cantidadBreak; 
                                        }
                                        //si las practicas restantes son menores o iguales a 1, es la primera de las excliudas y vale el total, sino se divide por la cantidad de practicas excuidas
                                        else /*if (p <= 1)*/ 
                                        { 
                                            valor = float.Parse(valor + GeneralTable[aTable[0].complejidad - 1].valorExedente.ToString()); 
                                        } 
                                        /*else 
                                        { 
                                            valor = float.Parse("0.0"); 
                                            valor = float.Parse(GeneralTable[aTable[0].complejidad - 1].valorInicial.ToString()) / p; 
                                        }*/
                                        //si el grupo actual es igual al total de grupos quiere decir que llego al limite y se incremeta el grupo para calcular las practicas que quedan excluidas 
                                        //de los grupos y se resetea el contador de bajas
                                        if (actualCinco == gruposCinco) 
                                        { 
                                            actualCinco += 1;
                                            //contInventadas = 0;//se comenta por que quieren que a partir de la cantidad break la practica valga el valor unitario de valor exedente  
                                        }
                                    }

                                break;
                                 //si es complejidad cinco

                                //si es complejidad inventada
                                case 4:
//-----------------------arreglo BUG para el calculo de de subpracticas duplicadas que no se tenian en cuenta-----
                                    //iniciamos array para guardar los codigos a consultar
                                    
                                    string[] separadasInventada;
                                    //guardamos los datos dentro del array
                                    separadasInventada = PracticasProtocolo.Split(',');

                                    int _countInventada = 0;
                                    for (int i = 1; i < separadasInventada.Length; i++)
                                    {
                                        DAL.BonoDAL.H3_ValorBono_x_PracticaDataTable mio = adapter.GetData(1, 188, Convert.ToInt64(separadasInventada[i]));

                                        //Console.WriteLine("MIO: "+GeneralTable[mio[0].complejidad].complejidad);
                                        //Console.WriteLine("0:  " + GeneralTable[aTable[0].complejidad]);
                                        //Console.WriteLine("-1: " + GeneralTable[aTable[0].complejidad-1].complejidad);

                                        if (GeneralTable[aTable[0].complejidad-1].complejidad == GeneralTable[mio[0].complejidad - 1].complejidad)
                                        {
                                            _countInventada++;
                                        }
                                    }
                                    cantidadInventadas = _countInventada;
//------------------------------------- 

                                    // para los que son de guardia
                                    if (datos.TipoOrden == "G") { valorSegunTipo = float.Parse(GeneralTable[aTable[0].complejidad - 1].valorGuardia.ToString()); }
                                    else { valorSegunTipo = float.Parse(GeneralTable[aTable[0].complejidad - 1].valorInicial.ToString()); }
                                    // para los que son de guardia

                                    //si es complejidad inventada y NO superan el limite de agrupado. divide el valor por la cantidad de inventada
                                    if (cantidadInventadas <= GeneralTable[aTable[0].complejidad - 1].cantidadBreak) 
                                    {
                                        valor = valorSegunTipo / cantidadInventadas; 
                                    }
                                    else
                                    {
                                        //va contando cuantas practicas inventadas que hay en el protocolo
                                        contInventadas += 1;
                                        //el contador que no se resetea
                                        contInventadasTotal += 1;
                                        //calcula cuantos grupos se pueden formar con la cantidad de inventadas que hay en el protocolo
                                        gruposInventadas = cantidadInventadas / GeneralTable[aTable[0].complejidad - 1].cantidadBreak;

                                        //si la cantidad de inventadas que se esta iterando es igual al break pasa a un nuevo grupo y se empieza a contar desde cero
                                        if (contInventadas == GeneralTable[aTable[0].complejidad - 1].cantidadBreak) 
                                        { 
                                            actualInventadas += 1;
                                            //contInventadas = 0; se comenta por que quieren que a partir de la cantidad break la practica valga el valor unitario de valor exedente
                                        }

                                        //la cantidad de practicas que no entran en ningun grupo
                                        int p = cantidadInventadas - (GeneralTable[aTable[0].complejidad - 1].cantidadBreak * gruposInventadas);

                                        //si el grupo actual es menor-igual al total de grupos que se pueden formar, se reseta el valor y se le asigna el valor dividido por el breack
                                        //if (actualInventadas <= gruposInventadas) 
                                        if (contInventadas <= GeneralTable[aTable[0].complejidad - 1].cantidadBreak) 
                                        { 
                                            valor = float.Parse("0.0"); 
                                            valor = valorSegunTipo / GeneralTable[aTable[0].complejidad - 1].cantidadBreak; 
                                        }
                                        //si las practicas restantes son menores o iguales a 1, es la primera de las excliudas y vale el total, sino se divide por la cantidad de practicas excuidas
                                        else /*if (p <= 1)*/ 
                                        { 
                                            valor = float.Parse(valor + GeneralTable[aTable[0].complejidad - 1].valorExedente.ToString()); 
                                        } 
                                        /*else 
                                        { 
                                            valor = float.Parse("0.0"); 
                                            valor = float.Parse(GeneralTable[aTable[0].complejidad - 1].valorInicial.ToString()) / p; 
                                        }*/
                                        //si el grupo actual es igual al total de grupos quiere decir que llego al limite y se incremeta el grupo para calcular las practicas que quedan excluidas 
                                        //de los grupos y se resetea el contador de bajas
                                        if (actualInventadas == gruposInventadas) 
                                        { 
                                            actualInventadas += 1;
                                            //contInventadas = 0;//se comenta por que quieren que a partir de la cantidad break la practica valga el valor unitario de valor exedente  
                                        }
                                    }

                                    break;
                                //si es baja complejidad
                                case 3:
//-----------------------arreglo BUG para el calculo de de subpracticas duplicadas que no se tenian en cuenta-----
                                    //iniciamos array para guardar los codigos a consultar
                                    string[] separadasBaja;
                                    //guardamos los datos dentro del array
                                    separadasBaja = PracticasProtocolo.Split(',');

                                    int _countBaja = 0;
                                    for (int i = 1; i < separadasBaja.Length; i++)
                                    {
                                        DAL.BonoDAL.H3_ValorBono_x_PracticaDataTable mio = adapter.GetData(1, 188, Convert.ToInt64(separadasBaja[i]));

                                        if (GeneralTable[aTable[0].complejidad-1].complejidad == GeneralTable[mio[0].complejidad-1].complejidad)
                                        {
                                            _countBaja++;
                                        }

                                    }
                                    cantidadBajas = _countBaja;
//-------------------------------------   

                                    // para los que son de guardia
                                    if (datos.TipoOrden == "G") { valorSegunTipo = float.Parse(GeneralTable[aTable[0].complejidad - 1].valorGuardia.ToString()); }
                                    else { valorSegunTipo = float.Parse(GeneralTable[aTable[0].complejidad - 1].valorInicial.ToString()); }
                                    // para los que son de guardia

                                    //si es baja complejidad y NO superan el limite de agrupado. divide el valor por la cantidad de bajas
                                    if (cantidadBajas <= GeneralTable[aTable[0].complejidad - 1].cantidadBreak) 
                                    {                                     

                                        valor = valorSegunTipo / cantidadBajas; 
                                    }
                                    else
                                    {

                                        //va contando cuantas practicas de baja hay en el protocolo
                                        contBajas += 1;
                                        //el contador que no se resetea
                                        contBajasTotal += 1;
                                        //calcula cuantos grupos se pueden formar con la cantidad de bajas que hay en el protocolo
                                        gruposBajas = cantidadBajas / GeneralTable[aTable[0].complejidad - 1].cantidadBreak;

                                        //si la cantidad de bajas que se esta iterando es igual al break pasa a un nuevo grupo y se empieza a contar desde cero
                                        if (contBajas == GeneralTable[aTable[0].complejidad - 1].cantidadBreak) 
                                        { 
                                            actualBajas += 1;
                                            //contBajas = 0; se comenta por que quieren que a partir de la cantidad break la practica valga el valor unitario de valor exedente 
                                        }

                                        //la cantidad de practicas que no entran en ningun grupo
                                        int p = cantidadBajas - (GeneralTable[aTable[0].complejidad - 1].cantidadBreak * gruposBajas);

                                        //si el grupo actual es menor-igual al total de grupos que se pueden formar, se reseta el valor y se le asigna el valor dividido por el breack
                                        //if (actualBajas < gruposBajas)
                                        if (contBajas <= GeneralTable[aTable[0].complejidad - 1].cantidadBreak) 
                                        { 
                                            valor = float.Parse("0.0"); 
                                            valor = valorSegunTipo / GeneralTable[aTable[0].complejidad - 1].cantidadBreak; 
                                        }
                                        //si las practicas restantes son menores o iguales a 1, es la primera de las excliudas y vale el total, sino se divide por la cantidad de practicas excuidas
                                        else /*if (p <= 1) */
                                        { 
                                            valor = float.Parse(valor + GeneralTable[aTable[0].complejidad - 1].valorExedente.ToString()); 
                                        }
                                       /* else 
                                        { 
                                            valor = float.Parse("0.0"); 
                                            valor = float.Parse(GeneralTable[aTable[0].complejidad - 1].valorInicial.ToString()) / p; 
                                        }*/
                                        //si el grupo actual es igual al total de grupos quiere decir que llego al limite y se incremeta el grupo para calcular las practicas que quedan excluidas 
                                        //de los grupos y se resetea el contador de bajas
                                        if (actualBajas == gruposBajas) 
                                        { 
                                            actualBajas += 1;
                                            //contBajas = 0; se comenta por que quieren que a partir de la cantidad break la practica valga el valor unitario de valor exedente 
                                        }
                                    }

                                    break;

                                //si es de media complejidad
                                case 2:
//-----------------------arreglo BUG para el calculo de de subpracticas duplicadas que no se tenian en cuenta-----
                                    //iniciamos array para guardar los codigos a consultar
                                    string[] separadasMedia;
                                    //guardamos los datos dentro del array
                                    separadasMedia = PracticasProtocolo.Split(',');

                                    int _countMedia = 0;
                                    for (int i = 1; i < separadasMedia.Length; i++)
                                    {
                                        DAL.BonoDAL.H3_ValorBono_x_PracticaDataTable mio = adapter.GetData(1, 188, Convert.ToInt64(separadasMedia[i]));

                                        if (GeneralTable[aTable[0].complejidad-1].complejidad == GeneralTable[mio[0].complejidad-1].complejidad)
                                        {
                                            _countMedia++;
                                        }
                                    }
                                    cantidadMedias = _countMedia;
//------------------------------------- 

                                    // para los que son de guardia
                                    if (datos.TipoOrden == "G") { valorSegunTipo = float.Parse(GeneralTable[aTable[0].complejidad - 1].valorGuardia.ToString()); }
                                    else { valorSegunTipo = float.Parse(GeneralTable[aTable[0].complejidad - 1].valorInicial.ToString()); }
                                    // para los que son de guardia

                                    //si es media complejidad y NO superan el limite de agrupado. divide el valor por la cantidad de medias
                                    if (cantidadMedias <= GeneralTable[1].cantidadBreak) 
                                    {
                                        valor = valorSegunTipo / cantidadMedias; 
                                    }
                                    else
                                    {
                                        //va contando cuantas practicas de media hay en el protocolo
                                        contMedias += 1;
                                        //el contador que no se resetea
                                        contMediasTotal += 1;
                                        //calcula cuantos grupos se pueden formar con la cantidad de medias que hay en el protocolo
                                        gruposMedias = cantidadMedias / GeneralTable[aTable[0].complejidad - 1].cantidadBreak;

                                        //si la cantidad de medias que se esta iterando es igual al break pasa a un nuevo grupo y se empieza a contar desde cero
                                        if (contMedias == GeneralTable[aTable[0].complejidad - 1].cantidadBreak) 
                                        { 
                                            actualMedias += 1; 
                                            //contMedias = 0; se comenta por que quieren que a partir de la cantidad break la practica valga el valor unitario de valor exedente 
                                        }
                                        
                                        //la cantidad de practicas que no entran en ningun grupo
                                        int p = cantidadMedias - (GeneralTable[aTable[0].complejidad - 1].cantidadBreak * gruposMedias);


                                        //si el grupo actual es menor-igual al total de grupos que se pueden formar, se reseta el valor y se le asigna el valor dividido por el breack
                                        //if (actualMedias <= gruposMedias)
                                        if (contMedias <= GeneralTable[aTable[0].complejidad - 1].cantidadBreak)
                                        { 
                                            valor = float.Parse("0.0"); 
                                            valor = valorSegunTipo / GeneralTable[aTable[0].complejidad - 1].cantidadBreak; 
                                        }
                                        //si las practicas restantes son menores o iguales a 1, es la primera de las excliudas y vale el total, sino se divide por la cantidad de practicas excuidas
                                        else 
                                           /*if (p <= 1) */
                                            { 
                                                valor = float.Parse(valor + GeneralTable[aTable[0].complejidad - 1].valorExedente.ToString()); 
                                            } 
                                           /*else 
                                            { 
                                                valor = float.Parse("0.0"); 
                                                valor = float.Parse(GeneralTable[aTable[0].complejidad - 1].valorInicial.ToString()) / p; 
                                            }*/
                                        //si el grupo actual es igual al total de grupos quiere decir que llego al limite y se incremeta el grupo para calcular las practicas que quedan excluidas 
                                        //de los grupos y se resetea el contador de medias
                                        if (actualMedias == gruposMedias) 
                                        { 
                                            actualMedias += 1;
                                            //contMedias = 0; se comenta por que quieren que a partir de la cantidad break la practica valga el valor unitario de valor exedente 
                                        }
                                    }
                                    break;
                                //si es alta complejidad
                                case 1:
//-----------------------arreglo BUG para el calculo de de subpracticas duplicadas que no se tenian en cuenta-----
                                    //iniciamos array para guardar los codigos a consultar
                                    string[] separadasAlta;
                                    //guardamos los datos dentro del array
                                    separadasAlta = PracticasProtocolo.Split(',');

                                    int _countAlta = 0;
                                    for (int i = 1; i < separadasAlta.Length; i++)
                                    {
                                        DAL.BonoDAL.H3_ValorBono_x_PracticaDataTable mio = adapter.GetData(1, 188, Convert.ToInt64(separadasAlta[i]));

                                        if (GeneralTable[aTable[0].complejidad - 1].complejidad == GeneralTable[mio[0].complejidad - 1].complejidad)
                                        {
                                            _countAlta++;
                                        }
                                    }
                                    cantidadAltas = _countAlta;
//------------------------------------- 

                                    // para los que son de guardia
                                    if (datos.TipoOrden == "G") { valorSegunTipo = float.Parse(GeneralTable[aTable[0].complejidad - 1].valorGuardia.ToString()); }
                                    else { valorSegunTipo = float.Parse(GeneralTable[aTable[0].complejidad - 1].valorInicial.ToString()); }
                                    // para los que son de guardia

                                    //si es alta complejidad y NO superan el limite de agrupado. divide el valor por la cantidad de altas
                                    if (cantidadAltas <= GeneralTable[aTable[0].complejidad - 1].cantidadBreak) 
                                    {
                                        valor = valorSegunTipo / cantidadAltas; 
                                    }
                                    else
                                    {
                                        //va contando cuantas practicas de alta hay en el protocolo
                                        contAltas += 1;
                                        //el contador que no se resetea
                                        contAltasTotal += 1;
                                        //calcula cuantos grupos se pueden formar con la cantidad de altas que hay en el protocolo
                                        gruposAltas = cantidadAltas / GeneralTable[0].cantidadBreak;

                                        //si la cantidad de altas que se esta iterando es igual al break pasa a un nuevo grupo y se empieza a contar desde cero
                                        if (contAltas == GeneralTable[aTable[0].complejidad - 1].cantidadBreak) 
                                        { 
                                            actualAltas += 1;
                                            //contAltas = 0; se comenta por que quieren que a partir de la cantidad break la practica valga el valor unitario de valor exedente 
                                        }

                                        //la cantidad de practicas que no entran en ningun grupo
                                        int p = cantidadAltas - (GeneralTable[aTable[0].complejidad - 1].cantidadBreak * gruposAltas);

                                        //si el grupo actual es menor-igual al total de grupos que se pueden formar, se reseta el valor y se le asigna el valor dividido por el breack
                                        //if (actualAltas <= gruposAltas) 
                                        if (contAltas <= GeneralTable[aTable[0].complejidad - 1].cantidadBreak)
                                        { 
                                            valor = float.Parse("0.0"); 
                                            valor = valorSegunTipo / GeneralTable[aTable[0].complejidad - 1].cantidadBreak; 
                                        }
                                        //si las practicas restantes son menores o iguales a 1, es la primera de las excliudas y vale el total, sino se divide por la cantidad de practicas excuidas
                                        else /*if (p <= 1) */
                                        { 
                                            valor = float.Parse(valor + GeneralTable[aTable[0].complejidad - 1].valorExedente.ToString()); 
                                        }
                                        /*
                                        else 
                                        { 
                                            valor = float.Parse("0.0"); 
                                            valor = float.Parse(GeneralTable[aTable[0].complejidad - 1].valorInicial.ToString()) / p; 
                                        }*/
                                        //si el grupo actual es igual al total de grupos quiere decir que llego al limite y se incremeta el grupo para calcular las practicas que quedan excluidas 
                                        //de los grupos y se resetea el contador de altas
                                        if (actualAltas == gruposAltas) 
                                        { 
                                            actualAltas += 1;
                                            //contAltas = 0; se comenta por que quieren que a partir de la cantidad break la practica valga el valor unitario de valor exedente 
                                        }
                                    }

                                    break;

                            }

                        }
                    }
                    catch
                    {
                        valor = 0;
                    }
                


                //if (row.Index == gridview.Rows.Count - 1)
                //{
                //    if (resto != 0)
                //    {
                //        valor = float.Parse((Total_Final - Total).ToString("##.##"));
                //    }
                //}


                prac.Codigo = Convert.ToInt32(row.Cells[0].Value);
                prac.Estado = 1;
                prac.PracticaId = Convert.ToInt32(row.Cells[0].Value);
                prac.Precio = valor.ToString();
                prac.PrecioReal = valor.ToString();


                lista_practias.Add(prac);

                Total = Total + valor;



                string[] nuevo = new string[] { row.Cells[0].Value.ToString(), row.Cells[4].Value.ToString(), row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString(), valor.ToString("##.##") };
                gv_bono.Rows.Add(nuevo);

            }
            lTotal.Text = "Total: $" + Total.ToString("##.##");
        }

        private void ck_nopaga_CheckedChanged(object sender, EventArgs e)
        {
            NoPaga();
        }

        string BonoActual = "";
        public void GuardarBono(List<Confirmarturnos> Practicas, BonoPase datos)
        {

            DateTime Fecha = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " 00:00:00");

            DAL.BonoDALTableAdapters.QueriesTableAdapter adapter_cab = new DAL.BonoDALTableAdapters.QueriesTableAdapter();
            Int32 Id = Convert.ToInt32(adapter_cab.H2_Bono_Insert(Fecha, datos.Documento, false, null, true, datos.AutorizanteId, datos.MedicoId, datos.EspecialidadId, false, false, false, datos.Usuario, VariablesGlobales.ip, datos.AutorizaBono, datos.AutorizaMotivo, datos.Observaciones));
            BonoActual = "";
            adapter_cab.H2_LABORATORIO_USAR_BONO(Id, datos.Usuario); //26-08-2016 SE USA EL BONO

            adapter_cab.H2_BonoPractica_Delete(Fecha, Id);

            foreach (Confirmarturnos practica in Practicas)
            {
                if (practica.Estado != 0)
                {
                    if (datos.NoPaga) { practica.Precio = "0"; practica.PrecioReal = "0"; }
                    adapter_cab.H2_BonoPractica_Insert(Fecha, Id, practica.PracticaId, Convert.ToDecimal(practica.Precio), Convert.ToDecimal(practica.PrecioReal));
                }
            }

            //if (!ck_nopaga.Checked) { Motivo_no_paga = ""; } 
            Impresion_Bono f = new Impresion_Bono(Fecha.ToShortDateString(), Id, Motivo_no_paga);
            f.Show();
        }


        private void NoPaga()
        {
            cbo_autorizante.Enabled = ck_nopaga.Checked;
            cbo_motivo.Enabled = ck_nopaga.Checked;
            //txt_comentario.Enabled = ck_nopaga.Checked;
            LNopaga.Visible = ck_nopaga.Checked;
        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            //solo presupuesto
            if(datos.accion == "Presupuesto")
            //if (chkPresupuesto.Checked)
            {//gv_bono
                Impresion_Presupuesto f = new Impresion_Presupuesto(gv_bono);
               
                f.Show();

                this.Close();

            }
            else
            {

                //public int Codigo { get; set; }
                //public string Practica { get; set; }
                //public string Precio { get; set; }
                //public string PrecioReal { get; set; }
                //public int Pos { get; set; }
                //public string ComentarioPractica { get; set; }
                //public int PracticaId { get; set; }
                //public int Estado { get; set; }


                datos.AutorizaBono = 0;
                datos.AutorizaMotivo = 0;

                if (ck_nopaga.Enabled)
                {
                    if (ck_nopaga.Checked)
                    {
                        if (cbo_autorizante.SelectedItem == null)
                        {
                            MessageBox.Show("Falta Seleccionar el autorizante", "¿Quien lo autoriza?", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (cbo_motivo.SelectedItem == null)
                        {
                            MessageBox.Show("Falta Seleccionar el motivo", "¿Que motivo?", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }

                if (cbo_autorizante.SelectedValue != null)
                {
                    datos.AutorizaBono = (Int32)cbo_autorizante.SelectedValue;
                }

                if (cbo_motivo.SelectedValue != null)
                {
                    datos.AutorizaMotivo = (Int32)cbo_motivo.SelectedValue;
                }

                datos.NoPaga = ck_nopaga.Checked;

                datos.Observaciones = txt_comentario.Text;
                GuardarBono(lista_practias, datos);

                datos.comentario = "";
                if (txt_comentario.Text.Trim() != "")
                {
                    DAL.BonoDALTableAdapters.QueriesTableAdapter adapter = new DAL.BonoDALTableAdapters.QueriesTableAdapter();
                    adapter.H3_GENTE_INSERTAR_COMENTARIO(txt_comentario.Text, datos.Documento);
                    datos.comentario = txt_comentario.Text;
                }

                datos.accion = "Guardar";

                if (LNopaga.Visible) { datos.Monto = "NO PAGA"; } else { datos.Monto = lTotal.Text.Replace("Total: $", ""); }


                this.Close();
            }
        }


/*
        private void InicializacionVariables()
        {
            //cantidad total de practicas de cada complejidad en el protocolo
            cantidadBajas = 0;
            cantidadMedias = 0;
            cantidadAltas = 0;
            cantidadInventadas = 0;
            //lista de practicas del protocolo
            PracticasProtocolo = "";
            //contador de la iteracion actual de cada practica
            contBajas = 0;
            contBajasTotal = 0;
            contMedias = 0;
            contMediasTotal = 0;
            contAltas = 0;
            contAltasTotal = 0;
            contInventadas = 0;
            contInventadasTotal = 0;
        }


        private void ConfirmarCantidadSubPracticasRepetidas()
        {
            string cadena = PracticasProtocolo; ;
            char aBuscar = ',';
            int n = 0;
            foreach (char c in cadena)
            {
                if (c == aBuscar) ++n;
            }

            if (n > cantidadBajas)
            {
                cantidadBajas = n;
            }

        }
 * */

    }
}
