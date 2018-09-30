using Mmu.Mlh.TestingExtensions.Areas.Common.Assertions.Models;

namespace Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Services
{
    public interface IPropertyAssertable<T>
    {
        AssertionResult Assert(T objectToCheck);
    }
}