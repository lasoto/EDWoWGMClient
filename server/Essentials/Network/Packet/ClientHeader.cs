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

  FURTHER CREDITS
   MangosClient
*/
using System;

namespace Essentials
{
    public class ClientHeader : Header
    {
        public Opcodes Opcode { get; private set; }
        private PacketWriter Packet;
        private byte[] encryptedCommand;
        private byte[] encryptedSize;

        public byte[] EncryptedCommand
        {
            get
            {
                if (encryptedCommand == null)
                {
                    encryptedCommand = BitConverter.GetBytes((uint)Opcode);
                    AuthenticationCrypto.Encrypt(encryptedCommand, 0, encryptedCommand.Length);
                }

                return encryptedCommand;
            }
        }

        public int Size 
        { 
            get { return (int)Packet.BaseStream.Length + 4; } 
        }

        public byte[] EncryptedSize
        {
            get
            {
                if (encryptedSize == null)
                {
                    encryptedSize = BitConverter.GetBytes(this.Size).SubArray(0, 2);
                    Array.Reverse(encryptedSize);
                    AuthenticationCrypto.Encrypt(encryptedSize, 0, 2);
                }

                return encryptedSize;
            }
        }

        public ClientHeader(Opcodes opcode, PacketWriter packet)
        {
            Opcode = opcode;
            Packet = packet;
        }
    }
}
