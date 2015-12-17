using System;

namespace Rpn.Core
{
    public class StringParserForcalculator
    {
        private readonly Calculator _calculator;

        public StringParserForcalculator(Calculator calculator)
        {
            _calculator = calculator;
        }

        private string _currentNumber;

        public string NumberBuffer => _currentNumber;

        public void Parse(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("input was null or empty");
            }

            int number;
            if (int.TryParse(input, out number))
            {
                _currentNumber += input;
            }
            if (string.Compare("sqrt", input, StringComparison.InvariantCultureIgnoreCase) == 0)
            {
                AddCurentNumberToInput();
                _calculator.Add(new SqrtOperator());
            }

            if (input == Environment.NewLine)
            {
                AddCurentNumberToInput();
            }

            switch (input[0])
            {
                case '\u221A':
                    AddCurentNumberToInput();
                    _calculator.Add(new SqrtOperator());
                    break;
                case '+':
                    AddCurentNumberToInput();
                    _calculator.Add(new PlusOperator());
                    break;
                case '-':
                    AddCurentNumberToInput();
                    _calculator.Add(new MinusOperator());
                    break;
                case '*':
                    AddCurentNumberToInput();
                    _calculator.Add(new MultiplyOperator());
                    break;
                case '/':
                    AddCurentNumberToInput();
                    _calculator.Add(new DivideOperator());
                    break;
            }
            
        }

        private void AddCurentNumberToInput()
        {
            var ip = CurrentNumberToInput();
            if (ip != null)
            {
                _calculator.Add(ip);
            }
        }

        private NumberInput CurrentNumberToInput()
        {
            if (string.IsNullOrEmpty(_currentNumber) == false)
            {
                decimal d;
                if (Decimal.TryParse(_currentNumber, out d))
                {
                    _currentNumber = "";
                    {
                        return new NumberInput(d);
                    }
                }
            }
            return null;
        }
    }
}