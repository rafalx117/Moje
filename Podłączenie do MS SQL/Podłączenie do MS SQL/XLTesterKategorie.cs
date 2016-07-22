using System;
using Podłączenie_do_MS_SQL;
using System.Data.SqlClient;

public class XLTesterKategorie
{
    private int Id;
    private string Nazwa;

    public XLTesterKategorie()
    {
        Id = 99;
        Nazwa = "Teścik";
    }
    
    public void insert()
    {
        MyConnectionToSQL tempConnection = new MyConnectionToSQL(); // tworzymy nowy obiekt i automatycznie podłączamy sie do bazy (podłączenie zawiera sie w konstruktorze)

         tempConnection.connection.Open();

        
            string saveStaff = "INSERT INTO [dbo].[XLTesterKategorie]([idKategorie],[nazwa]) VALUES (3, 'RM')";
            SqlCommand querySaveStaff = new SqlCommand(saveStaff, tempConnection.connection);
            querySaveStaff.Connection = tempConnection.connection;
        querySaveStaff.Parameters.Add("@id", "3");
        querySaveStaff.Parameters.Add("@nazwa", "RM");
        querySaveStaff.ExecuteNonQuery();
            // querySaveStaff.Parameters.Add("@staffName", SqlDbType.VarChar, 30).Value = name;

          

            tempConnection.connection.Close();
            }

    public void AnotherInsert()
    {
        using (SqlConnection openCon = new SqlConnection("Data Source=PC-RMAKSIM\\RAFALSQL;Initial Catalog=ERPXL_638;Persist Security Info=True;User ID=sa;Password=123456"))
        {
            string saveStaff = "INSERT INTO [dbo].[XLTesterKategorie]([idKategorie],[nazwa]) VALUES (55, 'Sprzedaż')";

            using (SqlCommand querySaveStaff = new SqlCommand(saveStaff))
            {
                querySaveStaff.Connection = openCon;  
         openCon.Open();

                openCon.Close();
            }
        }
    }

}


    



