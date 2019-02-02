using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerUI.ServerCommunication.Events
{
    class MetaDatenInformationEvent
    {
        public static void MetadataInformation_MetadataInformationEvent(ServerLib.Events.Args.ServerEventArgs args)
        {
            Handler.PrintInLog("MetaDataHandler", args.Message);
        }
    }
}
