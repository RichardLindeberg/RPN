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
            calculator.Add(5);
            calculator.Add(5);
            calculator.Add(OperatorEnum.Plus);
            var actaul = calculator.Calculate();
            Assert.AreEqual(expected, actaul, "Wrong result");
        }

        [Test]
        public void FiveAndFiveAndFivePlussPlussIsFiften()
        {
            var expected = 15M;
            var calculator = new Calculator();
            calculator.Add(5);
            calculator.Add(5);
            calculator.Add(5);
            calculator.Add(OperatorEnum.Plus);
            calculator.Add(OperatorEnum.Plus);
            var actaul = calculator.Calculate();
            Assert.AreEqual(expected, actaul, "Wrong result");
        }

        [Test]
        public void FiveAndFivePlussFivePlussIsFiften()
        {
            var expected = 15M;
            var calculator = new Calculator();
            calculator.Add(5);
            calculator.Add(5);
            calculator.Add(OperatorEnum.Plus);
            calculator.Add(5);
            calculator.Add(OperatorEnum.Plus);
            var actaul = calculator.Calculate();
            Assert.AreEqual(expected, actaul, "Wrong result");
        }

        [Test]
        public void OneTwoPlusThreemultiplyIs6()
        {
            var expected = 9M;
            var calculator = new Calculator();
            calculator.Add(1);
            calculator.Add(2);
            calculator.Add(OperatorEnum.Plus);
            calculator.Add(3);
            calculator.Add(OperatorEnum.Multiply);
            var actaul = calculator.Calculate();
            Assert.AreEqual(expected, actaul, "Wrong result");
        }

        [Test]
        public void ThreeOneTwoPlusMultiplyIs6()
        {
            var expected = 9M;
            var calculator = new Calculator();
            calculator.Add(3);
            calculator.Add(1);
            calculator.Add(2);
            calculator.Add(OperatorEnum.Plus);
            calculator.Add(OperatorEnum.Multiply);
            var actaul = calculator.Calculate();
            Assert.AreEqual(expected, actaul, "Wrong result");
        }

        [Test]
        public void Givven3_5_6_Plus_Multiply_ResultIs_33()
        {
            var expected = 33M;
            var calculator = new Calculator();
            calculator.Add(3);
            calculator.Add(5);
            calculator.Add(6);
            calculator.Add(OperatorEnum.Plus);
            calculator.Add(OperatorEnum.Multiply);
            var actaul = calculator.Calculate();
            Assert.AreEqual(expected, actaul, "Wrong result");
        }

        [Test]
        public void Givven9_Sqrt_ResultIs_3()
        {
            var expected = 3M;
            var calculator = new Calculator();
            calculator.Add(9);
            calculator.Add(OperatorEnum.Sqrt);
            var actaul = calculator.Calculate();
            Assert.AreEqual(expected, actaul, "Wrong result");
        }

        [Test]
        public void Givven3_3_Multiply_Sqrt_ResultIs_3()
        {
            var expected = 3M;
            var calculator = new Calculator();
            calculator.Add(3);
            calculator.Add(3);
            calculator.Add(OperatorEnum.Multiply);
            calculator.Add(OperatorEnum.Sqrt);
            var actaul = calculator.Calculate();
            Assert.AreEqual(expected, actaul, "Wrong result");
        }

        [Test]
        public void Givven5_2_Minus_ResultIs_3()
        {
            var expected = 3M;
            var calculator = new Calculator();
            calculator.Add(5);
            calculator.Add(2);
            calculator.Add(OperatorEnum.Minus);
            var actaul = calculator.Calculate();
            Assert.AreEqual(expected, actaul, "Wrong result");
        }

        [Test]
        public void Given6_2_Divide_ResultIs_3()
        {
            var expected = 3M;
            var calculator = new Calculator();
            calculator.Add(6);
            calculator.Add(2);
            calculator.Add(OperatorEnum.Dividie);
            var actaul = calculator.Calculate();
            Assert.AreEqual(expected, actaul, "Wrong result");
        }


        [Test]
        public void Given5_2_Divide_ResultIs_3()
        {
            var expected = 2.5M;
            var calculator = new Calculator();
            calculator.Add(5);
            calculator.Add(2);
            calculator.Add(OperatorEnum.Dividie);
            var actaul = calculator.Calculate();
            Assert.AreEqual(expected, actaul, "Wrong result");
        }
    }
}

