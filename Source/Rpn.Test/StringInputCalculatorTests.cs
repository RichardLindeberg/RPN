using System;
using NUnit.Framework;
using Rpn.Core;

namespace Rpn.Test
{
    [TestFixture]
    public class StringInputCalculatorTests
    {
        [Test]
        public void Given3_3_Multiply_ResultIs9()
        {
            var expected = "9";
            var sc = new StringInputCalculator();
            sc.EnterNewData("3");
            sc.EnterNewData("3");
            var actual = sc.EnterNewData("*");
            Assert.AreEqual(expected, actual, "Wrong result");
        }


        [Test]
        public void Givven3_5_6_Plus_Multiply_ResultIs_33()
        {
            var expected = "33";
            var calculator = new StringInputCalculator();
            Console.WriteLine(calculator.EnterNewData("3"));
            Console.WriteLine(calculator.EnterNewData("5"));
            Console.WriteLine(calculator.EnterNewData("6"));
            Console.WriteLine(calculator.EnterNewData("+"));
            var actual = calculator.EnterNewData("*");
            
            Assert.AreEqual(expected, actual, "Wrong result");
        }

        [Test]
        public void Givven9_Sqrt_ResultIs_3()
        {
            var expected = "3";
            var calculator = new StringInputCalculator();
            calculator.EnterNewData("9");
            var actual = calculator.EnterNewData("Sqrt");
            Assert.AreEqual(expected, actual, "Wrong result");
        }
    }
}