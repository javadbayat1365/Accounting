using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Utilities.Convertor
{
   public static class GenericMethods
    {
        public static string RialFormat(this string value)
        {
            return value+"ریال";
        }
        public static string ToShamsi(this DateTime value)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(value) + "/" + pc.GetMonth(value) + "/" + pc.GetDayOfMonth(value);
        }
    }
}
