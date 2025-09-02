using System.Globalization;

namespace Calculator
{
    public class CalculatorEngine
    {
        private bool isDecimal;
        private bool isFirstNumber;
        private bool canOverwriteResultBox;
        private bool resultCalculated;

        private double previousNumber;
        private double currentNumber;
        private Operation currentOperation;

        private readonly string decimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

        public string CurrentDisplay { get; private set; } = "0";

        public void WriteDigit(char inputChar)
        {
            if (inputChar == '.' || inputChar == ',')
            {
                if (!isDecimal && !resultCalculated)
                {
                    CurrentDisplay += decimalSeparator[0];
                    isDecimal = true;
                }
            }
            else if ((isFirstNumber || (!canOverwriteResultBox && !resultCalculated)) && !CurrentDisplay.Equals("0"))
            {
                CurrentDisplay += inputChar;
            }
            else
            {
                CurrentDisplay = inputChar.ToString();

                if (resultCalculated)
                    isFirstNumber = true;

                canOverwriteResultBox = false;
                resultCalculated = false;
            }

        }

        public void ExecuteCommand(string operation)
        {
            currentOperation = operation switch
            {
                "plusButton" or "+" => Operation.Add,
                "minusButton" or "-" => Operation.Subtract,
                "multiplyButton" or "*" => Operation.Multiply,
                "divideButton" or "/" => Operation.Divide,
                _ => throw new NotSupportedException()
            };

            currentNumber = ParseResultBox();

            if (isFirstNumber || resultCalculated)
            {
                previousNumber = currentNumber;
                isFirstNumber = false;
                resultCalculated = false;
            }
            else
            {
                previousNumber = CalculateResult(previousNumber, currentNumber, currentOperation);

                CurrentDisplay = previousNumber.ToString("G", CultureInfo.CurrentCulture);
            }

            canOverwriteResultBox = true;
            isDecimal = false;
        }

        public void ExecuteEqualsAction()
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

                CurrentDisplay = previousNumber.ToString("G", CultureInfo.CurrentCulture);
            }

            canOverwriteResultBox = true;
            resultCalculated = true;
            isDecimal = false;
        }

        private static double CalculateResult(double firstNumber, double secondNumber, Operation operation)
        {
            return operation switch
            {
                Operation.Add => firstNumber + secondNumber,
                Operation.Subtract => firstNumber - secondNumber,
                Operation.Multiply => firstNumber * secondNumber,
                Operation.Divide => firstNumber / secondNumber,
                _ => throw new NotSupportedException(),
            };
        }

        public void Negate()
        {
            if (CurrentDisplay != "0")
            {
                var negatedNumber = ParseResultBox() * -1;
                currentNumber = negatedNumber;
                CurrentDisplay = negatedNumber.ToString();
            }
        }

        public void Backspace()
        {
            if (CurrentDisplay.Length == 1)
            {
                CurrentDisplay = "0";
            }
            else
            {
                if (CurrentDisplay[CurrentDisplay.Length - 1] == decimalSeparator[0])
                    isDecimal = false;
                CurrentDisplay = CurrentDisplay[..^1];
            }   
        }

        private double ParseResultBox()
        {
            return double.TryParse(CurrentDisplay, out var number) ? number : 0;
        }

        public void Reset()
        {
            CurrentDisplay = "0";
            currentNumber = 0;
            isFirstNumber = true;
            resultCalculated = false;
            canOverwriteResultBox = true;
            isDecimal = false;
        }

        public void CE()
        {
            if (resultCalculated)
            {
                Reset();
            }
            else
            {
                CurrentDisplay = "0";
                currentNumber = 0;
            }
        }

        internal enum Operation
        {
            Add,

            Subtract,

            Multiply,

            Divide
        }
    }
}
