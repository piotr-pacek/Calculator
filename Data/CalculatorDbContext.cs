using Microsoft.EntityFrameworkCore;

namespace Calculator.Data
{
    public class CalculatorDbContext : DbContext
    {
        public DbSet<OperationEntity> Operations { get; set; }

        public DbSet<CurrencyRate> CurrencyRates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite("Data Source=Data/Database/calculator.db");
    }
}
