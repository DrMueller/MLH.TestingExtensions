using Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Services.Implementation;

namespace Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Services
{
    public static class CtorTestBuilderFactory
    {
        public static IObjectWithCtorBuilder<T> ForType<T>()
        {
            return new ObjectWithCtorBuilder<T>();
        }
    }
}