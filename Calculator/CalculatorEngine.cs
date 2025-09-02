using Calculator.Data;
using System.ComponentModel;
using System.Globalization;

namespace Calculator
{
    /// <summary>
    ///     Core engine for calculator operations.
    ///     Handles input, arithmetic operations, negation, backspace, and result history.
    /// </summary>
    public class CalculatorEngine
    {
        // Internal state flags
        private bool isDecimal;                   // True if current input contains a decimal separator
        private bool isFirstNumber;               // True if entering the first number of an operation
        private bool isWaitingForSecondNumber;    // True if waiting for the second number after an operator
        private bool canOverwriteResultBox;       // True if the next digit should overwrite the display
        private bool resultCalculated;            // True if a calculation was just performed

        // Numeric values
        private double previousNumber;            // Stores the previous number for calculations
        private double currentNumber;             // Stores the current input number
        private Operation? currentOperation;      // Currently selected operation

        // Decimal separator for current culture
        private readonly string decimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

        // Repository for storing operation history
        private readonly OperationRepository _repository;

        /// <summary>
        ///     Initializes a new instance of CalculatorEngine.
        /// </summary>
        /// <param name="repository">Repository for storing operation history</param>
        public CalculatorEngine(OperationRepository repository)
        {
            _repository = repository;
            ResetCalculator();
        }

        /// <summary>
        ///     Gets the value currently displayed in the calculator.
        /// </summary>
        public string CurrentDisplay { get; private set; } = "0";

        /// <summary>
        ///     Adds a digit or decimal separator to the current input.
        /// </summary>
        /// <param name="inputChar">Character to add (digit or decimal separator)</param>
        public void WriteCharacter(char inputChar)
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

        /// <summary>
        ///     Executes an arithmetic operation (+, -, *, /).
        ///     If a previous operation exists, it may calculate the intermediate result.
        /// </summary>
        /// <param name="operation">Operation identifier (button name or symbol)</param>
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

        /// <summary>
        ///     Executes the equals action for the current operation.
        /// </summary>
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

        /// <summary>
        ///     Calculates the result of an operation.
        /// </summary>
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

        /// <summary>
        ///     Negates the current number (multiplies by -1).
        /// </summary>
        public void Negate()
        {
            if (CurrentDisplay != "0" && !canOverwriteResultBox && CurrentDisplay != "E")
            {
                var negatedNumber = ParseResultBox() * -1;
                currentNumber = negatedNumber;
                CurrentDisplay = negatedNumber.ToString();
            }
        }

        /// <summary>
        ///     Deletes the last character from the current input.
        /// </summary>
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

        /// <summary>
        ///     Parses the current display string to a double.
        /// </summary>
        private double ParseResultBox()
        {
            return double.TryParse(CurrentDisplay, out var number) ? number : 0;
        }

        /// <summary>
        ///     Resets the calculator to its initial state.
        /// </summary>
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

        /// <summary>
        ///     Clears current entry or resets the calculator if a result was just calculated.
        /// </summary>
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

        /// <summary>
        ///     Returns the symbol for a given operation.
        /// </summary>
        private static string GetSymbol(Operation? op) => op switch
        {
            Operation.Add => "+",
            Operation.Subtract => "-",
            Operation.Multiply => "*",
            Operation.Divide => "/",
            _ => "?"
        };

        /// <summary>
        ///     Returns all recorded operations from the repository.
        /// </summary>
        public List<OperationEntity> GetHistory()
        {
            return _repository.GetOperations();
        }

        /// <summary>
        ///     Clears the operation history from the repository.
        /// </summary>
        public void ResetDatabase()
        {
            _repository.ClearOperations();
        }

        /// <summary>
        ///     Supported calculator operations.
        /// </summary>
        internal enum Operation
        {
            Add,
            Subtract,
            Multiply,
            Divide
        }
    }
}
