using System;
using System.Globalization;
/*
   08.07.2020 - first
 */
namespace Mkey
{
    public class EditorBefriend : IFormatProvider
    {
        private string TurbineOver;

        public EditorBefriend(string cultureName)
        {
            this.TurbineOver = cultureName;
        }

        public EditorBefriend(CultureInfo cInfo)
        {
            TurbineOver = cInfo.Name;
        }

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(DateTimeFormatInfo))
            {
                return new CultureInfo(TurbineOver).GetFormat(formatType);
            }
            else
            {
                return null;
            }
        }
    }
}
