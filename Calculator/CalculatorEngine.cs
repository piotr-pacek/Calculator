using Calculator.Data;
using System.ComponentModel;
using System.Globalization;

namespace Calculator
{
    public class CalculatorEngine
    {
        private bool isDecimal;
        private bool isFirstNumber;
        private bool isWaitingForSecondNumber;
        private bool canOverwriteResultBox;
        private bool resultCalculated;

        private double previousNumber;
        private double currentNumber;
        private Operation? currentOperation;

        private readonly string decimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

        private readonly OperationRepository _repository;

        public CalculatorEngine(OperationRepository repository)
        {
            _repository = repository;
            ResetCalculator();
        }

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
                {
                    isFirstNumber = true;
                    currentOperation = null;
                }

                isWaitingForSecondNumber = false;
                canOverwriteResultBox = false;
                resultCalculated = false;
            }
        }

        public void ExecuteCommand(string operation)
        {
            if (CurrentDisplay == "E")
                return;

            var newOperation = operation switch
            {
                "plusButton" or "+" => Operation.Add,
                "minusButton" or "-" => Operation.Subtract,
                "multiplyButton" or "*" => Operation.Multiply,
                "divideButton" or "/" => Operation.Divide,
                _ => throw new ArgumentException("Unhandled value: " + operation.ToString())
            };

            if (isWaitingForSecondNumber)
            {
                currentOperation = newOperation;
                return;
            }

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

            currentOperation = newOperation;
            canOverwriteResultBox = true;
            isDecimal = false;
            isWaitingForSecondNumber = true;
        }

        public void ExecuteEqualsAction()
        {
            if (!currentOperation.HasValue || CurrentDisplay == "E")
                return;

            double inputNumber = ParseResultBox();

            if (isFirstNumber)
            {
                previousNumber = inputNumber;
                isFirstNumber = false;
            }
            else
            {
                if (!resultCalculated)
                    currentNumber = ParseResultBox();

                var firstNumber = previousNumber;
                if (currentNumber == 0 && currentOperation == Operation.Divide)
                {
                    CurrentDisplay = "E";
                }
                else
                {
                    previousNumber = CalculateResult(firstNumber, currentNumber, currentOperation);
                    _repository.AddOperation($"{firstNumber} {GetSymbol(currentOperation)} {currentNumber}", previousNumber.ToString());
                    CurrentDisplay = previousNumber.ToString("G", CultureInfo.CurrentCulture);
                }
            }

            canOverwriteResultBox = true;
            resultCalculated = true;
            isDecimal = false;
        }

        private static double CalculateResult(double firstNumber, double secondNumber, Operation? operation)
        {
            return operation switch
            {
                Operation.Add => firstNumber + secondNumber,
                Operation.Subtract => firstNumber - secondNumber,
                Operation.Multiply => firstNumber * secondNumber,
                Operation.Divide => firstNumber / secondNumber,
                _ => throw new InvalidEnumArgumentException("Unexpected enum value: " + operation.ToString())
            };
        }

        public void Negate()
        {

            if (CurrentDisplay != "0" && !canOverwriteResultBox && CurrentDisplay != "E")
            {
                var negatedNumber = ParseResultBox() * -1;
                currentNumber = negatedNumber;
                CurrentDisplay = negatedNumber.ToString();
            }
        }

        public void Backspace()
        {
            if (canOverwriteResultBox || CurrentDisplay == "E")
                return;

            if (CurrentDisplay.Length == 1)
            {
                CurrentDisplay = "0";
            }
            else
            {
                if (CurrentDisplay[^1] == decimalSeparator[0])
                    isDecimal = false;
                CurrentDisplay = CurrentDisplay[..^1];
            }
        }

        private double ParseResultBox()
        {
            return double.TryParse(CurrentDisplay, out var number) ? number : 0;
        }

        public void ResetCalculator()
        {
            CurrentDisplay = "0";
            currentNumber = 0;
            currentOperation = null;
            isFirstNumber = true;
            resultCalculated = false;
            canOverwriteResultBox = true;
            isDecimal = false;
        }

        public void CE()
        {
            if (resultCalculated)
            {
                ResetCalculator();
            }
            else
            {
                CurrentDisplay = "0";
                currentNumber = 0;
            }
        }

        private static string GetSymbol(Operation? op) => op switch
        {
            Operation.Add => "+",
            Operation.Subtract => "-",
            Operation.Multiply => "*",
            Operation.Divide => "/",
            _ => "?"
        };

        public List<OperationEntity> GetHistory()
        {
            return _repository.GetOperations();
        }

        public void ResetDatabase()
        {
            _repository.ClearOperations();
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
