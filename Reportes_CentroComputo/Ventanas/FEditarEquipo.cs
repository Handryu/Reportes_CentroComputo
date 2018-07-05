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
    public partial class FEditarEquipo : Form
    {
        DBConnect.GenericConnection conexion;
        public FEditarEquipo(DBConnect.GenericConnection con, string id)
        {
            InitializeComponent();
            conexion = con;
            prepareData(id);
        }

        private void FEditarEquipo_Load(object sender, EventArgs e)
        {

        }

        private void prepareData(string id)
        {
            txtIDEquipo.Enabled = false;
            txtIDEquipo.BackColor = Color.White;
            txtIDCPU.Enabled = false;
            txtIDCPU.Text = id;
            txtIDEquipo.Text = conexion.command.ExecuteSentenceResponse(string.Format("SELECT Id_Equipo from equipo WHERE Id_Cpu='{0}'", id)).ElementAt(0)[0].ToString();
            txtIDMonitor.Text = conexion.command.ExecuteSentenceResponse(string.Format("SELECT Id_Monitor from equipo WHERE Id_Cpu='{0}'", id)).ElementAt(0)[0].ToString();
            txtIDRaton.Text = conexion.command.ExecuteSentenceResponse(string.Format("SELECT Id_Raton from equipo WHERE Id_Cpu='{0}'", id)).ElementAt(0)[0].ToString();
            txtIDTeclado.Text = conexion.command.ExecuteSentenceResponse(string.Format("SELECT Id_Teclado from equipo WHERE Id_Cpu='{0}'", id)).ElementAt(0)[0].ToString();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            List<object> values = new List<object>();
            string val = "";
            val = txtIDEquipo.Text;
            if (val.Length < 0)
                val = "NULL";
            values.Add(val);
            val = txtIDCPU.Text;
            if (val.Length < 0)
                val = "NULL";
            values.Add(val);
            val = txtIDMonitor.Text;
            if (val.Length < 0)
                val = "NULL";
            values.Add(val);
            val = txtIDTeclado.Text;
            if (val.Length < 0)
                val = "NULL";
            values.Add(val);
            val = txtIDRaton.Text;
            if (val.Length < 0)
                val = "NULL";
            values.Add(val);
            conexion.command.ExecuteSentence(string.Format("UPDATE equipo SET Id_Equipo = '{0}', Id_Cpu = '{1}', Id_Monitor = '{2}', Id_Teclado = '{3}', Id_Raton = '{4}', Activo = '1', Asignado = '1' WHERE equipo.Id_CPU = '{5}'", values.ToArray()));

            Dispose();
        }

        private void btnOpenCPU_Click(object sender, EventArgs e)
        {
            new FCPU(conexion, txtIDCPU).Visible = true;
        }
    }
}
