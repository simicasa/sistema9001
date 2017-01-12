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
        private dynamic findComparisonFunc;

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
            this.findComparisonFunc = this.CreateFindComparisonFunc();
        }
        public void Find(string searchText)
        {
            this.DataSourceFindAndUpdate(new Func<dynamic, bool>(instance => this.findComparisonFunc(instance, searchText)));
        }
        private dynamic CreateFindComparisonFunc()
        {
            var parameterExp = Expression.Parameter(typeof(Cliente), "type");
            var parameterText = Expression.Parameter(typeof(String), "searchText");
            var propertyExp = Expression.Property(parameterExp, this.memberToShow);
            MethodInfo method = typeof(string).GetMethod("IndexOf", new[] { typeof(string), typeof(StringComparison) });
            var strComparison = Expression.Constant(StringComparison.OrdinalIgnoreCase, typeof(StringComparison));
            var containsMethodExp = Expression.Call(propertyExp, method, new Expression[] { parameterText, strComparison });
            var containsMethodExp2 = Expression.GreaterThanOrEqual(containsMethodExp, Expression.Constant(0, typeof(int)));
            var casa = Expression.Lambda(containsMethodExp2, new ParameterExpression[] { parameterExp, parameterText }).Compile();
            return casa;
        }
        private void DataSourceFindAndUpdate(dynamic func)
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
