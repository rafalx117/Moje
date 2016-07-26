using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace s_317_pszczółki
{
    class Worker
    {
        public string CurrentJob { get; set; }
        public int ShiftsLeft { get { return shiftsToWork - shiftsWorked; }  }
        
        private string [] jobsIcanDo;
        private int shiftsToWork;
        private int shiftsWorked;

        public Worker(string [] tab)
        {
            jobsIcanDo = tab;
        }

        internal bool DoThisJob(string job, int shifts)
        {
             if(string.IsNullOrEmpty(CurrentJob))
            {
                foreach(string jb in jobsIcanDo)
                {
                    if(jb==job)
                    {
                        CurrentJob = job;
                        Console.WriteLine(CurrentJob);
                        shiftsToWork = shifts;
                        return true;
                    }
                }

                return false;
            }
             else
            {
                return false;
            }
        }

        public void WorkOneShift()
        {
            if (ShiftsLeft > 0)
                shiftsWorked++;
            else
            {
                shiftsWorked = 0;
                CurrentJob = null;
            }
        }

        public void info()
        {
            MessageBox.Show(CurrentJob + " " + ShiftsLeft);
        }
    }
}


