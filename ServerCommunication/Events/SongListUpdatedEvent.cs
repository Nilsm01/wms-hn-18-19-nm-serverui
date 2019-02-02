using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerUI.ServerCommunication.Events
{
    class SongListUpdatedEvent
    {
        public static void SongListUpdated_SongListUpdatedEvent(EventArgs args)
        {
            Handler.PrintInLog("Server", "Die Songliste wurde aktualisiert!");
        }
    }
}
