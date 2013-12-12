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
using System.IO;
using System.Text;
using System.Net.Sockets;

namespace Essentials
{
    public class PacketWriter : BinaryWriter, Packet
    {
        public Header Header { get; private set; }

        private readonly MemoryStream memoryStream;
        private byte[] FinalizedPacket;

        public PacketWriter(NetworkStream stream)
            : base(stream)
        {
        }

        public PacketWriter(Opcodes opcode)
            : base()
        {
            Header = new ClientHeader(opcode, this);

            memoryStream = new MemoryStream();
            base.OutStream = memoryStream;
        }

        public byte[] FinalizePacket()
        {
            if (FinalizedPacket == null)
            {
                byte[] data = new byte[6 + memoryStream.Length];
                byte[] size = ((ClientHeader)Header).EncryptedSize;
                byte[] command = ((ClientHeader)Header).EncryptedCommand;

                Array.Copy(size, 0, data, 0, 2);
                Array.Copy(command, 0, data, 2, 4);
                Array.Copy(memoryStream.ToArray(), 0, data, 6, memoryStream.Length);

                FinalizedPacket = data;
            }

            return FinalizedPacket;
        }

        public void WriteCString(string data)
        {
            Write(Encoding.UTF8.GetBytes(data));
            Write((byte)0);
        }

        public void WriteBytes(byte[] data, int count = 0)
        {
            if (count == 0)
                base.Write(data);
            else
                base.Write(data, 0, count);
        }
    }
}
