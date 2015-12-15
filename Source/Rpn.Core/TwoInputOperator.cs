using System;
using System.Collections.Generic;

namespace Rpn.Core
{
    public abstract class TwoInputOperator : IOperator
    {
        public decimal Calculate(Stack<decimal> stack)
        {
            var numberA = stack.Pop();
            var numberB = stack.Pop();
            
            return PerformOperation(numberA, numberB);
        }

        protected abstract Decimal PerformOperation(Decimal numberA, Decimal numberB);
    }
}