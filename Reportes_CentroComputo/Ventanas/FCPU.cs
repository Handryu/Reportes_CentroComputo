using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using DBConnect;


namespace Reportes_CentroComputo
{
    public partial class FCPU : Form
    {

        TextBox t;
        DBConnect.GenericConnection conexion;
        public FCPU(DBConnect.GenericConnection con, TextBox te)
        {
            InitializeComponent();
            t = te;
            conexion = con;
            createForm();
            fillData();
        }

        private void FCPU_Load(object sender, EventArgs e)
        {

        }

        public void createForm()
        {
            panel.Controls.Clear();
            List<string> partes = new List<string>();
            partes.Add("ID Unico");
            partes.Add("Numero de serie");
            partes.Add("Numero de inventario");
            partes.Add("Marca");
            partes.Add("Modelo");
            partes.Add("Procesador");
            partes.Add("Tipo de RAM");
            partes.Add("Tamaño de RAM");
            partes.Add("Tipo de disco duro");
            partes.Add("Tamaño de disco duro");

            int x = ((panel.Width - 400) / 2);

            int y = 20;
            for (int i = 0; i < partes.Count; i++)
            {
                Label l = new Label();
                l.Text = partes.ElementAt(i);
                l.Font = new Font("Verdana", 12);
                l.SetBounds(x, y, 185, 20);
                l.BackColor = Color.Transparent;
                l.ForeColor = Color.White;
                

                TextBox t = new TextBox();
                t.Font = new Font("Verdana", 12);
                t.SetBounds(x + 200, y, 200, 20);                

                panel.Controls.Add(l);
                panel.Controls.Add(t);
                y += 30;

            }
            Button b = new Button();
            b.Text = "Guardar";
            b.BackColor = Color.White;
            b.FlatStyle = FlatStyle.Flat;
            b.SetBounds(panel.Width - 100, y + 5, 80, 25);
            b.Click += B_Click;
            panel.Controls.Add(b);
        }

        private void B_Click(object sender, EventArgs e)
        {
            List<string> values = new List<string>();
            values.Add(((TextBox)panel.Controls[1]).Text);
            values.Add(((TextBox)panel.Controls[3]).Text);
            values.Add(((TextBox)panel.Controls[5]).Text);
            values.Add(((TextBox)panel.Controls[7]).Text);
            values.Add(((TextBox)panel.Controls[9]).Text);
            values.Add(((TextBox)panel.Controls[11]).Text);
            values.Add(((TextBox)panel.Controls[13]).Text);
            values.Add(((TextBox)panel.Controls[15]).Text);
            values.Add(((TextBox)panel.Controls[17]).Text);
            values.Add(((TextBox)panel.Controls[19]).Text);
            if (conexion.command.ExecuteSentenceResponse(string.Format("SELECT count(*) FROM cpu WHERE Id_Cpu='{0}'", ((TextBox)panel.Controls[1]).Text)).ElementAt(0)[0].Equals("0"))
            {
                conexion.command.ExecuteSentence(string.Format("INSERT INTO cpu (Id_Cpu, Num_Serie, Num_Inv, Marca, Modelo, Procesador, Mod_Ram, Gb_Ram, Mod_Dd, Gb_Dd) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}')", values.ToArray()));
            }
            else
            {
                values.Add(((TextBox)panel.Controls[1]).Text);
                conexion.command.ExecuteSentence(string.Format("UPDATE cpu SET Id_Cpu = '{0}', Num_Serie = '{1}', Num_Inv = '{2}', Marca = '{3}', Modelo = '{4}', Procesador = '{5}', Mod_Ram = '{6}', Gb_Ram = '{7}', Mod_Dd = '{8}', Gb_Dd = '{9}' WHERE Id_Cpu = '{10}'", values.ToArray()));
            }
            Dispose();
        }

        public void fillData()
        {
            TextBox t;
           
            t = (TextBox)panel.Controls[1];
            t.Text = new Herramientas.GetHardware().SearchInfo("Win32_ComputerSystemProduct", "UUID");
            this.t.Text = t.Text;
            t = (TextBox)panel.Controls[3];
            t.Text = new Herramientas.GetHardware().SearchInfo("Win32_BIOS", "SerialNumber");
            t = (TextBox)panel.Controls[7];
            t.Text = new Herramientas.GetHardware().SearchInfo("Win32_BaseBoard", "Manufacturer");
            t = (TextBox)panel.Controls[9];
            t.Text = new Herramientas.GetHardware().SearchInfo("Win32_BaseBoard", "Product");
            t = (TextBox)panel.Controls[11];
            t.Text = new Herramientas.GetHardware().SearchInfo("Win32_Processor", "Name");
            t = (TextBox)panel.Controls[13];
            t.Text = GetMemoryType(new Herramientas.GetHardware().SearchInfo("Win32_PhysicalMemory", "MemoryType"));
            t = (TextBox)panel.Controls[15];
            t.Text = ((Int32.Parse(new Herramientas.GetHardware().SearchInfo("Win32_SMBIOSMemory", "EndingAddress"))/1024)/1000).ToString()+" GB";
            t = (TextBox)panel.Controls[17];
            t.Text = new Herramientas.GetHardware().SearchInfo("Win32_DiskDrive", "Model");
            t = (TextBox)panel.Controls[19];
            t.Text = GetMemorySize(new Herramientas.GetHardware().SearchInfo("Win32_ComputerSystem", "TotalPhysicalMemory"));


        }

        public string GetMemoryType(string MemoryType)
        {
            switch (MemoryType)
            {
                case "20":
                    return "DDR";

                case "21":
                    return "DDR2";

                default:
                    if (MemoryType == "0" || MemoryType == "24")
                        return "DDR3 o DDR4";
                    else
                        return "Other";


            }
        }

        public string GetMemorySize(string size)
        {
            double fixedsize = double.Parse(size);
            if(size.Length>10)
            {
                return String.Format("{0}", (fixedsize / (Math.Pow(10, size.Length-1))).ToString().Split('.')[0] + " TB");
            }
            else
            {
                return String.Format("{0}", (fixedsize / (Math.Pow(10, size.Length-3))).ToString().Split('.')[0] + " GB");
            }
            
        }
    }
}
