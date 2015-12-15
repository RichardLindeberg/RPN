using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rpn.Core;

namespace Rpn.Test
{
    [TestFixture]
    public class CalculatorTests
    {
        [Test]
        public void FiveAndFivePlussIsTen()
        {
            var expected = 10M;
            var calculator = new Calculator();
            calculator.AddNumber(5);
            calculator.AddNumber(5);
            calculator.AddOperator(Operator.Plus);
            var actaul = calculator.Calculate();
            Assert.AreEqual(expected, actaul, "Wrong result");
        }

        [Test]
        public void FiveAndFiveAndFivePlussPlussIsFiften()
        {
            var expected = 15M;
            var calculator = new Calculator();
            calculator.AddNumber(5);
            calculator.AddNumber(5);
            calculator.AddNumber(5);
            calculator.AddOperator(Operator.Plus);
            calculator.AddOperator(Operator.Plus);
            var actaul = calculator.Calculate();
            Assert.AreEqual(expected, actaul, "Wrong result");
        }

        [Test]
        public void FiveAndFivePlussFivePlussIsFiften()
        {
            var expected = 15M;
            var calculator = new Calculator();
            calculator.AddNumber(5);
            calculator.AddNumber(5);
            calculator.AddOperator(Operator.Plus);
            calculator.AddNumber(5);
            calculator.AddOperator(Operator.Plus);
            var actaul = calculator.Calculate();
            Assert.AreEqual(expected, actaul, "Wrong result");
        }

        [Test]
        public void OneTwoPlusThreemultiplyIs6()
        {
            var expected = 9M;
            var calculator = new Calculator();
            calculator.AddNumber(1);
            calculator.AddNumber(2);
            calculator.AddOperator(Operator.Plus);
            calculator.AddNumber(3);
            calculator.AddOperator(Operator.Multiply);
            var actaul = calculator.Calculate();
            Assert.AreEqual(expected, actaul, "Wrong result");
        }

        [Test]
        public void ThreeOneTwoPlusMultiplyIs6()
        {
            var expected = 9M;
            var calculator = new Calculator();
            calculator.AddNumber(3);
            calculator.AddNumber(1);
            calculator.AddNumber(2);
            calculator.AddOperator(Operator.Plus);
            calculator.AddOperator(Operator.Multiply);
            var actaul = calculator.Calculate();
            Assert.AreEqual(expected, actaul, "Wrong result");
        }

        [Test]
        public void Givven3_5_6_Plus_Multiply_ResultIs_33()
        {
            var expected = 33M;
            var calculator = new Calculator();
            calculator.AddNumber(3);
            calculator.AddNumber(5);
            calculator.AddNumber(6);
            calculator.AddOperator(Operator.Plus);
            calculator.AddOperator(Operator.Multiply);
            var actaul = calculator.Calculate();
            Assert.AreEqual(expected, actaul, "Wrong result");
        }

        [Test]
        public void Givven9_Sqrt_ResultIs_3()
        {
            var expected = 3M;
            var calculator = new Calculator();
            calculator.AddNumber(9);
            calculator.AddOperator(Operator.Sqrt);
            var actaul = calculator.Calculate();
            Assert.AreEqual(expected, actaul, "Wrong result");
        }
    }
}

