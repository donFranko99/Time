using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeAndTimePeriod;
using System;

namespace TestProjectTimeAndTimePeriod
{
    [TestClass]
    public class UnitTestTimePeriod
    {
        [TestMethod]
        public void Constructor_Params_Long()
        {
            long hours = 21;
            long minutes = 37;
            long seconds = 0;

            TimePeriod p = new TimePeriod(hours, minutes, seconds);
            Assert.IsTrue(p.Duration == "21:37:0");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_Params_Long_ArgumentException()
        {
            long hours = -21;
            long minutes = 37;
            long seconds = 0;

            TimePeriod p = new TimePeriod(hours, minutes, seconds);
        }

        [TestMethod]
        public void Constructor_Param_Long()
        {
            long seconds = 3661;

            TimePeriod p = new TimePeriod(seconds);
            Assert.IsTrue(p.Duration == "1:1:1");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_Param_Long_ArgumentException()
        {
            long seconds = -3453;

            TimePeriod p = new TimePeriod(seconds);
        }

        [TestMethod]
        public void Constructor_Param_Time()
        {
            Time t1 = Time.Zero();
            Time t2 = new Time(5,5,0);

            TimePeriod p = new TimePeriod(t1, t2);

            Assert.IsTrue(p.Duration == "5:5:0");

            t2 = Time.Zero();
            t1 = new Time(5,5,0);

            p = new TimePeriod(t1, t2);

            Assert.IsTrue(p.Duration == "18:55:0");
        }

        [TestMethod]
        public void Multiply_ByIntNumber()
        {
            int n = 2;

            TimePeriod p = new TimePeriod(3600);

            p = p.Multiply(n);

            Assert.IsTrue(p.Duration == "2:0:0");

            p = TimePeriod.Multiply(p, n);

            Assert.IsTrue(p.Duration == "4:0:0");

            p = p * n;

            Assert.IsTrue(p.Duration == "8:0:0");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Myltiply_ByIntNumber_Method_InvalidOperation()
        {
            int n = -2;

            TimePeriod p = new TimePeriod(3600);

            p = p.Multiply(n);
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Myltiply_ByIntNumber_StaticMethod_InvalidOperation()
        {
            int n = -2;

            TimePeriod p = new TimePeriod(3600);

            p = TimePeriod.Multiply(p,n);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Myltiply_ByIntNumber_Operator_InvalidOperation()
        {
            int n = -2;

            TimePeriod p = new TimePeriod(3600);

            p = p * n;
        }
    }
}