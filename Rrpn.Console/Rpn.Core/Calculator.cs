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
            var numbers = new Queue<Decimal>();
            while (stack.Count > 0)
            {

                var popped = stack.Dequeue();

                var number = popped as NumberInput;
                if (number != null)
                {
                    numbers.Enqueue(number.Number);
                }
                
                var op = popped as OperatorInput;
                if (op != null)
                {
                    var numberA = numbers.Dequeue();
                    var numberB = numbers.Dequeue();
                    numbers.Enqueue(Calculate(numberA, numberB, op.Operator));
                }
            }
            return numbers.Dequeue();
            throw new InvalidOperationException("What have you done? Implemented a new class withouth handling it?");
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