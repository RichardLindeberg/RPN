namespace Rpn.Core
{
    public class OperatorInput : IInput
    {
        public OperatorInput(Operator @operator)
        {
            Operator = @operator;
        }

        public Operator Operator { get; set; }
    }
}