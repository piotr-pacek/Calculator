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
            SuspendLayout();
            // 
            // digit1
            // 
            digit1.Location = new Point(12, 134);
            digit1.Name = "digit1";
            digit1.Size = new Size(50, 25);
            digit1.TabIndex = 0;
            digit1.Text = "1";
            digit1.UseVisualStyleBackColor = true;
            digit1.Click += Button_Click;
            // 
            // digit2
            // 
            digit2.Location = new Point(68, 136);
            digit2.Name = "digit2";
            digit2.Size = new Size(50, 25);
            digit2.TabIndex = 1;
            digit2.Text = "2";
            digit2.UseVisualStyleBackColor = true;
            digit2.Click += Button_Click;
            // 
            // digit3
            // 
            digit3.Location = new Point(124, 136);
            digit3.Name = "digit3";
            digit3.Size = new Size(50, 25);
            digit3.TabIndex = 2;
            digit3.Text = "3";
            digit3.UseVisualStyleBackColor = true;
            digit3.Click += Button_Click;
            // 
            // digit4
            // 
            digit4.Location = new Point(12, 103);
            digit4.Name = "digit4";
            digit4.Size = new Size(50, 25);
            digit4.TabIndex = 3;
            digit4.Text = "4";
            digit4.UseVisualStyleBackColor = true;
            digit4.Click += Button_Click;
            // 
            // digit5
            // 
            digit5.Location = new Point(68, 103);
            digit5.Name = "digit5";
            digit5.Size = new Size(50, 25);
            digit5.TabIndex = 4;
            digit5.Text = "5";
            digit5.UseVisualStyleBackColor = true;
            digit5.Click += Button_Click;
            // 
            // digit6
            // 
            digit6.Location = new Point(124, 103);
            digit6.Name = "digit6";
            digit6.Size = new Size(50, 25);
            digit6.TabIndex = 5;
            digit6.Text = "6";
            digit6.UseVisualStyleBackColor = true;
            digit6.Click += Button_Click;
            // 
            // digit7
            // 
            digit7.Location = new Point(12, 72);
            digit7.Name = "digit7";
            digit7.Size = new Size(50, 25);
            digit7.TabIndex = 6;
            digit7.Text = "7";
            digit7.UseVisualStyleBackColor = true;
            digit7.Click += Button_Click;
            // 
            // digit8
            // 
            digit8.Location = new Point(68, 72);
            digit8.Name = "digit8";
            digit8.Size = new Size(50, 25);
            digit8.TabIndex = 7;
            digit8.Text = "8";
            digit8.UseVisualStyleBackColor = true;
            digit8.Click += Button_Click;
            // 
            // digit9
            // 
            digit9.Location = new Point(124, 72);
            digit9.Name = "digit9";
            digit9.Size = new Size(50, 25);
            digit9.TabIndex = 8;
            digit9.Text = "9";
            digit9.UseVisualStyleBackColor = true;
            digit9.Click += Button_Click;
            // 
            // digit0
            // 
            digit0.Location = new Point(68, 167);
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
            resultBox.Location = new Point(12, 12);
            resultBox.Name = "resultBox";
            resultBox.ReadOnly = true;
            resultBox.Size = new Size(218, 23);
            resultBox.TabIndex = 10;
            resultBox.TextAlign = HorizontalAlignment.Right;
            // 
            // plusButton
            // 
            plusButton.Location = new Point(180, 136);
            plusButton.Name = "plusButton";
            plusButton.Size = new Size(50, 25);
            plusButton.TabIndex = 11;
            plusButton.Text = "+";
            plusButton.UseVisualStyleBackColor = true;
            plusButton.Click += OperationButton_Click;
            // 
            // equalsButton
            // 
            equalsButton.Location = new Point(180, 167);
            equalsButton.Name = "equalsButton";
            equalsButton.Size = new Size(50, 25);
            equalsButton.TabIndex = 12;
            equalsButton.Text = "=";
            equalsButton.UseVisualStyleBackColor = true;
            equalsButton.Click += EqualsButton_Click;
            // 
            // minusButton
            // 
            minusButton.Location = new Point(180, 103);
            minusButton.Name = "minusButton";
            minusButton.Size = new Size(50, 25);
            minusButton.TabIndex = 13;
            minusButton.Text = "−";
            minusButton.UseVisualStyleBackColor = true;
            minusButton.Click += OperationButton_Click;
            // 
            // multiplyButton
            // 
            multiplyButton.Location = new Point(180, 72);
            multiplyButton.Name = "multiplyButton";
            multiplyButton.Size = new Size(50, 25);
            multiplyButton.TabIndex = 14;
            multiplyButton.Text = "×";
            multiplyButton.UseVisualStyleBackColor = true;
            multiplyButton.Click += OperationButton_Click;
            // 
            // divideButton
            // 
            divideButton.Location = new Point(180, 41);
            divideButton.Name = "divideButton";
            divideButton.Size = new Size(50, 25);
            divideButton.TabIndex = 15;
            divideButton.Text = "÷";
            divideButton.UseVisualStyleBackColor = true;
            divideButton.Click += OperationButton_Click;
            // 
            // commaButton
            // 
            commaButton.Location = new Point(124, 167);
            commaButton.Name = "commaButton";
            commaButton.Size = new Size(50, 25);
            commaButton.TabIndex = 16;
            commaButton.Text = ",";
            commaButton.UseVisualStyleBackColor = true;
            commaButton.Click += Button_Click;
            // 
            // negateButton
            // 
            negateButton.Location = new Point(12, 165);
            negateButton.Name = "negateButton";
            negateButton.Size = new Size(50, 25);
            negateButton.TabIndex = 17;
            negateButton.Text = "+/−";
            negateButton.UseVisualStyleBackColor = true;
            negateButton.Click += NegateButton_Click;
            // 
            // cButton
            // 
            cButton.Location = new Point(124, 41);
            cButton.Name = "cButton";
            cButton.Size = new Size(50, 25);
            cButton.TabIndex = 18;
            cButton.Text = "C";
            cButton.UseVisualStyleBackColor = true;
            cButton.Click += CButton_Click;
            // 
            // ceButton
            // 
            ceButton.Location = new Point(68, 41);
            ceButton.Name = "ceButton";
            ceButton.Size = new Size(50, 25);
            ceButton.TabIndex = 19;
            ceButton.Text = "CE";
            ceButton.UseVisualStyleBackColor = true;
            ceButton.Click += CEButton_Click;
            // 
            // backspaceButton
            // 
            backspaceButton.Location = new Point(12, 41);
            backspaceButton.Name = "backspaceButton";
            backspaceButton.Size = new Size(50, 25);
            backspaceButton.TabIndex = 20;
            backspaceButton.Text = "←";
            backspaceButton.UseVisualStyleBackColor = true;
            backspaceButton.Click += BackspaceButton_Click;
            // 
            // CalcForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(243, 203);
            Controls.Add(backspaceButton);
            Controls.Add(ceButton);
            Controls.Add(cButton);
            Controls.Add(negateButton);
            Controls.Add(commaButton);
            Controls.Add(divideButton);
            Controls.Add(multiplyButton);
            Controls.Add(minusButton);
            Controls.Add(equalsButton);
            Controls.Add(plusButton);
            Controls.Add(resultBox);
            Controls.Add(digit0);
            Controls.Add(digit9);
            Controls.Add(digit8);
            Controls.Add(digit7);
            Controls.Add(digit6);
            Controls.Add(digit5);
            Controls.Add(digit4);
            Controls.Add(digit3);
            Controls.Add(digit2);
            Controls.Add(digit1);
            KeyPreview = true;
            Name = "CalcForm";
            Text = "Calculator";
            Load += CalcForm_Load;
            ResumeLayout(false);
            PerformLayout();
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
    }
}
