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
            if (actualPropertyValue.Equals(_expectedValue))
            {
                return AssertionResult.CreateSuccess();
            }

            var notEqualMessage = FailingMessageFactory.CreateNotEqualMessage(_expectedValue, actualPropertyValue);
            return AssertionResult.CreateFail(notEqualMessage);
        }
    }
}