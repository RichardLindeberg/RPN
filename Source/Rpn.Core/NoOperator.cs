using System;
using System.Collections.Generic;

namespace Rpn.Core
{
    public class NoOperator : IOperator
    {
        public Decimal Calculate(Stack<Decimal> stack)
        {
            throw new InvalidOperationException("I'm no real operator");
        }

        public string ParseAndRemove(string input, out IOperator @operator)
        {
            throw new InvalidOperationException();
        }
    }
}