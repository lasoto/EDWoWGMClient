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

using Essentials;

namespace LogonServer
{
    public class AccountCommands : CommandParser
    {
        public static void CreateAccount(string[] args)
        {
            string username = Read<string>(args, 0);
            string password = Read<string>(args, 1);

            if (username == null || password == null)
                return;

            username = username.ToUpperInvariant();
            password = password.ToUpperInvariant();

            //QueryResult result = DatabaseGlobals.LogonDB.Select(PreparedResult.ACCOUNT_SELECT_ALL_BY_USERNAME, username);

            //if (result.Count == 0)
            //{
            //    if (DatabaseGlobals.LogonDB.Execute(PreparedResult.ACCOUNT_INSERT_NEW, username, password))
            //        Log.Notify("[Logon]", "Account {0} successfully created!", true, username);
            //}
            //else
            //    Log.Error("[Error]", "Account already exists!");
        }
    }
}
