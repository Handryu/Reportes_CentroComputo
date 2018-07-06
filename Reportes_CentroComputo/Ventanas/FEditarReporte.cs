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
    public partial class FEditarReporte : Form
    {
        DBConnect.GenericConnection conexion;
        public FEditarReporte()
        {
            InitializeComponent();
        }

        public FEditarReporte(DBConnect.GenericConnection con, string id)
        {
            InitializeComponent();
            conexion = con;
            createForm(id);
        }

        private void FEditarReporte_Load(object sender, EventArgs e)
        {

        }

        public void createForm(string id)
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

                if (i > 0 && i < 3)
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
            prepareData(id);

        }

        private void B_Click(object sender, EventArgs e)
        {
            List<object> values = new List<object>();
            int index = 3;
            
            foreach (var i in panel.Controls)
            {
                if (index >= panel.Controls.Count)
                    break;
                if (index == 3)
                {
                    values.Add(conexion.command.ExecuteSentenceResponse(string.Format("select Id_Tecnico from tecnico where Nombre='{0}' && Ap_Pat='{1}'", panel.Controls[index].Text.Split(' '))).ElementAt(0)[0].ToString());
                }
                else if (index == 5)
                {
                    values.Add(conexion.command.ExecuteSentenceResponse(string.Format("select Id_Usuario from usuario where Nombre='{0}' && Ap_Pat='{1}'", panel.Controls[index].Text.Split(' '))).ElementAt(0)[0].ToString());
                    
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
            string val2 = panel.Controls[1].Text;
            if (val2.Length <= 0)
                val2 = "NULL";
            Console.WriteLine(val2);
            values.Add(val2);
            conexion.command.ExecuteSentence(string.Format("UPDATE reporte SET ID_Tecnico = '{0}', ID_Usuario = '{1}', Id_Equipo = '{2}', Falla = '{3}', Componente_Dañado = '{4}', Solucion = '{5}', Notas = '{6}' WHERE reporte.Id_Folio = {7}", values.ToArray()));
            Dispose();
        }

        private void prepareData(string id)
        {
            TextBox t;
            t = (TextBox)panel.Controls[1];
            t.Enabled = false;
            t.BackColor = Color.White;
            t = (TextBox)panel.Controls[7];
            t.Enabled = false;
            t.BackColor = Color.White;

            t = (TextBox)panel.Controls[1];
            t.Text = id;
            conexion.functions.FillComboBox("select CONCAT(Nombre,' ',Ap_Pat,' ',Ap_Mat) as NombreC from tecnico", "NombreC", (ComboBox)panel.Controls[3]);
            ((ComboBox)panel.Controls[3]).Text = conexion.command.ExecuteSentenceResponse(string.Format("SELECT CONCAT(Nombre,' ',Ap_Pat,' ',Ap_Mat) as NombreC from tecnico WHERE Id_Tecnico = (SELECT Id_Tecnico from reporte WHERE Id_Folio={0})", id)).ElementAt(0)[0].ToString();
            conexion.functions.FillComboBox("select CONCAT(Nombre,' ',Ap_Pat,' ',Ap_Mat) as NombreC from usuario", "NombreC", (ComboBox)panel.Controls[5]);
            ((ComboBox)panel.Controls[5]).Text = conexion.command.ExecuteSentenceResponse(string.Format("SELECT CONCAT(Nombre,' ',Ap_Pat,' ',Ap_Mat) as NombreC from usuario WHERE Id_Usuario = (SELECT Id_Usuario from reporte WHERE Id_Folio={0})", id)).ElementAt(0)[0].ToString();
            t = (TextBox)panel.Controls[7];
            t.Text = conexion.command.ExecuteSentenceResponse(string.Format("SELECT Id_Equipo from reporte where Id_Folio={0}", id)).ElementAt(0)[0].ToString();
            t = (TextBox)panel.Controls[9];
            t.Text = conexion.command.ExecuteSentenceResponse(string.Format("SELECT Falla from reporte where Id_Folio={0}", id)).ElementAt(0)[0].ToString();
            t = (TextBox)panel.Controls[11];
            t.Text = conexion.command.ExecuteSentenceResponse(string.Format("SELECT Componente_Dañado from reporte where Id_Folio={0}", id)).ElementAt(0)[0].ToString();
            t = (TextBox)panel.Controls[13];
            t.Text = conexion.command.ExecuteSentenceResponse(string.Format("SELECT Solucion from reporte where Id_Folio={0}", id)).ElementAt(0)[0].ToString();
            t = (TextBox)panel.Controls[15];
            t.Text = conexion.command.ExecuteSentenceResponse(string.Format("SELECT Notas from reporte where Id_Folio={0}", id)).ElementAt(0)[0].ToString();
        }
    }
}
