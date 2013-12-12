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
using Essentials;

namespace GMHelper
{
    public class Character
    {
        public ulong GUID;
        public string Name { get; private set; }
        public byte Race;
        public byte Class;
        Gender Gender;
        byte[] Bytes;    // 5
        public byte Level { get; private set; }
        uint ZoneId;
        uint MapId;
        float X, Y, Z;
        uint GuildId;
        uint Flags;
        uint PetInfoId;
        uint PetLevel;
        uint PetFamilyId;
        Item[] Items = new Item[20];

        public Character(PacketReader reader)
        {
            GUID = reader.ReadUInt64();
            Name = reader.ReadCString();
            Race = reader.ReadByte();
            Class = reader.ReadByte();
            Gender = (Gender)reader.ReadByte();
            Bytes = reader.ReadBytes(5);
            Level = reader.ReadByte();
            ZoneId = reader.ReadUInt32();
            MapId = reader.ReadUInt32();
            X = reader.ReadSingle();
            Y = reader.ReadSingle();
            Z = reader.ReadSingle();
            GuildId = reader.ReadUInt32();
            Flags = reader.ReadUInt32();
            reader.ReadUInt32();
            reader.ReadByte();
            PetInfoId = reader.ReadUInt32();
            PetLevel = reader.ReadUInt32();
            PetFamilyId = reader.ReadUInt32();

            for (int i = 0; i < Items.Length - 1; ++i)
                Items[i] = new Item(reader);

            for (int i = 0; i < 4; ++i)
            {
                reader.ReadUInt32();
                reader.ReadByte();
                reader.ReadUInt32();
            }
        }
    }
}
