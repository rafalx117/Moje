using Hydra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows;
using System.Diagnostics;
using Podłączenie_do_MS_SQL.Services;
using System.Runtime.InteropServices;

namespace Podłączenie_do_MS_SQL.Services
{
    public class DatabaseHelper
    {
        private const string CLASS_NAME = "TestManagerService";

        private SqlConnection connection;

        /// <summary>
        /// Konstruktor, inicjalizacja obiektu połączenie z bazą danych - connection
        /// </summary>
        public DatabaseHelper()
        {
            connection = Runtime.ActiveRuntime.Repository.Connection;
        }

        /// <summary>
        /// Metoda wykonująca zadane zapytanie bazodanowe i zwracająca wynik
        /// </summary>
        /// <param name="queryString">Zapytanie w formie łańcucha</param>
        /// <returns>Obiekt typu DataTable, będący wynikiem zapytania</returns>
        /// <remarks>Nie działa obsługa insertów, updetów, deletów</remarks>
        public DataTable executeQuery(string queryString)
        {
            SqlDataReader dataReader = null;
            DataTable dataTable = new DataTable();
            DataSet dataSet = new DataSet();

            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                SqlCommand command = new SqlCommand(queryString, connection);
                if (isNonQuerySelect(queryString))
                {
                    //todo: obsługa insertów, updetów, deletów; ta poniżej nie działa
                    short rowsAffected = Hydra.Runtime.ConfigurationDictionary.ExecSql(queryString, false); // wyrzuca błąd
                    string resultColumnName = "Wynik";
                    dataTable.Columns.Add(resultColumnName, typeof(String));
                    DataRow dr = dataTable.NewRow();
                    dr[resultColumnName] = String.Format("Zmienonych wierszy - {0}", rowsAffected);
                }
                else
                {
                    dataReader = command.ExecuteReader();
                    dataTable.Load(dataReader);
                }

            }
            catch (Exception e)
            {
                Trace.WriteLine(this.GetType().Name + ".executeQuery() - " + e.StackTrace);
                //TODO dodanie do loga informacji o błędzie
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }

            return dataTable;
        }

        /// <summary>
        /// Metoda sprawdzająca, czy podany łańcuch nie jest zapytaniem typu SELECT
        /// </summary>
        /// <param name="queryString">Zapytanie do sprawdzenia</param>
        /// <returns>Wartość logiczna true (zapytanie bez SELECT) / false (zapytanie typu SELECT)</returns>
        private bool isNonQuerySelect(string queryString)
        {
            string queryStringUpper = queryString.ToUpper();

            return (queryStringUpper.Contains("INSERT")
                || queryStringUpper.Contains("UPDATE")
                || queryStringUpper.Contains("DELETE"));
        }

        /// <summary>
        /// Metoda wykonująca zadane zapytanie bazodanowe, którego wynik powinien być skalarem
        /// </summary>
        /// <param name="sqlQuery"></param>
        /// <returns>Skalar będący wynikiem zapytania</returns>
        public string getScalarFromDB(string sqlQuery)
        {
            object result = null;
            try
            {

                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = sqlQuery;
                result = cmd.ExecuteScalar();
            }

            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(this.GetType().Name + ".getScalarFromDB() - " + ex.StackTrace);
            }
            if (result == null)
            {
                throw new Exception(this.GetType().Name + ".getScalarFromDB() - zapytanie zwróciło null");
            }
            return result.ToString();
        }

        /// <summary>
        /// Metoda konwertująca obiekt typu DataTable w obiekt typu string
        /// </summary>
        /// <param name="dataTable">Obiekt do konwersji</param>
        /// <returns>Obiekt po konwersji</returns>
        public string convertDataTableToString(DataTable dataTable)
        {
            string output = "";

            foreach (DataColumn column in dataTable.Columns)
            {
                output += column.ColumnName;
                output += "; ";
            }
            output += "\n";

            foreach (DataRow dr in dataTable.Rows)
            {
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    output += dr[i].ToString() + "; ";
                }
                output += "\n";
            }

            return output;
        }

        /// <summary>
        /// Metoda sprawdzająca, czy dla listy zapytań ich wyniki zgadzają się z oczekiwanymi
        /// </summary>
        /// <param name="sqlCheckList">Lista obiektów typu <see cref="SQLCheck"/></param>
        /// <returns>Wartość logiczna true (przeszedł testy) / false (nie przeszedł testów)</returns>
        public bool isSqlCheckListPassedTests(List<SQLCheck> sqlCheckList)
        {
            foreach (var sqlCheck in sqlCheckList)
            {
                if (!isQueryResultEqualToExpectedValue(sqlCheck))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Metoda wykonująca zapytanie warunkowe, porównująca wynik zapytania z wartością oczekiwaną
        /// todo: zamienić obiekt zwracany bool, na obiekt posiadający pola wynik (bool) oraz message (string) w przypadku wystąpienia błędu
        /// </summary>
        /// <param name="sqlCheck">Obiekt wejściowy, zwierający dane do przetowrzenia i porównania</param>
        /// <returns>Wartość logiczna true (przeszedł testy) / false (nie przeszedł testów)</returns>
        public bool isQueryResultEqualToExpectedValue(SQLCheck sqlCheck)
        {
            string queryForCheck = sqlCheck.QueryForCheck;
            string expectedResult = sqlCheck.ExpectedResult;

            //sprawdzenie czy zapytanie oraz wartość oczekiwana jest niepusta
            if (queryForCheck != null && queryForCheck.Length > 0
                && expectedResult != null && expectedResult.Length > 0)
            {

                System.Diagnostics.Trace.WriteLine(String.Format("{0}.isQueryResultEqualToExpectedValue() queryForCheck: {1}, expectedResult: {2}", CLASS_NAME, queryForCheck, expectedResult));
                DataTable resultOfQuery = executeQuery(queryForCheck);

                if (resultOfQuery.Columns.Count == 1)
                {
                    return CheckValue(expectedResult, resultOfQuery);
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true; // w sytuacji gdy istnieje obiekt SQLCheck lecz jest pusty
            }
        }

        /// <summary>
        /// Metoda porównująca wartość oczekiwaną zapytania z wynikiem zapytania
        /// </summary>
        /// <param name="expectedResult">Wartość oczekiwana zapytania</param>
        /// <param name="resultOfQuery">Wynik zapytania</param>
        /// <returns>Wartość logiczna true (równy) / false (różny)</returns>
        private bool CheckValue(string expectedResult, DataTable resultOfQuery)
        {
            string columnName;
            dynamic value;
            Type fieldType;

            try
            {
                columnName = resultOfQuery.Columns[0].ColumnName;
                value = resultOfQuery.Rows[0][0];
                fieldType = resultOfQuery.Columns[0].DataType;
            }
            catch (Exception e)
            {
                System.Diagnostics.Trace.WriteLine(String.Format("{0}.CheckValue() ERROR: {1}", CLASS_NAME, e.StackTrace));
                return false;
            }

            System.Diagnostics.Trace.WriteLine(String.Format("{0}.CheckValue() fieldName: {1}", CLASS_NAME, columnName));



            if (expectedResult.ToLower().Equals("none"))
            {
                System.Diagnostics.Trace.WriteLine(String.Format("{0}.CheckValue(): Brak wartości do porównania", CLASS_NAME));
                return false;
            }
            else
            {
                try
                {
                    dynamic expectedResultObject = Convert.ChangeType(expectedResult, fieldType);
                    if (expectedResultObject == value)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception e)
                {
                    System.Diagnostics.Trace.WriteLine(String.Format("{0}.CheckValue() StackTrace: {1}", CLASS_NAME, e.StackTrace));
                    return false;
                }
            }
        }
    }
}
