using System;
using System.Collections.Generic;

namespace Rpn.Core
{
    public class Calculator
    {
        private Queue<IInput> stack = new Queue<IInput>();

        public void AddNumber(Decimal number)
        {
            stack.Enqueue(new NumberInput(number));
        }

        public void AddOperator(Operator @operator)
        {
            stack.Enqueue(new OperatorInput(@operator));
        }

        public decimal Calculate()
        {
            return DoCalculation();
        }

        private decimal DoCalculation()
        {
            var numbers = new Stack<Decimal>();
            while (stack.Count > 0)
            {

                var dequed = stack.Dequeue();

                var number = dequed as NumberInput;
                if (number != null)
                {
                    numbers.Push(number.Number);
                }
                
                var op = dequed as OperatorInput;
                if (op != null)
                {
                    var numberA = numbers.Pop();
                    var numberB = numbers.Pop();
                    numbers.Push(Calculate(numberA, numberB, op.Operator));
                }
            }
            if (numbers.Count > 1)
            {
                throw new InvalidOperationException("The stack is not empty, have you forgotten an operator?");
            }
            return numbers.Pop();
            
        }

        private decimal Calculate(Decimal numberA, Decimal numberB, Operator @operator)
        {
            switch (@operator)
            {
                case Operator.Plus:
                    return numberA + numberB;
                case Operator.Minus:
                    return numberA - numberB;
                case Operator.Dividie:
                    return numberA / numberB;
                case Operator.Multiply:
                    return numberA*numberB;
                default: 
                    throw new InvalidOperationException($"{@operator} is not a known operator");
            }
        }
    }
}