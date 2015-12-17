using System;

namespace Rpn.Core
{
    public class SqrtOperator : SingleInputOperator
    {
        protected override Decimal PerformOperation(Decimal numberA)
        {
            return (Decimal) Math.Sqrt((Double)numberA);
        }
    }
}