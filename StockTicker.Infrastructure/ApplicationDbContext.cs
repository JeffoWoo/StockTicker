using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using StockTicker.Application.Abstractions.Clock;
using StockTicker.Application.Exceptions;
using StockTicker.Domain.Abstractions;

namespace StockTicker.Infrastructure
{
    public sealed class ApplicationDbContext : DbContext, IUnitOfWork
    {
        private static readonly JsonSerializerSettings JsonSerializerSettings = new()
        {
            TypeNameHandling = TypeNameHandling.All
        };

        private readonly IDateTimeProvider _dateTimeProvider;

        public ApplicationDbContext(
            DbContextOptions options,
            IDateTimeProvider dateTimeProvider)
            : base(options)
        {
            _dateTimeProvider = dateTimeProvider;
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                //AddDomainEventsAsOutboxMessages();

                var result = await base.SaveChangesAsync(cancellationToken);

                return result;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new ConcurrencyException("Concurrency exception occurred.", ex);
            }
        }
    }
}
