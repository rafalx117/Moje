using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hydra;
using System.Windows.Forms;

[assembly: CallbackAssemblyDescription("Automatyczne zamykanie okien błedu", "Zamknij automatycznie okno błędu",
"Comarch",
"1.0",
"2016.3.0",
"11-07-2016")]

namespace AutomatyczneZamykanieOkienkaBłędu
{
    [SubscribeProcedure((Procedures)Procedures.KntEdycja, "TestowyCallback")]

    public class AutomatyczneZamykanieOkienkaBłędu : Callback
    {
        public override void Cleanup()
        {

        }

        public override void Init()
        {
            MessageBox.Show("w");
            AddSubscription(true, 0, Events.Refresh, new TakeEventDelegate(checkPopUp));
            MessageBox.Show("wy");

        }

        public bool checkPopUp (Procedures ProcedureId, int ControlId, Events Event) // metoda sprawdzająca, czy wyskoczył pop up
        {
             
                MessageBox.Show("Hej");
                ClaWindow window = GetWindow();
                ClaWindow saveButton;

                foreach (ClaWindow i in window.AllChildren)
                {

                    if (i.TipRaw.Equals("Zapisz"))
                    {
                        MessageBox.Show("elo");
                    }

                }
 
            return true;




        }
    }
}
