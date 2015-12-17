using System;

namespace Rpn.Core
{
    public class MultiplyOperator : TwoInputOperator
    {
        protected override Decimal PerformOperation(Decimal numberA, Decimal numberB)
        {
            return numberA * numberB;
        }

        public override string ToString()
        {
            return "*";
        }
    }
}