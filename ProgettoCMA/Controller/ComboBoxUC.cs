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
    class ComboBoxUC : ComboBox, IController
    {
        private Controller controller;
        private string memberToShow;
        private Type type;
        private dynamic findComparisonFunc;

        public ComboBoxUC()
        {
            this.controller = new Controller();
        }
        public void Initialize(Type type, string memberToShow)
        {
            this.type = type;
            this.DataSourceUpdate(Shared.cdc.Set(this.type));
            this.memberToShow = memberToShow;
            this.findComparisonFunc = this.CreateFindComparisonFunc(memberToShow);
            this.OrderBy(memberToShow, false);
        }
        public void Find(string searchText)
        {
            this.DataSourceFindAndUpdate(new Func<dynamic, bool>(instance => this.findComparisonFunc(instance, searchText)));
        }
        private dynamic CreateFindComparisonFunc(String fieldToSearch)
        {
            var parameterExp = Expression.Parameter(typeof(Cliente), "type");
            var parameterText = Expression.Parameter(typeof(String), "searchText");
            var propertyExp = Expression.Property(parameterExp, fieldToSearch);

            UnaryExpression convertToObjectExpr = Expression.Convert(propertyExp, typeof(object));
            var convertedExpression = Expression.Call(convertToObjectExpr, typeof(object).GetMethod("ToString"));

            MethodInfo indexOfMethod = typeof(string).GetMethod("IndexOf", new Type[] { typeof(string), typeof(StringComparison) });
            var strComparison = Expression.Constant(StringComparison.OrdinalIgnoreCase, typeof(StringComparison));
            var containsMethodExp = Expression.Call(convertedExpression, indexOfMethod, new Expression[] { parameterText, strComparison });
            var containsMethodExp2 = Expression.GreaterThanOrEqual(containsMethodExp, Expression.Constant(0, typeof(int)));
            var casa = Expression.Lambda(containsMethodExp2, new ParameterExpression[] { parameterExp, parameterText }).Compile();
            return casa;
        }
        private dynamic CreateOrderByFunc(String fieldToOrder)
        {
            var parameterExp = Expression.Parameter(typeof(Cliente), "type");
            var propertyExp = Expression.Property(parameterExp, fieldToOrder);
            var casa = Expression.Lambda(propertyExp, new ParameterExpression[] { parameterExp }).Compile();
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
            this.DataSource = this.controller.bindingListCreate(list, this.type);
        }
        public void OrderBy(String fieldToOrder, bool savePreviousSelected = true)
        {
            this.ValueMember = fieldToOrder;
            this.DisplayMember = fieldToOrder;
            this.findComparisonFunc = this.CreateFindComparisonFunc(fieldToOrder.ToString());
            dynamic selectedItem = this.SelectedItem;
            PropertyInfo fieldInfo = this.type.BaseType.GetProperty(fieldToOrder, BindingFlags.IgnoreCase | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
            if (fieldInfo == null)
            {
                throw new Exception("non esiste la property " + fieldToOrder);
            }
            MethodInfo orderByMethod = Generic.getGenericMethod(typeof(Enumerable), "OrderBy", new Type[] { this.type, typeof(Object) }, BindingFlags.Static | BindingFlags.Public, new Func<MethodInfo, bool>(orderby => orderby.GetParameters().Count() == 2));
            var list = orderByMethod.Invoke(this.DataSource, new Object[] { this.DataSource, new Func<dynamic, Object>(instance => this.CreateOrderByFunc(fieldToOrder)(instance)) });
            this.DataSourceUpdate(list);
            if (savePreviousSelected)
            {
                this.SelectedItem = selectedItem;
            }
        }
    }
}
