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

using Essentials;

namespace GMHelper
{
    public partial class WorldServer
    {
        [PacketHandler(Opcodes.ServerCharacterEnumeration)]
        void HandleServerCharEnum(PacketReader reader)
        {
            byte count = reader.ReadByte();

            if (count == 0)
                ErrorMessage = "You have no characters. Go create one.";
            else
            {
                Character[] characters = new Character[count];
                for (byte i = 0; i < count; ++i)
                    characters[i] = new Character(reader);

                Player = characters[0];
                InfoMessage += " Selecting your first character.. \n " + characters[0].Name + " has been selected.. \n Logging in..";
                PacketWriter writer = new PacketWriter(Opcodes.CMSG_PLAYER_LOGIN);
                writer.Write(characters[0].GUID);
                Send(writer);
            }
        }

        [PacketHandler(Opcodes.SMSG_LOGOUT_COMPLETE)]
        void HandleLogoutComplete(PacketReader reader)
        {
            Disconnect();
        }
        /// <summary>
        /// Requests to logout
        /// </summary>
        public void LogoutRequest()
        {
            PacketWriter writer = new PacketWriter(Opcodes.CMSG_LOGOUT_REQUEST);
            Send(writer);
        }

        [PacketHandler(Opcodes.SMSG_LOGIN_VERIFY_WORLD)]
        void HandleLogonVerifyWorld(PacketReader reader)
        {
            Player.HasVerified = true;
        }
    }
}
