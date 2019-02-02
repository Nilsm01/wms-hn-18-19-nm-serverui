using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerUI.ServerCommunication.Events
{
    class ServerStartedEvent
    {
        public static void ServerStarted_ServerStartedEvent(EventArgs args)
        {
            Handler.PrintInLog("Server", "Server gestartet!");
            Resources.Status_Label.Invoke(new MethodInvoker(delegate () { Resources.Status_Label.Text = "Online"; }));
            Resources.Status_Label.ForeColor = Color.Green;
            Resources.ServerOnline = true;
            Resources.StartButton.Invoke(new MethodInvoker(delegate () { Resources.StartButton.Text = "Server stoppen"; }));
        }        
    }
}
