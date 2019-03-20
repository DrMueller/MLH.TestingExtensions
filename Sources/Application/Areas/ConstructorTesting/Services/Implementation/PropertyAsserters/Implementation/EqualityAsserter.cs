using Mmu.Mlh.TestingExtensions.Areas.Common.Assertions.Models;
using Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Services.Servants;

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

            var expectedValueString = ObjectInterpreter.GetStringRepresentation(_expectedValue);
            var actualValueString = ObjectInterpreter.GetStringRepresentation(actualPropertyValue);
            var message = $"Expected value '{expectedValueString}' to equal '{actualValueString}'.";
            return AssertionResult.CreateFail(message);
        }
    }
}