using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Log
{
    public class DataBaseLogger : ILogger
    {
        private static SQLiteConnection sqliteConnection;
        public static void CreateDataBaseSQLite()
        {
            try
            {
               if(!File.Exists("log.sqlite"))
                SQLiteConnection.CreateFile(@"log.sqlite");
            }
            catch
            {
                throw;
            }
        }
        private static SQLiteConnection DbConnection()
        {
            sqliteConnection = new SQLiteConnection("Data Source=log.sqlite; Version=3;");
            sqliteConnection.Open();
            return sqliteConnection;
        }
        public static void CreateTableSQlite()
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS Logs(id INTEGER PRIMARY KEY AUTOINCREMENT, log Varchar(200), date varchar(20))";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Insert(string log)
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    var positionFinishDate = log.IndexOf(' ');
                    var date = log.Substring(0, positionFinishDate);
                    cmd.CommandText = "INSERT INTO Logs(log,date) values (@log,@date)";

                    cmd.Parameters.AddWithValue("@log", log.Substring(positionFinishDate + 1));
                    cmd.Parameters.AddWithValue("@date", log.Substring(0,positionFinishDate - 1));
                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        
        
       }

        public static void Selecionar()
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "select *  from Logs";

                    using (var reader = cmd.ExecuteReader())
                    {

                        // reader.GetString(1);

                        while (reader.Read())
                        {
                            Console.WriteLine(reader.GetInt32(0));
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void SelecionarTabela()
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "select *  from Logs";
                    DataTable dt = new DataTable();
                   var da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataBaseLogger()
        {
            CreateDataBaseSQLite();
            CreateTableSQlite();
            SelecionarTabela();
            
        }

        public void WriteLine(string content)
        {
          
            Insert(content);
        }
    }
}
