using System;
using System.Linq.Expressions;

namespace Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Services
{
    public interface IConstructorPropertyMapper<T>
    {
        IConstructorValuesBuilder<T> BuildMaps();

        IPropertyAssertionBuilder<T, TP> ToProperty<TP>(Expression<Func<T, TP>> propertyExpression);
    }
}