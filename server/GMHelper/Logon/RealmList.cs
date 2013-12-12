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
using System.IO;

using Essentials;

namespace GMHelper
{
    public class RealmList
    {
        public byte Type { get; private set; }
        private byte locked;
        public byte Flags { get; private set; }
        public string Name { get; private set; }
        public string Address { get; private set; }
        public int Port { get; private set; }
        public float Population { get; private set; }
        private byte load;
        private byte timezone;
        private byte major;
        private byte minor;
        private byte bugfix;
        private ushort build;
        private byte unk1;
        private ushort unk2;

        public RealmList(PacketReader reader)
        {
            Type = reader.ReadByte();
            locked = reader.ReadByte();
            Flags = reader.ReadByte();
            Name = reader.ReadCString();
            string address = reader.ReadCString();
            string[] tokens = address.Split(':');
            Address = tokens[0];
            Port = tokens.Length > 1 ? int.Parse(tokens[1]) : 8085;
            Population = reader.ReadSingle();
            load = reader.ReadByte();
            timezone = reader.ReadByte();
            unk1 = reader.ReadByte();

            if ((Flags & 4) != 0)
            {
                major = reader.ReadByte();
                minor = reader.ReadByte();
                bugfix = reader.ReadByte();
                build = reader.ReadUInt16();
            }

            unk2 = reader.ReadUInt16();
        }
    }
}
