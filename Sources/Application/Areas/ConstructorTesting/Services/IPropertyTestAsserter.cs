namespace Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Services
{
    public interface IPropertyTestAsserter<T, TP> : IPropertyAssertable<T>
    {
        ICtorTestAsserter<T> WithValue(TP expectedValue);
    }
}