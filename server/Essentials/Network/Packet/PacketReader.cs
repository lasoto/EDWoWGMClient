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
using System.Globalization;
using System.Collections.Generic;

namespace Essentials
{
    public class PacketReader : BinaryReader, Packet
    {
        public Opcodes Opcode { get; set; }
        public Header Header { get; private set; }

        public PacketReader(NetworkStream stream)
            : base(stream)
        {
        }

        public PacketReader(ServerHeader header)
            : this(header, new byte[] { })
        {
        }

        public PacketReader(ServerHeader header, byte[] buffer)
            : base(new MemoryStream(buffer))
        {
            Header = header;
        }

        public void Skip(int amount)
        {
            BaseStream.Seek(amount, SeekOrigin.Current);
        }

        public string ReadStringFromBytes(uint count)
        {
            byte[] stringArray = ReadBytes((int)count);
            Array.Reverse(stringArray);

            return UTF8Encoding.UTF8.GetString(stringArray);
        }

        public string ReadIPAddress()
        {
            byte[] ip = new byte[4];

            for (int i = 0; i < 4; ++i)
                ip[i] = ReadByte();

            return ip[0] + "." + ip[1] + "." + ip[2] + "." + ip[3];
        }

        public string ReadAccountName()
        {
            StringBuilder nameBuilder = new StringBuilder();

            byte nameLength = ReadByte();
            char[] name = new char[nameLength];

            for (int i = 0; i < nameLength; i++)
            {
                name[i] = base.ReadChar();
                nameBuilder.Append(name[i]);
            }

            return nameBuilder.ToString().ToUpper(CultureInfo.InvariantCulture);
        }

        public ulong ReadPackedGuid()
        {
            var mask = ReadByte();

            if (mask == 0)
                return (ulong)0;

            ulong res = 0;

            var i = 0;
            while (i < 8)
            {
                if ((mask & 1 << i) != 0)
                    res += (ulong)ReadByte() << (i * 8);

                i++;
            }

            return res;
        }
    }
}
