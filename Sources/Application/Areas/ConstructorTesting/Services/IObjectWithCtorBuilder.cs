using System;

namespace Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Services
{
    public interface IObjectWithCtorBuilder<T>
    {
        void Assert();

        ICtorTestBuilder<T> ForConstructorWithParams(params Type[] argTypes);

        ICtorTestBuilder<T> ForDefaultConstructor();
    }
}