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
    public partial class MessageWindow : Form
    {
        public MessageWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Invokes the chat to prevent cross-threaded errors
        /// Chat goes by type
        /// </summary>
        /// <param name="richTextBox"></param>
        /// <param name="chatMessage"></param>
        /// <param name="msg"></param>
        private void InvokeChat(RichTextBox richTextBox, ChatMessage chatMessage = null, string msg = null)
        {
            if (chatMessage != null)
            {
                switch (chatMessage.Type)
                {
                    case ChatType.CHAT_TYPE_SYSTEM:
                        BeginInvoke(new MethodInvoker(delegate
                        {
                            if (!string.IsNullOrEmpty(chatMessage.Message))
                                richTextBox.AppendText(string.Format("{0} \n", Manager.m_WorldServer.ReceiveCMDSyntax()));
                            chatMessage.Message = null;
                            Manager.m_WorldServer.CmdList.Clear();
                        }));
                        break;
                    case ChatType.CHAT_TYPE_SAY:
                    case ChatType.CHAT_TYPE_YELL:
                        if (string.IsNullOrEmpty(chatMessage.Name))
                            return;

                        BeginInvoke(new MethodInvoker(delegate
                        {
                            if (!string.IsNullOrEmpty(chatMessage.Message))
                                richTextBox.AppendText(string.Format("[{0}] says: {1} \n", chatMessage.Name, chatMessage.Message));
                            chatMessage.Message = null;
                            chatMessage.Name = null;
                        }));
                        break;
                    case ChatType.CHAT_TYPE_CHANNEL:
                        if (string.IsNullOrEmpty(chatMessage.Name) || string.IsNullOrEmpty(chatMessage.ChannelName))
                            return;

                        BeginInvoke(new MethodInvoker(delegate
                        {
                            if (!string.IsNullOrEmpty(chatMessage.Message))
                                richTextBox.AppendText(string.Format("[{0}] [{1}] says: {2} \n", chatMessage.ChannelName, chatMessage.Name, chatMessage.Message));
                            chatMessage.Message = null;
                        }));
                        break;

                }
            }

            if (!string.IsNullOrEmpty(msg))
            {
                BeginInvoke(new MethodInvoker(delegate
                {
                    richTextBox.AppendText(string.Format("{0} \n", msg));
                    msg = null;
                }));
            }
        }
        /// <summary>
        /// Sends a message by type
        /// </summary>
        /// <param name="type"></param>
        /// <param name="richTextBox"></param>
        private void SendMessage(ChatType type, RichTextBox richTextBox)
        {
            PacketWriter writer = new PacketWriter(Opcodes.CMSG_MESSAGECHAT);

            switch (type)
            {
                case ChatType.CHAT_TYPE_SAY:
                    writer.Write((UInt32)ChatType.CHAT_TYPE_SAY);
                    break;
                case ChatType.CHAT_TYPE_YELL:
                    writer.Write((UInt32)ChatType.CHAT_TYPE_YELL);
                    break;
            }

            writer.Write((UInt32)Language.LANG_UNIVERSAL);
            writer.Write(richTextBox.Text.ToCString());
            Manager.m_WorldServer.Send(writer);
            richTextBox.Text = "";
        }
        /// <summary>
        /// Receives messages from the server
        /// This is handled in SystemMgr.TimerCallback, updates every 100ms
        /// </summary>
        public void ReceiveChatMessage()
        {
            ChatMessage chatMessage = Manager.m_WorldServer.ReceiveMsg;
            switch (chatMessage.Type)
            {
                case ChatType.CHAT_TYPE_SYSTEM:
                    InvokeChat(richTextBoxReceiveSystemMsg, chatMessage);
                    break;
                case ChatType.CHAT_TYPE_SAY:
                    InvokeChat(richTextBoxReceiveSay, chatMessage);
                    break;
                case ChatType.CHAT_TYPE_YELL:
                    InvokeChat(richTextBoxReceiveYell, chatMessage);
                    break;
                case ChatType.CHAT_TYPE_TEXT_EMOTE:
                    InvokeChat(richTextBoxReceiveTextEmote, chatMessage);
                    break;
                case ChatType.CHAT_TYPE_CHANNEL:
                    InvokeChat(richTextBoxReceiveChannel, chatMessage);
                    break;
            }

            if (!string.IsNullOrEmpty(Manager.m_WorldServer.InfoMessage))
            {
                InvokeChat(richTextBoxReceiveInfo, null, Manager.m_WorldServer.InfoMessage + "\n");
                Manager.m_WorldServer.InfoMessage = null;
            }
            else if (!string.IsNullOrEmpty(Manager.m_WorldServer.WarningMessage))
            {
                InvokeChat(richTextBoxReceiveWarning, null, Manager.m_WorldServer.WarningMessage + "\n");
                Manager.m_WorldServer.WarningMessage = null;
            }
            else if (!string.IsNullOrEmpty(Manager.m_WorldServer.ErrorMessage))
            {
                InvokeChat(richTextBoxReceiveError, null, Manager.m_WorldServer.ErrorMessage + "\n");
                Manager.m_WorldServer.ErrorMessage = null;
            }
        }

        private void richTextBoxSendSay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(richTextBoxSendSay.Text))
            {
                e.Handled = true;
                SendMessage(ChatType.CHAT_TYPE_SAY, richTextBoxSendSay);
            }
        }

        private void richTextBoxSendYell_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(richTextBoxSendYell.Text))
            {
                e.Handled = true;
                SendMessage(ChatType.CHAT_TYPE_YELL, richTextBoxSendYell);
            }
        }

        #region Button Events
        private void minBtn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Close();
            if (mainForm.SystemMgr.Timer != null)
                mainForm.SystemMgr.Timer.Dispose();
        }

        private void minBtn_MouseEnter(object sender, EventArgs e)
        {
            minBtn.ForeColor = Color.White;
        }

        private void minBtn_MouseLeave(object sender, EventArgs e)
        {
            minBtn.ForeColor = Color.FromArgb(100, 100, 100);
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
    /// <summary>
    /// Access this Window's instance
    /// </summary>
    public class MessageForm
    {
        internal static MessageWindow MessageWindow;
    }
}
