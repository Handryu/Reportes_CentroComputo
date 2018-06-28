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
    public partial class FEditarDepartamento : Form
    {
        DBConnect.GenericConnection conexion;
        string id;
        public FEditarDepartamento(DBConnect.GenericConnection con, string id)
        {
            InitializeComponent();
            conexion = con;
            this.id = id;
            prepareData(id);
        }

        private void FEditarDepartamento_Load(object sender, EventArgs e)
        {
            
        }

        private void prepareData(string id)
        {
            txtNombre.Text = conexion.command.ExecuteSentenceResponse(string.Format("SELECT Nombre_Depto FROM departamento WHERE Id_Depto = {0}", id)).ElementAt(0)[0].ToString();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            conexion.command.ExecuteSentence(string.Format("UPDATE departamento SET Nombre_Depto = '{0}' WHERE departamento.Id_Depto = {1}", txtNombre.Text, id));
        }
    }
}
