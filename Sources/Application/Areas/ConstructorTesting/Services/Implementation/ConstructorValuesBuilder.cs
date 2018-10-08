using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Mmu.Mlh.LanguageExtensions.Areas.StringBuilders;
using Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Services.Servants;
using n = NUnit.Framework;

namespace Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Services.Implementation
{
    internal class ConstructorValuesBuilder<T> : IConstructorValuesBuilder<T>
    {
        private readonly List<ConstructorAssertionSelector<T>> _constructorAssertionSelectors = new List<ConstructorAssertionSelector<T>>();
        private readonly ConstructorInfo _constructorInfo;

        public ConstructorValuesBuilder(ConstructorInfo constructorInfo)
        {
            _constructorInfo = constructorInfo;
        }

        public void Assert()
        {
            var failingAssertions = _constructorAssertionSelectors.Select(f => f.Assert()).Where(f => !f.IsSuccess);
            if (!failingAssertions.Any())
            {
                return;
            }

            var sb = new StringBuilder();
            sb.AppendLine($"Assertion of type '{typeof(T).Name}' failed.");
            sb.AppendLineWithIndentation($"Constructor: {ConstructorInterpreter.GetStringRepresentation(_constructorInfo)}", 2);

            n.Assert.Fail(sb.ToString());
        }

        public IConstructorAssertionSelector<T> WithArgumentValues(params object[] argumentValues)
        {
            var constructorAssertionSelector = new ConstructorAssertionSelector<T>(this, _constructorInfo, argumentValues);
            _constructorAssertionSelectors.Add(constructorAssertionSelector);
            return constructorAssertionSelector;
        }
    }
}