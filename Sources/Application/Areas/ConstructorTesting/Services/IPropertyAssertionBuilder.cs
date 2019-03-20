namespace Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Services
{
    public interface IPropertyAssertionBuilder<T, TP> : IAssertableProperty<T>
    {
        IConstructorPropertyMapper<T> WithValue(TP expectedValue);

        IConstructorPropertyMapper<T> WithValues(TP values);
    }
}