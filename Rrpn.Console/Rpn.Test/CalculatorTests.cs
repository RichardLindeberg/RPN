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
            Assert.AreEqual(actaul, expected, "Wrong result");
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
            Assert.AreEqual(actaul, expected, "Wrong result");
        }
    }
}

