using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using Mmu.Mlh.LanguageExtensions.Areas.Collections;
using Mmu.Mlh.LanguageExtensions.Areas.Exceptions;
using Mmu.Mlh.LanguageExtensions.Areas.StringBuilders;
using Mmu.Mlh.TestingExtensions.Areas.Common.Assertions.Models;
using Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Services.Servants;

namespace Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Services.Implementation
{
    internal class CtorTestAsserter<T> : ICtorTestAsserter<T>
    {
        private readonly ConstructorInfo _ctorInfo;
        private readonly object[] _parameters;
        private readonly List<IPropertyAssertable<T>> _propertyTestAsserters = new List<IPropertyAssertable<T>>();
        private readonly ICtorTestBuilder<T> _testBuilder;
        private bool _shouldFail;

        public CtorTestAsserter(ICtorTestBuilder<T> testBuilder, ConstructorInfo ctorInfo, params object[] parameters)
        {
            _testBuilder = testBuilder;
            _ctorInfo = ctorInfo;
            _parameters = parameters;
        }

        public ICtorTestBuilder<T> Fails()
        {
            _shouldFail = true;
            return _testBuilder;
        }

        public IPropertyTestAsserter<T, TP> MapsToProperty<TP>(Expression<Func<T, TP>> propertyExpression)
        {
            var asserter = new PropertyTestAsserter<T, TP>(this, propertyExpression);
            _propertyTestAsserters.Add(asserter);

            return asserter;
        }

        public ICtorTestBuilder<T> Succeeds()
        {
            _shouldFail = false;
            return _testBuilder;
        }

        internal AssertionResult Assert()
        {
            var creationResult = TryCreating(out var createdObject);
            if (!creationResult.IsSuccess)
            {
                return creationResult;
            }

            var failingPropertyAssertions = _propertyTestAsserters.Select(f => f.Assert(createdObject)).Where(f => !f.IsSuccess).ToList();

            if (!failingPropertyAssertions.Any())
            {
                return AssertionResult.CreateSuccess();
            }

            var sb = new StringBuilder();
            _propertyTestAsserters
                .Select(f => f.Assert(createdObject))
                .Where(f => !f.IsSuccess)
                .ForEach(f => sb.AppendLineWithIndentation(f.Message, 4));

            return AssertionResult.CreateFail(sb.ToString());
        }

        private AssertionResult TryCreating(out T createdObject)
        {
            createdObject = default(T);
            try
            {
                createdObject = (T)_ctorInfo.Invoke(_parameters);
                if (!_shouldFail)
                {
                    return AssertionResult.CreateSuccess();
                }

                var message = $"Arguments '{ObjectInterpreter.GetStringRepresentation(_parameters)}' should fail.";
                return AssertionResult.CreateFail(message);
            }
            catch (Exception ex)
            {
                if (_shouldFail)
                {
                    return AssertionResult.CreateSuccess();
                }

                var message = $"Arguments '{ObjectInterpreter.GetStringRepresentation(_parameters)}' should not fail. Received Exception: {ex.GetMostInnerException().Message}";
                return AssertionResult.CreateFail(message);
            }
        }
    }
}