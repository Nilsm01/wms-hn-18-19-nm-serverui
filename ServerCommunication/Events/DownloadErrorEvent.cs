using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerUI.ServerCommunication.Events
{
	class DownloadErrorEvent
	{
		public static void DownloadError_DownloadErrorEvent(ServerLib.Events.Args.ErrorEventArgs args)
		{
			Handler.PrintInLog("Download Handler", "Fehler beim bereitstellen einer Datei: " + args.ErrorMessage);
		}
	}
}
