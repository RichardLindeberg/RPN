namespace Rpn.Core
{
    public class PlusOperator : TwoInputOperator
    {
        protected override decimal PerformOperation(decimal numberA, decimal numberB)
        {
            return numberA + numberB;
        }
    }
}