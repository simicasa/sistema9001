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
        public void Find(string puntotext)
        {
            //Func<dynamic, bool> f = new Func<dynamic, bool>(a);
            //var a = GenericFactory.createInstance(typeof(Func<>), new Type[] { typeof(Cliente), typeof(bool) }, new Object[] { typeof(Cliente), typeof(bool) });
            //typeof(Func<>).GetConstructor(new Type[] { typeof(Cliente), typeof(bool) }).Invoke();
            this.DataSourceFindAndUpdate(new Func<Cliente, bool>(a => a.Ragione.IndexOf(puntotext, StringComparison.OrdinalIgnoreCase) >= 0));
        }
        public void asd()
        {
            ParameterExpression parameterX = Expression.Parameter(typeof(Cliente), "x");
            ParameterExpression parameterY = Expression.Parameter(typeof(bool), "y");
            var a = typeof(Func<,>).MakeGenericType(new Type[] { typeof(Cliente), typeof(bool) });
            //a = a.GetConstructor(new Type[] { typeof(Cliente), typeof(bool) }).
            GenericFactory g = new GenericFactory(typeof(Expression));

            MethodInfo b = g.getGenericMethod("Lambda", a, BindingFlags.Default, new Func<MethodInfo, bool>(set => set.IsGenericMethod && set.GetParameters()[1].ParameterType == typeof(ParameterExpression[])));
            var c = b.Invoke(null, new Object[] { parameterY, new ParameterExpression[] { parameterX } });

            var aaa = typeof(Expression<>).MakeGenericType(new Type[] { a });
            GenericFactory g1 = new GenericFactory(typeof(Expression<>));
            MethodInfo compile = g1.getGenericMethod("Compile", aaa, BindingFlags.Default, new Func<MethodInfo, bool>(set => set.GetParameters().Count() == 0)); //set.ReturnType == a)); 
            var cc = b.Invoke(c, null);

            Shared.messageBox(cc.ToString());

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
