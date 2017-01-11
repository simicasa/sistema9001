using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoCMA.Controller
{
    class Generic
    {
        public static dynamic createInstance(Type type, Type genericType = null, Object[] parameters = null)
        {
            if(genericType != null)
            {
                type = type.MakeGenericType(genericType);
            }
            return (Activator.CreateInstance(type, parameters));
        }
        public static dynamic createInstance(Type type, Object[] parameters = null, Type genericType = null)
        {
            return (createInstance(type, genericType, parameters));
        }

        public static dynamic invokeMethod(dynamic instance, string methodName, Object[] parameters = null)
        {
            return instance.GetMethod(methodName)?.Invoke(instance, parameters);
        }
    }
}
