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
    public partial class FSelect : Form
    {
        DBConnect.GenericConnection conexion;
        int tipo = 0;
        

        public FSelect(DBConnect.GenericConnection con, int tipo, bool modo)
        {
            InitializeComponent();
            conexion = con;
            this.tipo = tipo;
            if(modo)
            {
                btnBorrar.Enabled = false;
                btnEditar.Enabled = true;

                btnBorrar.Text = "";
                btnEditar.Text = "Editar";
            }
            else
            {
                btnBorrar.Enabled = true;
                btnEditar.Enabled = false;

                btnBorrar.Text = "Eliminar";
                btnEditar.Text = "";
            }
            switch(tipo)
            {
                case 0:
                    conexion.functions.FillComboBox("SELECT Id_Folio from reporte", "Id_Folio", comboBox1);
                    break;
                case 1:
                    conexion.functions.FillComboBox("SELECT CONCAT(Nombre,' ',Ap_Pat,' ',Ap_Mat) as ID from usuario where Activo=1", "Id_Usuario", comboBox1);
                    break;
                case 2:
                    conexion.functions.FillComboBox("SELECT Id_Equipo from equipo where Activo=1", "Id_Cpu", comboBox1);
                    break;
                case 3:
                    conexion.functions.FillComboBox("SELECT Id_Depto from departamento", "Id_Depto", comboBox1);
                    break;
                case 4:
                    conexion.functions.FillComboBox("SELECT Id_Tecnico from tecnico", "Id_Tecnico", comboBox1);
                    break;
                case 5:
                    conexion.functions.FillComboBox("SELECT Id_Monitor from monitor where Activo=1", "Id_Monitor", comboBox1);
                    break;
            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch(tipo)
                {
                    case 0:
                        textBox1.Text = conexion.command.ExecuteSentenceResponse(string.Format("SELECT CONCAT(Id_Equipo,' ',Falla,' ',Fecha) as ID from reporte where Id_Folio={0}", comboBox1.SelectedItem.ToString())).ElementAt(0)[0].ToString();
                        break;
                    case 1:
                        textBox1.Text = conexion.command.ExecuteSentenceResponse(string.Format("SELECT Id_Usuario from usuario where Nombre='{0}' and Ap_Pat='{1}', and Ap_Mat='{2}'", comboBox1.SelectedItem.ToString().Split(' '))).ElementAt(0)[0].ToString();
                        break;
                    case 2:
                        textBox1.Text = conexion.command.ExecuteSentenceResponse(string.Format("SELECT CONCAT(cpu.Marca,' ',cpu.Modelo,' ',cpu.Num_Serie,' ',cpu.Num_Inv,' ',usuario.Nombre,' ',usuario.Ap_Pat,' ',usuario.Ap_Mat) FROM cpu,usuario WHERE cpu.Id_Cpu IN (SELECT equipo.Id_Cpu FROM equipo WHERE equipo.Id_Equipo='{0}') AND usuario.Id_Equipo IN (SELECT usuario.Id_Equipo FROM usuario WHERE usuario.Id_Equipo='{1}')", comboBox1.SelectedItem.ToString(), comboBox1.SelectedItem.ToString())).ElementAt(0)[0].ToString();
                        break;
                    case 3:
                        textBox1.Text = conexion.command.ExecuteSentenceResponse(string.Format("SELECT CONCAT(Nombre_Depto,' ') as ID from departamento where Id_Depto={0}", comboBox1.SelectedItem.ToString())).ElementAt(0)[0].ToString();
                        break;
                    case 4:
                        textBox1.Text = conexion.command.ExecuteSentenceResponse(string.Format("SELECT CONCAT(Nombre,' ',Ap_Pat,' ',Ap_Mat) as ID from tecnico where Id_Tecnico={0}", comboBox1.SelectedItem.ToString())).ElementAt(0)[0].ToString();
                        break;
                    case 5:
                        textBox1.Text = conexion.command.ExecuteSentenceResponse(string.Format("SELECT CONCAT(Num_Serie,' ',Marca,' ',Num_Inventario) as ID from monitor where Id_Tecnico={0}", comboBox1.SelectedItem.ToString())).ElementAt(0)[0].ToString();
                        break;
                }
                
            }
            catch(Exception)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch(tipo)
            {
                case 0:
                    new FEditarReporte(conexion, comboBox1.SelectedItem.ToString()).Visible = true;
                    break;
                case 1:
                    new FEditarUsuario(conexion, comboBox1.SelectedItem.ToString()).Visible = true;
                    break;
                case 2:
                    new FEditarEquipo(conexion, comboBox1.SelectedItem.ToString()).Visible = true;
                    break;
                case 3:
                    new FEditarDepartamento(conexion, comboBox1.SelectedItem.ToString()).Visible = true;
                    break;
                case 4:
                    new FEditarTecnico(conexion, comboBox1.SelectedItem.ToString()).Visible = true;
                    break;
            }
            Dispose();           
        }

        private void FSelectReporte_Load(object sender, EventArgs e)
        {

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            switch(tipo)
            {
                case 0:
                    conexion.command.ExecuteSentence(string.Format("DELETE from usuario WHERE Id_Folio={0}",comboBox1.SelectedItem.ToString()));
                    break;
                case 1:
                    conexion.command.ExecuteSentence(string.Format("UPDATE usuario SET Activo = '0' WHERE Id_Usuario ={0}", comboBox1.SelectedItem.ToString()));
                    break;
                case 2:
                    conexion.command.ExecuteSentence(string.Format("UPDATE equipo SET Activo = '0' WHERE Id_Equipo={0}", comboBox1.SelectedItem.ToString()));
                    break;
                case 3:
                    conexion.command.ExecuteSentence(string.Format("DELETE from departamento WHERE Id_Depto={0}", comboBox1.SelectedItem.ToString()));
                    break;
                case 4:
                    conexion.command.ExecuteSentence(string.Format("DELETE from tecnico WHERE Id_Tecnico={0}", comboBox1.SelectedItem.ToString()));
                    break;
                case 5:
                    conexion.command.ExecuteSentence(string.Format("UPDATE monitor SET Activo = '0' WHERE Id_Monitor={0}", comboBox1.SelectedItem.ToString()));
                    break;
            }
            Dispose();
        }
    }
}
