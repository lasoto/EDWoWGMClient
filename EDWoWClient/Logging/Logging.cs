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

using GMHelper;

namespace EDWoWClient
{
    public static class Logging
    {
        public static void Notify(string title, string format, bool time = true, params object[] args)
        {
            if (time)
                MessageForm.MessageWindow.richTextBoxReceiveInfo.AppendText(string.Format("[{0}] I {1} → ", DateTime.Now.ToString("HH:mm:ss"), title));
            else
                MessageForm.MessageWindow.richTextBoxReceiveInfo.AppendText(string.Format("{0} :: ", title));

            MessageForm.MessageWindow.richTextBoxReceiveInfo.AppendText(string.Format(format, args) + "\n");
        }

        public static void Warning(string title, string format, params object[] args)
        {
            MessageForm.MessageWindow.richTextBoxReceiveWarning.AppendText(string.Format("[{0}] {1} → ", DateTime.Now.ToString("HH:mm:ss"), title));
            MessageForm.MessageWindow.richTextBoxReceiveWarning.AppendText(string.Format(format, args) + "\n");
        }

        public static void Error(string title, string format, params object[] args)
        {
            MessageForm.MessageWindow.richTextBoxReceiveError.AppendText(string.Format("[{0}] {1} → ", DateTime.Now.ToString("HH:mm:ss"), title));
            MessageForm.MessageWindow.richTextBoxReceiveError.AppendText(string.Format(format, args) + "\n");
        }
    }
}
