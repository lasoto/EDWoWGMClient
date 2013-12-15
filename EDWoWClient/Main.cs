/*
          _______ _____  _______ _______ _______ 
         |    ___|     \|    ___|   |   |   |   |
         |    ___|  --  |    ___|       |   |   |
         |_______|_____/|_______|__|_|__|_______| 
     Copyright (C) 2013 EmuDevs <http://www.emudevs.com/>
 
  This program is free software; you can redistribute it and/or modify it
  under the terms of the GNU General Public License as published by the
  Free Software Foundation; either version 2 of the License, or (at your
  option) any later version.
 
  This program is distributed in the hope that it will be useful, but WITHOUT
  ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or
  FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for
  more details.
 
  You should have received a copy of the GNU General Public License along
  with this program. If not, see <http://www.gnu.org/licenses/>.
*/
using System;
using System.Windows.Forms;

using GMHelper;
using Essentials;
using System.Drawing;

namespace EDWoWClient
{
    public partial class mainForm : Form
    {
        public bool isConnected = false;
        public Logon logon;
        public static SystemMgr SystemMgr = new SystemMgr();

        public mainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            btnLogout.Visible = false;
            btnTickets.Visible = false;
        }

        #region Button Events
        /// <summary>
        /// Connects to the realmlist and afterwards, the WorldServer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (!isConnected)
            {
                logon = new Logon();
                if (logon.Start(ConfigOptions.Host, ConfigOptions.LogonPort, textBoxUsername.Text, textBoxPassword.Text))
                {
                    MessageForm.MessageWindow = new MessageWindow();
                    MessageForm.MessageWindow.Show();
                    SystemMgr.StartTimer();

                    #region Control Visibility
                    btnConnect.Visible = false;
                    textBoxUsername.Visible = false;
                    textBoxPassword.Visible = false;
                    btnLogout.Visible = true;
                    btnTickets.Visible = true;
                    #endregion

                    isConnected = true;
                    lblconnection.ForeColor = Color.SeaGreen;
                    lblconnection.Text = "   Connected";
                    Logging.Notify("[Info]:", "Successfully connected to the Logon..", true);
                }
                else
                    MessageBox.Show("Could not connect..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("You're already connected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        /// <summary>
        /// Opens the ticket window..
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTickets_Click(object sender, EventArgs e)
        {
            if (isConnected)
                new TicketForm().Show();
            else
                MessageBox.Show("Connect to the server first!");
        }

        private void minBtn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
        /// <summary>
        /// Logs the player out by sending a LogoutRequest to the server and receives a response
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogout_Click(object sender, EventArgs e)
        {
            isConnected = false;
            btnConnect.Visible = true;
            textBoxUsername.Visible = true;
            textBoxPassword.Visible = true;
            btnLogout.Visible = false;
            btnTickets.Visible = false;
            lblconnection.ForeColor = Color.OrangeRed;
            lblconnection.Text = "Disconnected";
            WorldMgr.Server.LogoutRequest();
            if (SystemMgr.Timer != null)
                mainForm.SystemMgr.Timer.Dispose();

            if (MessageForm.MessageWindow != null)
                MessageForm.MessageWindow.Close();
        }

        private void btnConnect_MouseEnter(object sender, EventArgs e)
        {
            btnConnect.ForeColor = Color.White;
        }

        private void btnConnect_MouseLeave(object sender, EventArgs e)
        {
            btnConnect.ForeColor = Color.FromArgb(100, 100, 100);
        }

        private void minBtn_MouseEnter(object sender, EventArgs e)
        {
            minBtn.ForeColor = Color.White;
        }

        private void minBtn_MouseLeave(object sender, EventArgs e)
        {
            minBtn.ForeColor = Color.FromArgb(100, 100, 100);
        }

        private void btnLogout_MouseEnter(object sender, EventArgs e)
        {
            btnLogout.ForeColor = Color.White;
        }

        private void btnLogout_MouseLeave(object sender, EventArgs e)
        {
            btnLogout.ForeColor = Color.FromArgb(100, 100, 100);
        }

        private void btnTickets_MouseEnter(object sender, EventArgs e)
        {
            btnTickets.ForeColor = Color.White;
        }

        private void btnTickets_MouseLeave(object sender, EventArgs e)
        {
            btnTickets.ForeColor = Color.FromArgb(100, 100, 100);
        }

        private void closeBtn_MouseEnter(object sender, EventArgs e)
        {
            closeBtn.ForeColor = Color.White;
        }

        private void closeBtn_MouseLeave(object sender, EventArgs e)
        {
            closeBtn.ForeColor = Color.FromArgb(100, 100, 100);
        }
        #endregion
    }
}
