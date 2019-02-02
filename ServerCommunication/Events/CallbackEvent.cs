using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerUI.ServerCommunication.Events
{
    class CallbackEvent
    {
        public static void Callback_CallbackEvent(ServerLib.Events.Args.CallbackEventArgs args)
        {
            Handler.PrintInLog("Callback Handler", args.Message);
        }
    }
}
