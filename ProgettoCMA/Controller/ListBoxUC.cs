using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgettoCMA.Controller
{
    class ListBoxUC : ListBox, IController
    {
        private Controller controller;
        private string memberToShow;
        private Type type;

        public ListBoxUC()
        {
            this.controller = new Controller();
        }
        public void Initialize(Type type, string memberToShow)
        {
            this.type = type;
            this.controller.type = this.type;
            this.DataSourceUpdate(Shared.cdc.Set(this.type));
            this.memberToShow = memberToShow;
            this.ValueMember = memberToShow;
            this.DisplayMember = memberToShow;
        }
        public void Find(string puntotext, Func<Cliente, bool> prova = null)
        {
            //Func<dynamic, bool> f = new Func<dynamic, bool>(a);
            //var a = GenericFactory.createInstance(typeof(Func<>), new Type[] { typeof(Cliente), typeof(bool) }, new Object[] { typeof(Cliente), typeof(bool) });
            //typeof(Func<>).GetConstructor(new Type[] { typeof(Cliente), typeof(bool) }).Invoke();
            if(prova == null)
            {
                this.DataSourceFindAndUpdate(new Func<Cliente, bool>(a => a.Ragione.IndexOf(puntotext, StringComparison.OrdinalIgnoreCase) >= 0));
            }
            else
            {
                this.DataSourceFindAndUpdate(prova);
            }
        }
        public void asd1()
        {
            /*
            ParameterExpression parameterX = Expression.Parameter(typeof(Cliente), "x");
            ParameterExpression parameterY = Expression.Parameter(typeof(bool), "x.ID == 1");
            Expression addXMultiplyYZ = Expression.(parameterX, parameterY);
            Func<Cliente, bool> f = Expression.Lambda<Func<Cliente, bool>>
            (
                addXMultiplyYZ,
                parameterX,
                parameterY
            ).Compile();
            Console.WriteLine(f(new Cliente(), 6));
            */

            /*
            Func<Cliente, object> asd = this.GetLambda<Cliente>("Ragione");
            Shared.messageBox(asd.ToString());
            */

            //this.Find("", asd);







            /*
            ParameterExpression parameterX = Expression.Parameter(typeof(Cliente), "x.Ragione");
            ParameterExpression parameterY = Expression.Parameter(typeof(bool), "y");


            Type a = GenericFactory.MakeGenericType(typeof(Func<,>), new Type[] { typeof(Cliente), typeof(bool) });
            GenericFactory g = new GenericFactory(typeof(Expression));
            MethodInfo b = g.getGenericMethod("Lambda", a, BindingFlags.Default, new Func<MethodInfo, bool>(set => set.IsGenericMethod && set.GetParameters()[1].ParameterType == typeof(ParameterExpression[])));
            
            var c = b.Invoke(null, new Object[] { parameterY, new ParameterExpression[] { parameterX } });

            Type aaa = GenericFactory.MakeGenericType(typeof(Expression<>), new Type[] { a });
            //GenericFactory g1 = new GenericFactory(typeof(Expression<>));
            GenericFactory g1 = new GenericFactory(aaa);
            //Expression.Lambda<Func<Cliente, bool>>().Compile()
            MethodInfo compile = g1.getGenericMethod("Compile", null, BindingFlags.Default, new Func<MethodInfo, bool>(set => set.GetParameters().Count() == 0 && set.ReturnType == typeof(Delegate))); 
            var cc = compile.Invoke(c, null);
            */





            var lambda1 = typeof(ListBoxUC)
                .GetMethod("GetExpression", new Type[] { typeof(string), typeof(string) })
                .MakeGenericMethod(new Type[] { typeof(Cliente) })
                .Invoke(null, new Object[] { "Ragione", "z" });
            /*
            //MethodInfo test1 = .GetType().GetConstructor(new Type[] { }).Invoke(null);
            MethodInfo test1 = typeof(Expression<>).GetMethods().Where(mi => mi.Name == "Compile").First();
            //var test11 = test1.MakeGenericMethod(new Type[] { typeof(Func<,>) }); 
            var test111 = test1.Invoke(lambda1, new Object[] { foo });
            Shared.messageBox(foo.Ragione.ToString() + " " + test111.ToString());
            */


            //Shared.messageBox(cc.ToString());

            /*
            typeof(Expression).GetConstructor(new Type[] { typeof(Cliente), typeof(bool) }).Invoke();
            typeof(Func<>).GetConstructor(new Type[] { typeof(Cliente), typeof(bool) }).Invoke();
            Func<int, bool> f = Expression.Lambda<Func<int, bool>>
            (
                parameterY,
                parameterX
            ).Compile();
            */
            //Console.WriteLine(f(c => c.ID == 1)); // prints 42 to the console
        }
        public void asd()
        {
            typeof(ListBoxUC).GetMethod("asd2").MakeGenericMethod(new Type[] { typeof(Cliente) }).Invoke(this, null);
            //this.asd2<Cliente>();
        }
        public void asd2<T>()
        {
            T foo = Shared.cdc.AziendaSet.OfType<T>().First();
            var lambda = GetExpression<T>("Ragione", "Z");
            bool test = lambda.Compile()(foo);
            Shared.messageBox(test.ToString());
        }
        public static Expression<Func<T, bool>> GetExpression<T>(string propertyName, string propertyValue)
        {
            var parameterExp = Expression.Parameter(typeof(T), "type");
            var propertyExp = Expression.Property(parameterExp, propertyName);
            MethodInfo method = typeof(string).GetMethod("Contains", new[] { typeof(string) });
            var someValue = Expression.Constant(propertyValue, typeof(string));
            var containsMethodExp = Expression.Call(propertyExp, method, someValue);

            return Expression.Lambda<Func<T, bool>>(containsMethodExp, parameterExp);
        }
        public void DataSourceFindAndUpdate(dynamic func)
        {
            MethodInfo setMethod = Generic.getGenericMethod(typeof(DbContext), "Set", this.type, BindingFlags.Default, new Func<MethodInfo, bool>(set => set.IsGenericMethod));
            MethodInfo whereMethod = Generic.getGenericMethod(typeof(Enumerable), "Where", this.type, BindingFlags.Static | BindingFlags.Public, new Func<MethodInfo, bool>(where => where.GetParameters()[1].ParameterType.GetGenericArguments().Count() == 2));
            var dbSet = setMethod.Invoke(Shared.cdc, null);
            var list = whereMethod.Invoke(dbSet, new Object[] { dbSet, func });
            this.DataSourceUpdate(list);
        }
        private void DataSourceUpdate(dynamic list)
        {
            this.controller.bindingListCreate(list);
            this.DataSource = this.controller.bindingListGet();
        }
    }
}
