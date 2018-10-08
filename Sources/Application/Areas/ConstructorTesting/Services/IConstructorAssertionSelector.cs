namespace Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Services
{
    public interface IConstructorAssertionSelector<T>
    {
        IConstructorValuesBuilder<T> Fails();

        IConstructorValuesBuilder<T> Succeeds();

        IConstructorPropertyMapper<T> Maps();
    }
}