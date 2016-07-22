using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pieniężne_rozrachunki
{
    public partial class Form1 : Form
    {
        public static decimal Average = -1;
        List<Customer> CustomerList = new List<Customer>();
        List<Form> windowsList = new List<Form>();


        public Form1()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            if(NumberOfPeopleTextBox.Text!=null && ReceiptTextBox.Text!=null)
            {
                if(int.Parse(NumberOfPeopleTextBox.Text) != 0)
                {
                    try
                    {
                        Average = decimal.Parse(ReceiptTextBox.Text) / decimal.Parse(NumberOfPeopleTextBox.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Coś poszło nie tak. " + ex.Message);
                        return;                         
                    }

                    int index = 0;
                    Form addCustomersForm = new Form();
                    addCustomersForm.Text = "Dodaj osobę";

                    TextBox customerName = new TextBox();
                    TextBox customerPayment = new TextBox();
                    Label name = new Label();
                    name.Text = "Imię";
                    Label payment = new Label();
                    payment.Text = "wpłata";
                    Button addPersonButton = new Button();
                    addPersonButton.Text = "Zapisz";

                    addPersonButton.Click += new EventHandler(delegate (Object o, EventArgs a)
                   {
                       try
                       {
                           Customer tempCust = new Customer(decimal.Parse(customerPayment.Text), customerName.Text);
                           CustomerList.Add(tempCust);
                           windowsList[index].Close();
                           if(index<windowsList.Count-1)
                           windowsList[index + 1].Close();

                           
                       }
                       catch (FormatException ex)
                       {
                           customerPayment.Text = "Błędna wartsość!";
                           
                       }
                     
                       
                   });

                    FlowLayoutPanel panel = new FlowLayoutPanel();
                    

                    panel.Controls.Add(name);
                    panel.Controls.Add(customerName);
                    panel.Controls.Add(payment);
                    panel.Controls.Add(customerPayment);
                    panel.Controls.Add(addPersonButton);


                    addCustomersForm.Controls.Add(panel);
         

                   
                    

                    for(int i = 0; i < int.Parse(NumberOfPeopleTextBox.Text); i++ )
                    {
                        Form temp = new Form();
                        temp.Controls.Add(panel);
                        windowsList.Add(temp);
                 
                    }
                    windowsList[0].Show();
                  
          

                        int unclearPeople = CustomerList.Count-1;

                    while(unclearPeople>0)
                    {
                        CustomerList = CustomerList.OrderBy(o => o.Payment).ToList(); //sortowanie listy

                        int i = 0;
                        Customer last = CustomerList.Last();
                        Customer current = CustomerList.ElementAt(i);

                        while (!last.IsClear)
                        {
                            current = CustomerList.ElementAt(i);

                            if(current.Difference != 0)
                            {

                                if (last.Difference > current.Difference )
                                {
                                    
                                    MessageBox.Show(current.Name + " placi " + current.Difference + " dla " + last.Name);
                                    last.Pay(current, current.Difference);
                                    current.IsClear = true;
                                    i++;
                                    unclearPeople--;
                                }
                                else
                                {
                                    MessageBox.Show(current.Name + " placi " + last.Difference + " dla " + last.Name);
                                    last.Pay(current, last.Difference);
                                    last.IsClear = true;
                                    unclearPeople--;
                                }

                            }

                        }


                    }

                    
                    





                }//koniec drugiego ifa
                else
                {
                    MessageBox.Show("Dzielisz przez 0!");
                    return;
                }



            } //koniec pierwszego ifa 
            else
            {
                MessageBox.Show("Wprowadź dane!");
            }
        }
    }
}
