using System;
using System.Linq.Expressions;
using Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Models;
using Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Services.Implementation.PropertyAsserters;
using Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Services.Implementation.PropertyAsserters.Implementation;

namespace Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Services.Implementation
{
    internal class PropertyAssertionBuilder<T, TP> : IPropertyAssertionBuilder<T, TP>
    {
        private readonly Expression<Func<T, TP>> _propertyExpression;
        private readonly ConstructorPropertyMapper<T> _propertyMapper;
        private IPropertyValueAsserter<TP> _propertyAsserter;

        public PropertyAssertionBuilder(ConstructorPropertyMapper<T> propertyMapper, Expression<Func<T, TP>> propertyExpression)
        {
            _propertyMapper = propertyMapper;
            _propertyExpression = propertyExpression;
        }

        public AssertionResult Assert(T objectToCheck)
        {
            var actualPropertyValue = _propertyExpression.Compile().Invoke(objectToCheck);
            return _propertyAsserter.Assert(actualPropertyValue);
        }

        public IConstructorPropertyMapper<T> WithValue(TP expectedValue)
        {
            _propertyAsserter = new EqualityAsserter<TP>(expectedValue);
            return _propertyMapper;
        }

        public IConstructorPropertyMapper<T> WithValues(TP values)
        {
            _propertyAsserter = new CollectionAsserter<TP>(values);
            return _propertyMapper;
        }
    }
}