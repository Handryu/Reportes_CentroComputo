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
    public partial class FEditarTecnico : Form
    {
        DBConnect.GenericConnection conexion;
        string id;
        public FEditarTecnico(DBConnect.GenericConnection con, string id)
        {
            InitializeComponent();
            conexion = con;
            this.id = id;
            prepareData();
        }

        private void FEditarTecnico_Load(object sender, EventArgs e)
        {

        }

        private void prepareData()
        {
            textBox1.Text = conexion.command.ExecuteSentenceResponse(string.Format("SELECT Nombre from tecnico where Id_Tecnico={0}",id)).ElementAt(0)[0].ToString();
            textBox2.Text = conexion.command.ExecuteSentenceResponse(string.Format("SELECT Ap_Pat from tecnico where Id_Tecnico={0}", id)).ElementAt(0)[0].ToString();
            textBox3.Text = conexion.command.ExecuteSentenceResponse(string.Format("SELECT Ap_Mat from tecnico where Id_Tecnico={0}", id)).ElementAt(0)[0].ToString();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length < 0)
                textBox1.Text = ".";
            if (textBox2.Text.Length < 0)
                textBox2.Text = ".";
            if (textBox3.Text.Length < 0)
                textBox3.Text = ".";
            conexion.command.ExecuteSentence(string.Format("UPDATE tecnico SET Nombre = '{0}', Ap_Pat = '{1}', Ap_Mat = '{2}' WHERE tecnico.Id_Tecnico = {3}", textBox1.Text, textBox2.Text, textBox3.Text, textBox1.Text));
        }
    }
}
