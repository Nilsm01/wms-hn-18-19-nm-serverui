using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerUI.ServerCommunication.Events
{
    class LoginFailedEvent
    {
        public static void LoginFailed_ClientLoginFailedEvent(ServerLib.Events.Args.ClientEventArgs args)
        {
            Handler.PrintInLog("Login Handler", "Login eines Clients fehlgeschlagen, verwendete Anmeldedaten: " + args.client.Username + ", " + args.client.Password);
        }
    }
}
