using System;
using System.Reflection;
using System.Resources;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.BLL
{
    internal class GeneralResources
    {
        internal object GetObjectFromGeneralResources(string objectId)
        {
            try
            {
                const string baseName = "ERPSYS.Resources.GeneralResources";
                ResourceManager resourcesManager = new ResourceManager(baseName, GetType().Assembly);
                return resourcesManager.GetObject(objectId);
            }
            catch (Exception ex)
            {
                ClsLogging.WriteExceptionMessage(ex);
                return null;
            }
        }

        internal static string GetStringFromResources(string stringId)
        {
            try
            {
                const string baseName = "ERPSYS.Resources.Notifications";
                ResourceManager resourcesManager = new ResourceManager(baseName, Assembly.GetExecutingAssembly());
                return resourcesManager.GetString(stringId).ReplaceWhenNullOrEmpty("missed message");
            }
            catch (Exception ex)
            {
                ClsLogging.WriteExceptionMessage(ex);
                return string.Empty;
            }
        }
    }
}