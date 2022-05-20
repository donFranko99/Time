using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestProjectTimeAndTimePeriod;
using System;

namespace TimeAndTimePeriod
{
    [TestClass]
    public class UnitTestTime
    {
        [TestMethod]
        public void Constructor_Byte_ThreeParameters()
        {
            byte h = 5;
            byte m = 21;
            byte s = 39;

            Time t = new Time(h, m, s);

            Assert.AreEqual(t.Hours, h);
            Assert.AreEqual(t.Minutes, m);
            Assert.AreEqual(t.Seconds, s);
        }

        [TestMethod]
        public void Constructor_Byte_TwoParameters()
        {
            byte h = 5;
            byte m = 21;

            Time t = new Time(h, m);

            Assert.AreEqual(t.Hours, h);
            Assert.AreEqual(t.Minutes, m);
            Assert.AreEqual(t.Seconds, 0);
        }

        [TestMethod]
        public void Constructor_Byte_OneParameter()
        {
            byte h = 5;

            Time t = new Time(h);

            Assert.AreEqual(t.Hours, h);
            Assert.AreEqual(t.Minutes, 0);
            Assert.AreEqual(t.Seconds, 0);
        }

        [TestMethod]
        public void Constructor_String_Correct()
        {
            string time = "23:59:59";

            Time t = new Time(time);

            Assert.AreEqual(t.Hours, 23);
            Assert.AreEqual(t.Minutes, 59);
            Assert.AreEqual(t.Seconds, 59);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_String_WrongArgument()
        {
            string time = "23:59:-5";
            Time t = new Time(time);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Constructor_String_WrongFormat()
        {
            string time = "23:59:05:06:03";
            Time t = new Time(time);
        }

        [TestMethod]
        public void ZeroFunction()
        {
            Time t = Time.Zero();

            Assert.AreEqual(t.Hours, 0);
            Assert.AreEqual(t.Minutes, 0);
            Assert.AreEqual(t.Seconds, 0);
        }

        [TestMethod]
        public void Equals_Obj_True()
        {
            object left = new Time(6,7,8);
            Time right = new Time("6:7:8");
            Assert.IsTrue(right.Equals(left));
        }

        [TestMethod]
        public void Equals_Time_True()
        {
            Time left = new Time(6, 7, 8);
            Time right = new Time("6:7:8");
            Assert.IsTrue(right.Equals(left));
        }
        [TestMethod]
        public void Equals_Obj_False()
        {
            object left = new Time(6, 6, 8);
            Time right = new Time("6:7:8");
            Assert.IsFalse(right.Equals(left));
        }

        [TestMethod]
        public void Equals_Time_False()
        {
            Time left = new Time(6, 6, 8);
            Time right = new Time("6:7:8");
            Assert.IsFalse(right.Equals(left));
        }

        [TestMethod]
        public void CompareTo_Time()
        {
            Time left1 = new Time(6, 6, 8);
            Time right1 = new Time("6:7:8");

            Time left2 = new Time(6, 8, 8);
            Time right2 = new Time("6:8:8");

            Time left3 = new Time(9, 8, 8);
            Time right3 = new Time("8:8:8");

            Assert.IsTrue(left1.CompareTo(right1) < 0);
            Assert.IsTrue(left2.CompareTo(right2) == 0);
            Assert.IsTrue(left3.CompareTo(right3) > 0);
        }
    }
}