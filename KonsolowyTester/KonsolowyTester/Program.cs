using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonsolowyTester
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Diagnostics.Process.Start("Calc.exe");
            Console.ReadKey();
        }
    }
}
