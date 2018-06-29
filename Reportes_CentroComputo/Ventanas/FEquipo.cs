using Reportes_CentroComputo.Ventanas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reportes_CentroComputo
{
    public partial class FEquipo : Form
    {
        DBConnect.GenericConnection conexion;
        ComboBox cmb;

        public FEquipo(DBConnect.GenericConnection con)
        {
            InitializeComponent();
            
            conexion = con;
            try
            {
                txtIDEquipo.Text = (int.Parse(conexion.command.ExecuteSentenceResponse("SELECT MAX(Id_Equipo) from equipo").ElementAt(0)[0].ToString()) + 1).ToString();
            }
            catch (Exception)
            {
                txtIDEquipo.Text = "1";
            }
        }

        public FEquipo(DBConnect.GenericConnection con, ComboBox c)
        {
            InitializeComponent();
            cmb = c;
            conexion = con;
            try
            {
                txtIDEquipo.Text = (int.Parse(conexion.command.ExecuteSentenceResponse("SELECT MAX(Id_Equipo) from equipo").ElementAt(0)[0].ToString()) + 1).ToString();
                
            }
            catch(Exception)
            {
                txtIDEquipo.Text = "1";
            }
        }

        private void FEquipo_Load(object sender, EventArgs e)
        {

        }

        private void btnOpenCPU_Click(object sender, EventArgs e)
        {
            new FCPU(conexion, txtIDCPU).Visible = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            prepareData();
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
            if(conexion.command.ExecuteSentenceResponse(string.Format("SELECT count(*) FROM equipo WHERE Id_Cpu='{0}'",txtIDCPU.Text)).ElementAt(0)[0].Equals("0"))
            {
                conexion.command.ExecuteSentence(string.Format("INSERT INTO equipo (Id_Equipo, Id_Cpu, Id_Monitor, Id_Teclado, Id_Raton, Activo, Asignado) VALUES ({0}, '{1}', {2}, '{3}', '{4}', '1', '1')", values.ToArray()));                
            }
            else
            {
                values.Add(values.ElementAt(1));
                conexion.command.ExecuteSentence(string.Format("UPDATE equipo SET Id_Equipo = '{0}', Id_Cpu = '{1}', Id_Monitor = '{2}', Id_Teclado = '{3}', Id_Raton = '{4}' WHERE Id_CPU = '{5}'", values.ToArray()));
            }
            if(cmb != null)
                cmb.Text = txtIDEquipo.Text;
            Dispose();
        }

        private void prepareData()
        {
            txtIDEquipo.Enabled = false;
            txtIDEquipo.BackColor = Color.White;
            if (!conexion.command.ExecuteSentenceResponse(string.Format("SELECT count(*) FROM equipo WHERE Id_Cpu='{0}'", txtIDCPU.Text)).ElementAt(0)[0].Equals("0"))
                txtIDEquipo.Text= (int.Parse(conexion.command.ExecuteSentenceResponse("SELECT Id_Equipo FROM equipo where ID_CPU='"+txtIDCPU.Text+"'").ElementAt(0)[0].ToString())).ToString();
            else
                txtIDEquipo.Text = (int.Parse(conexion.command.ExecuteSentenceResponse("SELECT max(Id_Equipo) FROM equipo").ElementAt(0)[0].ToString()) + 1).ToString();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (txtIDCPU.Text.Length <= 0)
                btnGuardar.Enabled = false;
            else
                btnGuardar.Enabled = true;
        }

        private void txtIDMonitor_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtIDMonitor_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new FMonitor(conexion, txtIDMonitor);
        }
    }
}
