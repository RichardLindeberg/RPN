using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Rpn.Core
{
    public class StringInputCalculator
    {
        
        private Stack<Decimal> numberStack = new Stack<decimal>();

        public string EnterNewData(string input)
        {
            var splitted_input = input.Split(' ');
            string lastResult = "no input";
            foreach (var str in splitted_input)
            {
                lastResult = ParseInput(str);
            }
            return lastResult;
        }

        private string ParseInput(string input)
        {
            decimal number;
            if (Decimal.TryParse(input, out number))
            {
                numberStack.Push(number);
                return number.ToString(CultureInfo.InvariantCulture);
            }
            IOperator op;
            if (OperatorParser.TryParse(input, out op))
            {
                var result = op.Calculate(numberStack);
                numberStack.Push(result);
                return result.ToString(CultureInfo.InvariantCulture);
            }
            return "failed";
        }
    }

    public static class OperatorParser
    {
        public static bool TryParse(string input, out IOperator @operator)
        {
            switch (input.ToLowerInvariant())
            {
                case "+":
                    @operator = new PlusOperator();
                    return true;
                case "-":
                    @operator = new MinusOperator();
                    return true;
                case "/":
                    @operator = new DivideOperator();
                    return true;
                case "*":
                    @operator = new MultiplyOperator();
                    return true;
                case "sqrt":
                    @operator = new SqrtOperator();
                    return true;
            }
            @operator = new PlusOperator();
            return false;
        }
    }
}