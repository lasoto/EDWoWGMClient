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
 
    FURTHER CREDITS:
      Arctium
*/
using System;

namespace Essentials
{
    public class FactionTemplate
    {
        public UInt32 ID;
        public UInt32 Faction;
        public UInt32 FactionGroup;
        public UInt32 Mask;
        public UInt32 FriendlyMask;
        public UInt32 HostileMask;
        public UInt32[] EnemyFactions = new UInt32[4];
        public UInt32[] FriendlyFactions = new UInt32[4];
    }

    public enum Gender : byte
    {
        Male = 0,
        Female = 1,
        None = 2,
    }

    public class Race
    {
        public UInt32 RaceId;
    }

    public class Class
    {
        public UInt32 ClassId;
    }
}
