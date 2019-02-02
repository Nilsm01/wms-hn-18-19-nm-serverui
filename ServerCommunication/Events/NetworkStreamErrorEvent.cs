using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerUI.ServerCommunication.Events
{
    class NetworkStreamErrorEvent
    {
        public static void NetworkStreamError_NetworkStreamErrorEvent(ServerLib.Events.Args.ErrorEventArgs args)
        {
            Handler.PrintInLog("Networkstream Handler", "NetworkStream Fehler: " + args.ErrorMessage);
        }
    }
}
