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
    public partial class FDepartamento : Form
    {
        DBConnect.GenericConnection conexion;
        public FDepartamento(DBConnect.GenericConnection con)
        {
            InitializeComponent();
            conexion = con;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            conexion.command.ExecuteSentence(string.Format("INSERT INTO departamento (Id_Depto, Nombre_Depto) VALUES (NULL, '{0}');",txtNombre.Text));
            Dispose();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (txtNombre.Text.Length < 0)
                btnGuardar.Enabled = false;
            else
                btnGuardar.Enabled = true;
        }
    }
}
