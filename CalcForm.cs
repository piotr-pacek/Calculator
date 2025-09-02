namespace Calculator
{
    public partial class CalcForm : Form
    {
        private readonly char[] operators = ['+', '-', '*', '/'];

        private readonly CalculatorEngine engine = new();

        public CalcForm()
        {
            KeyPreview = true;
            KeyPress += CalcForm_KeyPress;

            InitializeComponent();
        }

        private void CalcForm_Load(object sender, EventArgs e)
        {
            engine.Reset();
            resultBox.Text = engine.CurrentDisplay;
        }

        private void CalcForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '.')
            {
                engine.WriteDigit(e.KeyChar);
            }
            else if (operators.Contains(e.KeyChar))
            {
                engine.ExecuteCommand(e.KeyChar.ToString());
            }
            else if (e.KeyChar == '=')
            {
                engine.ExecuteEqualsAction();
            }

            resultBox.Text = engine.CurrentDisplay;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Decimal)
            {
                engine.WriteDigit('.');
            }
            else if (keyData == Keys.Escape)
            {
                engine.Reset();
            }
            else if (keyData == Keys.Enter)
            {
                engine.ExecuteEqualsAction();
                resultBox.Text = engine.CurrentDisplay;
                return true;
            }

            resultBox.Text = engine.CurrentDisplay;
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            engine.WriteDigit(button.Text[0]);
            resultBox.Text = engine.CurrentDisplay;
        }

        private void OperationButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            engine.ExecuteCommand(button.Name);
            resultBox.Text = engine.CurrentDisplay;
        }

        private void EqualsButton_Click(object sender, EventArgs e)
        {
            engine.ExecuteEqualsAction();
            resultBox.Text = engine.CurrentDisplay;
        }

        private void NegateButton_Click(object sender, EventArgs e)
        {
            engine.Negate();
            resultBox.Text = engine.CurrentDisplay;
        }

        private void CButton_Click(object sender, EventArgs e)
        {
            engine.Reset();
            resultBox.Text = engine.CurrentDisplay;
        }

        private void CEButton_Click(object sender, EventArgs e)
        {
            engine.CE();
            resultBox.Text = engine.CurrentDisplay;
        }

        private void BackspaceButton_Click(object sender, EventArgs e)
        {
            engine.Backspace();
            resultBox.Text = engine.CurrentDisplay;
        }
    }
}
