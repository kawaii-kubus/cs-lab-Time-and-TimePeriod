using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie2
{
    public struct Time : IEquatable<Time>, IComparable<Time>
    {
        public byte Hours { get; }
        public byte Minutes { get; }
        public byte Seconds { get; }

        const int hoursInOneDay = 24;

        const int minutesInOneHour = 60;

        const int secondsInOneMinutes = 60;

        public Time(byte Hours, byte Minutes, byte Seconds)
        {
            this.Hours = (byte)(Hours % hoursInOneDay);
            this.Minutes = (byte)(Minutes % minutesInOneHour);
            this.Seconds = (byte)(Seconds % secondsInOneMinutes);

            if (Hours >= 24 || Minutes >= 60 || Seconds >= 60)
                throw new ArgumentException("Podano nie prawidłowe dane");

            if (Hours > byte.MaxValue || Minutes > byte.MaxValue || Seconds > byte.MaxValue) throw new ArgumentOutOfRangeException();
            if (Hours < byte.MinValue || Minutes < byte.MinValue || Seconds < byte.MinValue) throw new ArgumentOutOfRangeException();


        }

        public Time() : this(0, 0, 0) { }
        public Time(byte Hours, byte Minutes) : this(Hours, Minutes, 0) { }
        public Time(byte Hours) : this(Hours, 0, 0) { }

        public Time(string hh, string mm, string ss)
        {
            this.Hours = byte.Parse(hh);
            this.Minutes = byte.Parse(mm);
            this.Seconds = byte.Parse(ss);

        }
        public override string ToString()
        {
            return ($"{Hours:00}:{Minutes:00}:{Seconds:00}");

        }

        public int CompareTo(Time other)
        {
            if (this.Equals(other))
                return 0;

            if (this.Hours != other.Hours)
                return other.Hours.CompareTo(this.Hours);


            if (!this.Minutes.Equals(other.Minutes))
                return other.Minutes.CompareTo(this.Minutes);


            return other.Seconds.CompareTo(this.Seconds);



        }

        public bool Equals(Time other)
        {
            if (this.Hours == other.Hours && this.Minutes == other.Minutes && this.Seconds == other.Seconds) return true;
            else
                return false;
        }
        public override bool Equals(object obj)
        {
            if (obj is Time)
                return Equals((Time)obj);
            else
                return false;
        }

        public override int GetHashCode()
        {
            return (Hours, Minutes, Seconds).GetHashCode();
        }

        public static Time operator +(Time a, Time b)
        {
            int sum = (a.Hours + b.Hours);
            int sum2 = (a.Minutes + b.Minutes);
            int sum3 = (a.Seconds + b.Seconds);
            int sumSum = sum + sum2 + sum3;
            return new Time((byte)sumSum);

        }

        public static bool operator ==(Time a, Time b) =>
            a.Equals(b);

        public static bool operator !=(Time a, Time b) =>
            !a.Equals(b);
        public static bool operator >(Time a, Time b) =>
            a.CompareTo(b) > 0;
        public static bool operator <(Time a, Time b) =>
            a.CompareTo(b) < 0;
        public static bool operator <=(Time a, Time b) =>
            a.CompareTo(b) <= 0;
        public static bool operator >=(Time a, Time b) =>
            a.CompareTo(b) >= 0;

 






    }
}
