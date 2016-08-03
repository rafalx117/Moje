using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace zabawa_z_rzutowaniem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public interface IJdedz
    {
         void jedz();
    }

    public class Samochod : Pojazd, IJdedz
    {
        int silnik;
        string model;

        public void jedz()
        {
            MessageBox.Show(model + " " + silnik + " jedzie " + masa);
        }

        public Samochod(string m, int s, int kg)
        {
            silnik = s;
            model = m;
            masa = kg;
        }
    }

    public class Motocykl: Pojazd, IJdedz
    {
        string marka;
        int silnik;

        public void jedz()
        {
            MessageBox.Show(marka + " " + silnik + " jedzie " + masa);
        }

        public Motocykl(string m, int s, int kg)
        {
            marka = m;
            silnik = s;
            masa = kg;
        }
    }

    public class Pojazd: IJdedz
    {
        public int masa;

        public void jedz()
        {
            MessageBox.Show(masa.ToString());
        }
    }


    public partial class MainWindow : Window
    {
        Pojazd[] Pojazdy = new Pojazd[2];
        

        public MainWindow()
        {
            InitializeComponent();
            Pojazdy[0] = new Samochod("BMW", 1800, 1450);
            Pojazdy[1] = new Motocykl("Yamaha", 125, 123);
            
        }

        private void RodzicButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void DzieckoButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void RzutujWDolBtn_Click(object sender, RoutedEventArgs e)
        {
            Samochod temp = Pojazdy[0] as Samochod;
            temp.jedz();
        }

        private void RzutujWGoreBtn_Click(object sender, RoutedEventArgs e)
        {
            Pojazdy[0].jedz();
        }
    }
}
