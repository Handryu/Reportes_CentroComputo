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
                crearTablas();
            }
            
        }

        public FInicial(string user, string pass, string server, string database)
        {
            InitializeComponent();
            conexion = new DBConnect.GenericConnection(user, pass, server, database);
        }

        public void crearTablas()
        {
            conexion.command.ExecuteSentence("CREATE TABLE cpu (  Id_Cpu varchar(70) NOT NULL,  Num_Serie int(11) DEFAULT NULL,  Num_Inv varchar(25) DEFAULT NULL,  Marca varchar(30) DEFAULT NULL,  Modelo varchar(30) DEFAULT NULL,  Procesador varchar(30) DEFAULT NULL,  Mod_Ram varchar(30) DEFAULT NULL,  Gb_Ram int(11) DEFAULT NULL,  Mod_Dd varchar(30) DEFAULT NULL,  Gb_Dd int(11) DEFAULT NULL);");
            conexion.command.ExecuteSentence("CREATE TABLE departamento (  Id_Depto int(11) NOT NULL,  Nombre_Depto varchar(40) DEFAULT NULL);");
            conexion.command.ExecuteSentence("CREATE TABLE equipo (  Id_Equipo int(11) NOT NULL,  Id_Cpu varchar(70) DEFAULT NULL,  Id_Monitor int(11) DEFAULT NULL,  Id_Teclado int(11) DEFAULT NULL,  Id_Raton int(11) DEFAULT NULL,  Activo tinyint(1) NOT NULL DEFAULT '1',  Asignado tinyint(1) NOT NULL DEFAULT '1');");
            conexion.command.ExecuteSentence("CREATE TABLE historial (  Id_Historial int(11) NOT NULL,  Id_Usuario int(11) DEFAULT NULL,  Id_Equipo int(11) DEFAULT NULL,  Fecha datetime NOT NULL DEFAULT CURRENT_TIMESTAMP);");
            conexion.command.ExecuteSentence("CREATE TABLE monitor (  Id_Monitor int(11) NOT NULL,  Num_Serie int(11) DEFAULT NULL,  Num_Inv varchar(30) DEFAULT NULL);");
            conexion.command.ExecuteSentence("CREATE TABLE reporte (  Id_Folio int(11) NOT NULL,  ID_Tecnico int(11) DEFAULT NULL,  ID_Usuario int(11) DEFAULT NULL,  Id_Equipo int(11) DEFAULT NULL,  Falla varchar(50) DEFAULT NULL,  Componente_Dañado varchar(20) DEFAULT NULL,  Solucion varchar(50) DEFAULT NULL,  Notas varchar(20) DEFAULT NULL,  Fecha timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP);");
            conexion.command.ExecuteSentence("CREATE TABLE tecnico (  Id_Tecnico int(11) NOT NULL,  Nombre varchar(20) DEFAULT NULL,  Ap_Pat varchar(10) DEFAULT NULL,  Ap_Mat varchar(10) DEFAULT NULL);");
            conexion.command.ExecuteSentence("CREATE TABLE usuario (  Id_Usuario int(11) NOT NULL,  Nombre varchar(15) DEFAULT NULL,  Ap_Pat varchar(10) DEFAULT NULL,  Ap_Mat varchar(10) DEFAULT NULL,  Id_Depto int(11) DEFAULT NULL,  Id_Equipo int(11) DEFAULT NULL,  Activo tinyint(1) NOT NULL DEFAULT '1');");
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
            new FSelect(conexion, 0).Visible = true;
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
    }
}
