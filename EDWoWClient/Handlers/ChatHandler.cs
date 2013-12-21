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

namespace EDWoWClient
{
    public partial class MessageWindow
    {
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
                                richTextBox.AppendText(string.Format("{0} \n", WorldMgr.Server.ReceiveCMDSyntax()));
                            chatMessage.Message = null;
                            WorldMgr.Server.CmdList.Clear();
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
                                richTextBox.AppendText(string.Format("[{0}] [{1}]: {2} \n", chatMessage.ChannelName, chatMessage.Name, chatMessage.Message));
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
            WorldMgr.Server.Send(writer);
            richTextBox.Text = "";
        }
        /// <summary>
        /// Receives messages from the server
        /// This is handled in SystemMgr.TimerCallback, updates every 100ms
        /// </summary>
        public void ReceiveChatMessage()
        {
            ChatMessage chatMessage = WorldMgr.Server.ReceiveMsg;
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

            if (!string.IsNullOrEmpty(WorldMgr.Server.InfoMessage))
            {
                InvokeChat(richTextBoxReceiveInfo, null, WorldMgr.Server.InfoMessage);
                WorldMgr.Server.InfoMessage = null;
            }
            else if (!string.IsNullOrEmpty(WorldMgr.Server.WarningMessage))
            {
                InvokeChat(richTextBoxReceiveWarning, null, WorldMgr.Server.WarningMessage);
                WorldMgr.Server.WarningMessage = null;
            }
            else if (!string.IsNullOrEmpty(WorldMgr.Server.ErrorMessage))
            {
                InvokeChat(richTextBoxReceiveError, null, WorldMgr.Server.ErrorMessage);
                WorldMgr.Server.ErrorMessage = null;
            }
        }
    }
}
