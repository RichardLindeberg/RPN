namespace Rpn.Core
{
    public class MultiplyOperator : TwoInputOperator
    {
        protected override decimal PerformOperation(decimal numberA, decimal numberB)
        {
            return numberA * numberB;
        }
    }
}