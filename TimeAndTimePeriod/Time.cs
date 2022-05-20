using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeAndTimePeriod
{
    public struct Time : IEquatable<Time>, IComparable<Time>
    {
        public  byte Hours { get; }
        public  byte Minutes { get; }
        public  byte Seconds { get; }

        /// <summary>
        /// Public constructor using 3 variables of type Byte (hours, minutes, seconds).
        /// If only 2 parameters are used, seconds are set to 0. If only 1 is used, 
        /// both seconds and minutes are set to 0.
        /// </summary>
        /// <param name="hours"></param>
        /// <param name="minutes"></param>
        /// <param name="seconds"></param>
        public Time(byte hours, byte minutes=0, byte seconds=0)
        {
            Hours = (byte)(hours % 24);
            Minutes = (byte)(minutes % 60);
            Seconds = (byte)(seconds % 60);
        }
        /// <summary>
        /// Public constructor with an string argument. Accepted data format is h:m:s. 
        /// If format is wrong or numbers converted from the string are less then 0,
        /// respective Exception is thrown.
        /// </summary>
        /// <param name="time"></param>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public Time(string time)
        {
            var data = time.Split(':');
            if (data.Length != 3)
            {
                throw new FormatException("Invalid data format. Correct input data format is h:m:s");
            }
            foreach(string n in data)
            {
                if (int.Parse(n)<0)
                {
                    throw new ArgumentException("Invalid argument, cant be less than 0");
                }
            }
            Seconds = (byte)(Byte.Parse(data[2]) % 60);
            Minutes = (byte)(Byte.Parse(data[1]) % 60);
            Hours = (byte)(Byte.Parse(data[0]) % 24);
        }
        /// <summary>
        /// Function that returns a time 0:0:0
        /// </summary>
        /// <returns>00:00:00</returns>
        public static Time Zero() => new Time(0);
        public Time Plus(TimePeriod t)
        {
            var dataT = t.Duration.Split(":");
            if (dataT.Length != 3) throw new FormatException("Invalid data format. Correct input data format is h:m:s");
            byte h = (byte)(Byte.Parse(dataT[0]) % 24);
            byte m = (byte)(Byte.Parse(dataT[1]) % 60);
            byte s = (byte)(Byte.Parse(dataT[2]) % 60);

            return new Time((byte)(h + Hours), (byte)(Minutes+m), (byte)(Seconds+s));
        }
        public static Time Plus(Time t, TimePeriod p)
        {
            return t.Plus(p);
        }
        public static Time operator +(Time t, TimePeriod p)
        {
            return Time.Plus(t, p);
        }
        public Time Minus(TimePeriod t)
        {
            var dataT = t.Duration.Split(":");
            if (dataT.Length != 3) throw new FormatException("Invalid data format. Correct input data format is h:m:s");
            byte h = (byte)(Byte.Parse(dataT[0]) % 24);
            byte m = (byte)(Byte.Parse(dataT[1]) % 60);
            byte s = (byte)(Byte.Parse(dataT[2]) % 60);

            return new Time((byte)(Hours-h), (byte)(Minutes-m), (byte)(Seconds-s));
        }
        public static Time Minus(Time t, TimePeriod p)
        {
            return t.Minus(p);
        }
        public static Time operator -(Time t, TimePeriod p)
        {
            return Time.Minus(t, p);
        }
        public override bool Equals(object? obj)
        {
            return obj is Time time &&
                   Hours == time.Hours &&
                   Minutes == time.Minutes &&
                   Seconds == time.Seconds;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Hours, Minutes, Seconds);
        }

        public bool Equals(Time other)
        {
            return (Hours==other.Hours && Minutes == other.Minutes && Seconds == other.Seconds);
        }

        public int CompareTo(Time other)
        {
            if (Hours-other.Hours != 0)
            {
                return Hours - other.Hours;
            }
            if (Minutes - other.Minutes != 0)
            {
                return Minutes - other.Minutes;
            }
            return Seconds - other.Seconds;
        }

        public static bool operator ==(Time left, Time right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Time left, Time right)
        {
            return !(left == right);
        }

        public static bool operator <(Time left, Time right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(Time left, Time right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >(Time left, Time right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(Time left, Time right)
        {
            return left.CompareTo(right) >= 0;
        }
    }
}
