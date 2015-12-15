namespace Rpn.Core
{
    public class DivideOperator : TwoInputOperator
    {
        protected override decimal PerformOperation(decimal numberA, decimal numberB)
        {
            return numberA / numberB;
        }
    }
}