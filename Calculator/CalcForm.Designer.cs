namespace Calculator
{
    partial class CalcForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            digit1 = new Button();
            digit2 = new Button();
            digit3 = new Button();
            digit4 = new Button();
            digit5 = new Button();
            digit6 = new Button();
            digit7 = new Button();
            digit8 = new Button();
            digit9 = new Button();
            digit0 = new Button();
            resultBox = new TextBox();
            plusButton = new Button();
            equalsButton = new Button();
            minusButton = new Button();
            multiplyButton = new Button();
            divideButton = new Button();
            commaButton = new Button();
            negateButton = new Button();
            cButton = new Button();
            ceButton = new Button();
            backspaceButton = new Button();
            historyListBox = new ListBox();
            tabControl = new TabControl();
            calculatorTab = new TabPage();
            currencyTab = new TabPage();
            bestDayLabel = new Label();
            currencyLabel = new Label();
            dateToLabel = new Label();
            dateFromLabel = new Label();
            valueLabel = new Label();
            dateToPicker = new DateTimePicker();
            dateFromPicker = new DateTimePicker();
            currencyBox = new ComboBox();
            findBestDayButton = new Button();
            currencyValueTextbox = new TextBox();
            tabControl.SuspendLayout();
            calculatorTab.SuspendLayout();
            currencyTab.SuspendLayout();
            SuspendLayout();
            // 
            // digit1
            // 
            digit1.Location = new Point(6, 132);
            digit1.Name = "digit1";
            digit1.Size = new Size(50, 25);
            digit1.TabIndex = 0;
            digit1.Text = "1";
            digit1.UseVisualStyleBackColor = true;
            digit1.Click += Button_Click;
            // 
            // digit2
            // 
            digit2.Location = new Point(62, 134);
            digit2.Name = "digit2";
            digit2.Size = new Size(50, 25);
            digit2.TabIndex = 1;
            digit2.Text = "2";
            digit2.UseVisualStyleBackColor = true;
            digit2.Click += Button_Click;
            // 
            // digit3
            // 
            digit3.Location = new Point(118, 134);
            digit3.Name = "digit3";
            digit3.Size = new Size(50, 25);
            digit3.TabIndex = 2;
            digit3.Text = "3";
            digit3.UseVisualStyleBackColor = true;
            digit3.Click += Button_Click;
            // 
            // digit4
            // 
            digit4.Location = new Point(6, 101);
            digit4.Name = "digit4";
            digit4.Size = new Size(50, 25);
            digit4.TabIndex = 3;
            digit4.Text = "4";
            digit4.UseVisualStyleBackColor = true;
            digit4.Click += Button_Click;
            // 
            // digit5
            // 
            digit5.Location = new Point(62, 101);
            digit5.Name = "digit5";
            digit5.Size = new Size(50, 25);
            digit5.TabIndex = 4;
            digit5.Text = "5";
            digit5.UseVisualStyleBackColor = true;
            digit5.Click += Button_Click;
            // 
            // digit6
            // 
            digit6.Location = new Point(118, 101);
            digit6.Name = "digit6";
            digit6.Size = new Size(50, 25);
            digit6.TabIndex = 5;
            digit6.Text = "6";
            digit6.UseVisualStyleBackColor = true;
            digit6.Click += Button_Click;
            // 
            // digit7
            // 
            digit7.Location = new Point(6, 70);
            digit7.Name = "digit7";
            digit7.Size = new Size(50, 25);
            digit7.TabIndex = 6;
            digit7.Text = "7";
            digit7.UseVisualStyleBackColor = true;
            digit7.Click += Button_Click;
            // 
            // digit8
            // 
            digit8.Location = new Point(62, 70);
            digit8.Name = "digit8";
            digit8.Size = new Size(50, 25);
            digit8.TabIndex = 7;
            digit8.Text = "8";
            digit8.UseVisualStyleBackColor = true;
            digit8.Click += Button_Click;
            // 
            // digit9
            // 
            digit9.Location = new Point(118, 70);
            digit9.Name = "digit9";
            digit9.Size = new Size(50, 25);
            digit9.TabIndex = 8;
            digit9.Text = "9";
            digit9.UseVisualStyleBackColor = true;
            digit9.Click += Button_Click;
            // 
            // digit0
            // 
            digit0.Location = new Point(62, 165);
            digit0.Name = "digit0";
            digit0.Size = new Size(50, 25);
            digit0.TabIndex = 9;
            digit0.Text = "0";
            digit0.UseVisualStyleBackColor = true;
            digit0.Click += Button_Click;
            // 
            // resultBox
            // 
            resultBox.BackColor = SystemColors.Window;
            resultBox.Location = new Point(6, 6);
            resultBox.Name = "resultBox";
            resultBox.ReadOnly = true;
            resultBox.Size = new Size(218, 23);
            resultBox.TabIndex = 10;
            resultBox.TextAlign = HorizontalAlignment.Right;
            // 
            // plusButton
            // 
            plusButton.Location = new Point(174, 134);
            plusButton.Name = "plusButton";
            plusButton.Size = new Size(50, 25);
            plusButton.TabIndex = 11;
            plusButton.Text = "+";
            plusButton.UseVisualStyleBackColor = true;
            plusButton.Click += OperationButton_Click;
            // 
            // equalsButton
            // 
            equalsButton.Location = new Point(174, 165);
            equalsButton.Name = "equalsButton";
            equalsButton.Size = new Size(50, 25);
            equalsButton.TabIndex = 12;
            equalsButton.Text = "=";
            equalsButton.UseVisualStyleBackColor = true;
            equalsButton.Click += EqualsButton_Click;
            // 
            // minusButton
            // 
            minusButton.Location = new Point(174, 101);
            minusButton.Name = "minusButton";
            minusButton.Size = new Size(50, 25);
            minusButton.TabIndex = 13;
            minusButton.Text = "−";
            minusButton.UseVisualStyleBackColor = true;
            minusButton.Click += OperationButton_Click;
            // 
            // multiplyButton
            // 
            multiplyButton.Location = new Point(174, 70);
            multiplyButton.Name = "multiplyButton";
            multiplyButton.Size = new Size(50, 25);
            multiplyButton.TabIndex = 14;
            multiplyButton.Text = "×";
            multiplyButton.UseVisualStyleBackColor = true;
            multiplyButton.Click += OperationButton_Click;
            // 
            // divideButton
            // 
            divideButton.Location = new Point(174, 39);
            divideButton.Name = "divideButton";
            divideButton.Size = new Size(50, 25);
            divideButton.TabIndex = 15;
            divideButton.Text = "÷";
            divideButton.UseVisualStyleBackColor = true;
            divideButton.Click += OperationButton_Click;
            // 
            // commaButton
            // 
            commaButton.Location = new Point(118, 165);
            commaButton.Name = "commaButton";
            commaButton.Size = new Size(50, 25);
            commaButton.TabIndex = 16;
            commaButton.Text = ",";
            commaButton.UseVisualStyleBackColor = true;
            commaButton.Click += Button_Click;
            // 
            // negateButton
            // 
            negateButton.Location = new Point(6, 163);
            negateButton.Name = "negateButton";
            negateButton.Size = new Size(50, 25);
            negateButton.TabIndex = 17;
            negateButton.Text = "+/−";
            negateButton.UseVisualStyleBackColor = true;
            negateButton.Click += NegateButton_Click;
            // 
            // cButton
            // 
            cButton.Location = new Point(118, 39);
            cButton.Name = "cButton";
            cButton.Size = new Size(50, 25);
            cButton.TabIndex = 18;
            cButton.Text = "C";
            cButton.UseVisualStyleBackColor = true;
            cButton.Click += CButton_Click;
            // 
            // ceButton
            // 
            ceButton.Location = new Point(62, 39);
            ceButton.Name = "ceButton";
            ceButton.Size = new Size(50, 25);
            ceButton.TabIndex = 19;
            ceButton.Text = "CE";
            ceButton.UseVisualStyleBackColor = true;
            ceButton.Click += CEButton_Click;
            // 
            // backspaceButton
            // 
            backspaceButton.Location = new Point(6, 39);
            backspaceButton.Name = "backspaceButton";
            backspaceButton.Size = new Size(50, 25);
            backspaceButton.TabIndex = 20;
            backspaceButton.Text = "←";
            backspaceButton.UseVisualStyleBackColor = true;
            backspaceButton.Click += BackspaceButton_Click;
            // 
            // historyListBox
            // 
            historyListBox.FormattingEnabled = true;
            historyListBox.ItemHeight = 15;
            historyListBox.Location = new Point(230, 6);
            historyListBox.Name = "historyListBox";
            historyListBox.Size = new Size(225, 184);
            historyListBox.TabIndex = 21;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(calculatorTab);
            tabControl.Controls.Add(currencyTab);
            tabControl.Location = new Point(12, 12);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(470, 226);
            tabControl.TabIndex = 22;
            // 
            // calculatorTab
            // 
            calculatorTab.Controls.Add(resultBox);
            calculatorTab.Controls.Add(historyListBox);
            calculatorTab.Controls.Add(digit1);
            calculatorTab.Controls.Add(backspaceButton);
            calculatorTab.Controls.Add(digit2);
            calculatorTab.Controls.Add(ceButton);
            calculatorTab.Controls.Add(digit3);
            calculatorTab.Controls.Add(cButton);
            calculatorTab.Controls.Add(digit4);
            calculatorTab.Controls.Add(negateButton);
            calculatorTab.Controls.Add(digit5);
            calculatorTab.Controls.Add(commaButton);
            calculatorTab.Controls.Add(digit6);
            calculatorTab.Controls.Add(divideButton);
            calculatorTab.Controls.Add(digit7);
            calculatorTab.Controls.Add(multiplyButton);
            calculatorTab.Controls.Add(digit8);
            calculatorTab.Controls.Add(minusButton);
            calculatorTab.Controls.Add(digit9);
            calculatorTab.Controls.Add(equalsButton);
            calculatorTab.Controls.Add(digit0);
            calculatorTab.Controls.Add(plusButton);
            calculatorTab.Location = new Point(4, 24);
            calculatorTab.Name = "calculatorTab";
            calculatorTab.Padding = new Padding(3);
            calculatorTab.Size = new Size(462, 198);
            calculatorTab.TabIndex = 0;
            calculatorTab.Text = "Calculator";
            calculatorTab.UseVisualStyleBackColor = true;
            // 
            // currencyTab
            // 
            currencyTab.Controls.Add(bestDayLabel);
            currencyTab.Controls.Add(currencyLabel);
            currencyTab.Controls.Add(dateToLabel);
            currencyTab.Controls.Add(dateFromLabel);
            currencyTab.Controls.Add(valueLabel);
            currencyTab.Controls.Add(dateToPicker);
            currencyTab.Controls.Add(dateFromPicker);
            currencyTab.Controls.Add(currencyBox);
            currencyTab.Controls.Add(findBestDayButton);
            currencyTab.Controls.Add(currencyValueTextbox);
            currencyTab.Location = new Point(4, 24);
            currencyTab.Name = "currencyTab";
            currencyTab.Padding = new Padding(3);
            currencyTab.Size = new Size(462, 198);
            currencyTab.TabIndex = 1;
            currencyTab.Text = "Currency";
            currencyTab.UseVisualStyleBackColor = true;
            // 
            // bestDayLabel
            // 
            bestDayLabel.AutoSize = true;
            bestDayLabel.Location = new Point(194, 114);
            bestDayLabel.Name = "bestDayLabel";
            bestDayLabel.Size = new Size(0, 15);
            bestDayLabel.TabIndex = 9;
            // 
            // currencyLabel
            // 
            currencyLabel.AutoSize = true;
            currencyLabel.Location = new Point(6, 50);
            currencyLabel.Name = "currencyLabel";
            currencyLabel.Size = new Size(58, 15);
            currencyLabel.TabIndex = 8;
            currencyLabel.Text = "Currency:";
            // 
            // dateToLabel
            // 
            dateToLabel.AutoSize = true;
            dateToLabel.Location = new Point(256, 50);
            dateToLabel.Name = "dateToLabel";
            dateToLabel.Size = new Size(23, 15);
            dateToLabel.TabIndex = 7;
            dateToLabel.Text = "To:";
            // 
            // dateFromLabel
            // 
            dateFromLabel.AutoSize = true;
            dateFromLabel.Location = new Point(256, 3);
            dateFromLabel.Name = "dateFromLabel";
            dateFromLabel.Size = new Size(38, 15);
            dateFromLabel.TabIndex = 6;
            dateFromLabel.Text = "From:";
            // 
            // valueLabel
            // 
            valueLabel.AutoSize = true;
            valueLabel.Location = new Point(6, 3);
            valueLabel.Name = "valueLabel";
            valueLabel.Size = new Size(95, 15);
            valueLabel.TabIndex = 5;
            valueLabel.Text = "Value to convert:";
            // 
            // dateToPicker
            // 
            dateToPicker.Location = new Point(256, 68);
            dateToPicker.Name = "dateToPicker";
            dateToPicker.Size = new Size(200, 23);
            dateToPicker.TabIndex = 4;
            // 
            // dateFromPicker
            // 
            dateFromPicker.Location = new Point(256, 21);
            dateFromPicker.Name = "dateFromPicker";
            dateFromPicker.Size = new Size(200, 23);
            dateFromPicker.TabIndex = 3;
            // 
            // currencyBox
            // 
            currencyBox.FormattingEnabled = true;
            currencyBox.Items.AddRange(new object[] { "EUR", "USD", "GBP", "CHF", "JPY" });
            currencyBox.Location = new Point(6, 68);
            currencyBox.Name = "currencyBox";
            currencyBox.Size = new Size(226, 23);
            currencyBox.TabIndex = 1;
            // 
            // findBestDayButton
            // 
            findBestDayButton.Location = new Point(6, 106);
            findBestDayButton.Name = "findBestDayButton";
            findBestDayButton.Size = new Size(95, 30);
            findBestDayButton.TabIndex = 5;
            findBestDayButton.Text = "Find best day";
            findBestDayButton.UseVisualStyleBackColor = true;
            findBestDayButton.Click += FindBestDayButton_Click;
            // 
            // currencyValueTextbox
            // 
            currencyValueTextbox.Location = new Point(6, 21);
            currencyValueTextbox.Name = "currencyValueTextbox";
            currencyValueTextbox.Size = new Size(226, 23);
            currencyValueTextbox.TabIndex = 0;
            // 
            // CalcForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(486, 243);
            Controls.Add(tabControl);
            KeyPreview = true;
            Name = "CalcForm";
            Text = "Calculator";
            Load += CalcForm_Load;
            tabControl.ResumeLayout(false);
            calculatorTab.ResumeLayout(false);
            calculatorTab.PerformLayout();
            currencyTab.ResumeLayout(false);
            currencyTab.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button digit1;
        private Button digit2;
        private Button digit3;
        private Button digit4;
        private Button digit5;
        private Button digit6;
        private Button digit7;
        private Button digit8;
        private Button digit9;
        private Button digit0;
        private TextBox resultBox;
        private Button plusButton;
        private Button equalsButton;
        private Button minusButton;
        private Button multiplyButton;
        private Button divideButton;
        private Button commaButton;
        private Button negateButton;
        private Button cButton;
        private Button ceButton;
        private Button backspaceButton;
        private ListBox historyListBox;
        private TabControl tabControl;
        private TabPage calculatorTab;
        private TabPage currencyTab;
        private Button findBestDayButton;
        private TextBox currencyValueTextbox;
        private Label valueLabel;
        private DateTimePicker dateToPicker;
        private DateTimePicker dateFromPicker;
        private ComboBox currencyBox;
        private Label dateToLabel;
        private Label dateFromLabel;
        private Label currencyLabel;
        private Label bestDayLabel;
    }
}
