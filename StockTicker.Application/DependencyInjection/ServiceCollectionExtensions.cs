using Microsoft.Extensions.DependencyInjection;
using StockTicker.Application.Abstractions.Messaging;
using StockTicker.Application.StockPrices;
using StockTicker.Application.StockPrices.GetStockPrice;

namespace StockTicker.Application
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Repository (production implementation using Dapper)
            services.AddScoped<IStockPriceQueryRepository, DapperStockPriceRepository>();

            // Handlers
            services.AddTransient<IQueryHandler<GetStockPriceQuery, StockPriceResponse>, GetStockPriceQueryHandler>();

            return services;
        }
    }
}