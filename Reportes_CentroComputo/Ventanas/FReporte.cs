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
    public partial class FReporte : Form
    {
        
        DBConnect.GenericConnection conexion;
        public FReporte()
        {
            InitializeComponent();
            
            createForm();
        }

        public FReporte(DBConnect.GenericConnection con)
        {
            InitializeComponent();
            conexion = con;
            createForm();            
        }


        private void FReporte_Load(object sender, EventArgs e)
        {

        }

        public T Getconexion<T>(object obj)
        {
            if (conexion != null)
                return (T)Convert.ChangeType(obj, typeof(DBConnect.MySQL));
            return (T)Convert.ChangeType(obj, typeof(DBConnect.MySQLite));
        }

        public void createForm()
        {
            panel.Controls.Clear();
            List<string> partes = new List<string>();
            partes.Add("Folio");
            partes.Add("Tecnico");
            partes.Add("Usuario");
            partes.Add("ID del equipo");
            partes.Add("Falla");
            partes.Add("Componente dañado");
            partes.Add("Solución");
            partes.Add("Notas");
            

            int x = ((panel.Width - 360) / 2);

            int y = 20;
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
                    aumento = 100;
                else
                    aumento = 20;

                if (i>0 && i<3)
                {
                    ComboBox t = new ComboBox();
                    t.SetBounds(x + 160, y, 200, aumento);
                    t.DropDownStyle = ComboBoxStyle.DropDown;
                    t.Font = new Font("Verdana", 10);
                    Button n = new Button();
                    n.Text = "N";
                    n.SetBounds(x + 360, y-1, 20, aumento+6);
                    n.Font = new Font("Verdana", 8);
                    n.FlatStyle = FlatStyle.Flat;
                    n.Visible = false;
                    panel.Controls.Add(l);
                    panel.Controls.Add(t);
                    panel.Controls.Add(n);
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
                
                y += aumento+10;

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
            
            List<object> values = new List<object>();
            int index = 1;
            ((TextBox)panel.Controls[9]).Text = conexion.command.ExecuteSentenceResponse(string.Format("select Id_Equipo from usuario where Nombre='{0}' && Ap_Pat='{1}'", ((ComboBox)panel.Controls[6]).Text.Split(' '))).ElementAt(0)[0].ToString();
            foreach(var i in panel.Controls)
            {
                if (index >= panel.Controls.Count)
                    break;
                if (index == 3)
                {
                    values.Add(conexion.command.ExecuteSentenceResponse(string.Format("select Id_Tecnico from tecnico where Nombre='{0}'", panel.Controls[index].Text.Split(' ')[0])).ElementAt(0)[0].ToString());
                    index++;
                }
                else if (index == 6)
                {
                    values.Add(conexion.command.ExecuteSentenceResponse(string.Format("select Id_Usuario from usuario where Nombre='{0}'", panel.Controls[index].Text.Split(' ')[0])).ElementAt(0)[0].ToString());
                    index++;
                }
                else
                {
                    string val = panel.Controls[index].Text;
                    if (val.Length <= 0)
                        val = "NULL";
                    Console.WriteLine(val);
                    values.Add(val);
                }
                    
                index += 2;
            }
            
            conexion.command.ExecuteSentence(string.Format("INSERT INTO reporte (Id_Folio, ID_Tecnico, ID_Usuario, Id_Equipo, Falla, Componente_Dañado, Solucion, Notas) VALUES( {0},{1},{2},{3},\"{4}\",'{5}',\"{6}\",\"{7}\")", values.ToArray()));
            Dispose();
        }

        

        private void prepareData()
        {
            TextBox t=null;
            try
            {
                t = (TextBox)panel.Controls[1];
                t.Enabled = false;
                t.BackColor = Color.White;
                t = (TextBox)panel.Controls[9];
                t.Enabled = false;
                t.BackColor = Color.White;

                t = (TextBox)panel.Controls[1];
                t.Text = (int.Parse(conexion.command.ExecuteSentenceResponse("SELECT max(Id_Folio) FROM reporte").ElementAt(0)[0].ToString()) + 1).ToString();
                conexion.functions.FillComboBox("select Concat(Nombre,' ',Ap_Pat,' ',Ap_Mat) as NombreC from tecnico", "NombreC", (ComboBox)panel.Controls[3]);
                conexion.functions.FillComboBox("select Concat(Nombre,' ',Ap_Pat,' ',Ap_Mat) as NombreC from usuario", "NombreC", (ComboBox)panel.Controls[6]);
            }
            catch(Exception)
            {
                t.Text = "0";
            }
        }
    }
}
