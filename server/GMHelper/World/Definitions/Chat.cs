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
namespace GMHelper
{
    public enum ChatType : byte
    {
        CHAT_TYPE_SYSTEM,
        CHAT_TYPE_SAY,
        CHAT_TYPE_PARTY,
        CHAT_TYPE_RAID,
        CHAT_TYPE_GUILD,
        CHAT_TYPE_OFFICER,
        CHAT_TYPE_YELL,
        CHAT_TYPE_WHISPER,
        CHAT_TYPE_WHISPER_FOREIGN,
        CHAT_TYPE_WHISPER_INFORM,
        CHAT_TYPE_EMOTE,
        CHAT_TYPE_TEXT_EMOTE,
        CHAT_TYPE_MONSTER_SAY,
        CHAT_TYPE_MONSTER_PARTY,
        CHAT_TYPE_MONSTER_YELL,
        CHAT_TYPE_MONSTER_WHISPER,
        CHAT_TYPE_MONSTER_EMOTE,
        CHAT_TYPE_CHANNEL,
        CHAT_TYPE_CHANNEL_JOIN,
        CHAT_TYPE_CHANNEL_LEAVE,
        CHAT_TYPE_CHANNEL_LIST,
        CHAT_TYPE_CHANNEL_NOTICE,
        CHAT_TYPE_CHANNEL_NOTICE_USER,
        CHAT_TYPE_AFK,
        CHAT_TYPE_DND
    }

    public enum Language : uint
    {
        LANG_UNIVERSAL = 0,
        LANG_ORCISH = 1,
        LANG_DARNASSIAN = 2,
        LANG_TAURAHE = 3,
        LANG_DWARVISH = 6,
        LANG_COMMON = 7,
        LANG_DEMONIC = 8,
        LANG_TITAN = 9,
        LANG_THALASSIAN = 10,
        LANG_DRACONIC = 11,
        LANG_KALIMAG = 12,
        LANG_GNOMISH = 13,
        LANG_TROLL = 14,
        LANG_GUTTERSPEAK = 33,
        LANG_DRAENEI = 35,
        LANG_ZOMBIE = 36,
        LANG_GNOMISH_BINARY = 37,
        LANG_GOBLIN_BINARY = 38,
    };

    public class ChatMessage
    {
        public ChatType Type;
        public string Name;
        public string ChannelName;
        public string Message;
    }
}
