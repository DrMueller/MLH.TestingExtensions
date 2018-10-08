using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Mmu.Mlh.TestingExtensions.Areas.Common.Assertions.Models;

namespace Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Services.Implementation
{
    internal class ConstructorAssertionSelector<T> : IConstructorAssertionSelector<T>
    {
        private readonly object[] _argumentValues;
        private readonly List<IAssertable> _assertables;
        private readonly ConstructorInfo _constructorInfo;
        private readonly IConstructorValuesBuilder<T> _constructorValuesBuilder;

        public ConstructorAssertionSelector(
            IConstructorValuesBuilder<T> constructorValuesBuilder,
            ConstructorInfo constructorInfo,
            params object[] argumentValues)
        {
            _constructorValuesBuilder = constructorValuesBuilder;
            _constructorInfo = constructorInfo;
            _argumentValues = argumentValues;
            _assertables = new List<IAssertable>();
        }

        public IConstructorAsserter<T> Is()
        {
            var asserter = new ConstructorAsserter<T>(_constructorValuesBuilder, _constructorInfo, _argumentValues);
            _assertables.Add(asserter);
            return asserter;
        }

        public IConstructorPropertyMapper<T> Maps()
        {
            var mapper = new ConstructorPropertyMapper<T>(_constructorValuesBuilder, _constructorInfo, _argumentValues);
            _assertables.Add(mapper);
            return mapper;
        }

        internal AssertionResult Assert()
        {
            var failingAssertions = _assertables.Select(f => f.Assert()).Where(f => !f.IsSuccess).ToList();

            if (!failingAssertions.Any())
            {
                return AssertionResult.CreateSuccess();
            }

            var sb = new StringBuilder();
            failingAssertions.ForEach(
                f =>
                {
                    sb.Append(f.Message);
                });

            return AssertionResult.CreateFail(sb.ToString());
        }
    }
}