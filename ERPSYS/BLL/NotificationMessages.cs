using System;

namespace ERPSYS.BLL
{
    public class Notifications
    {
        public static string GetMessage(string messageId)
        {
            try
            {
                return GeneralResources.GetStringFromResources(messageId);
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}