using Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Models;

namespace Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Services
{
    public interface IAssertableProperty<T>
    {
        AssertionResult Assert(T objectToCheck);
    }
}