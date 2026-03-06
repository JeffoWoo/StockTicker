using FluentAssertions;
using NetArchTest.Rules;
using StockTicker.ArchitectureTests.Infrastructure;
using StockTicker.Domain.Abstractions;
using System.Reflection;

namespace StockTicker.ArchitectureTests.Domain 
{
    public class DomainTests : BaseTest
    {
        [Fact]
        public void DomainEvents_Should_BeSealed()
        {
            var result = Types.InAssembly(DomainAssembly)
                .That()
                .Inherit(typeof(IDomainEvent))
                .Should()
                .BeSealed()
                .GetResult();

            result.IsSuccessful.Should().BeTrue();
        }

        [Fact]
        public void DomainEvents_ShouldHave_DomainEventsPostfix()
        {
            var result = Types.InAssembly(DomainAssembly)
                .That()
                .ImplementInterface(typeof(IDomainEvent))
                .Should().HaveNameEndingWith("DomainEvent")
                .GetResult();

            result.IsSuccessful.Should().BeTrue();
        }

        [Fact]
        public void Entities_ShouldHave_PrivateParameterlessConstructor()
        {
            IEnumerable<Type> entityTypes = Types.InAssembly(DomainAssembly)
                .That()
                .Inherit(typeof(Entity))
                .GetTypes();

            var failingTypes = new List<Type>();
            foreach (var entityType in entityTypes)
            {
                ConstructorInfo[] construtors = entityType.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);

                if (!construtors.Any(c => c.IsPrivate && c.GetParameters().Length == 0))
                {
                    failingTypes.Add(entityType);
                }
            }

            failingTypes.Should().BeEmpty();
        }
    }
}
