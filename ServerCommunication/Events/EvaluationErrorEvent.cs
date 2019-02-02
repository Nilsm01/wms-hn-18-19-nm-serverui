using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerUI.ServerCommunication.Events
{
    class EvaluationErrorEvent
    {
        public static void EvaluationError_EvaluationErrorEvent(ServerLib.Events.Args.ErrorEventArgs args)
        {
            Handler.PrintInLog("Paket Evaluation Handler", "Fehler bei Auswertung eines Datenpackets: " + args.ErrorMessage);
        }
    }
}
