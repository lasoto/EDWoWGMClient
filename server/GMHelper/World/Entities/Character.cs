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

using Essentials;

namespace GMHelper
{
    public class Character
    {
        public ulong GUID { get; private set; }
        public string Name { get; private set; }
        public byte Race { get; set; }
        public byte Class { get; set; }
        public Gender Gender { get; set; }
        public byte[] Bytes { get; private set; }
        public byte Level { get; private set; }
        public uint ZoneId { get; set; }
        public uint MapId { get; set; }
        public float X, Y, Z;
        public uint GuildId { get; set; }
        public uint Flags { get; set; }
        public uint PetInfoId { get; set; }
        public uint PetLevel { get; set; }
        public uint PetFamilyId { get; set; }
        public bool HasVerified { get; set; }
        public Item[] Items = new Item[20];

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

    public class PlayerName
    {
        public UInt64 GUID;
        public string Name;
    }
}
