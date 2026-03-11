using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockTicker.Domain.StockPrices;

namespace StockTicker.Infrastructure.Configurations.StockPrices
{
    internal sealed class StockPriceConfiguration : IEntityTypeConfiguration<StockPrice>
    {
        public void Configure(EntityTypeBuilder<StockPrice> builder)
        {
            builder.ToTable("stock_prices");

            builder.HasKey(stockPrice => stockPrice.Id);

            builder.Property(stockPrice => stockPrice.Ticker)
                .HasMaxLength(200)
                .HasConversion(
                        ticker => ticker.Value,
                        value => new Ticker(value));

            builder.Property(stockPrice => stockPrice.Price)
                .HasConversion(
                        price => price.Value,
                        value => new Price(value));
        }
    }
}
