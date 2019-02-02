using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerUI
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ServerCommunication.Resources.Log = richTextBox2;
            ServerCommunication.Resources.OnlineUsers = listBox1;
            ServerCommunication.Resources.UserList = listBox2;
            ServerCommunication.Resources.SongList = listBox3;
            ServerCommunication.Resources.Status_Label = this.Status_lbl;
            ServerCommunication.Resources.StartButton = this.metroButton1;
            ServerCommunication.Resources.ServerOnline = false;
            ServerCommunication.Resources.userAdministrator = new UserAdministrator();
            ServerCommunication.Resources.MaintenanceSwitch = metroToggle1;
            ServerCommunication.Handler.InitializeEvents();
            ServerCommunication.Handler.UpdateUserList();
            this.metroTabControl1.SelectedTab = metroTabPage1;
            ServerCommunication.Handler.UpdateSongList();
            ServerCommunication.Handler.PrintInLog("Server", "Applikation gestartet!");
            groupBox2.Visible = false;
            InitializeComboboxes();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (!ServerCommunication.Resources.ServerOnline)
            {
                if (metroRadioButton1.Checked)
                {
                    if ((metroComboBox1.SelectedItem != null &&
                            metroComboBox2.SelectedItem != null &&
                                metroComboBox3.SelectedItem != null &&
                                    metroComboBox4.SelectedItem != null) && metroRadioButton1.Checked)
                    {
                        ServerLib.Resources.Public_Resources.ResourceInputInteface.SetStaticItems(metroComboBox1.Text, metroComboBox2.Text, metroComboBox3.Text, metroComboBox4.Text);
                        ServerCommunication.Handler.StartServer(false);
                    }
                    else
                    {
                        MetroFramework.MetroMessageBox.Show(this, "Wenn der statische Home Screen ausgewählt ist, muss jeder Song in der Box daneben manuell bestimmt werden!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, 120);
                    }
                }
                else if (metroRadioButton2.Checked)
                {
                    ServerCommunication.Handler.StartServer(true);
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "Bitte wähle eine Art des Home-Screens aus!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, 120);
                }
            }
            else
            {

            }
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            ServerCommunication.Resources.Log.Clear();
        }

        private void metroToggle1_CheckedChanged(object sender, EventArgs e)
        {
            if (!metroToggle1.Checked)
            {
                if(ServerLib.Connection.ResourceProvider.IsMaintenanceModeOn())
                    ServerLib.Connection.MaintenanceMode.Stop();
            }
            else
            {
                if (ServerLib.Connection.ResourceProvider.IsServerOnline())
                {
                    metroToggle1.Checked = false;
                    MetroFramework.MetroMessageBox.Show(this, "Der Wartungsmodus kann nicht während der Laufzeit aktiviert werden!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, 130);
                }
            }
        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            ServerCommunication.Resources.userAdministrator.ShowDialog();
            ServerCommunication.Handler.UpdateUserList();
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            richTextBox2.SelectionStart = richTextBox2.Text.Length;
            richTextBox2.ScrollToCaret();
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            ServerLib.GUI.AddFileDialog addFileDialog= new ServerLib.GUI.AddFileDialog();
            addFileDialog.ShowDialog();
            ServerCommunication.Handler.UpdateSongList();
        }

        private void metroRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (metroRadioButton1.Checked)
            {
                groupBox2.Visible = true;
            }
            else
            {
                groupBox2.Visible = false;
            }
        }

        private void InitializeComboboxes()
        {
            metroComboBox1.Items.AddRange(ServerLib.Resources.Public_Resources.ResourceProvider.getAudioFiles());
            metroComboBox2.Items.AddRange(ServerLib.Resources.Public_Resources.ResourceProvider.getAudioFiles());
            metroComboBox3.Items.AddRange(ServerLib.Resources.Public_Resources.ResourceProvider.getAudioFiles());
            metroComboBox4.Items.AddRange(ServerLib.Resources.Public_Resources.ResourceProvider.getAudioFiles());
        }

        private void umbenennenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox3.SelectedItem != null)
            {
                ServerLib.MetaData.Template.MetaFile meta = ServerLib.MetaData.MetaFileAdministrator.getMetaDataFromFileName(listBox3.SelectedItem.ToString());
                MessageBox.Show("Downloads: " + meta.Downloaded +
                              "\nClicks:           " + meta.Clicked +
                              "\nKategorie:    " + meta.Kategory, "Audio Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
