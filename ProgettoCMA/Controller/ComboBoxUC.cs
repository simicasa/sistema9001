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
        private dynamic dataSource;

        public ComboBoxUC()
        {
            this.controller = new Controller();
            this.type = null;
            this.dataSource = null;
        }
        public void Initialize(Type type, dynamic list, ComboBoxStyle style = ComboBoxStyle.DropDownList)
        {
            this.type = type;
            this.StyleUpdate(style);
            this.DataSourceUpdate(list);
        }
        private void DataSourceUpdate(dynamic list)
        {
            this.DataSource = this.controller.bindingListCreate(list, this.type);
        }
        public void StyleUpdate(ComboBoxStyle style)
        {
            this.DropDownStyle = style;
        }
        public void Sort()
        {
            this.dataSource = this.DataSource;
            MethodInfo sortMethod = typeof(List<>).GetMethods().Where(mi => mi.GetParameters().Count() == 0).First();
            //MethodInfo sortMethod = Generic.getGenericMethod(typeof(List<>), "Sort", new Type[] { }, BindingFlags.Default, new Func<MethodInfo, bool>(set => set.GetParameters().Count() == 0));
            this.DataSource = sortMethod.Invoke(this.dataSource, null);
        }
    }
}
