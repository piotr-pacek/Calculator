using Calculator.Data;

namespace Calculator.Tests
{
    public class FakeRepository(CalculatorDbContext context) : OperationRepository(context)
    {
        private readonly List<OperationEntity> _operations = [];

        public new void AddOperation(string expression, string result)
        {
            _operations.Add(new OperationEntity { Expression = expression, Result = result });
        }

        public new List<OperationEntity> GetOperations() => _operations;

        public new void ClearOperations() => _operations.Clear();
    }
}
