using System;

namespace LixiBanff.Utils
{
    public static class Utiles
    {
        public static string DateTimeToEpoch(DateTime d)
        {
            TimeSpan t = d - new DateTime(1970, 1, 1);
            int secondsSinceEpoch = (int)t.TotalSeconds;
            return secondsSinceEpoch.ToString();
        }

        public static DateTime EpochToDatetime(string d)
        {
            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(long.Parse(d));
            return dateTimeOffset.DateTime;
        }
    }
}
