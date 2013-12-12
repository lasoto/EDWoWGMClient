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
    public static class Log
    {
        public static void Notify(string title, string format, bool time = true, params object[] args)
        {
            lock (Console.Out)
            {
                SetColor(ConsoleColor.Cyan);

                if (time)
                {
                    Console.Write("[{0}] I {1} → ", DateTime.Now.ToString("HH:mm:ss"), title);
                }
                else
                    Console.Write("{0} :: ", title);

                Console.Write(string.Format(format, args) + "\n");
                SetColor(ConsoleColor.Gray);
            }
        }

        public static void Notify(string title, ConsoleColor color, string format, bool time = true, params object[] args)
        {
            lock (Console.Out)
            {
                SetColor(ConsoleColor.Cyan);

                if (time)
                    Console.Write("[{0}] I {1} → ", DateTime.Now.ToString("HH:mm:ss"), title);
                else
                    Console.Write(">{0} → ", title);

                SetColor(color);
                Console.Write(string.Format(format, args) + "\n");
                SetColor(ConsoleColor.Gray);
            }
        }

        public static void Notify(ConsoleColor color, string format)
        {
            lock (Console.Out)
            {
                SetColor(color);
                Console.Write(new string(' ', (Console.WindowWidth - format.Length) / 2));
                Console.Write(format + "\n");

                SetColor(ConsoleColor.Gray);
            }
        }

        public static void Warning(string title, string format, params object[] args)
        {
            lock (Console.Out)
            {
                SetColor(ConsoleColor.Yellow);
                Console.Write("[{0}] {1} → ", DateTime.Now.ToString("HH:mm:ss"), title);
                Console.Write(string.Format(format, args) + "\n");
                SetColor(ConsoleColor.Gray);
            }
        }

        public static void Error(string title, string format, params object[] args)
        {
            lock (Console.Out)
            {
                SetColor(ConsoleColor.Red);
                Console.Write("[{0}] {1} → ", DateTime.Now.ToString("HH:mm:ss"), title);
                Console.Write(string.Format(format, args) + "\n");
                SetColor(ConsoleColor.Gray);
            }
        }

        public static void WriteF(string format, ConsoleColor color, params object[] args)
        {
            lock (Console.Out)
            {
                SetColor(color);
                Console.Write(string.Format(format, args));
                ResetColor();
            }
        }

        public static void Write(object obj, ConsoleColor color)
        {
            lock (Console.Out)
            {
                SetColor(color);
                Console.Write(obj.ToString());
                ResetColor();
            }
        }

        public static void WriteF(string format, params object[] args)
        {
            lock (Console.Out) { Console.Write(string.Format(format, args)); }
        }

        public static void Write(object obj)
        {
            lock (Console.Out) { Console.Write(obj.ToString()); }
        }

        public static void SetColor(ConsoleColor col)
        {
            Console.ForegroundColor = col;
        }

        public static void Clear()
        {
            Console.Clear();
        }

        public static void ResetColor()
        {
            Console.ResetColor();
        }

        public static void Center(String text)
        {
            Console.Write(new string(' ', (Console.WindowWidth - text.Length) / 2));
            Console.WriteLine(text);
        }
    }
}
