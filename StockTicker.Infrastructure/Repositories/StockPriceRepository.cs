using Dapper;
using StockTicker.Application.Abstractions.Data;
using StockTicker.Application.Repostitories;
using StockTicker.Application.StockPrices.GetStockPrice;
using StockTicker.Domain.StockPrices;

namespace StockTicker.Infrastructure.Repositories
{
    internal sealed class StockPriceRepository : IStockPriceRepository
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public StockPriceRepository(ISqlConnectionFactory sqlConnectionFactory) =>
            _sqlConnectionFactory = sqlConnectionFactory;

        public async Task<StockPriceResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            using var connection = _sqlConnectionFactory.CreateConnection();

            const string sql = """
            SELECT
                id AS Id,
                ticker AS Ticker,
                price AS Price,
                created_at_utc AS CreatedAtUtc
            FROM stockprices
            WHERE id = @StockPriceId
            """;

            return await connection.QueryFirstOrDefaultAsync<StockPriceResponse>(
                sql,
                new { StockPriceId = id });
        }

        public void Add(StockPrice stockPrice)
        {
            throw new NotImplementedException();
        }
    }
}
