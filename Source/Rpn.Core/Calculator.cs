using System;
using System.Collections.Generic;

namespace Rpn.Core
{
    public class Calculator
    {
        private readonly Queue<IInput> _inputQueue = new Queue<IInput>();

        public void AddNumber(Decimal number)
        {
            _inputQueue.Enqueue(new NumberInput(number));
        }

        public void AddOperator(IOperator @operator)
        {
            _inputQueue.Enqueue(@operator);
        }

        public void AddOperator(Operator @operator)
        {
            IOperator op;
            switch (@operator)
            {
                case Operator.Plus:
                    op = new PlusOperator();
                    break;
                case Operator.Minus:
                    op = new MinusOperator();
                    break;
                case Operator.Dividie:
                    op = new DivideOperator();
                    break;
                case Operator.Multiply:
                    op = new MultiplyOperator();
                    break;
                case Operator.Sqrt:
                    op = new SqrtOperator();
                    break;
                default:
                    throw new InvalidOperationException($"{@operator} is not a known operator");
            }
            _inputQueue.Enqueue(op);

        }

        public decimal Calculate()
        {
            var numbers = new Stack<Decimal>();
            while (_inputQueue.Count > 0)
            {

                var dequed = _inputQueue.Dequeue();

                var number = dequed as NumberInput;
                if (number != null)
                {
                    numbers.Push(number.Number);
                }

                var op = dequed as IOperator;
                if (op != null)
                {

                    numbers.Push(op.Calculate(numbers));
                }
            }
            if (numbers.Count > 1)
            {
                throw new InvalidOperationException("The stack is not empty, have you forgotten an operator?");
            }
            return numbers.Pop();
        }
    }
}