using System;
using NUnit.Framework;

namespace Mmu.Mlh.TestingExtensions.Areas.PatternTesting.Disposables
{
    public class DisposableTest<T>
        where T : class, IDisposable
    {
        private readonly DisposeInterceptor _interceptor;
        public T TestObject { get; }

        internal DisposableTest(T testObject, DisposeInterceptor interceptor)
        {
            TestObject = testObject;
            _interceptor = interceptor;
        }

        public void AssertDisposed()
        {
            if (!_interceptor.DisposeWasCalled)
            {
                Assert.Fail(AssertionErrorMessages.ObjectNotDisposedErrorMessage);
            }

            if (_interceptor.MemberWasInvokedAfterDisposal)
            {
                Assert.Fail(AssertionErrorMessages.MemberCalledAfterDisposedErrorMessage);
            }
        }
    }
}