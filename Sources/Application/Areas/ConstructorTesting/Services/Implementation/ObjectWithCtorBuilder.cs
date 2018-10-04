using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;
using n = NUnit.Framework;

namespace Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Services.Implementation
{
    internal class ObjectWithCtorBuilder<T> : IObjectWithCtorBuilder<T>
    {
        private readonly List<CtorTestBuilder<T>> _testBuilders = new List<CtorTestBuilder<T>>();

        public void Assert()
        {
            var failingAssertions = _testBuilders.Select(f => f.Assert()).Where(f => !f.IsSuccess).ToList();
            if (!failingAssertions.Any())
            {
                return;
            }

            var sb = new StringBuilder();
            sb.AppendLine($"Assertions failed for Type {typeof(T).Name} ");
            failingAssertions.ForEach(f => sb.AppendLine(f.Message));

            n.Assert.Fail(sb.ToString());
        }

        public ICtorTestBuilder<T> ForConstructorWithParams(params Type[] argTypes)
        {
            var constructorInfo = GetConstructors().FirstOrDefault(f => CheckIfMatchesArgumentTypes(f, argTypes));
            return CreateTestBuilder(constructorInfo);
        }

        private static bool CheckIfMatchesArgumentTypes(MethodBase constructorInfo, params Type[] argTypes)
        {
            var constructorParamterTypes = constructorInfo.GetParameters().Select(f => f.ParameterType).ToList();
            return constructorParamterTypes.SequenceEqual(argTypes);
        }

        public ICtorTestBuilder<T> ForDefaultConstructor()
        {
            var ctorInfo = GetConstructors().OrderBy(f => f.GetParameters().Length)
                .FirstOrDefault();

            return CreateTestBuilder(ctorInfo);
        }

        private ICtorTestBuilder<T> CreateTestBuilder(ConstructorInfo constructorInfo)
        {
            Guard.ObjectNotNull(() => constructorInfo);
            var ctorTestBuilder = new CtorTestBuilder<T>(this, constructorInfo);
            _testBuilders.Add(ctorTestBuilder);
            return ctorTestBuilder;
        }

        private static IEnumerable<ConstructorInfo> GetConstructors()
        {
            return typeof(T).GetConstructors(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
        }
    }
}