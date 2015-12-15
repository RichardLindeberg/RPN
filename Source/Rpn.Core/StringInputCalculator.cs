using System;
using System.Collections.Generic;
using System.Globalization;

namespace Rpn.Core
{
    public class StringInputCalculator
    {
        
        private Stack<Decimal> numberStack = new Stack<decimal>();

        public string EnterNewData(string input)
        {
            decimal number;
            if (Decimal.TryParse(input, out number))
            {
                numberStack.Push(number);
                return number.ToString(CultureInfo.InvariantCulture);
            }
            IOperator op;
            if (input.TryParse(out op))
            {
                var result = op.Calculate(numberStack);
                numberStack.Push(result);
                return result.ToString(CultureInfo.InvariantCulture);
            }
            return "failed";
        }
    }

    public static class OperatorParserExtension
    {
        public static bool TryParse(this string input, out IOperator @operator)
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