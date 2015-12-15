using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rpn.Core
{
    public enum Operator
    {
        Plus,
        Minus,
        Times,
        Dive
    }

    public interface IInput
    {

    }

    public class NumberInput : IInput
    {
        private int number;

        public NumberInput(int number)
        {
            this.number = number;
        }

        public int Tal { get; set; }
    }

    public class OperatorInput : IInput
    {
        public OperatorInput(Operator @operator)
        {
            Operator = @operator;
        }

        public Operator Operator { get; set; }
    }

    public class Calculator
    {
        private List<IInput> stack = new List<IInput>();

        public void AddNumber(int number)
        {
            stack.Add(new NumberInput(number));
        }

        public void AddOperator(Operator @operator)
        {
            stack.Add(new OperatorInput(@operator));
        }

        public decimal Calculate()
        {
            return 0M;
        }
    }
}
