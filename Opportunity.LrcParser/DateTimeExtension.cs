using System;
using System.Collections.Generic;
using System.Text;

namespace Opportunity.LrcParser
{
    internal static class DateTimeExtension
    {
        public static string ToLrcString(this DateTime dateTime)
        {
            var t = dateTime.Ticks;
            var m = t / TICKS_PER_MINUTE;
            t -= m * TICKS_PER_MINUTE;
            var s = (double)t / TICKS_PER_SECOND;
            return m.ToString("D2") + ":" + s.ToString("00.00");
        }

        public static string ToLrcStringRaw(this DateTime dateTime)
        {
            var t = dateTime.Ticks;
            var m = t / TICKS_PER_MINUTE;
            t -= m * TICKS_PER_MINUTE;
            var s = (double)t / TICKS_PER_SECOND;
            return m.ToString("D2") + ":" + s.ToString("00.00#####");
        }

        public static bool TryParseLrcString(string value, int start, int end, out DateTime result)
        {
            var m = 0;
            var s = 0;
            var t = 0;

            var i = start;
            for (; i < end; i++)
            {
                var v = value[i] - '0';
                if (v >= 0 && v <= 9)
                    m = m * 10 + v;
                else if (value[i] == ':')
                {
                    i++;
                    break;
                }
                else if (char.IsWhiteSpace(value, i))
                {
                    continue;
                }
                else
                {
                    goto ERROR;
                }
            }

            for (; i < end; i++)
            {
                var v = value[i] - '0';
                if (v >= 0 && v <= 9)
                    s = s * 10 + v;
                else if (value[i] == '.')
                {
                    i++;
                    break;
                }
                else if (char.IsWhiteSpace(value, i))
                {
                    continue;
                }
                else
                {
                    goto ERROR;
                }
            }

            var weight = (int)(TICKS_PER_SECOND / 10);
            for (; i < end; i++)
            {
                var v = value[i] - '0';
                if (v >= 0 && v <= 9)
                {
                    t += weight * v;
                    weight /= 10;
                }
                else if (char.IsWhiteSpace(value, i))
                {
                    continue;
                }
                else
                {
                    goto ERROR;
                }
            }

            result = new DateTime(t + TICKS_PER_SECOND * s + TICKS_PER_MINUTE * m, DateTimeKind.Unspecified);
            return true;

            ERROR:
            result = default;
            return false;
        }

        public const long TICKS_PER_MINUTE = TICKS_PER_SECOND * 60;
        public const long TICKS_PER_SECOND = TICKS_PER_MILLISECOND * 1000;
        public const long TICKS_PER_MILLISECOND = 10_000;
    }
}
