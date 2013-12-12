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
using System.Text;
using System.Threading;
using System.Collections.Generic;

using MySql.Data.MySqlClient;

namespace Essentials
{
    public class MySqlBase
    {
        string ConnectionInfo;

        public bool Initialize(string host, string username, string password, string database, int port, bool pooling, int minPoolSize, int maxPoolSize)
        {
            if (pooling)
            {
                var pool = String.Format("Min Pool Size={0};Max Pool Size={1};", minPoolSize, maxPoolSize);

                ConnectionInfo = "Server=" + host + ";User Id=" + username + ";Port=" + port +
                    ";" + "Password=" + password + ";Database=" + database + ";Allow Zero Datetime=True;" + pool + "CharSet=utf8";
            }
            else
                ConnectionInfo = "Server=" + host + ";User Id=" + username + ";Port=" + port + ";" + "Password=" + password + ";Database=" + database + ";Allow Zero Datetime=True;" + "Pooling=False;CharSet=utf8";

            using (var conn = new MySqlConnection(ConnectionInfo))
            {
                try
                {
                    conn.Open();
                    conn.Close();
                    return true;
                }
                catch (MySqlException ex)
                {
                    Log.Error("[Error]", "{0}", ex.Message);

                    Thread.Sleep(5000);

                    Initialize(host, username, password, database, port, pooling, minPoolSize, maxPoolSize);
                    return false;
                }
            }
        }

        public bool Execute(string query, params object[] args)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(query);

            using (var conn = new MySqlConnection(ConnectionInfo))
            {
                try
                {
                    conn.Open();

                    using (MySqlCommand sqlCommand = new MySqlCommand(sb.ToString(), conn))
                    {
                        var param = new List<MySqlParameter>(args.Length);

                        foreach (var i in args)
                            param.Add(new MySqlParameter("", i));

                        sqlCommand.Parameters.AddRange(param.ToArray());
                        sqlCommand.ExecuteNonQuery();
                    }

                    conn.Close();
                    return true;
                }
                catch (MySqlException ex)
                {
                    Log.Error("[Error]", "{0}", ex.Message);
                    return false;
                }
            }
        }

        public QueryResult Select(string query, params object[] args)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(query);

            using (var conn = new MySqlConnection(ConnectionInfo))
            {
                try
                {
                    conn.Open();

                    using (var sqlCommand = new MySqlCommand(sb.ToString(), conn))
                    {
                        var param = new List<MySqlParameter>(args.Length);

                        foreach (var i in args)
                            param.Add(new MySqlParameter("", i));

                        sqlCommand.Parameters.AddRange(param.ToArray());

                        using (var data = sqlCommand.ExecuteReader(CommandBehavior.Default))
                        {
                            using (var queryRes = new QueryResult())
                            {
                                queryRes.Load(data);
                                queryRes.Count = queryRes.Rows.Count;

                                conn.Close();
                                return queryRes;
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    Log.Error("[Error]", "{0}", ex.Message);
                }

                conn.Close();
            }
            return null;
        }
    }
}
