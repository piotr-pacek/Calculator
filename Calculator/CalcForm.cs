using Calculator.Data;
using System.Globalization;

namespace Calculator
{
    public partial class CalcForm : Form
    {
        private readonly char[] operators = ['+', '-', '*', '/'];

        private readonly CalculatorEngine engine;

        public CalcForm()
        {
            KeyPreview = true;
            KeyPress += CalcForm_KeyPress;

            var context = new CalculatorDbContext();
            var repository = new OperationRepository(context);

            engine = new CalculatorEngine(repository);

            InitializeComponent();
        }

        private void CalcForm_Load(object sender, EventArgs e)
        {
            using (var db = new CalculatorDbContext())
            {
                db.Database.EnsureCreated();
            }

            engine.ResetDatabase();
            engine.ResetCalculator();
            resultBox.Text = engine.CurrentDisplay;
        }

        private void CalcForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (tabControl.SelectedTab == calculatorTab)
            {
                HandleCalculatorKeyPress(e);
            }
        }

        private void HandleCalculatorKeyPress(KeyPressEventArgs e)
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
            if (tabControl.SelectedTab == calculatorTab)
            {
                switch (keyData)
                {
                    case Keys.Decimal:
                        engine.WriteDigit('.');
                        break;
                    case Keys.Escape:
                        engine.ResetCalculator();
                        break;
                    case Keys.Enter:
                        engine.ExecuteEqualsAction();
                        resultBox.Text = engine.CurrentDisplay;
                        RefreshHistory();
                        return true;
                    case Keys.Back:
                        engine.Backspace();
                        break;
                }

                resultBox.Text = engine.CurrentDisplay;
            }
            else if (tabControl.SelectedTab == currencyTab && keyData == Keys.Enter)
            {
                _ = FindBestDay();
                return true;
            }

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
            RefreshHistory();
        }

        private void NegateButton_Click(object sender, EventArgs e)
        {
            engine.Negate();
            resultBox.Text = engine.CurrentDisplay;
        }

        private void CButton_Click(object sender, EventArgs e)
        {
            engine.ResetCalculator();
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

        private void RefreshHistory()
        {
            var operations = engine.GetHistory();

            historyListBox.Items.Clear();
            foreach (var op in operations)
            {
                historyListBox.Items.Add($"{op.Expression} = {op.Result}");
            }
        }

        private async void FindBestDayButton_Click(object sender, EventArgs e)
        {
            bool flowControl = await FindBestDay();
            if (!flowControl)
            {
                return;
            }
        }

        private async Task<bool> FindBestDay()
        {
            string currency = currencyBox.SelectedItem?.ToString();

            currencyValueTextbox.Text = currencyValueTextbox.Text
                .Replace(".", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)
                .Replace(",", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

            if (string.IsNullOrEmpty(currency))
            {
                MessageBox.Show("Choose currency.");
                return false;
            }


            if (!decimal.TryParse(currencyValueTextbox.Text, out decimal amount))
            {
                MessageBox.Show("Enter correct value.");
                return false;
            }

            DateTime fromDate = dateFromPicker.Value.Date;
            DateTime toDate = dateToPicker.Value.Date;

            var service = new CurrencyService(new CalculatorDbContext());

            try
            {
                await service.FetchAndSaveRates(currency, fromDate, toDate);

                var (bestRate, convertedAmount) = service.GetBestConversion(currency, fromDate, toDate, amount);

                if (bestRate != null)
                {
                    bestDayLabel.Text = $"Best day: {bestRate.Date:yyyy-MM-dd}\n" +
                                       $"Rate: {bestRate.Rate:F2} PLN\n" +
                                       $"Value after conversion: {convertedAmount:F2} PLN";
                }
                else
                {
                    bestDayLabel.Text = "No rates available in given period.";
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Error with retrieving rates data: {ex.Message}");
            }

            return true;
        }
    }
}
