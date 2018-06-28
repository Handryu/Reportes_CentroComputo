using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Xml.Serialization;
using System.Xml;
using System.Windows.Forms;
using System.Drawing;

namespace Reportes_CentroComputo.Herramientas
{
    class ServiceFunctions
    {
        public bool DeleteTemporals()
        {
            foreach (var item in Directory.GetFileSystemEntries(Path.Combine(Environment.ExpandEnvironmentVariables(Path.Combine(Path.GetPathRoot(Environment.SystemDirectory), @"Users\hellw\AppData\Local\Temp")))))
            {
                Delete(Path.Combine(Environment.ExpandEnvironmentVariables(Path.Combine(Path.GetPathRoot(Environment.SystemDirectory),@"Users\hellw\AppData\Local\Temp")),item));
                //Console.WriteLine(Path.Combine(Environment.ExpandEnvironmentVariables(Path.Combine(Path.GetPathRoot(Environment.SystemDirectory), @"Users\hellw\AppData\Local\Temp")), item));
            }
            foreach (var item in Directory.GetFileSystemEntries(Path.Combine(Environment.ExpandEnvironmentVariables(Path.Combine(Path.GetPathRoot(Environment.SystemDirectory), @"Windows\Temp")))))
            {
                Delete(Path.Combine(Environment.ExpandEnvironmentVariables(Path.Combine(Path.GetPathRoot(Environment.SystemDirectory), @"Windows\Temp")), item));
                //Console.WriteLine(Path.Combine(Environment.ExpandEnvironmentVariables(Path.Combine(Path.GetPathRoot(Environment.SystemDirectory), @"Windows\Temp")), item));
            }
            return true;
        }

        private void Delete(string path)
        {
            FileAttributes attr = File.GetAttributes(path);

            //detect whether its a directory or file
            if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
            {
                
                try
                {
                    
                    Console.WriteLine("Borrando{0}", path);
                    Directory.Delete(path, true);
                }
                catch(Exception)
                {
                    goto Fin;
                }
            }
                
            else
            {
                try
                {
                    File.Delete(path);
                }
                catch (Exception)
                {
                    goto Fin;
                }
            }

            Fin:
            Console.WriteLine("No se puede borrar {0}",path);
        }

        public void ExecuteCMDCommand(string command)
        {
            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();

            cmd.StandardInput.WriteLine(command);
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
            Console.WriteLine(cmd.StandardOutput.ReadToEnd());
        }

        public void serializarXML<T>(List<T> lista, string path)
        {
            XmlSerializer fl = new XmlSerializer(typeof(List<T>));
            XmlTextWriter formater = new XmlTextWriter(path, Encoding.UTF8);
            formater.Formatting = Formatting.Indented;
            formater.Indentation = 1;
            formater.IndentChar = '\t';
            fl.Serialize(formater, lista);
            formater.Close();
        }

        public void serializarXML<T>(List<T> lista, string path, string name)
        {
            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            XmlSerializer fl = new XmlSerializer(typeof(List<T>));
            XmlTextWriter formater = new XmlTextWriter(Path.Combine(path,name), Encoding.UTF8);
            formater.Formatting = Formatting.Indented;
            formater.Indentation = 1;
            formater.IndentChar = '\t';
            fl.Serialize(formater, lista);
            formater.Close();
        }

        public List<T> deserializarXML<T>(string path,string name)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (File.Exists(Path.Combine(path, name)))
            {
                XmlSerializer fl = new XmlSerializer(typeof(List<T>));
                XmlTextReader reader = new XmlTextReader(Path.Combine(path,name));
                List<T> lista = fl.Deserialize(reader) as List<T>;
                reader.Close();
                return lista;
            }
            return null;
        }


        public Color HsvToRgb(double h, double s, double v)
        {
            int hi = (int)Math.Floor(h / 60.0) % 6;
            double f = (h / 60.0) - Math.Floor(h / 60.0);

            double p = v * (1.0 - s);
            double q = v * (1.0 - (f * s));
            double t = v * (1.0 - ((1.0 - f) * s));

            Color ret;

            switch (hi)
            {
                case 0:
                    ret = GetRgb(v, t, p);
                    break;
                case 1:
                    ret = GetRgb(q, v, p);
                    break;
                case 2:
                    ret = GetRgb(p, v, t);
                    break;
                case 3:
                    ret = GetRgb(p, q, v);
                    break;
                case 4:
                    ret = GetRgb(t, p, v);
                    break;
                case 5:
                    ret = GetRgb(v, p, q);
                    break;
                default:
                    ret = Color.FromArgb(0xFF, 0x00, 0x00, 0x00);
                    break;
            }
            return ret;
        }
        public Color GetRgb(double r, double g, double b)
        {
            return Color.FromArgb(255, (byte)(r * 255.0), (byte)(g * 255.0), (byte)(b * 255.0));
        }

        public void GenerateCSV(string name, List<Object> variables, List<Objeto> computadoras)
        {
            StringBuilder all = new StringBuilder();
            
            all.AppendLine(String.Format("{0},{1}", " ", createVars(variables.Distinct().ToList())));
            foreach(var c in computadoras)
            {
                StringBuilder builder = new StringBuilder();
                builder.Append(String.Format("{0},", c.Name));
                List<Object> temp = new List<Object>();
                foreach(var i in variables.Distinct().ToList())
                {
                    if(IsFinalVariable(c.Values,i))
                    {
                        temp.Add("Si");
                    }
                    else
                    {
                        temp.Add("No");
                    }
                }
                builder.Append(createVars(temp));
                all.AppendLine(builder.ToString());
                Console.WriteLine(builder.ToString());
            }
            File.WriteAllText(Application.StartupPath + "\\alg.csv", all.ToString());
        }

        public void WriteCSV(string path, string val)
        {
            using (var w = new StreamWriter(path))
            {
                w.WriteLine(val);
                w.Flush();
                w.Close();
            }
        }

        public bool IsFinalVariable(List<Object> lst, Object obj)
        {

            if (lst.Exists(x => x.Equals(obj)))
                return true;
            return false;

        }

        public string createVars(List<Object> v)
        {
            int val = 0;
            bool fi = true;
            StringBuilder b = new StringBuilder();

            foreach (var item in v)
            {
                if (fi)
                {
                    b.Append("{" + val + "}");
                    fi = false;
                }
                else
                {
                    b.Append(",{" + val + "}");
                }
                val++;
                Console.WriteLine(val);
            }
            //Console.WriteLine(string.Format(b.ToString(), v.ToArray<Object>()));
            return string.Format(b.ToString(), v.ToArray<Object>());
        }

    }
}
