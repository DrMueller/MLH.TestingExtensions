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
            var ctorInfo = typeof(T).GetConstructor(argTypes);
            return CreateTestBuilder(ctorInfo);
        }

        public ICtorTestBuilder<T> ForDefaultConstructor()
        {
            var ctorInfo = typeof(T)
                .GetConstructors()
                .OrderBy(f => f.GetParameters().Length)
                .FirstOrDefault();

            return CreateTestBuilder(ctorInfo);
        }

        private ICtorTestBuilder<T> CreateTestBuilder(ConstructorInfo ctorInfo)
        {
            Guard.ObjectNotNull(() => ctorInfo);
            var ctorTestBuilder = new CtorTestBuilder<T>(this, ctorInfo);
            _testBuilders.Add(ctorTestBuilder);
            return ctorTestBuilder;
        }
    }
}