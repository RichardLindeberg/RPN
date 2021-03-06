using System;
using System.Collections.Generic;

namespace Rpn.Core
{
    public abstract class TwoInputOperator : IOperator
    {
        public Decimal Calculate(Stack<Decimal> stack)
        {
            
            var numberB = stack.Pop();
            var numberA = stack.Pop();

            return PerformOperation(numberA, numberB);
        }

        public string ParseAndRemove(string input, out IOperator @operator)
        {
            switch (input.Substring(0, 1))
            {
                case "+":
                    @operator = new PlusOperator();
                    return input.Substring(1);
                case "-":
                    @operator = new MinusOperator();
                    return input.Substring(1);
                case "/":
                    @operator = new DivideOperator();
                    return input.Substring(1);
                case "*":
                    @operator = new MultiplyOperator();
                    return input.Substring(1);
            }
            @operator = new NoOperator();
            return input;
        }

        protected abstract Decimal PerformOperation(Decimal numberA, Decimal numberB);
    }
}