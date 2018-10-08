using System;
using System.Reflection;

namespace Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Services.Servants
{
    internal static class ObjectFactory
    {
        internal static bool TryCreatingObject<T>(out T createdObject, ConstructorInfo constructorInfo, params object[] argumentValues)
        {
            try
            {
                createdObject = (T)constructorInfo.Invoke(argumentValues);
                return true;
            }
            catch (Exception)
            {
                createdObject = default(T);
                return false;
            }
        }
    }
}