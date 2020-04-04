using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Services.Servants
{
    internal static class ObjectFactory
    {
        internal static bool TryCreatingObject<T>(out T createdObject, ConstructorInfo constructorInfo, params object[] argumentValues)
        {
            try
            {
                var args = argumentValues?.ToList() ?? new List<object> { null };
                SpreadParamsParameter(constructorInfo, args);
                createdObject = (T)constructorInfo.Invoke(args.ToArray());
                return true;
            }
            catch (Exception)
            {
                createdObject = default;
                return false;
            }
        }

        private static void SpreadParamsParameter(MethodBase constructorInfo, IList<object> args)
        {
            // This block is needed to spread the params argument
            var ctorParams = constructorInfo.GetParameters();
            var paramsCnt = ctorParams.Length;
            var lastParam = ctorParams.Last();
            var paramArrayAttr = lastParam.GetCustomAttribute<ParamArrayAttribute>();

            if (paramArrayAttr != null)
            {
                var argsAtAndAfterParamPosition = args.Where(f => args.IndexOf(f) + 1 >= paramsCnt).ToList();
                Array paramsArray;
                var arrayType = lastParam.ParameterType.GetElementType();

                if (arrayType == null)
                {
                    throw new Exception("Something went horribly wrong.");
                }

                if (!argsAtAndAfterParamPosition.Any())
                {
                    // This means, there was no args passed to the params
                    // Therefore we pass an empty array
                    // As the params has to be array, we need to take the element type
                    paramsArray = Array.CreateInstance(arrayType, 0);
                }
                else
                {
                    // This means exactly one arg was passed to the params
                    // Therefore, we create an array and pass the value as entry
                    // As we need the correct type, we recreate it
                    paramsArray = Array.CreateInstance(arrayType, argsAtAndAfterParamPosition.Count);
                    for (var i = 0; i < argsAtAndAfterParamPosition.Count; i++)
                    {
                        paramsArray.SetValue(argsAtAndAfterParamPosition[i], i);
                    }
                }

                argsAtAndAfterParamPosition.ForEach(arg => args.Remove(arg));
                args.Add(paramsArray);
            }
        }
    }
}