using System;
using System.Diagnostics;
using NodaTime;
class Program
    {
        static void Main(string[] args)
        {
           

        }
        static void GeneralDateTimeUsage()
        {
            var now = DateTime.Now;
            var someDate = new DateTime();
            var nowWithOffset = DateTimeOffset.Now;
            var ticks = DateTime.Now.Ticks;
        }

        static void TimeMeasure()
        {
            //wrong way.
            var start = DateTime.Now;
            // do something
            var end = DateTime.Now;
            var elapsed1 = end - start;
            //correct way;
            var sw = Stopwatch.StartNew();
            //do something
            var elapsed2 = sw.Elapsed;
        }

        static void Scheduling()
        {
           var trueNow = SystemClock.Instance.GetCurrentInstant();
            ZonedDateTime nowInIsoUtc = trueNow.InUtc();
            var london = DateTimeZoneProviders.Tzdb["Europe/London"];
            var londonTime = trueNow.InZone(london);
            var localDate = new LocalDateTime(2019, 3, 31, 1, 45, 00);
            london.AtStrictly(localDate);
        }
    }
