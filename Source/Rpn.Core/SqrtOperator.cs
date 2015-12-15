using System;

namespace Rpn.Core
{
    public class SqrtOperator : SingleInputOperator
    {
        protected override decimal PerformOperation(decimal numberA)
        {
            return (decimal) Math.Sqrt((double)numberA);
        }
    }
}