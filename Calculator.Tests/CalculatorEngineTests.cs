namespace Calculator.Tests
{
    public class CalculatorEngineTests
    {
        private static CalculatorEngine CreateEngine()
        {
            var repo = new FakeRepository(new Data.CalculatorDbContext());
            return new CalculatorEngine(repo);
        }

        [Fact]
        public void Add_TwoNumbers_ReturnsCorrectResult()
        {
            var engine = CreateEngine();

            engine.WriteCharacter('5');
            engine.ExecuteCommand("+");
            engine.WriteCharacter('3');
            engine.ExecuteEqualsAction();

            Assert.Equal("8", engine.CurrentDisplay);
        }

        [Fact]
        public void Subtract_TwoNumbers_ReturnsCorrectResult()
        {
            var engine = CreateEngine();

            engine.WriteCharacter('1');
            engine.WriteCharacter('0'); // "10"
            engine.ExecuteCommand("-");
            engine.WriteCharacter('4');
            engine.ExecuteEqualsAction();

            Assert.Equal("6", engine.CurrentDisplay);
        }

        [Fact]
        public void Multiply_TwoNumbers_ReturnsCorrectResult()
        {
            var engine = CreateEngine();

            engine.WriteCharacter('7');
            engine.ExecuteCommand("*");
            engine.WriteCharacter('6');
            engine.ExecuteEqualsAction();

            Assert.Equal("42", engine.CurrentDisplay);
        }

        [Fact]
        public void Divide_TwoNumbers_ReturnsCorrectResult()
        {
            var engine = CreateEngine();

            engine.WriteCharacter('2');
            engine.WriteCharacter('0'); // "20"
            engine.ExecuteCommand("/");
            engine.WriteCharacter('5');
            engine.ExecuteEqualsAction();

            Assert.Equal("4", engine.CurrentDisplay);
        }

        [Fact]
        public void Divide_ByZero_SetsErrorState()
        {
            var engine = CreateEngine();

            engine.WriteCharacter('9');
            engine.ExecuteCommand("/");
            engine.WriteCharacter('0');
            engine.ExecuteEqualsAction();

            Assert.Equal("E", engine.CurrentDisplay);
        }

        [Fact]
        public void ChainOperationsAfterEqual_UsesLastResultForCalculation()
        {
            var engine = CreateEngine();

            // 2 + 3 = 5 => 5 * 4
            engine.WriteCharacter('2');
            engine.ExecuteCommand("+");
            engine.WriteCharacter('3');
            engine.ExecuteEqualsAction(); // = 5
            engine.ExecuteCommand("*");
            engine.WriteCharacter('4');
            engine.ExecuteEqualsAction();

            Assert.Equal("20", engine.CurrentDisplay);
        }

        [Fact]
        public void ChainOperations_ExecutesSequentially()
        {
            var engine = CreateEngine();

            // 4 + 1 * 3
            engine.WriteCharacter('4');
            engine.ExecuteCommand("+");
            engine.WriteCharacter('1');
            engine.ExecuteCommand("*");
            engine.WriteCharacter('3');
            engine.ExecuteEqualsAction();

            Assert.Equal("15", engine.CurrentDisplay);
        }


        [Fact]
        public void Negate_ChangesSign()
        {
            var engine = CreateEngine();

            engine.WriteCharacter('9');
            engine.Negate();

            Assert.Equal("-9", engine.CurrentDisplay);
        }

        [Fact]
        public void Backspace_RemovesLastDigit()
        {
            var engine = CreateEngine();

            engine.WriteCharacter('1');
            engine.WriteCharacter('2');
            engine.WriteCharacter('3');
            engine.Backspace();

            Assert.Equal("12", engine.CurrentDisplay);
        }

        [Fact]
        public void ResetCalculator_ResetsDisplay()
        {
            var engine = CreateEngine();

            engine.WriteCharacter('5');
            engine.ExecuteCommand("+");
            engine.WriteCharacter('5');
            engine.ExecuteEqualsAction();

            engine.ResetCalculator();

            Assert.Equal("0", engine.CurrentDisplay);
        }
    }
}
