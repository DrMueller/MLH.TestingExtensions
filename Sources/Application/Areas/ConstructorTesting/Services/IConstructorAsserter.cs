namespace Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Services
{
    public interface IConstructorAsserter<T>
    {
        IConstructorValuesBuilder<T> Fail();

        IConstructorValuesBuilder<T> Succeeding();
    }
}