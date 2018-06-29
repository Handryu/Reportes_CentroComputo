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
            InitializeComponent();
            if(DBExist("DBInterna"))
            {
                conexion = new DBConnect.GenericConnection("DBInterna");
            }
            else
            {
                conexion = new DBConnect.GenericConnection("DBInterna");
                new Herramientas.ServiceFunctions().crearTablas(conexion);
            }
            
        }

        public FInicial(string user, string pass, string server, string database)
        {
            InitializeComponent();
            conexion = new DBConnect.GenericConnection(user, pass, server, database);
        }

        

        public bool DBExist(string fname)
        {
            FileInfo db = new FileInfo(fname);
            if (db.Exists)
                return true;
            return false;
        }

        private void OpcionMapeo_Click(object sender, EventArgs e)
        {
            new FMapeo().Visible = true;
        }

        private void OpcionLimpieza_Click(object sender, EventArgs e)
        {
            new FLimpieza().Start();
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
            new FReporte(conexion).Visible = true;
        }

        private void verReporteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FSelect(conexion, 0, true).Visible = true;
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FUsuario(conexion).Visible = true;
        }

        private void equipoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FEquipo(conexion).Visible = true;
        }

        private void departamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FDepartamento(conexion).Visible = true;
        }

        private void tecnicosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FTecnico(conexion).Visible = true;
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FSelect(conexion, 1, true).Visible = true;
        }

        private void equipoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new FSelect(conexion, 2, true).Visible = true;
        }

        private void departamentoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new FSelect(conexion, 3, true).Visible = true;
        }

        private void tecnicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FSelect(conexion, 4, true).Visible = true;
        }

        private void usuarioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new FSelect(conexion, 1, false).Visible = true;
        }

        private void equipoToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            new FSelect(conexion, 2, false).Visible = true;
        }

        private void departamentoToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            new FSelect(conexion, 3, false).Visible = true;
        }

        private void tecnicoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new FSelect(conexion, 4, false).Visible = true;
        }

        private void baseLocalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Herramientas.ServiceFunctions().sincronizarDBLocal(conexion);
            MessageBox.Show("Listo");
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
    }
}
