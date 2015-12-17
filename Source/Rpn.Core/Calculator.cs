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

        public void AddOperator(OperatorEnum operatorEnum)
        {
            IOperator op;
            switch (operatorEnum)
            {
                case OperatorEnum.Plus:
                    op = new PlusOperator();
                    break;
                case OperatorEnum.Minus:
                    op = new MinusOperator();
                    break;
                case OperatorEnum.Dividie:
                    op = new DivideOperator();
                    break;
                case OperatorEnum.Multiply:
                    op = new MultiplyOperator();
                    break;
                case OperatorEnum.Sqrt:
                    op = new SqrtOperator();
                    break;
                default:
                    throw new InvalidOperationException($"{operatorEnum} is not a known operator");
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
                    var opResult = op.Calculate(numbers);
                    numbers.Push(opResult);
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