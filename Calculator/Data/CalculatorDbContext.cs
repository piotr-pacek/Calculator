using Microsoft.EntityFrameworkCore;

namespace Calculator.Data
{
    public class CalculatorDbContext : DbContext
    {
        public DbSet<OperationEntity> Operations { get; set; }

        public DbSet<CurrencyRate> CurrencyRates { get; set; }

        public CalculatorDbContext()
        {
        }

        public CalculatorDbContext(DbContextOptions<CalculatorDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlite("Data Source=Data/Database/calculator.db");
        }
    }
}
