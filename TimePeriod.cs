using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie2
{
    public struct TimePeriod : IEquatable<TimePeriod>,IComparable<TimePeriod>
    {
        public long Hours { get; }
        public long Minutes { get;}
        public long Seconds { get; }

        public TimePeriod(int hours, int minutes, int seconds)
        {
            this.Hours = hours;
            this.Minutes = minutes;
            this.Seconds = seconds;
        }
        public TimePeriod(int hours, int minutes) : this(hours, minutes, 0) { }
        public TimePeriod(int seconds) : this(0, 0, seconds) { }

        public TimePeriod(Time t1,Time t2)
        {
            int t1Total = t1.Hours + t1.Minutes + t1.Seconds;
            int t2Total = t2.Hours + t2.Minutes + t2.Seconds;

            int timeSubstraction = t1Total < t2Total ? t1Total - t2Total : t2Total - t1Total;

            this = new TimePeriod(timeSubstraction);
        }
        public override string ToString()
        {
            return ($"{Hours:0}:{Minutes:00}:{Seconds:00}");

        }
        public TimePeriod(string hours,string minutes,string seconds)
        {
            this.Hours = long.Parse(hours);
            this.Minutes = long.Parse(minutes);
            this.Seconds = long.Parse(seconds);
        }


        public bool Equals(TimePeriod other)
        {
            if (this.Hours == other.Hours && this.Minutes == other.Minutes && this.Seconds == other.Seconds) return true;
            else
                return false;
        }
        public override bool Equals(object obj)
        {
            if (obj is TimePeriod)
                return Equals((TimePeriod)obj);
            else
                return false;
        }

        public int CompareTo(TimePeriod other)
        {
            if (this.Equals(other))
                return 0;

            if (this.Hours != other.Hours)
                return other.Hours.CompareTo(this.Hours);


            if (!this.Minutes.Equals(other.Minutes))
                return other.Minutes.CompareTo(this.Minutes);


            return other.Seconds.CompareTo(this.Seconds);

        }

        public override int GetHashCode()
        {
            return (Hours, Minutes, Seconds).GetHashCode();
        }




        public static bool operator ==(TimePeriod a, TimePeriod b) =>
            a.Equals(b);

        public static bool operator !=(TimePeriod a, TimePeriod b) =>
            !a.Equals(b);
        public static bool operator >(TimePeriod a, TimePeriod b) =>
            a.CompareTo(b) > 0;
        public static bool operator <(TimePeriod a, TimePeriod b) =>
            a.CompareTo(b) < 0;
        public static bool operator <=(TimePeriod a, TimePeriod b) =>
            a.CompareTo(b) <= 0;
        public static bool operator >=(TimePeriod a, TimePeriod b) =>
            a.CompareTo(b) >= 0;

    }
}
