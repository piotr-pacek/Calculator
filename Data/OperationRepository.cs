namespace Calculator.Data
{
    public class OperationRepository
    {
        private readonly CalculatorDbContext _context;

        public OperationRepository(CalculatorDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        public void AddOperation(string expression, string result)
        {
            var op = new OperationEntity
            {
                Expression = expression,
                Result = result
            };

            _context.Operations.Add(op);
            _context.SaveChanges();
        }

        public List<OperationEntity> GetOperations()
        {
            return [.. _context.Operations.OrderByDescending(o => o.Timestamp)];
        }

        public void ClearOperations()
        {
            _context.Operations.RemoveRange(_context.Operations);
            _context.SaveChanges();
        }
    }
}
