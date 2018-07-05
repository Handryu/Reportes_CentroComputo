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
    public partial class FUsuario : Form
    {

        DBConnect.GenericConnection conexion;
        public FUsuario(DBConnect.GenericConnection con)
        {
            InitializeComponent();
            conexion = con;
            createForm();
        }

        

        public T Getconexion<T>(object obj)
        {
            if (obj.GetType().ToString().Equals("DBConnect.MySQL", StringComparison.Ordinal))
                return (T)Convert.ChangeType(obj, typeof(DBConnect.MySQL));
            return (T)Convert.ChangeType(obj, typeof(DBConnect.MySQLite));
        }

        private void FUsuario_Load(object sender, EventArgs e)
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
            Button n = new Button();

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

                    if(i==0)
                    {
                        
                        n.Text = "E";
                        
                        n.Font = new Font("Verdana", 8);
                        n.FlatStyle = FlatStyle.Flat;
                        n.Click += N_Click;
                        panel.Controls.Add(n);
                    }
                    panel.Controls.Add(l);
                    panel.Controls.Add(t);
                }

                y += aumento + 10;

            }
            n.SetBounds(x + 360, y - 29, 20, 22);
            
            Button b = new Button();
            b.Text = "Guardar";
            b.BackColor = Color.White;
            b.FlatStyle = FlatStyle.Flat;
            b.SetBounds(panel.Width - 100, y + 5, 80, 25);
            b.Click += B_Click;
            panel.Controls.Add(b);
            prepareData();

        }

        private void N_Click(object sender, EventArgs e)
        {
            ComboBox c = null;
            try
            {
                
                c = (ComboBox)panel.Controls[12];
                new FEquipo(conexion, c).Visible = true;
            }
            catch(Exception)
            {
                MessageBox.Show("Este usuario no tiene ninguna computadora asignada, primero registre su computadora");
                
                Dispose();
            }
        }

        private void prepareData()
        {
            TextBox t = null;
            try
            {
                t = (TextBox)panel.Controls[2];
                t.Text = (int.Parse(conexion.command.ExecuteSentenceResponse("SELECT MAX(Id_Usuario) from usuario").ElementAt(0)[0].ToString()) + 1).ToString();
                ComboBox c;
                c = (ComboBox)panel.Controls[10];
                conexion.functions.FillComboBox("SELECT Nombre_Depto from departamento", "Nombre_Depto", c);
                c = (ComboBox)panel.Controls[12];
                conexion.functions.FillComboBox("SELECT Id_Equipo from equipo", "Id_Equipo", c);
            }
            catch(Exception)
            {
                t.Text = "1";
            }
        }

        

        private void B_Click(object sender, EventArgs e)
        {
            List<string> values = new List<string>();
            values.Add(((TextBox)panel.Controls[2]).Text);
            values.Add(((TextBox)panel.Controls[4]).Text);
            values.Add(((TextBox)panel.Controls[6]).Text);
            values.Add(((TextBox)panel.Controls[8]).Text);
            values.Add(conexion.command.ExecuteSentenceResponse(string.Format("SELECT MAX(Id_Depto) from departamento where Nombre_Depto='{0}'",((ComboBox)panel.Controls[10]).Text)).ElementAt(0)[0].ToString());
            values.Add(((ComboBox)panel.Controls[12]).Text);
            
            conexion.command.ExecuteSentence(string.Format("INSERT INTO usuario (Id_Usuario, Nombre, Ap_Pat, Ap_Mat, Id_Depto, Id_Equipo, Activo) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '1')",values.ToArray()));
            Dispose();
        }
    }
}
