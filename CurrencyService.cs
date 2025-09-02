using Calculator.Data;
using System.Text.Json;

namespace Calculator
{
    public class CurrencyService(CalculatorDbContext context)
    {
        private readonly CalculatorDbContext _context = context;
        private readonly HttpClient _http = new();

        public async Task FetchAndSaveRates(string currency, DateTime from, DateTime to)
        {
            string url = $"https://api.nbp.pl/api/exchangerates/rates/A/{currency}/{from:yyyy-MM-dd}/{to:yyyy-MM-dd}/?format=json";
            var json = await _http.GetStringAsync(url);

            var data = JsonSerializer.Deserialize<NbpResponse>(json);

            foreach (var rate in data.rates)
            {
                if (!_context.CurrencyRates.Any(r => r.Currency == currency && r.Date == rate.effectiveDate))
                {
                    _context.CurrencyRates.Add(new CurrencyRate
                    {
                        Currency = currency,
                        Date = rate.effectiveDate,
                        Rate = rate.mid
                    });
                }
            }

            await _context.SaveChangesAsync();
        }

        public CurrencyRate? GetBestRate(string currency, DateTime from, DateTime to)
        {
            return _context.CurrencyRates
                .Where(r => r.Currency == currency && r.Date >= from && r.Date <= to)
                .AsEnumerable()
                .OrderByDescending(r => (double)r.Rate)
                .FirstOrDefault();
        }

        public (CurrencyRate? bestRate, decimal convertedAmount) GetBestConversion(string currency, DateTime from, DateTime to, decimal amount)
        {
            var bestRate = GetBestRate(currency, from, to);
            if (bestRate == null)
                return (null, 0);

            decimal converted = amount * bestRate.Rate;
            return (bestRate, converted);
        }

    }

    public class NbpResponse
    {
        public required string code { get; set; }

        public required List<Rate> rates { get; set; }
    }

    public class Rate
    {
        public DateTime effectiveDate { get; set; }

        public decimal mid { get; set; }
    }
}
