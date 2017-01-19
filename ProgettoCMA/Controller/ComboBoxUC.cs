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
        private Type type;

        public ComboBoxUC()
        {
            this.controller = new Controller(true);
            this.type = null;
        }
        public void Initialize(Type type, dynamic list, ComboBoxStyle style = ComboBoxStyle.DropDownList)
        {
            this.type = type;
            this.StyleUpdate(style);
            this.DataSourceUpdate(list);
        }
        private void DataSourceUpdate(dynamic list)
        {
            this.DataSource = this.CreateBindingList(list);
        }
        private dynamic CreateBindingList(dynamic list, Type type = null)
        {
            Type bindingListType = (type != null) ? type : this.type;
            return this.controller.bindingListCreate(list, bindingListType);
        }
        public void StyleUpdate(ComboBoxStyle style)
        {
            this.DropDownStyle = style;
        }
        public void Sort()
        {
            GenericFactory g = new GenericFactory(typeof(Enumerable));
            var dataSourceList = g.invokeMethod("ToList", null, this.type, this.DataSource);
            typeof(List<>).MakeGenericType(this.type).GetMethod("Sort", Type.EmptyTypes).Invoke(dataSourceList, null);
            this.DataSourceUpdate(dataSourceList);
        }
    }
}
