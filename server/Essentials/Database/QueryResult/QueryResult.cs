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
using System.Data;
using System.Globalization;

namespace Essentials
{
    public class QueryResult : DataTable
    {
        public int Count { get; set; }

        public T Read<T>(int row, string colName, int count = 0)
        {
            checked
            {
                var value = Rows[row][colName + (count != 0 ? (1 + count).ToString() : "")];

                if (typeof(T).IsEnum)
                    return (T)Enum.ToObject(typeof(T), value);

                return (T)Convert.ChangeType(value, typeof(T));
            }
        }

        public object[] ReadAllFieldValues(string colName)
        {
            object[] obj = new object[Count];

            for (int i = 0; i < Count; i++)
                obj[i] = Rows[i][colName];

            return obj;
        }
    }
}
