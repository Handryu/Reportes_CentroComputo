using Microsoft.Win32;
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
    public partial class FProgramas : Form
    {
        string registry_key = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";

        public FProgramas()
        {
            InitializeComponent();
            loadInstalledPrograms();
        }

        private void FProgramas_Load(object sender, EventArgs e)
        {

        }

        public IEnumerable<string> GetInstalledProgramsFromRegistry(RegistryView registryView)
        {
            var result = new List<string>();

            using (RegistryKey key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, registryView).OpenSubKey(registry_key))
            {
                foreach (string subkey_name in key.GetSubKeyNames())
                {
                    using (RegistryKey subkey = key.OpenSubKey(subkey_name))
                    {
                        if (IsProgramVisible(subkey))
                        {
                            result.Add((string)subkey.GetValue("DisplayName"));
                        }
                    }
                }
            }

            return result;
        }

        private void loadInstalledPrograms()
        {
            var result = new List<string>();
            result.AddRange(GetInstalledProgramsFromRegistry(RegistryView.Registry32));
            result.AddRange(GetInstalledProgramsFromRegistry(RegistryView.Registry64));
            List<Programa> programas = new List<Programa>();
            int index = 1;
            foreach (var item in result)
            {
                programas.Add(new Programa() { index = index, name = item });
                index++;
            }
            List<Programa> noduplicate = programas.Distinct(new ItemEqualityComparer()).ToList();
            foreach(var item in noduplicate)
            {
                dataGridView1.Rows.Add(item.getData());
            }
            
            dataGridView1.Columns[0].Width = dataGridView1.Rows[dataGridView1.Rows.Count-1].Cells[0].Value.ToString().Length*10;
            dataGridView1.Columns[1].Width = dataGridView1.Width - (dataGridView1.Columns[0].Width + 60);
        }

        public bool IsProgramVisible(RegistryKey subkey)
        {
            var name = (string)subkey.GetValue("DisplayName");
            var releaseType = (string)subkey.GetValue("ReleaseType");
            //var unistallString = (string)subkey.GetValue("UninstallString");
            var systemComponent = subkey.GetValue("SystemComponent");
            var parentName = (string)subkey.GetValue("ParentDisplayName");
            Console.WriteLine("{0},{1},{2},{3}", name, releaseType, systemComponent, parentName);
            return
                !string.IsNullOrEmpty(name)
                && string.IsNullOrEmpty(releaseType)
                && string.IsNullOrEmpty(parentName)
                && (systemComponent == null || (int)systemComponent == 0);
        }
    }

    public class Programa
    {
        public int index;
        public string name;

        public string[] getData()
        {
            string[] items = { index.ToString(), name };

            return items;
        }
    }

    public class ItemEqualityComparer : IEqualityComparer<Programa>
    {
        

        public bool Equals(Programa x, Programa y)
        {
            return x.name == y.name;
        }


        public int GetHashCode(Programa obj)
        {
            return obj.name.GetHashCode();
        }
    }
}
