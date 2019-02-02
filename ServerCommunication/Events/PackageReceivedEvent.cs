using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerUI.ServerCommunication.Events
{
    class PackageReceivedEvent
    {
        public static void PackageReceived_ClientPackageReceived(ServerLib.Events.Args.ClientEventArgs args)
        {
            Handler.PrintInLog("Package Handler", "Es wurde ein Datenpacket von " + args.client.Username + " empfangen");
        }
    }
}
