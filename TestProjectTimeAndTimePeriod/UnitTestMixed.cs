using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeAndTimePeriod;
using System;

namespace TestProjectTimeAndTimePeriod
{
    [TestClass]
    public class UnitTestMixed
    {
        [TestMethod]
        public void TimePlusPeriod()
        {
            string t = "4:5:6";
            Time time1 = new Time(t);
            Time timex = new Time("5:5:6");

            long s = 3600;
            TimePeriod period = new TimePeriod(s);

            time1 = time1.Plus(period);

            Assert.IsTrue(time1 == timex);
        }

        [TestMethod]
        public void TimePlusPeriod_Static()
        {
            string t = "4:5:6";
            Time time1 = new Time(t);
            Time timex = new Time("5:5:6");

            long s = 3600;
            TimePeriod period = new TimePeriod(s);

            time1 = Time.Plus(time1, period);

            Assert.IsTrue(time1 == timex);
        }

        [TestMethod]
        public void TimePlusPeriod_Static_Operator()
        {
            string t = "4:5:6";
            Time time1 = new Time(t);
            Time timex = new Time("5:5:6");

            long s = 3600;
            TimePeriod period = new TimePeriod(s);

            time1 = time1 + period;

            Assert.IsTrue(time1 == timex);
        }

        [TestMethod]
        public void TimeMinusPeriod()
        {
            string t = "5:5:6";
            Time time1 = new Time(t);
            Time timex = new Time("4:5:6");

            long s = 3600;
            TimePeriod period = new TimePeriod(s);

            time1 = time1.Minus(period);

            Assert.IsTrue(time1 == timex);
        }

        [TestMethod]
        public void TimeMinusPeriod_Static()
        {
            string t = "5:5:6";
            Time time1 = new Time(t);
            Time timex = new Time("4:5:6");

            long s = 3600;
            TimePeriod period = new TimePeriod(s);

            time1 = Time.Minus(time1, period);

            Assert.IsTrue(time1 == timex);
        }

        [TestMethod]
        public void TimeMinusPeriod_Static_Operator()
        {
            string t = "5:5:6";
            Time time1 = new Time(t);
            Time timex = new Time("4:5:6");

            long s = 3600;
            TimePeriod period = new TimePeriod(s);

            time1 = time1 - period;

            Assert.IsTrue(time1 == timex);
        }
    }
}