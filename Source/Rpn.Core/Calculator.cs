using System;
using System.Collections.Generic;
using System.Globalization;

namespace Rpn.Core
{
    public class Calculator
    {
        private readonly List<IInput> _inputQueue = new List<IInput>();

        public Calculator()
        {
            _stringParserForcalculator = new StringParserForcalculator(this);
        }

        private StringParserForcalculator _stringParserForcalculator;

        public void Add(string input)
        {
            _stringParserForcalculator.Parse(input);
        }



        public string GetInputAsString()
        {
            var res = "";
            foreach (var input in _inputQueue)
            {
                res += input.ToString();
                if (input is NumberInput)
                {
                    res += " ";
                }
            }
            res += _stringParserForcalculator.NumberBuffer;
            return res.Trim();
        }

        public void Add(Decimal number)
        {
            _inputQueue.Add(new NumberInput(number));
        }
       
        public void Add(IInput input)
        {
            _inputQueue.Add(input);
        }

        public void Add(OperatorEnum operatorEnum)
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
            _inputQueue.Add(op);

        }

        public decimal Calculate()
        {
            var numbers = new Stack<Decimal>();
            foreach (var input in _inputQueue)
            {
                var number = input as NumberInput;
                if (number != null)
                {
                    numbers.Push(number.Number);
                }

                var op = input as IOperator;
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

        public string CalculateAsString()
        {
            try
            {
                return Calculate().ToString(CultureInfo.CurrentCulture);
            }
            catch (InvalidOperationException ex)
            {
                return "Not computable";
            }
        }
    }
}