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
            foreach (var item in Directory.GetFileSystemEntries(Path.Combine(Environment.ExpandEnvironmentVariables(Path.Combine(Path.GetPathRoot(Environment.SystemDirectory),Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData))))))
            {
                Delete(Path.Combine(Environment.ExpandEnvironmentVariables(Path.Combine(Path.GetPathRoot(Environment.SystemDirectory), Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData))),item));
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

        public void crearTablas(DBConnect.GenericConnection conexion)
        {
            conexion.command.ExecuteSentence("CREATE TABLE consultas ( Consulta TEXT NOT NULL );");
            conexion.command.ExecuteSentence("CREATE TABLE cpu (  Id_Cpu varchar(70) NOT NULL,  Num_Serie int(11) DEFAULT NULL,  Num_Inv varchar(25) DEFAULT NULL,  Marca varchar(30) DEFAULT NULL,  Modelo varchar(30) DEFAULT NULL,  Procesador varchar(30) DEFAULT NULL,  Mod_Ram varchar(30) DEFAULT NULL,  Gb_Ram int(11) DEFAULT NULL,  Mod_Dd varchar(30) DEFAULT NULL,  Gb_Dd int(11) DEFAULT NULL);");
            conexion.command.ExecuteSentence("CREATE TABLE departamento (  Id_Depto int(11) NOT NULL,  Nombre_Depto varchar(40) DEFAULT NULL);");
            conexion.command.ExecuteSentence("CREATE TABLE equipo (  Id_Equipo int(11) NOT NULL,  Id_Cpu varchar(70) DEFAULT NULL,  Id_Monitor int(11) DEFAULT NULL,  Id_Teclado int(11) DEFAULT NULL,  Id_Raton int(11) DEFAULT NULL,  Activo tinyint(1) NOT NULL DEFAULT '1',  Asignado tinyint(1) NOT NULL DEFAULT '1');");
            conexion.command.ExecuteSentence("CREATE TABLE historial (  Id_Historial int(11) NOT NULL,  Id_Usuario int(11) DEFAULT NULL,  Id_Equipo int(11) DEFAULT NULL,  Fecha datetime NOT NULL DEFAULT CURRENT_TIMESTAMP);");
            conexion.command.ExecuteSentence("CREATE TABLE monitor (  Id_Monitor int(11) NOT NULL,  Num_Serie int(11) DEFAULT NULL,  Num_Inv varchar(30) DEFAULT NULL);");
            conexion.command.ExecuteSentence("CREATE TABLE reporte (  Id_Folio int(11) NOT NULL,  ID_Tecnico int(11) DEFAULT NULL,  ID_Usuario int(11) DEFAULT NULL,  Id_Equipo int(11) DEFAULT NULL,  Falla varchar(50) DEFAULT NULL,  Componente_Dañado varchar(20) DEFAULT NULL,  Solucion varchar(50) DEFAULT NULL,  Notas varchar(20) DEFAULT NULL,  Fecha timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP);");
            conexion.command.ExecuteSentence("CREATE TABLE tecnico (  Id_Tecnico int(11) NOT NULL,  Nombre varchar(20) DEFAULT NULL,  Ap_Pat varchar(10) DEFAULT NULL,  Ap_Mat varchar(10) DEFAULT NULL);");
            conexion.command.ExecuteSentence("CREATE TABLE usuario (  Id_Usuario int(11) NOT NULL,  Nombre varchar(15) DEFAULT NULL,  Ap_Pat varchar(10) DEFAULT NULL,  Ap_Mat varchar(10) DEFAULT NULL,  Id_Depto int(11) DEFAULT NULL,  Id_Equipo int(11) DEFAULT NULL,  Activo tinyint(1) NOT NULL DEFAULT '1');");
            
        }

        public void sincronizarDBLocal(DBConnect.GenericConnection con)
        {
            
            DBConnect.GenericConnection conexion = new DBConnect.GenericConnection("DBInterna");
            crearTablas(conexion);
            foreach(var table in con.command.ExecuteSentenceResponse("SHOW TABLES"))
            {
                Console.WriteLine(table[0]);
                switch(table[0].ToString())
                {
                    case "cpu":
                        foreach(var res in con.command.ExecuteSentenceResponse("SELECT * from cpu"))
                        {
                            conexion.command.ExecuteSentence(string.Format("INSERT INTO cpu (Id_Cpu, Num_Serie, Num_Inv, Marca, Modelo, Procesador, Mod_Ram, Gb_Ram, Mod_Dd, Gb_Dd) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}')", res));
                        }
                        break;
                    case "departamento":
                        foreach(var res in con.command.ExecuteSentenceResponse("SELECT * from departamento"))
                        {
                            conexion.command.ExecuteSentence(string.Format("INSERT INTO departamento (Id_Depto, Nombre_Depto) VALUES ({0}, '{1}');", res));
                        }
                        break;
                    case "equipo":
                        foreach (var res in con.command.ExecuteSentenceResponse("SELECT * from equipo"))
                        {
                            conexion.command.ExecuteSentence(string.Format("INSERT INTO equipo (Id_Equipo, Id_Cpu, Id_Monitor, Id_Teclado, Id_Raton, Activo, Asignado) VALUES ({0}, '{1}', {2}, {3}, {4}, '1', '1')", res));
                        }
                        break;
                    case "historial":
                        Console.WriteLine("");
                        break;
                    case "monitor":
                        Console.WriteLine("");
                        break;
                    case "reporte":
                        foreach (var res in con.command.ExecuteSentenceResponse("SELECT * from reporte"))
                        {
                            conexion.command.ExecuteSentence(string.Format("INSERT INTO reporte (Id_Folio, ID_Tecnico, ID_Usuario, Id_Equipo, Falla, Componente_Dañado, Solucion, Notas) VALUES( {0},{1},{2},{3},'{4}','{5}','{6}','{7}')", res));
                        }
                        break;
                    case "tecnico":
                        foreach (var res in con.command.ExecuteSentenceResponse("SELECT * from tecnico"))
                        {
                            conexion.command.ExecuteSentence(string.Format("INSERT INTO tecnico (Id_Tecnico, Nombre, Ap_Pat, Ap_Mat) VALUES ({0}, '{1}', '{2}', '{3}')", res));
                        }
                        break;
                    case "usuario":
                        foreach (var res in con.command.ExecuteSentenceResponse("SELECT * from usuario"))
                        {
                            conexion.command.ExecuteSentence(string.Format("INSERT INTO usuario (Id_Usuario, Nombre, Ap_Pat, Ap_Mat, Id_Depto, Id_Equipo, Activo) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '1')", res));
                        }
                        break;
                }
            }
        }

        public void sincronizarDBCentral(DBConnect.GenericConnection con)
        {
            DBConnect.GenericConnection conexion = new DBConnect.GenericConnection(Microsoft.VisualBasic.Interaction.InputBox("Ingrese sus datos de acceso separados por coma\n\rusuario,contraseña,servidor,basede datos","Nueva sesion","Remote,CComputo,localhost,servicio").Trim().Split(','));
            //conexion.command.ExecuteSentence("INSERT INTO `test` (`id`, `val`) VALUES (NULL, 'mel');");
            foreach(var res in con.command.ExecuteSentenceResponse("SELECT * consultas"))
            {
                conexion.command.ExecuteSentence(res[0].ToString());
            }
        }
    }
}
