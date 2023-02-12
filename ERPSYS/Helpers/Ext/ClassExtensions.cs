using System;

namespace ERPSYS.Helpers.Ext
{
	public static class ClassExtensions
	{
		public static void ThrowIfArgumentIsNull<T>(this T obj, string text) where T : class
		{
			if (obj == null) 
				throw new ArgumentNullException(text + " not allowed to be null");

		}
	}
}
