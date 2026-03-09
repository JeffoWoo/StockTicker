using StockTicker.Application.Abstractions.Messaging;
using StockTicker.Domain.Abstractions;
using StockTicker.Infrastructure;
using System.Reflection;

namespace StockTicker.ArchitectureTests.Infrastructure
{
    public abstract class BaseTest
    {
        protected static readonly Assembly DomainAssembly = typeof(Entity).Assembly;

        protected static readonly Assembly ApplicationAssembly = typeof(IBaseCommand).Assembly;

        protected static readonly Assembly InfrastructureAssembly = typeof(ApplicationDbContext).Assembly;
    }
}
