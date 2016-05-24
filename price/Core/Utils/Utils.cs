using System;

namespace Core.Utils
{
    public static class Utils
    {
        public static DateTime TruncateAfterSeconds(this DateTime dateTime)
        {
            return dateTime.AddTicks(-(dateTime.Ticks % TimeSpan.TicksPerSecond));
        }
    }
}
