namespace Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Services
{
    public interface IConstructorAssertionSelector<T>
    {
        IConstructorValuesBuilder<T> Fails();

        IConstructorPropertyMapper<T> Maps();

        IConstructorValuesBuilder<T> Succeeds();
    }
}