using System;
using System.Collections.Generic;

namespace Rpn.Core
{
    public abstract class SingleInputOperator : IOperator
    {
        public Decimal Calculate(Stack<Decimal> stack)
        {
            var numberA = stack.Pop();
            
            return PerformOperation(numberA);
        }

        public string ParseAndRemove(string input, out IOperator @operator)
        {
            throw new NotImplementedException();
        }

        protected abstract Decimal PerformOperation(Decimal numberA);
    }
}