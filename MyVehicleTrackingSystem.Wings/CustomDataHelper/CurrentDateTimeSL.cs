using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDataHelper
{
    public class CurrentDateTimeSL
    {
        public static DateTime GetCurrentDate()
        {
            TimeZoneInfo UAETimeZone = TimeZoneInfo.FindSystemTimeZoneById("Sri Lanka Standard Time");
            DateTime utc = DateTime.UtcNow;
            DateTime dateNow = TimeZoneInfo.ConvertTimeFromUtc(utc, UAETimeZone);
            return dateNow;
        }
    }
}
