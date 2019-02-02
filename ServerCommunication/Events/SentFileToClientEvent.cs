using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerUI.ServerCommunication.Events
{
	class SentFileToClientEvent
	{
		public static void SentFileToClient_SentFileToClientEvent(ServerLib.Events.Args.DataPackageEventArgs args)
		{
			Handler.PrintInLog("Download Handler", "Datei: " + args.dataPackage.Data + " an Client " + args.client.Username + " versendet!");
		}
	}
}
