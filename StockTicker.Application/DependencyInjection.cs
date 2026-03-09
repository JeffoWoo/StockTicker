using Microsoft.Extensions.DependencyInjection;
using StockTicker.Application.Abstractions.Bevhaviours;

namespace StockTicker.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);

                configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));

                configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });

            return services;
        }
    }
}
