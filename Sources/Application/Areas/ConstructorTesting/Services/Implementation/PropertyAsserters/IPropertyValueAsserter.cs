using Mmu.Mlh.TestingExtensions.Areas.Common.Assertions.Models;

namespace Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Services.Implementation.PropertyAsserters
{
    public interface IPropertyValueAsserter<TP>
    {
        AssertionResult Assert(TP actualPropertyValue);
    }
}