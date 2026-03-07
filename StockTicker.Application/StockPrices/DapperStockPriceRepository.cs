using Dapper;
using StockTicker.Application.Abstractions.Data;
using StockTicker.Domain.StockPrices;

namespace StockTicker.Application.StockPrices
{
    internal sealed class DapperStockPriceRepository : IStockPriceQueryRepository
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public DapperStockPriceRepository(ISqlConnectionFactory sqlConnectionFactory) =>
            _sqlConnectionFactory = sqlConnectionFactory;

        public async Task<StockPrice?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            using var connection = _sqlConnectionFactory.CreateConnection();

            const string sql = """
            SELECT
                id AS Id,
                symbol AS Symbol,
                price AS Price,
                created_at_utc AS CreatedAtUtc
            FROM stockprices
            WHERE id = @StockPriceId
            """;

            return await connection.QueryFirstOrDefaultAsync<StockPrice>(
                sql,
                new { StockPriceId = id });
        }
    }
}
