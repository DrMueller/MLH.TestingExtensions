namespace Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Services
{
    public interface ICtorTestBuilderFactory
    {
        IObjectWithCtorBuilder<T> ForType<T>();
    }
}