using Mmu.Mlh.TestingExtensions.Areas.Common.Assertions.Models;

namespace Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Services
{
    internal interface IAssertable
    {
        AssertionResult Assert();
    }
}