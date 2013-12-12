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
        /// Calls a new ChatMessage to be used throughout the WorldServer class
        /// </summary>
        public ChatMessage QueryChatMessage = new ChatMessage();

        [PacketHandler(Opcodes.SMSG_NAME_QUERY_RESPONSE)]
        void HandleNameQueryResponse(PacketReader reader)
        {
            UInt64 playerGUID = reader.ReadPackedGuid();
            bool noData = reader.ReadBoolean();
            if (noData)
                return;

            string name = reader.ReadCString();
            reader.ReadCString(); // Realm Name (Cross Realm)
            reader.ReadByte();
            reader.ReadByte();
            reader.ReadByte();

            bool declined = reader.ReadBoolean(); // Name declined/not declined
            if (declined)
                for (byte i = 0; i < 5; ++i)
                    reader.ReadByte();

            PlayerName result = Manager.m_WorldServer.PlayerNameList.Find(
                delegate(PlayerName playerName)
                {
                    return playerName.GUID == playerGUID;
                });

            if (result == null)
            {
                PlayerName playerName = new PlayerName();
                playerName.GUID = playerGUID;
                playerName.Name = name;
                QueryChatMessage.Name = name;

                ReceiveMsg = QueryChatMessage;
                PlayerNameList.Add(playerName);
            }
        }
    }
}
