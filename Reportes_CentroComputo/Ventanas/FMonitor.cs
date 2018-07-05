using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reportes_CentroComputo.Ventanas
{
    public partial class FMonitor : Form
    {
        TextBox t;
        DBConnect.GenericConnection conexion;
        public FMonitor()
        {
            InitializeComponent();
        }

        public FMonitor(DBConnect.GenericConnection con, TextBox te)
        {
            InitializeComponent();
            t = te;
            conexion = con;
            conexion.functions.FillComboBox("SELECT Nombre_Marca from marca", "Nombre_Marca", cmbMarcas);
        }

        public FMonitor(DBConnect.GenericConnection con)
        {
            InitializeComponent();

            conexion = con;
            conexion.functions.FillComboBox("SELECT Nombre_Marca from marca", "Nombre_Marca", cmbMarcas);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(t != null)
                t.Text = (int.Parse(conexion.command.ExecuteSentenceResponse("SELECT MAX(Id_Monitor) from monitor").ElementAt(0)[0].ToString()) + 1).ToString();
            conexion.command.ExecuteSentence(string.Format("INSERT INTO monitor (Id_Monitor, Num_Serie, Num_Inv, Marca) VALUES (NULL, '{0}', '{1}','{2}');", txtNSerie.Text, txtNInv.Text, cmbMarcas.SelectedItem.ToString()));
            Dispose();
        }

        private void FMonitor_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtNSerie_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtNInv_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void cmbMarcas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
