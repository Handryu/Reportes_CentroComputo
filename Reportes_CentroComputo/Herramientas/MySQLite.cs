using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DBConnect
{
    public class MySQLite 
    {
        public MySQLIiteConnector connector { get; }
        public MySQLIiteCommand command { get; }
        public Functions2 functions { get; }

        public MySQLite(string fname)
        {
            if (DBExist(fname))
            {
                Console.WriteLine("DB conected");
                connector = new MySQLIiteConnector(string.Format("{0}.sqlite", fname));
                command = new MySQLIiteCommand(connector.getConnection());
                functions = new Functions2(connector.getConnection(), command);
            }
            else
            {
                SQLiteConnection.CreateFile(string.Format("{0}.sqlite",fname));
                connector = new MySQLIiteConnector(string.Format("{0}.sqlite", fname));
                command = new MySQLIiteCommand(connector.getConnection());
                functions = new Functions2(connector.getConnection(), command);
            }
        }

        public bool DBExist(string fname)
        {
            FileInfo db = new FileInfo(fname);
            if (db.Exists)
                return true;
            return false;
        }
    }

    public class MySQLIiteConnector
    {
        static SQLiteConnection conexion;
        public MySQLIiteConnector(string database)
        {
            conexion = new SQLiteConnection(string.Format("Data Source={0}; Version=3;",database));
        }

        public bool checkConnection()
        {
            try
            {
                conexion.Open();
                return true;
            }
            catch (SQLiteException)
            {
                conexion.Close();
                return false;
            }
            catch(Exception)
            {
                return false;
            }
            finally
            {
                conexion.Close();
            }
        }

        public SQLiteConnection getConnection()
        {
            return conexion;
        }
    }

    public class MySQLIiteCommand
    {
        static SQLiteConnection conexion;
        public MySQLIiteCommand(SQLiteConnection con)
        {
            conexion = con;
        }

        public void ExecuteSentence(string sentencia)
        {
            //ExecuteSentenceBak(sentencia);
            SQLiteCommand cmd;
            cmd = conexion.CreateCommand();
            cmd.CommandText = sentencia;
            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();            
        }

        public void ExecuteSentenceBak(string sentencia)
        {
            SQLiteCommand cmd;
            cmd = conexion.CreateCommand();
            cmd.CommandText = string.Format("INSERT INTO consultas (Consulta) VALUES ('{0}');", sentencia);
            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public List<object[]> ExecuteSentenceResponse(string sentencia)
        {
            SQLiteCommand cmd;
            SQLiteDataReader consulta;

            int buffer;
            List<object[]> resultado = new List<object[]>();
            object[] resultados;
            try
            {
                cmd = conexion.CreateCommand();
                cmd.CommandText = sentencia;
                conexion.Open();
                consulta = cmd.ExecuteReader();
                //MessageBox.Show(consulta.FieldCount.ToString());
                buffer = consulta.FieldCount;
                resultados = new object[buffer];
                while (consulta.Read())
                {
                    resultados = new object[buffer];
                    int v = 0;
                    while (v < resultados.Length)
                    {
                        resultados[v] = consulta.GetString(v);
                        v++;
                    }
                    resultado.Add(resultados);
                }
                conexion.Close();
                //MessageBox.Show("Ejecucion finalizada");
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
                conexion.Close();
            }
            return resultado;
        }

        public int getQueryLength(string sentencia)
        {
            SQLiteCommand cmd;
            SQLiteDataReader consulta;

            int length = 0;
            try
            {
                cmd = conexion.CreateCommand();
                cmd.CommandText = sentencia;
                conexion.Open();
                consulta = cmd.ExecuteReader();
                //MessageBox.Show(consulta.FieldCount.ToString());
                length = consulta.FieldCount;
                conexion.Close();
                //MessageBox.Show("Ejecucion finalizada");
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
                conexion.Close();
            }
            return length;
        }
    }

    public class Functions2
    {
        static SQLiteConnection conexion;
        static MySQLIiteCommand command;
        public Functions2(SQLiteConnection con, MySQLIiteCommand com)
        {
            conexion = con;
            command = com;
        }
        public void FillTable(string sentencia, DataGridView table)
        {
            try
            {
                string act = sentencia;
                SQLiteDataAdapter datosAdapter;
                SQLiteCommandBuilder comandoSQL;
                SQLiteCommand cmd = conexion.CreateCommand();

                datosAdapter = new SQLiteDataAdapter(act, conexion);
                comandoSQL = new SQLiteCommandBuilder(datosAdapter);
                DataTable tabla = new DataTable();
                datosAdapter.Fill(tabla);

                table.DataSource = tabla;
            }
            catch (SQLiteException)
            {
                MessageBox.Show("No hay conexion o el servidor no esta andando");
            }
        }

        public DataTable FillTable(string sentencia)
        {
            try
            {
                string act = sentencia;
                SQLiteDataAdapter datosAdapter;
                SQLiteCommandBuilder comandoSQL;
                SQLiteCommand cmd = conexion.CreateCommand();

                datosAdapter = new SQLiteDataAdapter(act, conexion);
                comandoSQL = new SQLiteCommandBuilder(datosAdapter);
                DataTable data = new DataTable();
                datosAdapter.Fill(data);

                return data;
            }
            catch (SQLiteException)
            {
                return null;
            }
        }

        public void FillComboBox(string sentencia, string key, ComboBox cmb)
        {
            List<object[]> resultados = command.ExecuteSentenceResponse(sentencia);
            foreach (var item in resultados)
            {
                cmb.Items.Add(item.ElementAt(getIndexByKey(item, key)));
            }
        }

        private int getIndexByKey(object[] obj, string key)
        {
            int index = 0;
            foreach (var i in obj)
            {
                if (i.ToString().ToUpper().Equals(key.ToUpper(), StringComparison.Ordinal))
                    return index;
                else
                    index++;

            }
            return 0;
        }
        //Funciones predefinidas
        public void getDataBases(ComboBox cmb)
        {
            cmb.Items.Clear();
            List<object[]> databases = command.ExecuteSentenceResponse("show databases;");
            foreach (object[] database in databases)
            {
                cmb.Items.Add(database[0]);
            }

        }
    }
}
