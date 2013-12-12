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
using System.IO;
using System.Collections.Generic;

namespace Essentials
{
    public class DBCReader
    {
        public static List<T> Read<T>(string dbcFile) where T : new()
        {
            List<T> tempList = null;

            try
            {
                using (var dbReader = new BinaryReader(new MemoryStream(File.ReadAllBytes("dbc/" + dbcFile))))
                {
                    DBCHeader header = new DBCHeader
                    {
                        Signature = dbReader.ReadString(4),
                        RecordCount = dbReader.ReadUInt32(),
                        FieldCount = dbReader.ReadUInt32(),
                        RecordSize = dbReader.ReadUInt32(),
                        StringBlockSize = dbReader.ReadUInt32()
                    };

                    if (header.IsValidDb2File)
                    {
                        var hash = dbReader.ReadUInt32();
                        var wowBuild = dbReader.ReadUInt32();
                        var unknown = dbReader.ReadUInt32();
                        var min = dbReader.ReadInt32();
                        var max = dbReader.ReadInt32();
                        var locale = dbReader.ReadInt32();
                        var unknown2 = dbReader.ReadInt32();

                        if (max != 0)
                        {
                            var diff = (max - min) + 1;

                            dbReader.ReadBytes(diff * 4);
                            dbReader.ReadBytes(diff * 2);
                        }
                    }

                    if (header.IsValidDbcFile || header.IsValidDb2File)
                    {
                        tempList = new List<T>();
                        var fields = typeof(T).GetFields();
                        var lastStringOffset = 0;
                        var lastString = "";

                        for (int i = 0; i < header.RecordCount; i++)
                        {
                            T newObj = new T();

                            foreach (var f in fields)
                            {
                                switch (f.FieldType.Name)
                                {
                                    case "SByte":
                                        f.SetValue(newObj, dbReader.ReadSByte());
                                        break;
                                    case "Byte":
                                        f.SetValue(newObj, dbReader.ReadByte());
                                        break;
                                    case "Int32":
                                        f.SetValue(newObj, dbReader.ReadInt32());
                                        break;
                                    case "UInt32":
                                        f.SetValue(newObj, dbReader.ReadUInt32());
                                        break;
                                    case "Int64":
                                        f.SetValue(newObj, dbReader.ReadInt64());
                                        break;
                                    case "UInt64":
                                        f.SetValue(newObj, dbReader.ReadUInt64());
                                        break;
                                    case "Single":
                                        f.SetValue(newObj, dbReader.ReadSingle());
                                        break;
                                    case "Boolean":
                                        f.SetValue(newObj, dbReader.ReadBoolean());
                                        break;
                                    case "SByte[]":
                                        f.SetValue(newObj, dbReader.ReadSByte(((sbyte[])f.GetValue(newObj)).Length));
                                        break;
                                    case "Byte[]":
                                        f.SetValue(newObj, dbReader.ReadByte(((byte[])f.GetValue(newObj)).Length));
                                        break;
                                    case "Int32[]":
                                        f.SetValue(newObj, dbReader.ReadInt32(((int[])f.GetValue(newObj)).Length));
                                        break;
                                    case "UInt32[]":
                                        f.SetValue(newObj, dbReader.ReadUInt32(((uint[])f.GetValue(newObj)).Length));
                                        break;
                                    case "Single[]":
                                        f.SetValue(newObj, dbReader.ReadSingle(((float[])f.GetValue(newObj)).Length));
                                        break;
                                    case "Int64[]":
                                        f.SetValue(newObj, dbReader.ReadInt64(((long[])f.GetValue(newObj)).Length));
                                        break;
                                    case "UInt64[]":
                                        f.SetValue(newObj, dbReader.ReadUInt64(((ulong[])f.GetValue(newObj)).Length));
                                        break;
                                    case "String":
                                        {
                                            var stringOffset = dbReader.ReadUInt32();

                                            if (stringOffset != lastStringOffset)
                                            {
                                                var currentPos = dbReader.BaseStream.Position;
                                                var stringStart = (header.RecordCount * header.RecordSize) + 20 + stringOffset;
                                                dbReader.BaseStream.Seek(stringStart, 0);

                                                f.SetValue(newObj, lastString = dbReader.ReadCString());

                                                dbReader.BaseStream.Seek(currentPos, 0);
                                            }
                                            else
                                                f.SetValue(newObj, lastString);

                                            break;
                                        }
                                    default:
                                        dbReader.BaseStream.Position += 4;
                                        break;
                                }
                            }

                            tempList.Add(newObj);
                        }
                    }
                }

                ++DBC.DBCFileCount;
            }
            catch (Exception ex)
            {
                Log.Error("[Error]", "Error while loading {0}: {1}", dbcFile, ex.Message);
            }

            return tempList;
        }
    }
}
