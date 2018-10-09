using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using Mmu.Mlh.LanguageExtensions.Areas.Collections;
using Mmu.Mlh.LanguageExtensions.Areas.StringBuilders;
using Mmu.Mlh.TestingExtensions.Areas.Common.Assertions.Models;
using Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Services.Servants;

namespace Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Services.Implementation
{
    internal class ConstructorPropertyMapper<T> : IConstructorPropertyMapper<T>, IAssertable
    {
        private readonly object[] _argumentValues;
        private readonly ConstructorInfo _constructorInfo;
        private readonly List<IAssertableProperty<T>> _propertyAssertionBuilders = new List<IAssertableProperty<T>>();
        private readonly IConstructorValuesBuilder<T> _valuesBuilder;

        public ConstructorPropertyMapper(IConstructorValuesBuilder<T> valuesBuilder, ConstructorInfo constructorInfo, params object[] argumentValues)
        {
            _valuesBuilder = valuesBuilder;
            _constructorInfo = constructorInfo;
            _argumentValues = argumentValues;
        }

        public AssertionResult Assert()
        {
            if (!ObjectFactory.TryCreatingObject<T>(out var createdObject, _constructorInfo, _argumentValues))
            {
                return AssertionResult.CreateFail("    Could not create Object to check Propertes.");
            }

            var failingPropertyAssertions = _propertyAssertionBuilders.Select(f => f.Assert(createdObject)).Where(f => !f.IsSuccess).ToList();
            if (!failingPropertyAssertions.Any())
            {
                return AssertionResult.CreateSuccess();
            }

            var sb = new StringBuilder();
            _propertyAssertionBuilders
                .Select(f => f.Assert(createdObject))
                .Where(f => !f.IsSuccess)
                .ForEach(f => sb.AppendLineWithIndentation(f.Message, 4));

            return AssertionResult.CreateFail(sb.ToString());
        }

        public IConstructorValuesBuilder<T> BuildMaps()
        {
            return _valuesBuilder;
        }

        public IPropertyAssertionBuilder<T, TP> ToProperty<TP>(Expression<Func<T, TP>> propertyExpression)
        {
            var asserter = new PropertyValueAsserter<T, TP>(this, propertyExpression);
            _propertyAssertionBuilders.Add(asserter);

            return asserter;
        }
    }
}