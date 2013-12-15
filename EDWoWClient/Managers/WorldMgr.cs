using GMHelper;

namespace EDWoWClient
{
    public static class WorldMgr
    {
        public static WorldServer Server
        {
            get { return Manager.m_WorldServer; }
        }

        public static Character Player
        {
            get { return Manager.m_WorldServer.Player; }
        }
    }
}
