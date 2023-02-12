using System;

namespace ERPSYS.Helpers.Ext
{
    public static class BoolExtensions
    {
        private const bool DefaultBoolValue = false;

        public static bool ToBool(this object text)
        {
            try
            {
                //bool flag;
                return bool.Parse(text.ToString());
            }
            catch(Exception)
            {
                return Convert.ToBoolean(DefaultBoolValue);
            }
        }
    }
}