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

        [TestMethod]
        public void Plus_TimePeriod()
        {
            TimePeriod p1 = new TimePeriod(3600);
            TimePeriod p2 = new TimePeriod(3600);

            p1 = p1.Plus(p2);

            Assert.IsTrue(p1.Duration == "2:0:0");

            p1 = TimePeriod.Plus(p1, p2);

            Assert.IsTrue(p1.Duration == "3:0:0");

            p1 = p1 + p2;

            Assert.IsTrue(p1.Duration == "4:0:0");
        }

        [TestMethod]
        public void Minus_TimePeriod()
        {
            TimePeriod p1 = new TimePeriod(3600*4);
            TimePeriod p2 = new TimePeriod(3600);

            p1 = p1.Minus(p2);

            Assert.IsTrue(p1.Duration == "3:0:0");

            p1 = TimePeriod.Minus(p1, p2);

            Assert.IsTrue(p1.Duration == "2:0:0");

            p1 = p1 - p2;

            Assert.IsTrue(p1.Duration == "1:0:0");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Minus_TimePeriod_InvalidOperation_Method()
        {
            TimePeriod p1 = new TimePeriod(3600);
            TimePeriod p2 = new TimePeriod(3600 * 4);

            p1= p1.Minus(p2);
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Minus_TimePeriod_InvalidOperation_StaticMethod()
        {
            TimePeriod p1 = new TimePeriod(3600);
            TimePeriod p2 = new TimePeriod(3600 * 4);

            p1 = TimePeriod.Minus(p1,p2);
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Minus_TimePeriod_InvalidOperation_Operator()
        {
            TimePeriod p1 = new TimePeriod(3600);
            TimePeriod p2 = new TimePeriod(3600 * 4);

            p1 = p1 - p2;
        }

        [TestMethod]
        public void EqualsTimePeriod_Obj_True()
        {
            object left = new TimePeriod(3661);
            TimePeriod right = new TimePeriod(3661);
            Assert.IsTrue(right.Equals(left));
        }

        [TestMethod]
        public void EqualsTimePeriod_Time_True()
        {
            TimePeriod left = new TimePeriod(3661);
            TimePeriod right = new TimePeriod(3661);
            Assert.IsTrue(right.Equals(left));
        }
        [TestMethod]
        public void EqualsTimePeriod_Obj_False()
        {
            object left = new TimePeriod(3661);
            TimePeriod right = new  TimePeriod(3662);
            Assert.IsFalse(right.Equals(left));
        }

        [TestMethod]
        public void EqualsTimePeriod_Time_False()
        {
            TimePeriod left =  new TimePeriod(3661);
            TimePeriod right = new TimePeriod(3662);
            Assert.IsFalse(right.Equals(left));
        }

        [TestMethod]
        public void CompareTimePeriodTo_TimeTimePeriod()
        {
            TimePeriod left1 =  new TimePeriod(3661);
            TimePeriod right1 = new TimePeriod(3662);
                                        
            TimePeriod left2 =  new TimePeriod(3661);
            TimePeriod right2 = new TimePeriod(3661);
                                        
            TimePeriod left3 =  new TimePeriod(3663);
            TimePeriod right3 = new TimePeriod(3661);

            Assert.IsTrue(left1.CompareTo(right1) < 0);
            Assert.IsTrue(left2.CompareTo(right2) == 0);
            Assert.IsTrue(left3.CompareTo(right3) > 0);
        }

        [TestMethod]
        public void OperatorsTimePeriod_Equal_NotEqual()
        {
            TimePeriod left1 = new TimePeriod(3661);
            TimePeriod right1 = new TimePeriod(3661);

            TimePeriod left2 = new TimePeriod(3661);
            TimePeriod right2 = new TimePeriod(3662);


            Assert.IsTrue(left1 == right1);
            Assert.IsTrue(left2 != right2);
        }

        [TestMethod]
        public void OperatorsTimePeriod_Greater_Lesser()
        {
            TimePeriod left =  new TimePeriod(3661);
            TimePeriod right = new TimePeriod(3662);

            Assert.IsTrue(left < right);
            Assert.IsFalse(left > right);
        }

        [TestMethod]
        public void OperatorsTimePeriod_GreaterOrEqual_LesserOrEqual()
        {
            TimePeriod left =  new TimePeriod(3661);
            TimePeriod right = new TimePeriod(3662);

            Assert.IsTrue(left <= right);
            Assert.IsFalse(left >= right);

            left = new TimePeriod(3662);

            Assert.IsTrue(left <= right);
            Assert.IsTrue(left >= right);
        }

        [TestMethod]
        public void HashCodeTimePeriod()
        {
            TimePeriod t1 = new TimePeriod(3661);
            TimePeriod t2 = new TimePeriod(3661);
                                    
            TimePeriod t3 = new TimePeriod(3662);
            TimePeriod t4 = new TimePeriod(3662);

            Assert.IsTrue(t1.GetHashCode() == t2.GetHashCode());
            Assert.IsTrue(t3.GetHashCode() == t4.GetHashCode());

            Assert.IsFalse(t1.GetHashCode() == t3.GetHashCode());
            Assert.IsFalse(t2.GetHashCode() == t4.GetHashCode());

        }
    }
}