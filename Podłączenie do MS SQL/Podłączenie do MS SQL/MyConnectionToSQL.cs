using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace   Podłączenie_do_MS_SQL
{
 
    public class MyConnectionToSQL
    {
        public SqlConnection connection;
        private SqlConnectionStringBuilder connectionStringBuilder;

        void ConnectTo()
        { 
            connectionStringBuilder = new SqlConnectionStringBuilder();
            connectionStringBuilder.DataSource = "PC-RMAKSIM\\RAFALSQL";
            connectionStringBuilder.InitialCatalog = "ERPXL_638";
            connectionStringBuilder.IntegratedSecurity = true;

            connection = new SqlConnection(connectionStringBuilder.ToString());
            
        }

        public MyConnectionToSQL()
        {
            ConnectTo();
        }

        public List<string> showMe()
        {
            List<string> data = new List<string>();

            try
            {
                string text = "SELECT TOP 1000 [nazwa] FROM [ERPXL_638].[dbo].[XLTesterKategorie]";
                SqlCommand cmd = new SqlCommand(text, connection);
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    data.Add(reader["nazwa"].ToString());
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
