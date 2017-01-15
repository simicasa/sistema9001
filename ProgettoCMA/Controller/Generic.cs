using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoCMA.Controller
{
    class Generic
    {
        public Generic()
        {

        }

        public static MethodInfo getGenericMethod(Type parentType, string methodName, Type genericMethodType, BindingFlags bindingFlags = BindingFlags.Default, Func<MethodInfo, bool> func = null)
        {
            GenericFactory g = new GenericFactory(parentType);
            return g.getGenericMethod(methodName, genericMethodType, bindingFlags, func);
        }
        public static MethodInfo getGenericMethod(Type parentType, string methodName, Type[] genericMethodTypes, BindingFlags bindingFlags = BindingFlags.Default, Func<MethodInfo, bool> func = null)
        {
            GenericFactory g = new GenericFactory(parentType);
            return g.getGenericMethod(methodName, genericMethodTypes, bindingFlags, func);
        }
        /*
        public static dynamic invokeMethod(dynamic instance, Type instanceType, string methodName, Type genericType = null, Object[] parameters = null)
        {
            MethodInfo method = instanceType.GetMethod(methodName);
            if (method == null)
            {
                throw new Exception("invokeMethod: metodo " + methodName + " non trovato nel tipo " + instanceType.Name);
            }
            if (genericType != null)
            {
                method = method.MakeGenericMethod(genericType);
            }
            return method?.Invoke(instance, parameters);
        }
        */
    }
}
