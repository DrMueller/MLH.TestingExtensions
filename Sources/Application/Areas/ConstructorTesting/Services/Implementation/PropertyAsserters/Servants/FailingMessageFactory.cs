using Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Services.Servants;

namespace Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Services.Implementation.PropertyAsserters.Servants
{
    internal static class FailingMessageFactory
    {
        internal static string CreateNotEqualMessage(object expected, object actual)
        {
            var expectedValueString = ObjectInterpreter.GetStringRepresentation(expected);
            var actualValueString = ObjectInterpreter.GetStringRepresentation(actual);

            var message = $"Expected '{expectedValueString}' to equal actual '{actualValueString}'.";
            return message;
        }
    }
}