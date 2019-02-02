using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerUI
{
    public partial class UserAdministrator : MetroFramework.Forms.MetroForm
    {
        public UserAdministrator()
        {
            InitializeComponent();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(Environment.CurrentDirectory + "\\Users\\" + metroTextBox1.Text))
                {
                    StreamWriter STW = new StreamWriter(Environment.CurrentDirectory + "\\Users\\" + metroTextBox1.Text);
                    STW.WriteLine(metroTextBox2.Text);
                    if(metroComboBox1.SelectedItem.ToString() == "Artist")
                    {
                        STW.WriteLine(0);
                    }
                    else if(metroComboBox1.SelectedItem.ToString() == "Premium")
                    {
                        STW.WriteLine(1);
                    }
                    else if(metroComboBox1.SelectedItem.ToString() == "User")
                    {
                        STW.WriteLine(2);
                    }
                    STW.Close();
                    MetroFramework.MetroMessageBox.Show(this, "Der Benutzer wurde erfolgreich angelegt!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, 120);
                    ClearDialog();
                    this.Close();
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "Dieser Benutzer existiert bereits!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error, 120);
                }
            }
            catch
            {
                MetroFramework.MetroMessageBox.Show(this, "Fehler beim erstellen der Benutzer-Datei", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error, 120);
            }
        }

        private void ClearDialog()
        {
            metroTextBox1.Clear();
            metroTextBox2.Clear();
            metroComboBox1.SelectedItem = null;
            metroComboBox1.Text = string.Empty;
        }
    }
}
