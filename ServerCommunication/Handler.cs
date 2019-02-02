using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServerLib;

namespace ServerUI.ServerCommunication
{
    class Handler
    {
        public static void InitializeEvents()
        {
            ServerLib.Events.ClientEvents.ClientDisconnected.ClientDisconnectedEvent += Events.ClientDisconnectedEvent.ClientDisconnected_ClientDisconnectedEvent;
            ServerLib.Events.ClientEvents.ClientLoggedIn.ClientLoggedInEvent += Events.ClientLoggedInEvent.ClientLoggedIn_ClientLoggedInEvent;
            ServerLib.Events.ClientEvents.LoginFailed.ClientLoginFailedEvent += Events.LoginFailedEvent.LoginFailed_ClientLoginFailedEvent;
            ServerLib.Events.ClientEvents.PackageReceived.ClientPackageReceived += Events.PackageReceivedEvent.PackageReceived_ClientPackageReceived;

            ServerLib.Events.ServerEvents.ServerStarted.ServerStartedEvent += Events.ServerStartedEvent.ServerStarted_ServerStartedEvent;
            ServerLib.Events.ServerEvents.SongListUpdated.SongListUpdatedEvent += Events.SongListUpdatedEvent.SongListUpdated_SongListUpdatedEvent;
            ServerLib.Events.ServerEvents.MetaFileInformation.MetaFileInformationEvent += Events.MetaDatenInformationEvent.MetadataInformation_MetadataInformationEvent;

			ServerLib.Events.DataPackageEvent.SentFileToClient.SentFileToClientEvent += Events.SentFileToClientEvent.SentFileToClient_SentFileToClientEvent;
            ServerLib.Events.DataPackageEvent.Callback.CallbackEvent += Events.CallbackEvent.Callback_CallbackEvent;

            ServerLib.Events.ErrorEvents.ConnectionError.ConnectionErrorEvent += Events.ConnectionErrorEvent.ConnectionError_ConnectionErrorEvent;
            ServerLib.Events.ErrorEvents.EvaluationError.EvaluationErrorEvent += Events.EvaluationErrorEvent.EvaluationError_EvaluationErrorEvent;
            ServerLib.Events.ErrorEvents.IOError.IOErrorEvent += Events.IOErrorEvent.IOError_IOErrorEvent;
			ServerLib.Events.ErrorEvents.NetworkStreamError.NetworkStreamErrorEvent += Events.NetworkStreamErrorEvent.NetworkStreamError_NetworkStreamErrorEvent;
			ServerLib.Events.ErrorEvents.DownloadError.DownloadErrorEvent += Events.DownloadErrorEvent.DownloadError_DownloadErrorEvent;
            ServerLib.Events.ServerEvents.Maintenance.MaintenanceEvent += Events.MaintenanceEvent.Maintenance_MaintenanceEvent;
        }

		public static void StartServer(bool Dynamic)
        {
            ServerLib.Connection.ResourceProvider.SetMaintenanceMode(Resources.MaintenanceSwitch.Checked);
            ServerLib.ServerHandle.StartServer(Dynamic);
        }

        public static void StopServer()
        {

        }

        public static void PrintInLog(string sender, string message)
        {
            Resources.Log.Invoke(new MethodInvoker(delegate () { Resources.Log.AppendText("[" + DateTime.Now.ToLongTimeString() + "][" + sender + "]: " + message + "\n"); }));
        }

        public static void UpdateSongList()
        {
            Resources.SongList.Invoke(new MethodInvoker(delegate ()
            {
                Resources.SongList.Items.Clear();
                foreach (string file in Directory.GetFiles(Environment.CurrentDirectory + "\\Files"))
                {
                    Resources.SongList.Items.Add(Path.GetFileNameWithoutExtension(file));
                }
            }));
        }

        public static void UpdateConnectedClientList()
        {
            Resources.OnlineUsers.Invoke(new MethodInvoker(delegate ()
            { 
                Resources.OnlineUsers.Items.Clear();
                List<ServerLib.Connection.Client> ConnectedClients = ServerLib.Connection.ResourceProvider.GetConnectedClients();
                for (int i=0; i< ConnectedClients.Count; i++)
                {
                    Resources.OnlineUsers.Items.Add(ConnectedClients[i].Username);
                }
            }));
        }

        public static void UpdateUserList()
        {
            Resources.UserList.Invoke(new MethodInvoker(delegate ()
            {
                Resources.UserList.Items.Clear();
                DirectoryInfo directoryInfo = new DirectoryInfo(Environment.CurrentDirectory + "\\Users");
                Resources.UserList.Items.AddRange(directoryInfo.GetFiles());
            }));
        }
    }
}
