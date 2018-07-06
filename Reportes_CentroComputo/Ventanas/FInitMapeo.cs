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
    public partial class FInitMapeo : Form
    {
        int x, y;
        FMapeo map;
        public FInitMapeo()
        {
            InitializeComponent();
            map = new FMapeo();
        }

        public FInitMapeo(int x, int y, FMapeo m)
        {
            InitializeComponent();
            this.x = x;
            this.y = y;
            map = m;
        }

        private void FInitMapeo_Load(object sender, EventArgs e)
        {
            for(int i=1;i<=100;i++)
            {
                cmbFilas.Items.Add(i);
                cmbCols.Items.Add(i);
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            x = int.Parse(cmbCols.SelectedItem.ToString());
            y = int.Parse(cmbFilas.SelectedItem.ToString());
            map.GenerateSalon(x, y);
            map.Visible = true;
            Dispose();
        }
    }
}
