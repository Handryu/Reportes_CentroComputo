using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBConnect
{
    public class GenericConnection
    {

        private MySQL conexionSQL;
        private MySQLite conexionSQLite;
        public Connector connector { get; }
        public Command command { get; }
        public Functions3 functions { get; }

        public GenericConnection(string user, string pass, string server, string database)
        {
            conexionSQL = new MySQL(user, pass, server, database);
            connector = new Connector(conexionSQL);
            command = new Command(conexionSQL);
            functions = new Functions3(conexionSQL);
        }

        public GenericConnection(string[]access)
        {
            conexionSQL = new MySQL(access[0], access[1], access[2], access[3]);
            connector = new Connector(conexionSQL);
            command = new Command(conexionSQL);
            functions = new Functions3(conexionSQL);
        }

        public GenericConnection(string database)
        {
            conexionSQLite = new MySQLite(database);
            connector = new Connector(conexionSQLite);
            command = new Command(conexionSQLite);
            functions = new Functions3(conexionSQLite);
        }

        public class Connector
        {
            private MySQL conexionSQL;
            private MySQLite conexionSQLite;
            public Connector(MySQL con)
            {
                conexionSQL = con;
            }

            public Connector(MySQLite con)
            {
                conexionSQLite = con;
            }
            public bool checkConnection()
            {
                if(conexionSQL!=null)
                {
                    try
                    {
                        return conexionSQL.connector.checkConnection();
                    }
                    catch(Exception)
                    {
                        return false;
                    }
                }
                else
                {
                    try
                    {
                        return conexionSQLite.connector.checkConnection();
                    }
                    catch(Exception)
                    {
                        return false;
                    }
                }
            }
        }

        public class Command
        {
            private MySQL conexionSQL;
            private MySQLite conexionSQLite;
            public Command(MySQL con)
            {
                conexionSQL = con;
            }

            public Command(MySQLite con)
            {
                conexionSQLite = con;
            }

            public void ExecuteSentence(string sentencia)
            {
                if(conexionSQL != null)
                {
                    conexionSQL.command.ExecuteSentence(sentencia);
                }
                else
                {
                    conexionSQLite.command.ExecuteSentence(sentencia);
                }
            }

            public List<object[]> ExecuteSentenceResponse(string sentencia)
            {
                if(conexionSQL != null)
                {
                    return conexionSQL.command.ExecuteSentenceResponse(sentencia);
                }
                else
                {
                    return conexionSQLite.command.ExecuteSentenceResponse(sentencia);
                }
            }

            public int getQueryLength(string sentencia)
            {
                if(conexionSQL != null)
                {
                    return conexionSQL.command.getQueryLength(sentencia);
                }
                else
                {
                    return conexionSQLite.command.getQueryLength(sentencia);
                }
            }
        }

        public class Functions3
        {
            private MySQL conexionSQL;
            private MySQLite conexionSQLite;
            public Functions3(MySQL con)
            {
                conexionSQL = con;
            }

            public Functions3(MySQLite con)
            {
                conexionSQLite = con;
            }

            public void FillTable(string sentencia, DataGridView table)
            {
                if(conexionSQL != null)
                {
                    conexionSQL.functions.FillTable(sentencia, table);
                }
                else
                {
                    conexionSQLite.functions.FillTable(sentencia, table);
                }
            }

            public DataTable FillTable(string sentencia)
            {
                if (conexionSQL != null)
                {
                    return conexionSQL.functions.FillTable(sentencia);
                }
                else
                {
                    return conexionSQLite.functions.FillTable(sentencia);
                }
            }

            public void FillComboBox(string sentencia, string key, ComboBox cmb)
            {
                if (conexionSQL != null)
                {
                    conexionSQL.functions.FillComboBox(sentencia, key, cmb);
                }
                else
                {
                    conexionSQLite.functions.FillComboBox(sentencia, key, cmb);
                }
            }

            public void getDataBases(ComboBox cmb)
            {
                if (conexionSQL != null)
                {
                    conexionSQL.functions.getDataBases(cmb);
                }
                else
                {
                    conexionSQLite.functions.getDataBases(cmb);
                }
            }
        }
    }
}
