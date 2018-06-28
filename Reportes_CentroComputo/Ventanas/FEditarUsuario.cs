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
    public partial class FEditarUsuario : Form
    {
        DBConnect.GenericConnection conexion;
        string id;
        public FEditarUsuario(DBConnect.GenericConnection con, string id)
        {
            InitializeComponent();
            this.id = id;
            conexion = con;
        }

        private void FEditarUsuario_Load(object sender, EventArgs e)
        {

        }

        public void createForm()
        {
            panel.Controls.Clear();
            List<string> partes = new List<string>();
            partes.Add("ID del Usuario");
            partes.Add("Nombre");
            partes.Add("Apellido Paterno");
            partes.Add("Apellido Materno");
            partes.Add("Departamento");
            partes.Add("Equipo");


            int x = ((panel.Width - 360) / 2);

            int y = 40;
            for (int i = 0; i < partes.Count; i++)
            {
                Label l = new Label();
                l.Text = partes.ElementAt(i);
                l.SetBounds(x, y, 150, 20);
                l.Font = new Font("Verdana", 12);
                l.BackColor = Color.Transparent;
                l.ForeColor = Color.White;

                int aumento = 20;



                if (i > 3)
                {
                    ComboBox t = new ComboBox();
                    t.SetBounds(x + 160, y, 200, aumento);
                    t.DropDownStyle = ComboBoxStyle.DropDown;
                    t.Font = new Font("Verdana", 10);

                    panel.Controls.Add(l);
                    panel.Controls.Add(t);

                }
                else
                {
                    TextBox t = new TextBox();
                    t.Multiline = true;
                    t.Font = new Font("Verdana", 10);
                    t.SetBounds(x + 160, y, 200, aumento);

                    
                    panel.Controls.Add(l);
                    panel.Controls.Add(t);
                }

                y += aumento + 10;

            }

            Button b = new Button();
            b.Text = "Guardar";
            b.BackColor = Color.White;
            b.FlatStyle = FlatStyle.Flat;
            b.SetBounds(panel.Width - 100, y + 5, 80, 25);
            b.Click += B_Click;
            panel.Controls.Add(b);
            prepareData();

        }

        private void B_Click(object sender, EventArgs e)
        {
            List<string> values = new List<string>();
            values.Add(((TextBox)panel.Controls[1]).Text);
            values.Add(((TextBox)panel.Controls[3]).Text);
            values.Add(((TextBox)panel.Controls[5]).Text);
            values.Add(((TextBox)panel.Controls[7]).Text);
            values.Add(((ComboBox)panel.Controls[9]).Text);
            values.Add(((ComboBox)panel.Controls[11]).Text);
            values.Add(((TextBox)panel.Controls[1]).Text);
            conexion.command.ExecuteSentence(string.Format("UPDATE usuario SET Id_Usuario = '{0}', Nombre = '{1}', Ap_Pat = '{2}', Ap_Mat = '{3}', Id_Depto = '{4}', Id_Equipo = '{5}' WHERE Id_Usuario = {6}", values.ToArray()));
            Dispose();
        }

        private void prepareData()
        {
            TextBox t = null;
            ComboBox c = null;
            try
            {
                t = (TextBox)panel.Controls[1];
                t.Text = id;
                t = (TextBox)panel.Controls[3];
                t.Text = conexion.command.ExecuteSentenceResponse(string.Format("SELECT Nombre from usuario where Id_Usuario='{0}'",id)).ElementAt(0)[0].ToString();
                t = (TextBox)panel.Controls[5];
                t.Text = conexion.command.ExecuteSentenceResponse(string.Format("SELECT Ap_Pat from usuario where Id_Usuario='{0}'", id)).ElementAt(0)[0].ToString();
                t = (TextBox)panel.Controls[7];
                t.Text = conexion.command.ExecuteSentenceResponse(string.Format("SELECT Ap_Mat from usuario where Id_Usuario='{0}'", id)).ElementAt(0)[0].ToString();
                c = (ComboBox)panel.Controls[9];
                conexion.functions.FillComboBox("SELECT Nombre_Depto from departamento", "Nombre_Depto", c);
                c.Text = conexion.command.ExecuteSentenceResponse(string.Format("SELECT Id_Depto from usuario where Id_Usuario='{0}'", id)).ElementAt(0)[0].ToString();
                c = (ComboBox)panel.Controls[11];
                conexion.functions.FillComboBox("SELECT Id_Equipo from equipo", "Id_Equipo", c);
                c.Text = conexion.command.ExecuteSentenceResponse(string.Format("SELECT Id_Equipo from usuario where Id_Usuario='{0}'", id)).ElementAt(0)[0].ToString();
            }
            catch (Exception)
            {
                t.Text = "1";
            }
        }
    }
}
