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
    public partial class FVariables : Form
    {
        
        List<Object> variables;
        public FVariables(List<Object> v)
        {
            InitializeComponent();
            variables = v;
        }

        public void Initialize(List<Object> lst)
        {
            lstVariables.Items.Clear();
            foreach(var item in lst.Distinct().ToList())
            {
                lstVariables.Items.Add(item);
            }
        }

        public void makeVisible()
        {
            Visible = true;
            Initialize(variables);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nuevo = Microsoft.VisualBasic.Interaction.InputBox("");
            if (nuevo != null && nuevo != "")
            {
                variables.Add(nuevo);
                Initialize(variables);
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (lstVariables.SelectedIndex >= 0 && lstVariables.SelectedIndex < lstVariables.Items.Count)
            {
                variables.RemoveAll(x => x.Equals(lstVariables.SelectedItem.ToString()));
                Initialize(variables);
            }
        }
    }
}
