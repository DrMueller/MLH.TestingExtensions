using Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Models;

namespace Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Services.Implementation.PropertyAsserters
{
    public interface IPropertyValueAsserter<TP>
    {
        AssertionResult Assert(TP actualPropertyValue);
    }
}