using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rpn.Core;

namespace Rpn.Gui
{
    public partial class Form1 : Form
    {
        private Calculator _calculator;
        private string _currentNumber;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _calculator = new Calculator();
        }

        private void AddCurrentNumber()
        {
            decimal number;
            if (decimal.TryParse(_currentNumber, out number))
            {
                _calculator.Add(number);
            }
            _currentNumber = string.Empty;
            
        }

        private void One_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if (btn == null)
            {
                throw new ArgumentOutOfRangeException("Sender must be a button");
            }
            _currentNumber += (string) btn.Tag;
            textBoxInput.Text += (string) btn.Tag;

        }

        private void Pluss_Click(object sender, EventArgs e)
        {
            AddCurrentNumber();
            _calculator.Add(new PlusOperator());
        }

        private void Divide_Click(object sender, EventArgs e)
        {
            AddCurrentNumber();
            _calculator.Add(new DivideOperator());
        }

        private void Multiply_Click(object sender, EventArgs e)
        {
            AddCurrentNumber();
            _calculator.Add(new MultiplyOperator());
        }

        private void Dividie_Click(object sender, EventArgs e)
        {
            AddCurrentNumber();
            _calculator.Add(new DivideOperator());
        }

        private void Sqrt_Click(object sender, EventArgs e)
        {
            AddCurrentNumber();
            _calculator.Add(new SqrtOperator());
        }

        private void Enter_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentNumber))
            {
                textBoxResult.Text = _calculator.Calculate().ToString(CultureInfo.InvariantCulture);
                
            }
            else
            {
                AddCurrentNumber();
                textBoxInput.Text += " ";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBoxInput.Text = "";
            textBoxResult.Text = "";
            _currentNumber = "";
            _calculator = new Calculator();
        }
    }
}
