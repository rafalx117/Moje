using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pieniężne_rozrachunki;

namespace pieniężne_rozrachunki
{
    class Customer
    {
        private static int Id = 1;

        public string Name;
        public decimal Payment;
        public decimal Difference; //różnica miedzy wpłatą a średnią na łepka
        public bool IsClear;

       
 

        public Customer(decimal money)
    {
        Name = Id.ToString();
        IsClear = false;      
        Payment = money;
          Difference =  CalculateDifference();
            Id++;
    }
        public Customer(decimal money, string name)
        {
            Name = name;
            IsClear = false;
            Payment = money;
            Difference = CalculateDifference();
        }

    public decimal CalculateDifference()
    {
        decimal temp = Math.Abs(Form1.Average - Payment);
            

        if (temp == 0)
            IsClear = true;
        else       
            IsClear = false;

            return temp;
    }

        public void Pay(Customer customer,decimal money)
        {
            customer.Get(money);
            Payment -= money;
            Difference = CalculateDifference();
            
        }

        public void Get(decimal money)
        {
            Payment += money;
            Difference = CalculateDifference();
             
        }

        public void PayFromXToY(Customer x, Customer y, decimal value)
        {
            x.Pay(y, value);
        }





    }

}
    

 
 
    

