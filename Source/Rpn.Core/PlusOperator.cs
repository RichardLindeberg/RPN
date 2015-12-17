using System;

namespace Rpn.Core
{
    public class PlusOperator : TwoInputOperator
    {
        protected override Decimal PerformOperation(Decimal numberA, Decimal numberB)
        {
            return numberA + numberB;
        }
    }
}