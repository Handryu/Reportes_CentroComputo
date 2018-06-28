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
    public partial class FInit : Form
    {
        public FInit()
        {
            InitializeComponent();
        }

        private void btnMySQL_Click(object sender, EventArgs e)
        {
            new FLogin().Visible = true;
            Hide();
        }

        private void btnLocal_Click(object sender, EventArgs e)
        {
            new FInicial().Visible = true;
            Hide();
        }
    }
}
