using FluentAssertions;
using NetArchTest.Rules;
using StockTicker.ArchitectureTests.Infrastructure;

namespace StockTicker.ArchitectureTests.Layers
{
    public class LayersTests : BaseTest
    {
        [Fact]
        public void DomainLayer_ShouldNotHaveDependencyOn_ApplicationLayer()
        {
            var result = Types.InAssembly(DomainAssembly)
                .Should()
                .NotHaveDependencyOn(ApplicationAssembly.GetName().Name)
                .GetResult();
            result.IsSuccessful.Should().BeTrue();
        }

        [Fact]
        public void DomainLayer_ShouldNotHaveDependencyOn_InfrastructureLayer()
        {
            var result = Types.InAssembly(DomainAssembly)
                .Should()
                .NotHaveDependencyOn(InfrastructureAssembly.GetName().Name)
                .GetResult();
            result.IsSuccessful.Should().BeTrue();
        }

        [Fact]
        public void ApplicationLayerShouldNotHaveDependencyOn_InfrastructureLayer()
        {
            var result = Types.InAssembly(ApplicationAssembly)
                .Should()
                .NotHaveDependencyOn(InfrastructureAssembly.GetName().Name)
                .GetResult();

            result.IsSuccessful.Should().BeTrue();
        }
    }
}
