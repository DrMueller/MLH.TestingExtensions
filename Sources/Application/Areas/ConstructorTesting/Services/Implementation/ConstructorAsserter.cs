using System;
using System.Reflection;
using Mmu.Mlh.LanguageExtensions.Areas.Exceptions;
using Mmu.Mlh.TestingExtensions.Areas.Common.Assertions.Models;
using Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Services.Servants;

namespace Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Services.Implementation
{
    internal class ConstructorAsserter<T> : IConstructorAsserter<T>, IAssertable
    {
        private readonly IConstructorValuesBuilder<T> _constructorValuesBuilder;
        private readonly ConstructorInfo _ctorInfo;
        private readonly object[] _parameters;
        private bool _shouldFail;

        public ConstructorAsserter(IConstructorValuesBuilder<T> constructorValuesBuilder, ConstructorInfo ctorInfo, params object[] parameters)
        {
            _constructorValuesBuilder = constructorValuesBuilder;
            _ctorInfo = ctorInfo;
            _parameters = parameters;
        }

        public AssertionResult Assert()
        {
            var creationResult = TryCreating(out var createdObject);
            if (!creationResult.IsSuccess)
            {
                return creationResult;
            }

            return AssertionResult.CreateSuccess();
        }

        public IConstructorValuesBuilder<T> Fail()
        {
            _shouldFail = true;
            return _constructorValuesBuilder;
        }

        public IConstructorValuesBuilder<T> Succeeding()
        {
            _shouldFail = false;
            return _constructorValuesBuilder;
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

                var message = $"    Arguments '{ObjectInterpreter.GetStringRepresentation(_parameters)}' should fail.";
                return AssertionResult.CreateFail(message);
            }
            catch (Exception ex)
            {
                if (_shouldFail)
                {
                    return AssertionResult.CreateSuccess();
                }

                var message = $"    Arguments '{ObjectInterpreter.GetStringRepresentation(_parameters)}' should not fail. Received Exception: {ex.GetMostInnerException().Message}";
                return AssertionResult.CreateFail(message);
            }
        }
    }
}