using System;

namespace Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Services
{
    public interface IConstructorSelector<T>
    {
        IConstructorValuesBuilder<T> UsingConstructorWithParameters(params Type[] argTypes);

        IConstructorValuesBuilder<T> UsingDefaultConstructor();
    }
}