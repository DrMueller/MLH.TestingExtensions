using System.Reflection;
using Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Models;
using Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Services.Servants;

namespace Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Services.Implementation
{
    internal class ConstructorAsserter<T> : IAssertable
    {
        private readonly object[] _argumentValues;
        private readonly bool _constructingShouldFail;
        private readonly ConstructorInfo _constructorInfo;

        public ConstructorAsserter(
            ConstructorInfo constructorInfo,
            bool constructingShouldFail,
            params object[] argumentValues)
        {
            _constructorInfo = constructorInfo;
            _argumentValues = argumentValues;
            _constructingShouldFail = constructingShouldFail;
        }

        public AssertionResult Assert()
        {
            var canCreateobject = ObjectFactory.TryCreatingObject(out T _, _constructorInfo, _argumentValues);

            if (canCreateobject && _constructingShouldFail)
            {
                var shouldFailMessage = $"    Arguments '{ObjectInterpreter.GetStringRepresentation(_argumentValues)}' should fail.";
                return AssertionResult.CreateFail(shouldFailMessage);
            }

            if (!canCreateobject && !_constructingShouldFail)
            {
                var shouldNotFailMessage = $"    Arguments '{ObjectInterpreter.GetStringRepresentation(_argumentValues)}' should not fail.";
                return AssertionResult.CreateFail(shouldNotFailMessage);
            }

            return AssertionResult.CreateSuccess();
        }
    }
}