using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie2
{
    public struct TimePeriod : IEquatable<TimePeriod>,IComparable<TimePeriod>
    {
        /// <summary>
        /// Struktura zawierająca długość odcinka w czasie w postaci Godzina:Minuta:Sekunda
        /// </summary>
        #region Properties
        /// <summary>
        /// Properties zawierający godzinę jako odcinek w czasie w postaci 'long' 
        /// </summary>
        public long Hours { get; }
        /// <summary>
        /// Properties zawierający minutę jako odcinek w czasie w postaci 'long' 
        /// </summary>
        public long Minutes { get;}
        /// <summary>
        /// Properties zawierający sekudę jako odcinek w czasie w postaci 'long' 
        /// </summary>
        public long Seconds { get; }
        #endregion

        #region Constructors
        /// <summary>
        /// Tworzy TimePeriod poprzez hours,minutes,seconds w reprezentacji 'long'
        /// </summary>
        public TimePeriod(long hours, long minutes, long seconds)
        {
            if (hours > long.MaxValue || minutes > long.MaxValue || seconds > long.MaxValue)
                throw new ArgumentOutOfRangeException();
            if (hours < long.MinValue || minutes < long.MinValue || minutes < long.MinValue)
                throw new ArgumentOutOfRangeException();


            this.Hours = hours;
            this.Minutes = minutes;
            this.Seconds = seconds;
        }
        /// <summary>
        /// Tworzy TimePeriod poprzez hours,minutes w reprezentacji 'long' oraz ustawia sekundy jako 0
        /// </summary>
        public TimePeriod(long hours, long minutes) : this(hours, minutes, 0) { }
        /// <summary>
        /// Tworzy TimePeriod seconds w reprezentacji 'long' oraz ustawia godzinę i minutę na 0
        /// </summary>
        public TimePeriod(long seconds) : this(0, 0, seconds) { }
        /// <summary>
        /// Tworzy TimePeriod poprzez dwa typy 'Time' odejmując dwie jednostki upływu czasu 
        /// </summary>
        public TimePeriod(Time t1, Time t2)
        {
            long hoursSubtraction = t1.Hours - t2.Hours;
            long minutesSubtraction = t1.Minutes - t2.Minutes;
            long secundesSubtraction = t1.Seconds - t2.Seconds;

            this.Hours = hoursSubtraction;
            this.Minutes = minutesSubtraction;
            this.Seconds = secundesSubtraction;
        }
        /// <summary>
        /// Tworzy TimePeriod poprzez typ 'string' w postaci h:mm:ss
        /// </summary>
        public TimePeriod(string h, string mm, string ss)
        {
            this.Hours = long.Parse(h);
            this.Minutes = long.Parse(mm);  
            this.Seconds = long.Parse(ss);
        }
        #endregion

        #region ToString
        public override string ToString()
        {
            return ($"{Hours:0}:{Minutes:00}:{Seconds:00}");

        }
        #endregion
        #region IEquatable
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
        #endregion
        #region IComparable
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
        #endregion

        #region GetHashCode
        public override int GetHashCode()
        {
            return HashCode.Combine(Hours, Minutes, Seconds);
        }
        #endregion

        #region Operatory

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
        public static TimePeriod operator +(TimePeriod t1, TimePeriod t2)
        {
            long hoursAdditon = t1.Hours + t2.Hours;
            long minutesAddition = t1.Minutes + t2.Minutes;
            long secundesAddition = t1.Seconds + t2.Seconds;

            return new TimePeriod(hoursAdditon, minutesAddition,secundesAddition);
        }
        public static TimePeriod operator -(TimePeriod t1, TimePeriod t2)
        {
            long hoursSubtraction = t1.Hours - t2.Hours;
            long minutesSubtraction = t1.Minutes - t2.Minutes;
            long secundesSubtraction = t1.Seconds - t2.Seconds;

            return new TimePeriod(hoursSubtraction,minutesSubtraction,secundesSubtraction);
        }
        #endregion

    }
}
