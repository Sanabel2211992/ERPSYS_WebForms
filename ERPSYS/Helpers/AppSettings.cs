using System.Configuration;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.Helpers
{
    public class AppSettings
    {
        public static string SystemTitle
        {
            get { return ConfigurationManager.AppSettings["SystemTitle"].ToTrimString(); }
        }

        public static string SystemVersion
        {
            get { return ConfigurationManager.AppSettings["SystemVersion"].ToTrimString(); }
        }

        public static bool SaveFileDataDb
        {
            get { return ConfigurationManager.AppSettings["SaveFileDataDB"].ToBool(); }
        }
    }
}