using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerUI.ServerCommunication.Events
{
    class MaintenanceEvent
    {
        public static void Maintenance_MaintenanceEvent(ServerLib.Events.Args.ServerEventArgs args)
        {
            Handler.PrintInLog("Wartung", args.Message);
        }
    }
}
