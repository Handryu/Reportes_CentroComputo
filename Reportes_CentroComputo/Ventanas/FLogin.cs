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
    public partial class FLogin : Form
    {
        public FLogin()
        {
            InitializeComponent();
        }

        private void FLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            new FInicial(txtUser.Text, txtPass.Text, txtServer.Text, txtDatabase.Text).Visible = true;
            Hide();
        }

        private void timerLogin_Tick(object sender, EventArgs e)
        {
            if(txtUser.Text.Length > 0 && txtPass.Text.Length > 0)
            {
                btnLogin.Enabled = true;
                txtUser.BackColor = Color.White;
                txtPass.BackColor = Color.White;
            }
            else
            {
                txtUser.BackColor = Color.Red;
                txtPass.BackColor = Color.Red;
                btnLogin.Enabled = false;
            }
        }

        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtUser.Text.Length > 0 && txtPass.Text.Length > 0)
                {
                    btnLogin.Focus();
                }
            }
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (txtUser.Text.Length > 0 && txtPass.Text.Length > 0)
                {
                    btnLogin.Focus();
                }
            }
        }
    }
}
