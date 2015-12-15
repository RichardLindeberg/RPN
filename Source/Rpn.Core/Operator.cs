using System;
using System.Collections.Generic;

namespace Rpn.Core
{
    public enum Operator
    {
        Plus,
        Minus,
        Multiply,
        Dividie, 
        Sqrt
    }

    public interface IOperator : IInput
    {
        Decimal Calculate(Stack<Decimal> stack);
    }

    public abstract class TwoInputOperator : IOperator
    {
        public decimal Calculate(Stack<Decimal> stack)
        {
            var numberA = stack.Pop();
            var numberB = stack.Pop();
            
            return PerformOperation(numberA, numberB);
        }

        protected abstract Decimal PerformOperation(Decimal numberA, Decimal numberB);
    }

    public abstract class SingleInputOperator : IOperator
    {
        public decimal Calculate(Stack<Decimal> stack)
        {
            var numberA = stack.Pop();
            
            return PerformOperation(numberA);
        }

        protected abstract Decimal PerformOperation(Decimal numberA);
    }

    public class SqrtOperator : SingleInputOperator
    {
        protected override decimal PerformOperation(decimal numberA)
        {
            return (decimal) Math.Sqrt((double)numberA);
        }
    }

    public class PlusOperator : TwoInputOperator
    {
        protected override decimal PerformOperation(decimal numberA, decimal numberB)
        {
            return numberA + numberB;
        }
    }

    public class MinusOperator : TwoInputOperator
    {
        protected override decimal PerformOperation(decimal numberA, decimal numberB)
        {
            return numberA - numberB;
        }
    }

    public class DivideOperator : TwoInputOperator
    {
        protected override decimal PerformOperation(decimal numberA, decimal numberB)
        {
            return numberA / numberB;
        }
    }

    public class MultiplyOperator : TwoInputOperator
    {
        protected override decimal PerformOperation(decimal numberA, decimal numberB)
        {
            return numberA * numberB;
        }
    }
}