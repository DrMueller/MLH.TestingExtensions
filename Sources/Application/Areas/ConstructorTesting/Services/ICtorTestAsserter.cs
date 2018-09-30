using System;
using System.Linq.Expressions;

namespace Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Services
{
    public interface ICtorTestAsserter<T>
    {
        ICtorTestBuilder<T> Fails();

        IPropertyTestAsserter<T, TP> MapsToProperty<TP>(Expression<Func<T, TP>> propertyExpression);

        ICtorTestBuilder<T> Succeeds();
    }
}