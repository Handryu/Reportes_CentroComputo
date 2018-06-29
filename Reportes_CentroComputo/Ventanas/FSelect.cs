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
            }
            else
            {
                btnBorrar.Enabled = true;
                btnEditar.Enabled = false;
            }
            switch(tipo)
            {
                case 0:
                    conexion.functions.FillComboBox("SELECT Id_Folio from reporte", "Id_Folio", comboBox1);
                    break;
                case 1:
                    conexion.functions.FillComboBox("SELECT Id_Usuario from usuario", "Id_Usuario", comboBox1);
                    break;
                case 2:
                    conexion.functions.FillComboBox("SELECT Id_Cpu from equipo", "Id_Cpu", comboBox1);
                    break;
                case 3:
                    conexion.functions.FillComboBox("SELECT Id_Depto from departamento", "Id_Depto", comboBox1);
                    break;
                case 4:
                    conexion.functions.FillComboBox("SELECT Id_Tecnico from tecnico", "Id_Tecnico", comboBox1);
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
                        textBox1.Text = conexion.command.ExecuteSentenceResponse(string.Format("SELECT CONCAT(Nombre,' ',Ap_Pat,' ',Ap_Mat) as ID from usuario where Id_Usuario={0}", comboBox1.SelectedItem.ToString())).ElementAt(0)[0].ToString();
                        break;
                    case 2:
                        textBox1.Text = conexion.command.ExecuteSentenceResponse(string.Format("SELECT CONCAT(Id_Equipo,' ',Id_Cpu) as ID from equipo where Id_Cpu='{0}'", comboBox1.SelectedItem.ToString())).ElementAt(0)[0].ToString();
                        break;
                    case 3:
                        textBox1.Text = conexion.command.ExecuteSentenceResponse(string.Format("SELECT CONCAT(Nombre_Depto,' ') as ID from departamento where Id_Depto={0}", comboBox1.SelectedItem.ToString())).ElementAt(0)[0].ToString();
                        break;
                    case 4:
                        textBox1.Text = conexion.command.ExecuteSentenceResponse(string.Format("SELECT CONCAT(Nombre,' ',Ap_Pat,' ',Ap_Mat) as ID from tecnico where Id_Tecnico={0}", comboBox1.SelectedItem.ToString())).ElementAt(0)[0].ToString();
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
            
            Hide();
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
                    conexion.command.ExecuteSentence(string.Format("DELETE from usuario WHERE Id_Usuario={0}", comboBox1.SelectedItem.ToString()));
                    break;
                case 2:
                    conexion.command.ExecuteSentence(string.Format("DELETE from equipo WHERE Id_Equipo={0}", comboBox1.SelectedItem.ToString()));
                    break;
                case 3:
                    conexion.command.ExecuteSentence(string.Format("DELETE from departamento WHERE Id_Depto={0}", comboBox1.SelectedItem.ToString()));
                    break;
                case 4:
                    conexion.command.ExecuteSentence(string.Format("DELETE from tecnico WHERE Id_Tecnico={0}", comboBox1.SelectedItem.ToString()));
                    break;
            }
        }
    }
}
