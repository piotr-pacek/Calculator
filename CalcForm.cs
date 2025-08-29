namespace Calculator
{
    public partial class CalcForm : Form
    {
        public CalcForm()
        {
            InitializeComponent();
        }

        private void CalcForm_Load(object sender, EventArgs e)
        {

        }

        private void CalcForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                resultBox.Text += e.KeyChar;
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                resultBox.Text += btn.Text;
            }
        }

    }
}
