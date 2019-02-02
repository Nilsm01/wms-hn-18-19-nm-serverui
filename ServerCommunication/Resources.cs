using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerUI.ServerCommunication
{
    class Resources
    {
        public static RichTextBox Log { get; set; }
        public static ListBox OnlineUsers { get; set; }
        public static ListBox UserList { get; set; }
        public static ListBox SongList { get; set; }
        public static Label Status_Label { get; set; }
        public static Button StartButton { get; set; }
        public static bool ServerOnline { get; set; }
        public static UserAdministrator userAdministrator { get; set; }
        public static MetroFramework.Controls.MetroToggle MaintenanceSwitch { get; set; }
    }
}
