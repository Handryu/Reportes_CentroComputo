using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reportes_CentroComputo
{
    public partial class FLimpieza : Form
    {
        public FLimpieza()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void background_DoWork(object sender, DoWorkEventArgs e)
        {
            List<string> rutas = new List<string>();
            string path;

            path = Path.Combine(Environment.ExpandEnvironmentVariables(Path.Combine(Path.GetPathRoot(Environment.SystemDirectory), String.Format(@"Users\{0}\AppData\Local\Temp",Environment.UserName))));
            foreach (var item in Directory.GetFileSystemEntries(path))
            {
                rutas.Add(Path.Combine(path,item));
            }
            path = Path.Combine(Environment.ExpandEnvironmentVariables(Path.Combine(Path.GetPathRoot(Environment.SystemDirectory), @"Windows\Temp")));
            foreach (var item in Directory.GetFileSystemEntries(path))
            {
                rutas.Add(Path.Combine(path, item));
            }

            pBar.Maximum = rutas.Count;

            foreach (var ruta in rutas)
            {
                Delete(ruta);
            }

            
        }
        private void Delete(string path)
        {
            FileAttributes attr = File.GetAttributes(path);

            //detect whether its a directory or file
            if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
            {

                try
                {
                    txtLog.AppendText(String.Format("Borrando{0}\n\r", path));
                    Console.WriteLine("Borrando{0}", path);
                    Directory.Delete(path, true);
                    pBar.Increment(1);
                }
                catch (Exception)
                {
                    goto Fin;
                }
            }

            else
            {
                try
                {
                    txtLog.AppendText(String.Format("Borrando{0}\n\r", path));
                    File.Delete(path);
                    pBar.Increment(1);
                }
                catch (Exception)
                {
                    goto Fin;
                }
            }

            Fin:
            pBar.Increment(1);
            txtLog.AppendText(String.Format("No se puede borrar {0}\n\r", path));
            Console.WriteLine("No se puede borrar {0}", path);
        }

        private void background_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pBar.Increment(1);
        }

        private void background_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Limpieza completada");
            Dispose();
        }

        public void Start()
        {
            Visible = true;
            background.RunWorkerAsync();
        }

        private void FLimpieza_Load(object sender, EventArgs e)
        {

        }
    }
}
