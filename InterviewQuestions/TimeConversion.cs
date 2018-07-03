using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions
{
    class TimeConversion
    {
        public static void Main(string[] args)
        {
            var dt = DateTime.UtcNow;
            Console.WriteLine(dt.ToLocalTime());

            var tz = TimeZoneInfo.FindSystemTimeZoneById("Jordan Standard Time");
            var utcOffset = new DateTimeOffset(dt, TimeSpan.Zero);
            Console.WriteLine(utcOffset.ToOffset(tz.GetUtcOffset(utcOffset)));
            Console.WriteLine(utcOffset);
        }
    }
}
