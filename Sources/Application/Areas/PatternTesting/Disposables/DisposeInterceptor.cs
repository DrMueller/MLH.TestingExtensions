using Castle.DynamicProxy;

namespace Mmu.Mlh.TestingExtensions.Areas.PatternTesting.Disposables
{
    public class DisposeInterceptor : IInterceptor
    {
        public bool DisposeWasCalled { get; private set; }
        public bool MemberWasInvokedAfterDisposal { get; private set; }

        public void Intercept(IInvocation invocation)
        {
            if (invocation.Method.Name == "Dispose")
            {
                DisposeWasCalled = true;
            }
            else if (DisposeWasCalled)
            {
                MemberWasInvokedAfterDisposal = true;
            }

            invocation.Proceed();
        }
    }
}