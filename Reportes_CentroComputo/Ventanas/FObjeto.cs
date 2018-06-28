using MTControls.MTButtons;
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
    public partial class FObjeto : Form
    {
        Objeto obj;
        MTMultiGradiantButton b;
        List<Object> gV;
        public FObjeto(MTMultiGradiantButton btn, Objeto objeto, List<Object> gVar)
        {
            InitializeComponent();
            obj = objeto;
            b = btn;
            gV = gVar;
            Initialize(obj);
        }

        private void FObjeto_Load(object sender, EventArgs e)
        {

        }

        public void Initialize(Objeto objeto)
        {
            txtNombre.Text = objeto.Name;
            listCaracteristicas.Items.Clear();
            foreach(var item in objeto.Values)
            {
                listCaracteristicas.Items.Add(item);
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            obj.Name = txtNombre.Text;
            b.Text = txtNombre.Text;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nuevo = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el nombre de la variable a añadir\n\rnota:escriba getprogramas para obtener la lista de programas instalados","");
            if(nuevo != null && nuevo != "")
            {
                if(nuevo.ToLower().Equals("getprogramas",StringComparison.Ordinal))
                {
                    var programas = new Herramientas.GetHardware().getInstalledPrograms();
                    foreach(var item in programas)
                    {
                        obj.Values.Add(item);
                        gV.Add(item);
                    }
                    Initialize(obj);
                }
                else
                {
                    obj.Values.Add(nuevo);
                    gV.Add(nuevo);
                    Initialize(obj);
                }
                
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if(listCaracteristicas.SelectedIndex>=0 && listCaracteristicas.SelectedIndex<listCaracteristicas.Items.Count)
            {
                obj.Values.RemoveAt(listCaracteristicas.SelectedIndex);
                //gV.Remove(listCaracteristicas.SelectedItem.ToString());
                Initialize(obj);
            }
        }
    }
}
