using System;
using System.Collections.Generic;

namespace Rpn.Core
{
    public interface IOperator : IInput
    {
        Decimal Calculate(Stack<Decimal> stack);

        string ParseAndRemove(string input, out IOperator @operator);
    }
}