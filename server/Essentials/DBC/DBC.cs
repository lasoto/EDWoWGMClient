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
using System.Collections.Generic;

namespace Essentials
{
    public class DBC
    {
        public static int DBCFileCount { get; set; }

        public static List<Race> CharacterRaces;
        public static List<Class> CharacterClasses;

        public static void Initialize()
        {
            Log.Notify("[DBC]", "Loading DBCs...");

            //CharacterRaces = DBCReader.Read<Race>("ChrRaces.dbc");
            //CharacterClasses = DBCReader.Read<Class>("ChrClasses.dbc");

            Log.Notify("[DBC]", "Loaded {0} DBCs...", true, DBCFileCount);
        }
    }
}
