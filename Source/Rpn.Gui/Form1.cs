using System;
using System.Windows.Forms;
using Rpn.Core;

namespace Rpn.Gui
{
    public partial class Form1 : Form
    {
        private Calculator _calculator;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _calculator = new Calculator();
        }

        private void One_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if (btn == null)
            {
                throw new ArgumentOutOfRangeException("Sender must be a button");
            }
            _calculator.Add(btn.Text);
        }

        private void Enter_Click(object sender, EventArgs e)
        {
            _calculator.Add(Environment.NewLine);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBoxInput.Text = "";
            textBoxResult.Text = "";
            _calculator = new Calculator();
        }
    }
}
