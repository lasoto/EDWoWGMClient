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

namespace Essentials
{
    public class ServerHeader : Header
    {
        public Opcodes Opcode { get; private set; }
        public int Size { get; private set; }
        public int Length { get; private set; }

        public ServerHeader(byte[] data)
        {
            Length = data.Length;

            if (Length == 4)
            {
                Size = (int)(((uint)data[0]) << 8 | data[1]);
                Opcode = (Opcodes)BitConverter.ToUInt16(data, 2);
            }
            else if (Length == 5)
            {
                Size = (int)(((((uint)data[0]) & 0x7F) << 16) | (((uint)data[1]) << 8) | data[2]);
                Opcode = (Opcodes)BitConverter.ToUInt16(data, 3);
            }
            else
                return;

            Size -= 2;
        }
    }
}
