using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Mmu.Mlh.LanguageExtensions.Areas.StringBuilders;
using Mmu.Mlh.TestingExtensions.Areas.Common.Assertions.Models;
using Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Services.Servants;

namespace Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Services.Implementation
{
    internal class CtorTestBuilder<T> : ICtorTestBuilder<T>
    {
        private readonly List<CtorTestAsserter<T>> _asserters;
        private readonly ConstructorInfo _ctorInfo;
        private readonly ObjectWithCtorBuilder<T> _objectBuilder;

        public CtorTestBuilder(ObjectWithCtorBuilder<T> objectBuilder, ConstructorInfo ctorInfo)
        {
            _objectBuilder = objectBuilder;
            _ctorInfo = ctorInfo;
            _asserters = new List<CtorTestAsserter<T>>();
        }

        public IObjectWithCtorBuilder<T> Build()
        {
            return _objectBuilder;
        }

        public ICtorTestAsserter<T> WithArgumentValues(params object[] values)
        {
            var asserter = new CtorTestAsserter<T>(this, _ctorInfo, values);
            _asserters.Add(asserter);

            return asserter;
        }

        internal AssertionResult Assert()
        {
            var failingAssertions = _asserters.Select(f => f.Assert()).Where(f => !f.IsSuccess).ToList();

            if (!failingAssertions.Any())
            {
                return AssertionResult.CreateSuccess();
            }

            var sb = new StringBuilder();
            sb.AppendLine($"Assertion of type {typeof(T).Name} failed.");
            sb.AppendLineWithIndentation($"Constructor: {CtorInterpreter.GetStringRepresentation(_ctorInfo)}", 2);

            failingAssertions.ForEach(
                f =>
                {
                    sb.Append(f.Message);
                });

            return AssertionResult.CreateFail(sb.ToString());
        }
    }
}