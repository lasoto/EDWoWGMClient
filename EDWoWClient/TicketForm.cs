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
            using (QueryResult result = DatabaseGlobals.CharacterDB.Select(PreparedResult.CHARACTER_GM_TICKET_GET))
            {
                TicketMgr.TicketList.Clear();

                Ticket ticket;
                UInt32 ticketId = 0, mapId = 0, createTime = 0, lastModifiedTime = 0;
                float x = 0, y = 0, z = 0;
                UInt64 playerGUID = 0, closedBy = 0, assignedToGUID;
                string playerName = "", message = "";

                for (int i = 0; i < result.Count; i++)
                {
                    ticket = new Ticket();
                    ticketId = result.Read<UInt32>(i, "ticketId");
                    playerGUID = result.Read<UInt64>(i, "guid");
                    playerName = result.Read<string>(i, "name");
                    message = result.Read<string>(i, "message");
                    createTime = result.Read<UInt32>(i, "createTime");
                    mapId = result.Read<UInt32>(i, "mapId");
                    x = result.Read<float>(i, "posX");
                    y = result.Read<float>(i, "posY");
                    z = result.Read<float>(i, "posZ");
                    lastModifiedTime = result.Read<UInt32>(i, "lastModifiedTime");
                    closedBy = result.Read<UInt64>(i, "closedBy");
                    assignedToGUID = result.Read<UInt64>(i, "assignedTo");

                    ticket.Id = ticketId;
                    ticket.PlayerGUID = playerGUID;
                    ticket.PlayerName = playerName;
                    ticket.Message = message;
                    ticket.CreateTime = createTime;
                    ticket.MapId = mapId;
                    ticket.PlayerX = x;
                    ticket.PlayerY = y;
                    ticket.PlayerZ = z;
                    ticket.LastModifiedTime = lastModifiedTime;
                    ticket.AssignedToGUID = assignedToGUID;

                    if (closedBy == 0)
                    {
                        listBoxTickets.Items.Add(string.Format("TicketId: {0}, PlayerGUID: {1}, PlayerName: {2}", ticketId, playerGUID, playerName));

                        if (TicketMgr.TicketList != null)
                            TicketMgr.TicketList.Add(ticket);
                    }
                }
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

        private void listBoxTickets_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Ticket ticket in TicketMgr.TicketList)
            {
                if (listBoxTickets.Items[listBoxTickets.SelectedIndex].ToString().Contains(ticket.PlayerName))
                {
                    textBoxTicketId.Text = ticket.Id.ToString();
                    textBoxPlayerName.Text = ticket.PlayerName;
                    textBoxPlayerGUID.Text = ticket.PlayerGUID.ToString();
                    textBoxMessage.Text = ticket.Message;
                }
            }
        }
    }
}
