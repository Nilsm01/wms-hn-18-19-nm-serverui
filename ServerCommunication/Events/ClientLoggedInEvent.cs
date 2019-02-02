using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerUI.ServerCommunication.Events
{
    class ClientLoggedInEvent
    {
        public static void ClientLoggedIn_ClientLoggedInEvent(ServerLib.Events.Args.ClientEventArgs args)
        {
            Handler.PrintInLog("Login Handler", args.client.Username + " hat sich erfolgreich eingeloggt!");
            Handler.UpdateConnectedClientList();
        }
    }
}
