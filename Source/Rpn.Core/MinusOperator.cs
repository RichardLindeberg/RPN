using System;

namespace Rpn.Core
{
    public class MinusOperator : TwoInputOperator
    {
        protected override Decimal PerformOperation(Decimal numberA, Decimal numberB)
        {
            return numberA - numberB;
        }
    }
}