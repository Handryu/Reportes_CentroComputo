using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reportes_CentroComputo.Ventanas
{
    public partial class FInicial : Form
    {
        private DBConnect.GenericConnection conexion;
        public FInicial()
        {
            try
            {
                InitializeComponent();
                if (DBExist("DBInterna"))
                {
                    conexion = new DBConnect.GenericConnection("DBInterna");
                }
                else
                {
                    conexion = new DBConnect.GenericConnection("DBInterna");
                    new Herramientas.ServiceFunctions().crearTablas(conexion);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error inesperado: {0}", ex.Message));
                Console.WriteLine(string.Format("Error inesperado: {0}", ex.Message));
            }
            
        }

        public FInicial(string user, string pass, string server, string database)
        {
            try
            {
                InitializeComponent();
                conexion = new DBConnect.GenericConnection(user, pass, server, database);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error inesperado: {0}", ex.Message));
                Console.WriteLine(string.Format("Error inesperado: {0}", ex.Message));
            }
        }

        

        public bool DBExist(string fname)
        {
            FileInfo db = new FileInfo(string.Format("{0}.sqlite", fname));
            if (db.Exists)
                return true;
            return false;
        }

        private void OpcionMapeo_Click(object sender, EventArgs e)
        {
            try
            {
                new FMapeo().Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error inesperado: {0}", ex.Message));
                Console.WriteLine(string.Format("Error inesperado: {0}", ex.Message));
            }
        }

        private void OpcionLimpieza_Click(object sender, EventArgs e)
        {
            try
            {
                new FLimpieza().Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error inesperado: {0}", ex.Message));
                Console.WriteLine(string.Format("Error inesperado: {0}", ex.Message));
            }
        }

        private void FInicial_Load(object sender, EventArgs e)
        {

        }

        private void myClose()
        {
            Environment.Exit(0);
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                new FReporte(conexion).Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error inesperado: {0}", ex.Message));
                Console.WriteLine(string.Format("Error inesperado: {0}", ex.Message));
            }
        }

        private void verReporteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                new FSelect(conexion, 0, true).Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error inesperado: {0}", ex.Message));
                Console.WriteLine(string.Format("Error inesperado: {0}", ex.Message));
            }
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                new FUsuario(conexion).Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error inesperado: {0}", ex.Message));
                Console.WriteLine(string.Format("Error inesperado: {0}", ex.Message));
            }
        }

        private void equipoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                new FEquipo(conexion).Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error inesperado: {0}", ex.Message));
                Console.WriteLine(string.Format("Error inesperado: {0}", ex.Message));
            }
        }

        private void departamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                new FDepartamento(conexion).Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error inesperado: {0}", ex.Message));
                Console.WriteLine(string.Format("Error inesperado: {0}", ex.Message));
            }
        }

        private void tecnicosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                new FTecnico(conexion).Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error inesperado: {0}", ex.Message));
                Console.WriteLine(string.Format("Error inesperado: {0}", ex.Message));
            }
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                new FSelect(conexion, 1, true).Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error inesperado: {0}", ex.Message));
                Console.WriteLine(string.Format("Error inesperado: {0}", ex.Message));
            }
        }

        private void equipoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                new FSelect(conexion, 2, true).Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error inesperado: {0}", ex.Message));
                Console.WriteLine(string.Format("Error inesperado: {0}", ex.Message));
            }
        }

        private void departamentoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                new FSelect(conexion, 3, true).Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error inesperado: {0}", ex.Message));
                Console.WriteLine(string.Format("Error inesperado: {0}", ex.Message));
            }
        }

        private void tecnicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                new FSelect(conexion, 4, true).Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error inesperado: {0}", ex.Message));
                Console.WriteLine(string.Format("Error inesperado: {0}", ex.Message));
            }
        }

        private void usuarioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                new FSelect(conexion, 1, false).Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error inesperado: {0}", ex.Message));
                Console.WriteLine(string.Format("Error inesperado: {0}", ex.Message));
            }
        }

        private void equipoToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                new FSelect(conexion, 2, false).Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error inesperado: {0}", ex.Message));
                Console.WriteLine(string.Format("Error inesperado: {0}", ex.Message));
            }
        }

        private void departamentoToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                new FSelect(conexion, 3, false).Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error inesperado: {0}", ex.Message));
                Console.WriteLine(string.Format("Error inesperado: {0}", ex.Message));
            }
        }

        private void tecnicoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                new FSelect(conexion, 4, false).Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error inesperado: {0}", ex.Message));
                Console.WriteLine(string.Format("Error inesperado: {0}", ex.Message));
            }
        }

        private void baseLocalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                new Herramientas.ServiceFunctions().sincronizarDBLocal(conexion);
                MessageBox.Show("Listo");
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error inesperado: {0}", ex.Message));
                Console.WriteLine(string.Format("Error inesperado: {0}", ex.Message));
            }
        }

        private void baseCentralToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                new Herramientas.ServiceFunctions().sincronizarDBCentral(conexion);
            }
            catch(Exception)
            {
                MessageBox.Show("Sesion cancelada o datos de acceso incorectos");
            }
            MessageBox.Show("Listo");
        }

        private void monitorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                new FMonitor(conexion).Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error inesperado: {0}", ex.Message));
                Console.WriteLine(string.Format("Error inesperado: {0}", ex.Message));
            }
        }

        private void monitorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                new FSelect(conexion, 5, false).Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error inesperado: {0}", ex.Message));
                Console.WriteLine(string.Format("Error inesperado: {0}", ex.Message));                
            }
            
        }
    }
}
