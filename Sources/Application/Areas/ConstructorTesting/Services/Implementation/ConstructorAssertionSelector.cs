using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Models;

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

        public IConstructorValuesBuilder<T> Fails()
        {
            _assertables.Add(new ConstructorAsserter<T>(_constructorInfo, true, _argumentValues));
            return _constructorValuesBuilder;
        }

        public IConstructorPropertyMapper<T> Maps()
        {
            var mapper = new ConstructorPropertyMapper<T>(_constructorValuesBuilder, _constructorInfo, _argumentValues);
            _assertables.Add(mapper);
            return mapper;
        }

        public IConstructorValuesBuilder<T> Succeeds()
        {
            _assertables.Add(new ConstructorAsserter<T>(_constructorInfo, false, _argumentValues));
            return _constructorValuesBuilder;
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