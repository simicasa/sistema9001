using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoCMA.Controller
{
    class GenericFactory
    {
        Type type;
        public GenericFactory(Type type)
        {
            this.type = type;
        }

        private MethodInfo GetMethod(String methodName, BindingFlags bindingFlags = BindingFlags.Default)
        {
            if(bindingFlags == BindingFlags.Default)
            {
                return (this.type.GetMethod(methodName));
            }
            return (this.type.GetMethod(methodName, bindingFlags));
        }
        private MethodInfo GetMethod(String methodName, Func<MethodInfo, bool> whereClause, BindingFlags bindingFlags = BindingFlags.Default)
        {
            MethodInfo[] methods;
            if (bindingFlags == BindingFlags.Default)
            {
                methods = this.type.GetMethods();
            }
            else
            {
                methods = this.type.GetMethods(bindingFlags);
            }
            var filteredMethods = methods.Where(mi => mi.Name == methodName).Where(whereClause);
            /*
            foreach (var item in filteredMethods)
            {
                foreach (var itemm in item.GetParameters())
                {
                    Console.WriteLine(itemm.Name + " " + itemm.ParameterType.ToString());
                }
                Console.WriteLine(" " + item.ReturnType.ToString());
            }
            */
            int methodsCount;
            if ((methodsCount = filteredMethods.Count()) != 1)
            {
                /*
                foreach (var item in filteredMethods)
                {
                    Console.WriteLine(item.GetParameters().Count().ToString());
                    foreach(var itemm in item.GetParameters())
                    {
                        Console.WriteLine(itemm.Name + " " + itemm.ParameterType.Name);
                    }
                }
                */
                throw new Exception("GetMethod dopo la clausola where ha " + methodsCount + " risultati per la funzione " + methodName);
            }
            return (filteredMethods.First());
        }
        public MethodInfo getGenericMethod(String methodName, Type genericMethodType, BindingFlags bindingFlags = BindingFlags.Default, Func<MethodInfo, bool> func = null)
        {
            return this.getGenericMethod(methodName, new Type[] { genericMethodType }, bindingFlags, func);
        }
        public MethodInfo getGenericMethod(String methodName, Type[] genericMethodTypes, BindingFlags bindingFlags = BindingFlags.Default, Func<MethodInfo, bool> func = null)
        {
            MethodInfo method = (func != null) ? this.GetMethod(methodName, func, bindingFlags) : method = this.GetMethod(methodName, bindingFlags);
            return (genericMethodTypes == null) ? method : method.MakeGenericMethod(genericMethodTypes);
        }
        public dynamic invokeMethod(String methodName, dynamic instance, Type genericMethodType = null, Object[] methodParameters = null)
        {
            MethodInfo asd = this.getGenericMethod(methodName, genericMethodType);
            var dsa = asd.Invoke(instance, methodParameters);
            return dsa;
        }
        public static Type MakeGenericType(Type typeToGeneralize, Type[] generalizationTypes)
        {
            return typeToGeneralize.MakeGenericType(generalizationTypes);
        }
        public static dynamic createInstance(Type type, Type[] genericType = null, Object[] parameters = null)
        {
            if (genericType != null)
            {
                type = type.MakeGenericType(genericType);
            }
            return (Activator.CreateInstance(type, parameters));
        }
        public static dynamic createInstance(Type type, Object[] parameters = null, Type genericType = null)
        {
            return (createInstance(type, new Type[] { genericType }, parameters));
        }
    }
}
