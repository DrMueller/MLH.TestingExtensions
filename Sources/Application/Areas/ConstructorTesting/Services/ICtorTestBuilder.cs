namespace Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Services
{
    public interface ICtorTestBuilder<T>
    {
        IObjectWithCtorBuilder<T> Build();

        ICtorTestAsserter<T> WithArgumentValues(params object[] values);
    }
}