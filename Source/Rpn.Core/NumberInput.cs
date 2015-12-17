using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rpn.Core
{
    public class NumberInput : IInput
    {
        public NumberInput(Decimal number)
        {
            this.Number = number;
        }

        public Decimal Number { get; set; }

        public override string ToString()
        {
            return Number.ToString(CultureInfo.InvariantCulture);
        }
    }
}
