namespace Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Services
{
    public interface IConstructorAssertionSelector<T>
    {
        IConstructorAsserter<T> Is();

        IConstructorPropertyMapper<T> Maps();
    }
}