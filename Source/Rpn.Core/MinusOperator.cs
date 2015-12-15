namespace Rpn.Core
{
    public class MinusOperator : TwoInputOperator
    {
        protected override decimal PerformOperation(decimal numberA, decimal numberB)
        {
            return numberA - numberB;
        }
    }
}