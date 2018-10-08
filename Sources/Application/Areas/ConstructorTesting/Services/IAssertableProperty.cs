using Mmu.Mlh.TestingExtensions.Areas.Common.Assertions.Models;

namespace Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Services
{
    public interface IAssertableProperty<T>
    {
        AssertionResult Assert(T objectToCheck);
    }
}