namespace Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Services
{
    public interface IConstructorValuesBuilder<T>
    {
        void Assert();

        IConstructorAssertionSelector<T> WithArgumentValues(params object[] argumentValues);
    }
}