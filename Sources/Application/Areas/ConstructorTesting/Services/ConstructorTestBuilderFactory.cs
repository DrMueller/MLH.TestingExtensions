using Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Services.Implementation;

namespace Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Services
{
    public static class ConstructorTestBuilderFactory
    {
        public static IConstructorSelector<T> Constructing<T>()
        {
            return new ConstructorSelector<T>();
        }
    }
}