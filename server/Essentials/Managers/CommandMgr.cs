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
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace Essentials
{
    public class CommandMgr
    {
        public delegate void CommandHandler(string[] args);
        protected static Dictionary<string, CommandHandler> commandHandlers = new Dictionary<string, CommandHandler>();

        public static void DefineCommand(string cmd, CommandHandler handler)
        {
            commandHandlers[cmd] = handler;
        }

        protected static bool InvokeCommandHandler(string cmd, params string[] args)
        {
            if (commandHandlers.ContainsKey(cmd))
            {
                commandHandlers[cmd].Invoke(args);
                return true;
            }
            else
                return false;
        }

        public static void InitializeCommands()
        {
            while (true)
            {
                Thread.Sleep(1);

                string[] readLineData = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.None);
                string[] args = new string[readLineData.Length - 1];
                Array.Copy(readLineData, 1, args, 0, readLineData.Length - 1);

                InvokeCommandHandler(readLineData[0].ToLowerInvariant(), args);
            }
        }
    }
}
