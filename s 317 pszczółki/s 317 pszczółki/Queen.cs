using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace s_317_pszczółki
{
    class Queen
    {
        private Worker[] workers;
        private int shiftNumber = 1;

        public Queen(Worker[] tab)
        {
            workers = tab;
        }

        public bool AssignWork(string job, int shifts)
        {
            bool success = false;
            bool jobAssigned = false;
            foreach(Worker bee in workers)
            {
               if(!jobAssigned)
               if( bee.DoThisJob(job, shifts))
                success = jobAssigned = true;
            }

            return success;
        }
        /// <summary>
        /// metoda zwracająca raport 
        /// </summary>
        /// <returns></returns>
        public string WorkNextShift()
        {
            string report = "Raport zmiany nr "+shiftNumber+" \n";
            int i = 1;    

            foreach (var bee in workers)
            {
                report += "Pszczoła nr " + i;

                if (string.IsNullOrEmpty(bee.CurrentJob))
                    report += " nie pracuje \n";
                else if(bee.ShiftsLeft>1)
                    report += " robi " + bee.CurrentJob + " jezcze przez " + bee.ShiftsLeft + "\n";
                else if (bee.ShiftsLeft == 1)
                    report += " zakończy " + bee.CurrentJob + " po tej zmianie \n";
                else
                    report += " nie pracuje \n";

                bee.WorkOneShift();
                i++;
            }

            shiftNumber++;

            return report;
        }

        public void GetInfo()
        {
            foreach (var bee in workers)
                bee.info();
        }

    }
}
