using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerUI.ServerCommunication.Events
{
    class ConnectionErrorEvent
    {
        public static void ConnectionError_ConnectionErrorEvent(ServerLib.Events.Args.ErrorEventArgs args)
        {
            Handler.PrintInLog("Connection Handler", "Verbindungsfehler: " + args.ErrorMessage);
        }
    }
}
