namespace ERPSYS.Helpers.Ext
{
    public static class FloatExtensions
    {
        #region PercentageOf calculations
        
       
        public static decimal PercentageOf(this float value, int percentOf)
        {
            return (decimal)(value / percentOf * 100);
        }
        
        public static decimal PercentageOf(this float value, float percentOf)
        {
            return (decimal)(value / percentOf * 100);
        }
        
        public static decimal PercentageOf(this float value, double percentOf)
        {
            return (decimal)(value / percentOf * 100);
        }
        
        public static decimal PercentageOf(this float value, long percentOf)
        {
            return (decimal)(value / percentOf * 100);
        }

        #endregion
    }
}
