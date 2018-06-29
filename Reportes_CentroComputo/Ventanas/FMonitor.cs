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
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            t.Text = (int.Parse(conexion.command.ExecuteSentenceResponse("SELECT MAX(Id_Monitor) from monitor").ElementAt(0)[0].ToString()) + 1).ToString();
            conexion.command.ExecuteSentence(string.Format("INSERT INTO monitor (Id_Monitor, Num_Serie, Num_Inv) VALUES (NULL, '{0}', '{1}');", txtNSerie.Text, txtNInv.Text));
            Dispose();
        }
    }
}
