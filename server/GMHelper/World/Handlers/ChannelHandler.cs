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
        [PacketHandler(Opcodes.SMSG_CHANNEL_LIST)]
        void HandleChannelList(PacketReader reader)
        {
            byte type = reader.ReadByte();
            string name = reader.ReadCString();
            ChannelFlags flags = (ChannelFlags)reader.ReadByte();
            UInt32 size = reader.ReadUInt32();
            for (UInt32 i = 0; i < size; i++)
            {
                reader.ReadUInt64();
                reader.ReadByte();
            }
        }

        [PacketHandler(Opcodes.SMSG_CHANNEL_NOTIFY)]
        void HandleChannelNotify(PacketReader reader)
        {
            ChatNotify chatNotify = (ChatNotify)reader.ReadByte();
            string name = reader.ReadCString();

            switch (chatNotify)
            {
                case ChatNotify.CHAT_YOU_JOINED_NOTICE:
                    break;
            }
        }
        /// <summary>
        /// Request Channel List by ChannelName
        /// You must be in the channel to receive a list
        /// </summary>
        /// <param name="channelName"></param>
        public void RequestChannelList(string channelName)
        {
            PacketWriter writer = new PacketWriter(Opcodes.CMSG_CHANNEL_LIST);
            writer.Write(channelName.ToCString());
            Send(writer);
        }
        /// <summary>
        /// Joins the specified channel
        /// </summary>
        /// <param name="channelName"></param>
        /// <param name="password"></param>
        public void JoinChannel(Channel channel)
        {
            if (ChannelMgr.ChannelList.Contains(channel))
                return;

            PacketWriter writer = new PacketWriter(Opcodes.CMSG_JOIN_CHANNEL);
            writer.Write((UInt32)0);
            writer.Write((byte)0);
            writer.Write((byte)0);
            writer.Write(channel.Name.ToCString());
            writer.Write(channel.Password);
            Send(writer);

            RequestChannelList(channel.Name);
        }
    }
}
