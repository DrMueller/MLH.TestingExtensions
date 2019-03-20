using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Mmu.Mlh.LanguageExtensions.Areas.Collections;
using Mmu.Mlh.TestingExtensions.Areas.Common.Assertions.Models;
using Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Services.Servants;

namespace Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Services.Implementation.PropertyAsserters.Implementation
{
    internal class CollectionAsserter<TP> : IPropertyValueAsserter<TP>
    {
        private readonly IEnumerable<object> _expectedValues;

        public CollectionAsserter(TP expectedValues)
        {
            _expectedValues = expectedValues as IEnumerable<object>;
        }

        [SuppressMessage("Microsoft.Usage", "SA1119:StatementMustNotUseUnnecessaryParenthesis", Justification = "Bug in StyleCop")]
        public AssertionResult Assert(TP actualPropertyValue)
        {
            var actualValueString = ObjectInterpreter.GetStringRepresentation(actualPropertyValue);

            if (!(actualPropertyValue is IEnumerable<object> actualCollection))
            {
                var notEnumerableMessage = $"Actual values '{actualValueString}' is not an IEnumerable.";
                return AssertionResult.CreateFail(notEnumerableMessage);
            }

            if (actualCollection.HasSameElementsAs(_expectedValues))
            {
                return AssertionResult.CreateSuccess();
            }

            var expectedValueString = ObjectInterpreter.GetStringRepresentation(_expectedValues);
            var message = $"Expected values '{expectedValueString}' to equal '{actualValueString}'.";
            return AssertionResult.CreateFail(message);
        }
    }
}