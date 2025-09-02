using Calculator.Data;
using Microsoft.EntityFrameworkCore;

namespace Calculator.Tests
{
    public class CurrencyServiceTests
    {
        private static CalculatorDbContext GetInMemoryContext()
        {
            var options = new DbContextOptionsBuilder<CalculatorDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new CalculatorDbContext(options);
        }

        [Fact]
        public async Task GetBestRate_ReturnsHighestRate()
        {
            using var context = GetInMemoryContext();

            context.CurrencyRates.AddRange(
                new CurrencyRate { Currency = "USD", Date = new DateTime(2025, 1, 1), Rate = 4.5m },
                new CurrencyRate { Currency = "USD", Date = new DateTime(2025, 1, 2), Rate = 4.8m },
                new CurrencyRate { Currency = "USD", Date = new DateTime(2025, 1, 3), Rate = 4.7m }
            );
            await context.SaveChangesAsync();

            var service = new CurrencyService(context);

            var best = service.GetBestRate("USD", new DateTime(2025, 1, 1), new DateTime(2025, 1, 3));

            Assert.NotNull(best);
            Assert.Equal(4.8m, best!.Rate);
            Assert.Equal(new DateTime(2025, 1, 2), best.Date);
        }

        [Fact]
        public async Task GetBestConversion_CalculatesConvertedAmount()
        {
            using var context = GetInMemoryContext();

            context.CurrencyRates.AddRange(
                new CurrencyRate { Currency = "EUR", Date = new DateTime(2025, 1, 1), Rate = 4.2m },
                new CurrencyRate { Currency = "EUR", Date = new DateTime(2025, 1, 2), Rate = 4.4m }
            );
            await context.SaveChangesAsync();

            var service = new CurrencyService(context);

            decimal amount = 100m;
            var (bestRate, converted) = service.GetBestConversion("EUR", new DateTime(2025, 1, 1), new DateTime(2025, 1, 2), amount);

            Assert.NotNull(bestRate);
            Assert.Equal(4.4m, bestRate!.Rate);
            Assert.Equal(amount * 4.4m, converted);
        }

        [Fact]
        public async Task GetBestRate_ReturnsNullWhenNoRates()
        {
            using var context = GetInMemoryContext();
            var service = new CurrencyService(context);

            var best = service.GetBestRate("USD", new DateTime(2025, 1, 1), new DateTime(2025, 1, 3));

            Assert.Null(best);
        }
    }
}