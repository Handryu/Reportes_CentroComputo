using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MTControls;
using MTControls.MTButtons;

namespace Reportes_CentroComputo
{
    public partial class FMapeo : Form
    {
        
        public List<Objeto> computadoras;
        static List<Object> variables;
        int x, y;
        FVariables vars;
        public FMapeo()
        {
            InitializeComponent();
            computadoras = new List<Objeto>();
            variables = new List<Object>();
            vars = new FVariables(variables);
            //GenerateSalon(10, 4);
        }

        public FMapeo(int x, int y)
        {
            InitializeComponent();
            computadoras = new List<Objeto>();
            variables = new List<Object>();
            vars = new FVariables(variables);
            GenerateSalon(x, y);
        }

            private void FMapeo_Load(object sender, EventArgs e)
        {

        }

        public void GenerateSalon(int x, int y)
        {
            this.x = x;
            this.y = y;
            panel.Controls.Clear();
            Size tamaño = new Size(panel.Width / x, panel.Height / y);
            int indice = 1;
            for (int i=0;i<y;i++)
            {
                for(int j=0;j<x;j++)
                {

                    MTMultiGradiantButton b = new MTMultiGradiantButton();
                    b.SetBounds(j * tamaño.Width, i * tamaño.Height, tamaño.Width, tamaño.Height);
                    double p = 360.0 / (double)100;

                    for (int n = 9000; n < 9200; n++)
                    {
                        b.Colors.Add(new Herramientas.ServiceFunctions().HsvToRgb( (n * n) * p, 1.0, 1.0));
                    }
                    b.Text = indice.ToString();
                    b.Tag = indice.ToString();
                    b.Click += B_Click;
                    
                    computadoras.Add(new Objeto() { indice=indice, Values=new List<Object>()});

                    indice++;
                    panel.Controls.Add(b);
                }
            }

            //new Herramientas.ServiceFunctions().DeleteTemporals();
            new Herramientas.ServiceFunctions().serializarXML<Objeto>(computadoras, Application.StartupPath + "\\prueba.xml");
        }

        public void GenerateSalon(int x, int y, List<Objeto> c)
        {
            this.x = x;
            this.y = y;
            panel.Controls.Clear();
            Size tamaño = new Size(panel.Width / x, panel.Height / y);
            int indice = 1;
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {

                    MTMultiGradiantButton b = new MTMultiGradiantButton();
                    b.SetBounds(j * tamaño.Width, i * tamaño.Height, tamaño.Width, tamaño.Height);
                    double p = 360.0 / (double)100;

                    for (int n = 9000; n < 9200; n++)
                    {
                        b.Colors.Add(new Herramientas.ServiceFunctions().HsvToRgb((n * n) * p, 1.0, 1.0));
                    }
                    b.Text = c.ElementAt(indice-1).Name;
                    b.Tag = indice.ToString();
                    b.Click += B_Click;

                    indice++;
                    panel.Controls.Add(b);
                }
            }

            //new Herramientas.ServiceFunctions().DeleteTemporals();
            new Herramientas.ServiceFunctions().serializarXML<Objeto>(computadoras, Application.StartupPath + "\\prueba.xml");
        }

        private void B_Click(object sender, EventArgs e)
        {
            MTMultiGradiantButton button = (MTMultiGradiantButton)sender;
            new FObjeto(button, getObj(int.Parse(button.Tag.ToString())-1),variables).Visible = true;
        }

        

        public Objeto getObj(int index)
        {
            return computadoras.ElementAt(index);
        }

        


        private void Variables_Click(object sender, EventArgs e)
        {
            vars.makeVisible();
        }

        private void gCSV_Click(object sender, EventArgs e)
        {
            Console.WriteLine(new Herramientas.ServiceFunctions().createVars(variables));
            Console.WriteLine("Listo");
            new Herramientas.ServiceFunctions().GenerateCSV("", variables, computadoras);
        }

        private void gMapa_Click(object sender, EventArgs e)
        {
            if (panel.Controls.Count > 0)
            {
                List<Mapa> mapa = new List<Reportes_CentroComputo.Mapa>();
                mapa.Add(new Mapa() { X = x, Y = y, objetos = computadoras, variables = variables });
                new Herramientas.ServiceFunctions().serializarXML<Mapa>(mapa, Path.Combine(Application.StartupPath, "Saves"), Microsoft.VisualBasic.Interaction.InputBox("Nombre del archivo") + ".mapa");
            }
            else
            {
                MessageBox.Show("No hay nada que guardar");
            }
        }

        private void Cerrar_Click(object sender, EventArgs e)
        {

            vars.Close();
            computadoras.Clear();
            variables.Clear();
            Dispose();
        }

        private void Nuevo_Click(object sender, EventArgs e)
        {
            new FInitMapeo(x, y,this).Visible = true;
            
        }

        private void cMapa_Click(object sender, EventArgs e)
        {
            List<Mapa> mapa = new Herramientas.ServiceFunctions().deserializarXML<Mapa>(Path.Combine(Application.StartupPath, "Saves"), Microsoft.VisualBasic.Interaction.InputBox("Nombre del archivo") + ".mapa");
            if(mapa != null)
            {
                computadoras = mapa.ElementAt(0).objetos;
                variables = mapa.ElementAt(0).variables;
                GenerateSalon(mapa.ElementAt(0).X, mapa.ElementAt(0).Y, computadoras);
            }
            else
            {
                MessageBox.Show("No existe el archivo solicitado");
            }
        }
    }

    public class Mapa
    {
        public int X { get; set; }
        public int Y { get; set; }
        public List<Objeto> objetos { get; set; }
        public List<Object> variables { get; set; }
    }

    public class Objeto
    {

        public int indice { get; set; }
        public string Name { get; set; }
        public List<Object> Values { get; set; }

    }
}
