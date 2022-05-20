﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeAndTimePeriod
{
    public struct TimePeriod : IEquatable<TimePeriod>, IComparable<TimePeriod>
    {
        private readonly long seconds;
        public string Duration { get => $"{seconds/3600}:{(seconds%3600)/60}:{(seconds%3600)%60}"; }

        public TimePeriod(long h, long m , long s = 0)
        {
            seconds = h*3600 + m*60 + s;
        }
        public TimePeriod(long s = 0)
        {
            seconds = s;
        }
        public TimePeriod(Time t1, Time t2)
        {
            seconds = Math.Abs((t2.Hours-t1.Hours)*3600 + (t2.Minutes-t1.Minutes)*60 + (t2.Seconds-t1.Seconds));
        }

        public TimePeriod Plus(TimePeriod t)
        {
            return new TimePeriod(seconds + t.seconds);
        }
        public static TimePeriod Plus(TimePeriod left, TimePeriod right)
        {
            return new TimePeriod(left.seconds + right.seconds);
        }
        public static TimePeriod operator +(TimePeriod left, TimePeriod right)
        {
            return TimePeriod.Plus(left, right);
        }
        

        public override bool Equals(object? obj)
        {
            return obj is TimePeriod period &&
                   seconds == period.seconds;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(seconds);
        }

        public bool Equals(TimePeriod other)
        {
            if (seconds == other.seconds)
                return true;
            return false;
        }

        public int CompareTo(TimePeriod other)
        {
            return Math.Sign(seconds - other.seconds);
        }

        public static bool operator ==(TimePeriod left, TimePeriod right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(TimePeriod left, TimePeriod right)
        {
            return !(left == right);
        }

        public static bool operator <(TimePeriod left, TimePeriod right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(TimePeriod left, TimePeriod right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >(TimePeriod left, TimePeriod right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(TimePeriod left, TimePeriod right)
        {
            return left.CompareTo(right) >= 0;
        }
    }
}
