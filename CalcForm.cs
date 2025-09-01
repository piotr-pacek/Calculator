namespace Calculator
{
    public partial class CalcForm : Form
    {
        private bool isDecimal = false;
        private bool isFirstNumber = true;
        private bool canOverwriteResultBox = false;
        private bool resultCalculated = false;
        private double previousNumber;
        private double currentNumber;
        private Operation currentOperation;

        private char[] operators = { '+', '-', '*', '/' };


        public CalcForm()
        {
            KeyPreview = true;
            KeyPress += CalcForm_KeyPress;

            InitializeComponent();
        }

        private void CalcForm_Load(object sender, EventArgs e)
        {
            resultBox.Text = "0";
        }

        private void CalcForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '.')
            {
                WriteDigit(e.KeyChar.ToString());
            }
            else if (operators.Contains(e.KeyChar))
            {
                currentNumber = ParseResultBox();

                currentOperation = e.KeyChar switch
                {
                    '+' => currentOperation = Operation.Add,
                    '-' => currentOperation = Operation.Substract,
                    '*' => currentOperation = Operation.Multiply,
                    '/' => currentOperation = Operation.Divide,
                    _ => throw new NotSupportedException()
                };

                ExecuteCommand(previousNumber, currentNumber, currentOperation);
            }
            else if (e.KeyChar == '=')
            {
                EqualsButton_Click(sender, e);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                ResetCalculator();
            }
            else if (keyData == Keys.Enter)
            {
                ExecuteEqualsAction();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            WriteDigit(button.Text);
        }

        private void WriteDigit(string digit)
        {
            if (!isDecimal && (digit == "." || digit == ","))
            {
                resultBox.Text += ",";
                isDecimal = true;
            }
            else if ((isFirstNumber || (!canOverwriteResultBox && !resultCalculated)) && !resultBox.Text.Equals("0"))
            {
                resultBox.Text += digit;
            }
            else
            {
                resultBox.Text = digit;

                if (resultCalculated)
                    isFirstNumber = true;

                canOverwriteResultBox = false;
                resultCalculated = false;
            }
        }

        private void OperationButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            currentOperation = button.Name switch
            {
                "plusButton" => Operation.Add,
                "minusButton" => Operation.Substract,
                "multiplyButton" => Operation.Multiply,
                "divideButton" => Operation.Divide,
                _ => throw new NotSupportedException()
            };

            currentNumber = ParseResultBox();

            ExecuteCommand(previousNumber, currentNumber, currentOperation);
        }

        private void EqualsButton_Click(object sender, EventArgs e)
        {
            ExecuteEqualsAction();
        }

        private void ExecuteEqualsAction()
        {
            if (isFirstNumber)
            {
                previousNumber = ParseResultBox();
                isFirstNumber = false;
            }
            else
            {
                if (!resultCalculated)
                    currentNumber = ParseResultBox();

                previousNumber = CalculateResult(previousNumber, currentNumber, currentOperation);

                resultBox.Text = previousNumber.ToString();
            }

            canOverwriteResultBox = true;
            resultCalculated = true;
            isDecimal = false;
        }

        public void ExecuteCommand(double firstNumber, double secondNumber, Operation operation)
        {
            if (isFirstNumber || resultCalculated)
            {
                previousNumber = currentNumber;
                isFirstNumber = false;
                resultCalculated = false;
            }
            else
            {
                previousNumber = CalculateResult(firstNumber, secondNumber, operation);

                resultBox.Text = previousNumber.ToString();
            }

            canOverwriteResultBox = true;
            isDecimal = false;
        }

        private static double CalculateResult(double firstNumber, double secondNumber, Operation operation)
        {
            return operation switch
            {
                Operation.Add => firstNumber + secondNumber,
                Operation.Substract => firstNumber - secondNumber,
                Operation.Multiply => firstNumber * secondNumber,
                Operation.Divide => firstNumber / secondNumber,
                _ => throw new NotSupportedException(),
            };
        }

        private void NegateButton_Click(object sender, EventArgs e)
        {
            if (resultBox.Text != "0")
            {
                var negatedNumber = ParseResultBox() * -1;
                currentNumber = negatedNumber;
                resultBox.Text = negatedNumber.ToString();
            }
        }

        private void ResetCalculator()
        {
            resultBox.Text = "0";
            isFirstNumber = true;
            resultCalculated = false;
            canOverwriteResultBox = true;
            isDecimal = false;
        }

        private double ParseResultBox()
        {
            return double.TryParse(resultBox.Text, out var number) ? number : 0;
        }
    }

    public enum Operation
    {
        Add,

        Substract,

        Multiply,

        Divide
    }
}
