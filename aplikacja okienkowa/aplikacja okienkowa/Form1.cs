using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aplikacja_okienkowa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            var DataContext = new testowaEntities1();
            DataContext.
        }











        //DZIAŁA
        /*private void button1_Click(object sender, EventArgs e)
        {

            //DateTime date = DateTime.Now;
            //MessageBox.Show(date.ToString());
            //MessageBox.Show(date.ToShortDateString());
            //MessageBox.Show(date.ToShortTimeString());

            SqlConnection connection;
            SqlConnectionStringBuilder connectionStringBuilder;
            connectionStringBuilder = new SqlConnectionStringBuilder();
            connectionStringBuilder.DataSource = "PC-RMAKSIM\\RAFALSQL";
            connectionStringBuilder.InitialCatalog = "ERPXL_638";
            connectionStringBuilder.IntegratedSecurity = true;

            connection = new SqlConnection(connectionStringBuilder.ToString());
            connection.Open();


            string cmdTxt = "SELECT  MAX([idScenariusz])FROM XLTesterScenariusze; ";
            SqlCommand cmd = new SqlCommand(cmdTxt, connection);
            // int number = cmd.ExecuteNonQuery();

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    MessageBox.Show(reader.GetInt32(0).ToString());

                }

            }
            else
            {
                MessageBox.Show("Wygląda na to, że baza danych jest pusta!");
            }

        }*/


    }
}
