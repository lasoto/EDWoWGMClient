namespace GMHelper
{
    #region Channel/Chat
    public enum ChannelFlags : byte
    {
        CHANNEL_FLAG_NONE = 0x00,
        CHANNEL_FLAG_CUSTOM = 0x01,
        CHANNEL_FLAG_TRADE = 0x04,
        CHANNEL_FLAG_NOT_LFG = 0x08,
        CHANNEL_FLAG_GENERAL = 0x10,
        CHANNEL_FLAG_CITY = 0x20,
        CHANNEL_FLAG_LFG = 0x40,
        CHANNEL_FLAG_VOICE = 0x80
        // General                  0x18 = 0x10 | 0x08
        // Trade                    0x3C = 0x20 | 0x10 | 0x08 | 0x04
        // LocalDefence             0x18 = 0x10 | 0x08
        // GuildRecruitment         0x38 = 0x20 | 0x10 | 0x08
        // LookingForGroup          0x50 = 0x40 | 0x10
    };

    public enum ChatNotify : byte
    {
        CHAT_JOINED_NOTICE = 0x00,                 //+ "%s joined channel.";
        CHAT_LEFT_NOTICE = 0x01,                   //+ "%s left channel.";
        CHAT_YOU_JOINED_NOTICE = 0x02,             //+ "Joined Channel: [%s]"; -- You joined
        CHAT_YOU_LEFT_NOTICE = 0x03,               //+ "Left Channel: [%s]"; -- You left
        CHAT_WRONG_PASSWORD_NOTICE = 0x04,         //+ "Wrong password for %s.";
        CHAT_NOT_MEMBER_NOTICE = 0x05,             //+ "Not on channel %s.";
        CHAT_NOT_MODERATOR_NOTICE = 0x06,          //+ "Not a moderator of %s.";
        CHAT_PASSWORD_CHANGED_NOTICE = 0x07,       //+ "[%s] Password changed by %s.";
        CHAT_OWNER_CHANGED_NOTICE = 0x08,          //+ "[%s] Owner changed to %s.";
        CHAT_PLAYER_NOT_FOUND_NOTICE = 0x09,       //+ "[%s] Player %s was not found.";
        CHAT_NOT_OWNER_NOTICE = 0x0A,              //+ "[%s] You are not the channel owner.";
        CHAT_CHANNEL_OWNER_NOTICE = 0x0B,          //+ "[%s] Channel owner is %s.";
        CHAT_MODE_CHANGE_NOTICE = 0x0C,            //?
        CHAT_ANNOUNCEMENTS_ON_NOTICE = 0x0D,       //+ "[%s] Channel announcements enabled by %s.";
        CHAT_ANNOUNCEMENTS_OFF_NOTICE = 0x0E,      //+ "[%s] Channel announcements disabled by %s.";
        CHAT_MODERATION_ON_NOTICE = 0x0F,          //+ "[%s] Channel moderation enabled by %s.";
        CHAT_MODERATION_OFF_NOTICE = 0x10,         //+ "[%s] Channel moderation disabled by %s.";
        CHAT_MUTED_NOTICE = 0x11,                  //+ "[%s] You do not have permission to speak.";
        CHAT_PLAYER_KICKED_NOTICE = 0x12,          //? "[%s] Player %s kicked by %s.";
        CHAT_BANNED_NOTICE = 0x13,                 //+ "[%s] You are bannedStore from that channel.";
        CHAT_PLAYER_BANNED_NOTICE = 0x14,          //? "[%s] Player %s bannedStore by %s.";
        CHAT_PLAYER_UNBANNED_NOTICE = 0x15,        //? "[%s] Player %s unbanned by %s.";
        CHAT_PLAYER_NOT_BANNED_NOTICE = 0x16,      //+ "[%s] Player %s is not bannedStore.";
        CHAT_PLAYER_ALREADY_MEMBER_NOTICE = 0x17,  //+ "[%s] Player %s is already on the channel.";
        CHAT_INVITE_NOTICE = 0x18,                 //+ "%2$s has invited you to join the channel '%1$s'.";
        CHAT_INVITE_WRONG_FACTION_NOTICE = 0x19,   //+ "Target is in the wrong alliance for %s.";
        CHAT_WRONG_FACTION_NOTICE = 0x1A,          //+ "Wrong alliance for %s.";
        CHAT_INVALID_NAME_NOTICE = 0x1B,           //+ "Invalid channel name";
        CHAT_NOT_MODERATED_NOTICE = 0x1C,          //+ "%s is not moderated";
        CHAT_PLAYER_INVITED_NOTICE = 0x1D,         //+ "[%s] You invited %s to join the channel";
        CHAT_PLAYER_INVITE_BANNED_NOTICE = 0x1E,   //+ "[%s] %s has been bannedStore.";
        CHAT_THROTTLED_NOTICE = 0x1F,              //+ "[%s] The number of messages that can be sent to this channel is limited, please wait to send another message.";
        CHAT_NOT_IN_AREA_NOTICE = 0x20,            //+ "[%s] You are not in the correct area for this channel."; -- The user is trying to send a chat to a zone specific channel, and they're not physically in that zone.
        CHAT_NOT_IN_LFG_NOTICE = 0x21,             //+ "[%s] You must be queued in looking for group before joining this channel."; -- The user must be in the looking for group system to join LFG chat channels.
        CHAT_VOICE_ON_NOTICE = 0x22,               //+ "[%s] Channel voice enabled by %s.";
        CHAT_VOICE_OFF_NOTICE = 0x23               //+ "[%s] Channel voice disabled by %s.";
    };

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
    #endregion

    #region Tickets
    public enum GMTicketResponse : uint
    {
        GMTICKET_RESPONSE_ALREADY_EXIST = 1,
        GMTICKET_RESPONSE_CREATE_SUCCESS = 2,
        GMTICKET_RESPONSE_CREATE_ERROR = 3,
        GMTICKET_RESPONSE_UPDATE_SUCCESS = 4,
        GMTICKET_RESPONSE_UPDATE_ERROR = 5,
        GMTICKET_RESPONSE_TICKET_DELETED = 9
    };

    public enum GMTicketStatus : byte
    {
        GMTICKET_STATUS_HASTEXT = 6,
        GMTICKET_STATUS_DEFAULT = 10
    };

    public enum GMTicketEscalationStatus : byte
    {
        TICKET_UNASSIGNED = 0,
        TICKET_ASSIGNED = 1,
        TICKET_IN_ESCALATION_QUEUE = 2,
        TICKET_ESCALATED_ASSIGNED = 3
    };

    public enum GMTicketOpenedByGMStatus : byte
    {
        GMTICKET_OPENEDBYGM_STATUS_NOT_OPENED = 0,  // ticket has never been opened by a gm
        GMTICKET_OPENEDBYGM_STATUS_OPENED = 1       // ticket has been opened by a gm
    };
    #endregion
}
