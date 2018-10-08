using System;
using System.Linq.Expressions;
using Mmu.Mlh.TestingExtensions.Areas.Common.Assertions.Models;
using Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Services.Servants;

namespace Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Services.Implementation
{
    internal class PropertyAssertionBuilder<T, TP> : IPropertyAssertionBuilder<T, TP>
    {
        private readonly Expression<Func<T, TP>> _propertyExpression;
        private readonly ConstructorPropertyMapper<T> _propertyMapper;
        private TP _expectedValue;

        public PropertyAssertionBuilder(ConstructorPropertyMapper<T> propertyMapper, Expression<Func<T, TP>> propertyExpression)
        {
            _propertyMapper = propertyMapper;
            _propertyExpression = propertyExpression;
        }

        public AssertionResult Assert(T objectToCheck)
        {
            var actualValue = _propertyExpression.Compile().Invoke(objectToCheck);
            if (actualValue.Equals(_expectedValue))
            {
                return AssertionResult.CreateSuccess();
            }

            var expectedValueString = ObjectInterpreter.GetStringRepresentation(_expectedValue);
            var actualValueString = ObjectInterpreter.GetStringRepresentation(actualValue);
            var message = $"Expected value '{expectedValueString}' to equal '{actualValueString}'.";
            return AssertionResult.CreateFail(message);
        }

        public IConstructorPropertyMapper<T> WithValue(TP expectedValue)
        {
            _expectedValue = expectedValue;
            return _propertyMapper;
        }
    }
}