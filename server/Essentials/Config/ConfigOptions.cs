namespace Essentials
{
    public class ConfigOptions
    {
        public static Config OptionConfig = new Config("Options.conf");

        public static int LogonPort = OptionConfig.GetIntValue("Logon.Port", 3724);
        public static int WorldPort = OptionConfig.GetIntValue("World.Port", 8085);
        public static int MySQLPort = OptionConfig.GetIntValue("MySql.Port", 3306);
        public static string Host = OptionConfig.GetStringValue("Server.Host", "127.0.0.1");
        public static string CharDBHost = OptionConfig.GetStringValue("DB.Host", "127.0.0.1");
        public static string CharDBUser = OptionConfig.GetStringValue("DB.Username", "root");
        public static string CharDBPass = OptionConfig.GetStringValue("DB.Password", "root");
        public static string CharDBName = OptionConfig.GetStringValue("DB.Database", "characters");
    }
}
