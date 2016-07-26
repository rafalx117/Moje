using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace s_317_pszczółki
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Queen queen;

        public MainWindow()
        {
            InitializeComponent();
            DataObject.AddPastingHandler(numericTextBox, NumericTextBoxPasting); //stackoverflow, dodajemy handler obsługi zdarzenia wklejania do textboxa
            workerBeeJobComboBox.SelectedIndex = 0;

            Worker[] workers = new Worker[4];
            workers[0] = new Worker(new string[] { "Zbieranie nektaru", "Wytwarzanie miodu" });
            workers[1] = new Worker(new string[] { "Pielęgnacja jaj", "Nauczanie pszczółek" });
            workers[2] = new Worker(new string[] { "Utrzymywanie ula, Patrol z żądłami" });
            workers[3] = new Worker(new string[] { "Zbieranie nektaru", "Wytwarzanie miodu", "Pielęgnacja jaj","Nauczanie pszczółek","Utrzymywanie ula", "Patrol z żądłami" });

             queen = new Queen(workers);


        }

        private void numericUpBtn_Click(object sender, RoutedEventArgs e)
        {
            numericTextBox.Text = (int.Parse(numericTextBox.Text) + 1).ToString();
        }

        private void cumericDownBtn_Click(object sender, RoutedEventArgs e)
        {
            numericTextBox.Text = (int.Parse(numericTextBox.Text) - 1).ToString();
        }

        private void numericTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private static bool IsTextAllowed(string text) //stack, zapobiega wprowadzaniu tekstu do textBoxa
        {
            Regex regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text
            return !regex.IsMatch(text);
        }

        private void NumericTextBoxPasting(object sender, DataObjectPastingEventArgs e) //stack, zapobiega wklejaniu tekstu do textBoxa
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                String text = (String)e.DataObject.GetData(typeof(String));
                if (!IsTextAllowed(text))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }

        private void nextShiftBtn_Click(object sender, RoutedEventArgs e)
        {
            reportTextBox.Text = queen.WorkNextShift();
        }

        private void assignJobBtn_Click(object sender, RoutedEventArgs e)
        {
            queen.AssignWork(workerBeeJobComboBox.Text, int.Parse(numericTextBox.Text));
            
        }

     
    }
}
