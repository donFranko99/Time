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

        public Time(byte hours, byte minutes=0, byte seconds=0)
        {
            Hours = (byte)(hours % 24);
            Minutes = (byte)(minutes % 60);
            Seconds = (byte)(seconds % 60);
        }
        public Time(string time)
        {
            var data = time.Split(':');
            Hours = (byte)(Byte.Parse(data[0])%24);
            Minutes = (byte)(Byte.Parse(data[1])%60);
            Seconds = (byte)(Byte.Parse(data[2])%60);
        }
        public static Time Zero() => new Time(0);

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
