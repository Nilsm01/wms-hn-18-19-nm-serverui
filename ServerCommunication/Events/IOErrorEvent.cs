using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerUI.ServerCommunication.Events
{
    class IOErrorEvent
    {
        public static void IOError_IOErrorEvent(ServerLib.Events.Args.ErrorEventArgs args)
        {
            Handler.PrintInLog("I/O Handler", "I/O Fehler: " + args.ErrorMessage);
        }
    }
}
