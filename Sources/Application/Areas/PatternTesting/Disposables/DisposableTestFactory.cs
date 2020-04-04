using System;
using Castle.DynamicProxy;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlh.TestingExtensions.Areas.PatternTesting.Disposables
{
    public static class DisposableTestFactory
    {
        public static DisposableTest<TDis> Create<TDis>(Func<TDis> targetFactoryFunc)
            where TDis : class, IDisposable
        {
            Guard.That(() => typeof(TDis).IsInterface, "Disposable type has to be an Interface.");

            var generator = new ProxyGenerator();
            var interceptor = new DisposeInterceptor();

            var proxy = generator.CreateInterfaceProxyWithTarget(targetFactoryFunc(), interceptor);

            return new DisposableTest<TDis>(proxy, interceptor);
        }
    }
}