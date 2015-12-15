using System;
using System.Collections.Generic;

namespace Rpn.Core
{
    public abstract class SingleInputOperator : IOperator
    {
        public decimal Calculate(Stack<decimal> stack)
        {
            var numberA = stack.Pop();
            
            return PerformOperation(numberA);
        }

        protected abstract Decimal PerformOperation(Decimal numberA);
    }
}