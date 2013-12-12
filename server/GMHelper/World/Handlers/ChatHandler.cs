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

using Essentials;

namespace GMHelper
{
    public partial class WorldServer
    {
        /// <summary>
        /// Command Syntax List
        /// Handled within CHAT_TYPE_SYSTEM
        /// </summary>
        public List<string> CmdList = new List<string>();

        [PacketHandler(Opcodes.SMSG_MESSAGECHAT)]
        void HandleServerChatMessage(PacketReader reader)
        {
            ChatType type = (ChatType)reader.ReadByte();
            Language language;
            UInt64 targetGUID;
            UInt64 targetGUIDOther;
            UInt32 messageLength;
            string channelName = null;
            string message;
            
            if ((type != ChatType.CHAT_TYPE_CHANNEL && type != ChatType.CHAT_TYPE_WHISPER))
                language = (Language)reader.ReadUInt32();
            else
                language = (Language)reader.ReadUInt32();

            targetGUID = reader.ReadUInt64();
            reader.ReadUInt32();

            switch (type)
            {
                case ChatType.CHAT_TYPE_CHANNEL:
                    channelName = reader.ReadCString();
                    break;
            }

            targetGUIDOther = reader.ReadUInt64();
            messageLength = reader.ReadUInt32();
            message = reader.ReadCString();
            reader.ReadByte();

            PlayerName result = PlayerNameList.Find(
                delegate(PlayerName playerName)
                {
                    return playerName.GUID == targetGUID;
                });

            if (type == ChatType.CHAT_TYPE_SYSTEM)
            {
                foreach (string syntax in message.Split('\n'))
                    if (!CmdList.Contains(syntax)) // Prevent double message
                        CmdList.Add(syntax);
            }
 
            if (result != null)
            {
                QueryChatMessage.Type = type;
                QueryChatMessage.Message = message;
                QueryChatMessage.Name = result.Name;
                if (channelName != null)
                    QueryChatMessage.ChannelName = channelName;
                ReceiveMsg = QueryChatMessage;
            }
            else
            {
                QueryChatMessage.Type = type;
                QueryChatMessage.Message = message;
                if (channelName != null)
                    QueryChatMessage.ChannelName = channelName;
            }

            if (targetGUID > 0)
            {
                PacketWriter writer = new PacketWriter(Opcodes.CMSG_NAME_QUERY);
                writer.Write(targetGUID);
                Send(writer);
            }
        }
        /// <summary>
        /// Receives a new message from another player
        /// </summary>
        public ChatMessage ReceiveMsg
        {
            get { return QueryChatMessage; }
            set { QueryChatMessage = value; }
        }
        /// <summary>
        /// Handles commands & other System messages
        /// </summary>
        /// <returns></returns>
        public string ReceiveCMDSyntax()
        {
            string temp = null;
            foreach (string cmd in CmdList)
                temp += cmd + "\n";
            return temp;
        }

        [PacketHandler(Opcodes.SMSG_CHAT_PLAYER_NOT_FOUND)]
        void HandleChatPlayerNotFound(PacketReader reader)
        {
            WarningMessage = "Player " + reader.ReadCString() + " not found..";
        }
    }
}
