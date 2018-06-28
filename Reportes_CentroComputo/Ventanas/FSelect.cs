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
        

        public FSelect(DBConnect.GenericConnection con, int tipo)
        {
            InitializeComponent();
            conexion = con;
            this.tipo = tipo;
            switch(tipo)
            {
                case 1:
                    conexion.functions.FillComboBox("SELECT Id_Folio from reporte", "Id_Folio", comboBox1);
                    break;
                case 2:
                    conexion.functions.FillComboBox("SELECT Id_Equipo from equipo", "Id_Equipo", comboBox1);
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
                    case 2:
                        textBox1.Text = conexion.command.ExecuteSentenceResponse(string.Format("SELECT CONCAT(Id_Equipo,' ',Id_Cpu) as ID from equipo where Id_Equipo={0}", comboBox1.SelectedItem.ToString())).ElementAt(0)[0].ToString();
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
                case 2:
                    new FEditarEquipo(conexion, comboBox1.SelectedItem.ToString()).Visible = true;
                    break;                
            }
            
            Hide();
        }

        private void FSelectReporte_Load(object sender, EventArgs e)
        {

        }
    }
}
