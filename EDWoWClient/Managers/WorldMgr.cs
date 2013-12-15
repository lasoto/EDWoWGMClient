using GMHelper;

namespace EDWoWClient
{
    public class WorldMgr : Manager
    {
        public static WorldServer Server
        {
            get { return m_WorldServer; }
        }

        public static Character Player
        {
            get { return m_WorldServer.Player; }
        }
    }
}
