using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace Reportes_CentroComputo
{
    public partial class LOG : Form
    {
        public LOG()
        {
            InitializeComponent();
            box.BackColor = Color.Black;
            box.Font = new Font("Verdana", 12,FontStyle.Regular);
            AppendText("liena 1", Color.AliceBlue);
            AppendText("liena 2dm<jsgvn<dsjnvgjzsfdkcf<sjdnfajzds", Color.Crimson);
            AppendText("linea we", Color.DarkCyan);
        }

        private void LOG_Load(object sender, EventArgs e)
        {

        }

        

        public void AppendText(string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text+"\n");
            box.SelectionColor = box.ForeColor;
        }
    }
}
