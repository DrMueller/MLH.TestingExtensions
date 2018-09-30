namespace Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Services.Implementation
{
    internal class CtorTestBuilderFactory : ICtorTestBuilderFactory
    {
        public IObjectWithCtorBuilder<T> ForType<T>()
        {
            return new ObjectWithCtorBuilder<T>();
        }
    }
}