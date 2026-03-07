using Microsoft.Extensions.DependencyInjection;
using StockTicker.Application.Abstractions.Messaging;
using StockTicker.Application.StockPrices;
using StockTicker.Application.StockPrices.GetStockPrice;
using StockTicker.Domain.StockPrices;

namespace StockTicker.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
            });

            // Repository (production implementation using Dapper) - read/query side
            services.AddScoped<IStockPriceQueryRepository, DapperStockPriceRepository>();

            // Handlers
            services.AddTransient<IQueryHandler<GetStockPriceQuery, StockPrice>, GetStockPriceQueryHandler>();

            return services;
        }
    }
}
