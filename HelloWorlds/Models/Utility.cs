using System.Collections.Specialized;
using System.Configuration;

namespace HelloWorlds.Models
{
    public class Utility
    {
        public static string GetConnectionString()
        {
            var appConfig = ConfigurationManager.AppSettings;

            switch (appConfig["environment"])
            {
                case "environment":
                    return GetRdsConnectionString(appConfig);
                default:
                    return GetLocalConnectionString();
            }
        }

        private static string GetRdsConnectionString(NameValueCollection appConfig)
        {
            var dbname = appConfig["RDS_DB_NAME"];

            if (string.IsNullOrEmpty(dbname)) return null;

            var username = appConfig["RDS_USERNAME"];
            var password = appConfig["RDS_PASSWORD"];
            var hostname = $"{appConfig["RDS_HOSTNAME"]},{appConfig["RDS_PORT"]}";

            return "Data Source=" + hostname + ";Initial Catalog=" + dbname + ";User ID=" + username + ";Password=" + password + ";";
        }

        private static string GetLocalConnectionString()
        {
            return "Server =.\\SQLEXPRESS; Database = HelloWorldsDb; User Id = hellotest; password = pw123;";
        }
    }
}