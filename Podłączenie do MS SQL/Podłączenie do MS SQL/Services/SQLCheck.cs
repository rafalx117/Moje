using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hydra;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Podłączenie_do_MS_SQL.Services
{
    /// <summary>
    /// Klasa modelu zawierająca pola: zapytanie warunkowe do wykonania oraz oczekiwaną wartość
    /// </summary>
    /// <remarks>Przenieść do namespace Model</remarks>
    public class SQLCheck
    {
        private string _queryForCheck;
        private string _expectedResult;

        public SQLCheck() { }

        public SQLCheck(string queryForCheck, string modelResultForCheckQuery)
        {
            this._queryForCheck = queryForCheck;
            this._expectedResult = modelResultForCheckQuery;
        }

        #region Properties

        public string QueryForCheck
        {
            get { return _queryForCheck; }
            set { _queryForCheck = value; }
        }

        public string ExpectedResult
        {
            get { return _expectedResult; }
            set { _expectedResult = value; }
        }

        #endregion
    }
}
