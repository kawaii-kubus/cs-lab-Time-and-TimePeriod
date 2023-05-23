using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie2
{
    /// <summary>
    /// Struktura zawierająca upływ czasu w postaci Godzina:Minuta:Sekunda
    /// </summary>
    public struct Time : IEquatable<Time>, IComparable<Time>
    {
        #region Properties
        /// <summary>
        /// Properties zawierający godzinę w postaci 'byte' jako punkt w czasie
        /// </summary>
        public byte Hours { get; }
        /// <summary>
        /// Properties zawierający minutę w postaci 'byte' jako punkt w czasie
        /// </summary>
        public byte Minutes { get; }
        /// <summary>
        /// Properties zawierający sekundę w postaci 'byte' jako punkt w czasie
        /// </summary>
        public byte Seconds { get; }
        #endregion

        #region Fields
        const int hoursInOneDay = 24;

        const int minutesInOneHour = 60;

        const int secondsInOneMinutes = 60;
        #endregion

        #region Constructors
        /// <summary>
        /// Tworzy Time poprzez Hours,Minutes,Seconds w reprezentacji 'byte'
        /// </summary>
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
        /// <summary>
        /// Tworzy Time oraz usatawia czas na 00:00:00
        /// </summary>
        public Time() : this(0, 0, 0) { }
        /// <summary>
        /// Tworzy Time poprzez Hours,Minutes w reprezentacji 'byte' oraz ustawaia sekundy na 0
        /// </summary>
        public Time(byte Hours, byte Minutes) : this(Hours, Minutes, 0) { }
        /// <summary>
        /// Tworzy Time poprzez Hours w reprezentacji 'byte' oraz ustawaia sekundy oraz minuty na 0
        /// </summary>
        public Time(byte Hours) : this(Hours, 0, 0) { }
        /// <summary>
        /// Tworzy Time poprzez hh,mm,ss w reprezentacji 'string' 
        /// </summary>
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
        #endregion

        #region ToString
        public override string ToString()
        {
            return ($"{Hours:00}:{Minutes:00}:{Seconds:00}");

        }
        #endregion

        #region IComparable
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
        #endregion


        #region IEquatable
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
        #endregion

        #region GetHashCode
        public override int GetHashCode()
        {
            return HashCode.Combine(Hours, Minutes, Seconds);
        }
        #endregion

        #region Operatory
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

            return new Time((byte)(hoursAdditon), (byte)(minutesAddition ), (byte)(secundesAddition));
        }
        public static Time operator -(Time t1,Time t2)
        {
            int hoursSubtraction = t1.Hours - t2.Hours;
            int minutesSubtraction = t1.Minutes - t2.Minutes;
            int secundesSubtraction = t1.Seconds - t2.Seconds;

            if (hoursSubtraction < 0)
            {
                hoursSubtraction += 24;
            }

            return new Time((byte)(hoursSubtraction), (byte)(minutesSubtraction), (byte)(secundesSubtraction));
        }
        #endregion
    }

}
