using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerUI.ServerCommunication.Events
{
    class ClientDisconnectedEvent
    {
        public static void ClientDisconnected_ClientDisconnectedEvent(ServerLib.Events.Args.ClientEventArgs args)
        {
            Handler.PrintInLog("Server", args.client.Username + " hat die Verbindung getrennt!");
            Handler.UpdateConnectedClientList();
        }
    }
}
