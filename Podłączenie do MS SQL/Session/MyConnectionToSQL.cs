using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Podłączenie_do_MS_SQL
{
    public class MyConnectionToSQL
    {
        SqlConnection connection;
        SqlConnectionStringBuilder connectionStringBuilder;

        void ConnectTo()
        { 
            connectionStringBuilder = new SqlConnectionStringBuilder();
            connectionStringBuilder.DataSource = "PC-RMAKSIM\\RAFALSQL";
            connectionStringBuilder.InitialCatalog = "ERPXL_638";
            connectionStringBuilder.IntegratedSecurity = true;

            connection = new SqlConnection(connectionStringBuilder.ToString());

            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
            
        }

        public MyConnectionToSQL()
        {
            ConnectTo();
        }

        /// <summary>
        /// metoda wybiera z bazy danych przykładowe dane
        /// </summary>
        /// <returns></returns>

        public List<string> showMe() 
        {
            List<string> data = new List<string>();

            try
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                    connection.Open();

                string text = "SELECT * FROM dbo.XLTesterAkcje";
                SqlCommand cmd = new SqlCommand(text, connection);      
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    data.Add(reader["opis"].ToString());
                }
                 
                
                return data;
            }
            catch (Exception)
            {

                MessageBox.Show("BŁĄD");
                return null;
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }

        public void insert()
        {

        }

        public void update()
        {

        }

    }
}
