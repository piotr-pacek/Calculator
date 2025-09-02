using Calculator.Data;
using System.Text.Json;

namespace Calculator
{
    /// <summary>
    ///     Service responsible for fetching currency rates from NBP API and managing them in the database.
    /// </summary>
    /// <remarks>
    ///     Initializes a new instance of <see cref="CurrencyService"/> with the specified database context.
    /// </remarks>
    /// <param name="context">Database context for accessing CurrencyRates table</param>
    public class CurrencyService(CalculatorDbContext context)
    {
        private readonly CalculatorDbContext _context = context;
        private readonly HttpClient _http = new();

        /// <summary>
        ///     Fetches currency rates for the specified currency and date range from NBP API and saves them to the database.
        /// </summary>
        /// <param name="currency">Currency code (e.g., "USD", "EUR")</param>
        /// <param name="from">Start date of the range</param>
        /// <param name="to">End date of the range</param>
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

        /// <summary>
        ///     Returns the best (highest) exchange rate for the specified currency in the given date range.
        /// </summary>
        /// <param name="currency">Currency code</param>
        /// <param name="from">Start date</param>
        /// <param name="to">End date</param>
        /// <returns>The CurrencyRate with the highest rate, or null if no data is available</returns>
        public CurrencyRate? GetBestRate(string currency, DateTime from, DateTime to)
        {
            return _context.CurrencyRates
                .Where(r => r.Currency == currency && r.Date >= from && r.Date <= to)
                .AsEnumerable()
                .OrderByDescending(r => (double)r.Rate)
                .FirstOrDefault();
        }

        /// <summary>
        ///     Returns the best conversion for the given amount using the highest rate in the specified date range.
        /// </summary>
        /// <param name="currency">Currency code</param>
        /// <param name="from">Start date</param>
        /// <param name="to">End date</param>
        /// <param name="amount">Amount to convert</param>
        /// <returns>Tuple containing the best rate and converted amount</returns>
        public (CurrencyRate? bestRate, decimal convertedAmount) GetBestConversion(string currency, DateTime from, DateTime to, decimal amount)
        {
            var bestRate = GetBestRate(currency, from, to);
            if (bestRate == null)
                return (null, 0);

            decimal converted = amount * bestRate.Rate;
            return (bestRate, converted);
        }
    }

    /// <summary>
    ///     Represents the JSON response from the NBP API.
    /// </summary>
    public class NbpResponse
    {
        public required string code { get; set; }

        public required List<Rate> rates { get; set; }
    }

    /// <summary>
    ///     Represents a single exchange rate entry from the NBP API response.
    /// </summary>
    public class Rate
    {
        public DateTime effectiveDate { get; set; }

        public decimal mid { get; set; }
    }
}
