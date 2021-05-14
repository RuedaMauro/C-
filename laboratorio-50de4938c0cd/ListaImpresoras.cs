using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Xml;

namespace Laboratorio2
{
    public partial class ListaImpresoras : Form
    {
        public ListaImpresoras()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                txt_Imp_Cod_Barra.Text = printDialog1.PrinterSettings.PrinterName;
            }
        }

        private void b2_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                txt_Imp_Comprobante.Text = printDialog1.PrinterSettings.PrinterName;
            }
        }

        private void ListaImpresoras_Load(object sender, EventArgs e)
        {
            txt_Imp_Cod_Barra.Text = ConfigurationManager.AppSettings["ImpresoraCodBarra"];
            txt_Imp_Comprobante.Text = ConfigurationManager.AppSettings["ImpresoraComprobante"];
            txt_Imp_Bono.Text = ConfigurationManager.AppSettings["ImpresoraBono"];
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

            foreach (XmlElement element in xmlDoc.DocumentElement)
            {
                if (element.Name.Equals("appSettings"))
                {
                    foreach (XmlNode node in element.ChildNodes)
                    {
                        if (node.Attributes[0].Value.Equals("ImpresoraCodBarra"))
                        {
                            node.Attributes[1].Value = txt_Imp_Cod_Barra.Text;
                        }

                        if (node.Attributes[0].Value.Equals("ImpresoraComprobante"))
                        {
                            node.Attributes[1].Value = txt_Imp_Comprobante.Text;
                        }

                        if (node.Attributes[0].Value.Equals("ImpresoraBono"))
                        {
                            node.Attributes[1].Value = txt_Imp_Bono.Text;
                        }
                    }
                }
            }

            xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

            ConfigurationManager.RefreshSection("appSettings");

            MessageBox.Show("Impresoras Guardadas", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void b3_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                txt_Imp_Bono.Text = printDialog1.PrinterSettings.PrinterName;
            }
        }
    }
}
