using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
 
namespace Podłączenie_do_MS_SQL
{
    public partial class Form1 : Form
    {
        MyConnectionToSQL session;
        List<string> checkBoxData = new List<string> { "Akcje","Callback","Kategorie","Modul","Scenariusze","Typ Akcji","Typ Callback","Wykonanie Akcji" };


        public Form1()
        {
            
            InitializeComponent();
            whatToAddComboBox.DataSource = checkBoxData;


    }
        

        private void showButton_Click(object sender, EventArgs e)
        {
            MyConnectionToSQL conn = new MyConnectionToSQL();
            comboBox1.DataSource = conn.showMe();
        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            XLTesterKategorie firstCategory = new XLTesterKategorie();
            firstCategory.insert();
            firstCategory.AnotherInsert();
        }
    }
}
