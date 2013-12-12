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

using System;
using System.IO;
using System.Text;

namespace Essentials
{
    public class Config
    {
        string[] configData;

        public Config(string _configData)
        {
            if (File.Exists(_configData))
                configData = File.ReadAllLines(_configData, Encoding.UTF8);
        }

        public string GetStringValue(string dataName, string val)
        {
            string valTwo = null;

            try
            {
                foreach (var data in configData)
                {
                    var values = data.Split(new char[] { '=' }, StringSplitOptions.None);
                    if (values[0].StartsWith(dataName, StringComparison.InvariantCulture))
                        valTwo = (values[1].Trim() == "" ? "" : valTwo = values[1].Replace("\"", "").Trim());
                }
            }
            catch
            {
                Log.Error("[Error]:", "Error retrieving data in ({0})", valTwo);
            }
            return valTwo;
        }

        public int GetIntValue(string dataName, int val)
        {
            string valTwo = null;

            try
            {
                foreach (var data in configData)
                {
                    var values = data.Split(new char[] { '=' }, StringSplitOptions.None);
                    if (values[0].StartsWith(dataName, StringComparison.InvariantCulture))
                        valTwo = (values[1].Trim() == "" ? "" : valTwo = values[1].Replace("\"", "").Trim());
                }
            }
            catch
            {
                Log.Error("[Error]:", "Error retrieving data in ({0})", valTwo);
            }
            return Convert.ToInt32(valTwo);
        }
    }
}
