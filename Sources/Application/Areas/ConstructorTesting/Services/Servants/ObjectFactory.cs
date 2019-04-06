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
                // If the argumentValues are actually null, they are not recognized
                // So, we create a new array with one entry being null
                var args = argumentValues ?? new object[] { null };
                createdObject = (T)constructorInfo.Invoke(args);
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