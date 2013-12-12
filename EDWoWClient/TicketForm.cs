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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Essentials;
using GMHelper;

namespace EDWoWClient
{
    public partial class TicketForm : Form
    {
        public TicketForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Loads each ticket from the database and sends it to a listbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TicketForm_Load(object sender, EventArgs e)
        {
            QueryResult result = DatabaseGlobals.CharacterDB.Select(PreparedResult.CHARACTER_GM_TICKET_GET);

            if (result.Count != 0)
            {
                UInt32 ticketId = result.Read<UInt32>(0, "ticketId");
                UInt64 playerGUID = result.Read<UInt64>(0, "guid");
                string playerName = result.Read<string>(0, "name");
                string message = result.Read<string>(0, "message");

                listBoxTickets.Items.Add(string.Format("TicketId: {0}, PlayerGUID: {1}, PlayerName: {2}, Message {3}", ticketId, playerGUID, playerName, message));
            }
        }

        private void minBtn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        #region Button Events
        private void minBtn_MouseEnter(object sender, EventArgs e)
        {
            minBtn.ForeColor = Color.White;
        }

        private void closeBtn_MouseLeave(object sender, EventArgs e)
        {
            closeBtn.ForeColor = Color.FromArgb(100, 100, 100);
        }

        private void closeBtn_MouseEnter(object sender, EventArgs e)
        {
            closeBtn.ForeColor = Color.White;
        }

        private void minBtn_MouseLeave(object sender, EventArgs e)
        {
            minBtn.ForeColor = Color.FromArgb(100, 100, 100);
        }
        #endregion
    }
}
