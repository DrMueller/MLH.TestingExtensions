using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Mmu.Mlh.LanguageExtensions.Areas.Collections;
using Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Models;
using Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Services.Implementation.PropertyAsserters.Servants;
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
            var notEqualMessage = FailingMessageFactory.CreateNotEqualMessage(_expectedValues, actualPropertyValue);

            var actualIsNull = actualPropertyValue == null;
            var expectedIsNull = _expectedValues == null;

            // Both Null = fine
            if (actualIsNull && expectedIsNull)
            {
                return AssertionResult.CreateSuccess();
            }

            // One Null = Not fine
            if (!actualIsNull ^ !expectedIsNull)
            {
                return AssertionResult.CreateFail(notEqualMessage);
            }

            // Compare enumerables
            if (!(actualPropertyValue is IEnumerable<object> actualCollection))
            {
                var notEnumerableMessage = $"Actual '{ObjectInterpreter.GetStringRepresentation(actualPropertyValue)}' is not an IEnumerable.";
                return AssertionResult.CreateFail(notEnumerableMessage);
            }

            if (actualCollection.HasSameElementsAs(_expectedValues))
            {
                return AssertionResult.CreateSuccess();
            }

            return AssertionResult.CreateFail(notEqualMessage);
        }
    }
}