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
using System.Threading;

using GMHelper;

namespace EDWoWClient
{
    public class SystemMgr
    {
        /// <summary>
        /// Handles System Update
        /// </summary>
        public Timer Timer { get; private set; }

        /// <summary>
        /// Start the timer
        /// </summary>
        public void StartTimer()
        {
            Timer timer = new Timer(TimerCallback, null, 0, 100);
            Timer = timer;
            Logging.Notify("[Info]:", "Started Update Timer..", true);
        }

        /// <summary>
        /// Call what needs to be updated
        /// </summary>
        /// <param name="obj"></param>
        void TimerCallback(Object obj)
        {
            if (MessageForm.MessageWindow != null && WorldMgr.Player!= null)
                if (WorldMgr.Player.HasVerified)
                    MessageForm.MessageWindow.ReceiveChatMessage();
        }
    }
}
