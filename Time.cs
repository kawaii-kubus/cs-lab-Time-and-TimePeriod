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

            if (Hours > 24 || Minutes > 60 || Seconds > 60)
                throw new ArgumentException("Podano nie prawidłowe dane");

            if (Hours > byte.MaxValue || Minutes > byte.MaxValue || Seconds > byte.MaxValue) throw new ArgumentOutOfRangeException();
            if (Hours < byte.MinValue || Minutes < byte.MinValue || Seconds < byte.MinValue) throw new ArgumentOutOfRangeException();


        }

        public Time() : this(0, 0, 0) { }
        public Time(byte Hours, byte Minutes) : this(Hours, Minutes, 0) { }

        public Time(byte Hours) : this(Hours, 0, 0) { }

        public Time(string hh, string mm, string ss)
        {

            if (byte.Parse(hh) < 24)
            {
                this.Hours = byte.Parse(hh);

            }
            else
                throw new ArgumentException("Za duża wartość");

            if (byte.Parse(mm) < 60)
            {
                this.Minutes = byte.Parse(mm);

            }
            else
                throw new ArgumentException("Za duża wartość");

            if (byte.Parse(ss) < 60)
            {
                this.Seconds = byte.Parse(ss);

            }
            else
                throw new ArgumentException("Za duża wartość");


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
        public static Time operator +(Time t1,Time t2)
        {
            int hoursAdditon = t1.Hours + t2.Hours;
            int minutesAddition = t1.Minutes + t2.Minutes;
            int secundesAddition = t1.Seconds + t2.Seconds;

            return new Time((byte)(hoursAdditon % hoursInOneDay), (byte)(minutesAddition % minutesInOneHour), (byte)(secundesAddition % secondsInOneMinutes));
        }
        public static Time operator -(Time t1,Time t2)
        {
            int hoursSubtraction = t1.Hours - t2.Hours;
            int minutesSubtraction = t1.Minutes - t2.Minutes;
            int secundesSubtraction = t1.Seconds - t2.Seconds;

            return new Time((byte)(hoursSubtraction), (byte)(minutesSubtraction % minutesInOneHour), (byte)(secundesSubtraction % secondsInOneMinutes));
        }
    }
            
}
