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
    public partial class FTecnico : Form
    {
        DBConnect.GenericConnection conexion;
        public FTecnico(DBConnect.GenericConnection con)
        {
            InitializeComponent();
            conexion = con;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conexion.command.ExecuteSentence(string.Format("INSERT INTO tecnico (Id_Tecnico, Nombre, Ap_Pat, Ap_Mat) VALUES (NULL, '{0}', '{1}', '{2}')",textBox1.Text,textBox2.Text,textBox3.Text));
            Dispose();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0 && textBox3.Text.Length > 0)
                button1.Enabled = true;
            else
                button1.Enabled = false;
        }
    }
}
