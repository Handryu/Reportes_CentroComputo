using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBConnect
{
    public class MySQL 
    {
        public MySQLConnector connector { get; }
        public MySQLCommand command { get; }
        public Functions functions { get; }
        public MySQL(string user, string pass, string server, string database)
        {
            connector = new MySQLConnector(user, pass, server, database);
            command = new MySQLCommand(connector.getConnection());
            functions = new Functions(connector.getConnection(),command);
        }

        
    }

    public class MySQLConnector
    {
        public MySqlConnectionStringBuilder builder { get; }
        static MySqlConnection conexion;
        
        public MySQLConnector(string user, string pass, string server)
        {
            builder = new MySqlConnectionStringBuilder();
            builder.Server = server;
            builder.UserID = user;
            builder.Password = pass;

            conexion = new MySqlConnection(builder.ToString());

        }

        public MySQLConnector(string user, string pass, string server, string database)
        {
            builder = new MySqlConnectionStringBuilder();
            builder.Server = server;
            builder.UserID = user;
            builder.Password = pass;
            builder.Database = database;


            conexion = new MySqlConnection(builder.ToString());

        }

        public bool checkConnection()
        {
            try
            {
                conexion.Open();
                return true;
            }
            catch(MySqlException)
            {
                conexion.Close();
                return false;
            }
            finally
            {
                conexion.Close();
            }
        }

        public MySqlConnection getConnection()
        {
            return conexion;
        }
    }



    public class MySQLCommand 
    {
        static MySqlConnection conexion;

        public MySQLCommand(MySqlConnection con)
        {
            conexion = con;
        }

        public void ExecuteSentence(string sentencia)
        {
            Console.WriteLine(sentencia);
            MySqlCommand cmd;
            cmd = conexion.CreateCommand();
            cmd.CommandText = sentencia;
            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();
            //MessageBox.Show("Ejecucion finalizada");
        }

        public List<object[]> ExecuteSentenceResponse(string sentencia)
        {
            MySqlCommand cmd;
            MySqlDataReader consulta;
            Console.WriteLine(sentencia);
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
            MySqlCommand cmd;
            MySqlDataReader consulta;

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

    public class Functions
    {
        static MySqlConnection conexion;
        static MySQLCommand command;
        public Functions(MySqlConnection con, MySQLCommand com)
        {
            conexion = con;
            command = com;
        }
        public void FillTable(string sentencia, DataGridView table)
        {
            try
            {
                string act = sentencia;
                MySqlDataAdapter datosAdapter;
                MySqlCommandBuilder comandoSQL;
                MySqlCommand cmd = conexion.CreateCommand();

                datosAdapter = new MySqlDataAdapter(act, conexion);
                comandoSQL = new MySqlCommandBuilder(datosAdapter);
                DataTable tabla = new DataTable();
                datosAdapter.Fill(tabla);

                table.DataSource = tabla;
            }
            catch (MySqlException)
            {
                MessageBox.Show("No hay conexion o el servidor no esta andando");
            }
        }

        public DataTable FillTable(string sentencia)
        {
            try
            {
                string act = sentencia;
                MySqlDataAdapter datosAdapter;
                MySqlCommandBuilder comandoSQL;
                MySqlCommand cmd = conexion.CreateCommand();

                datosAdapter = new MySqlDataAdapter(act, conexion);
                comandoSQL = new MySqlCommandBuilder(datosAdapter);
                DataTable data = new DataTable();
                datosAdapter.Fill(data);

                return data;
            }
            catch (MySqlException)
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
