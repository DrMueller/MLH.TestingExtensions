using Mmu.Mlh.TestingExtensions.Areas.Common.Assertions.Models;
using Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Services.Implementation.PropertyAsserters.Servants;

namespace Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Services.Implementation.PropertyAsserters.Implementation
{
    public class EqualityAsserter<TP> : IPropertyValueAsserter<TP>
    {
        private readonly TP _expectedValue;

        public EqualityAsserter(TP expectedValue)
        {
            _expectedValue = expectedValue;
        }

        public AssertionResult Assert(TP actualPropertyValue)
        {
            var notEqualMessage = FailingMessageFactory.CreateNotEqualMessage(_expectedValue, actualPropertyValue);

            var actualIsNull = actualPropertyValue == null;
            var expectedIsNull = _expectedValue == null;

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

            if (actualPropertyValue.Equals(_expectedValue))
            {
                return AssertionResult.CreateSuccess();
            }

            return AssertionResult.CreateFail(notEqualMessage);
        }
    }
}