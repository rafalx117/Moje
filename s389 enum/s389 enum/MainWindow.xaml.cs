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
using static s389_enum.EnumCard;

namespace s389_enum
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Card> ListaKart = new List<Card>();
        List<Card> cards = new List<Card>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            listView.Items.Clear();
            Random random = new Random();
            int numberBetween0And3 = random.Next(4);
            int numberBetween1And13 = random.Next(1, 14);
            int anyRandomInteger = random.Next();

            Card card = new Card((CardValue)numberBetween1And13, (CardColor)numberBetween0And3);

            cards = new List<Card>();

            for (int i = 0; i < 10; i++)
            {
                numberBetween0And3 = random.Next(4);
                numberBetween1And13 = random.Next(1, 14);
                anyRandomInteger = random.Next();
                card = new Card((CardValue)numberBetween1And13, (CardColor)numberBetween0And3);
                cards.Add(card);
                listView.Items.Add(card);
            }

        }
            //eloeessssssssssssss

        

        private void sort_Click(object sender, RoutedEventArgs e)
        {
            listView.Items.Clear();
            cards.Sort((x,y)=>x.Color.CompareTo(y.Color));
          
           
            foreach (var x in cards)
                listView.Items.Add(x);
                
        }
    }
  }

