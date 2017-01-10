using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoCMA.Controller
{
    class Controller : IController
    {
        private dynamic bindingList { get; set; }
        private dynamic bindingListType { get; set; }
        private Type type { get; set; }

        protected void bindingListCreate()
        {
            this.bindingListType = typeof(BindingList<>).MakeGenericType(this.type);
            this.bindingList = Activator.CreateInstance(this.bindingListType, new Object[] { Shared.cdc.CategoriaSet.ToList() });
            
            foreach (MethodInfo item in this.bindingListType.GetMethods())
            {
                Console.WriteLine(item.Name);
            }
            if(this.bindingListType.GetMethod("ToString") != null)
            {

            }
            string str = this.bindingListType.GetMethod("ToString").Invoke(this.bindingList, null).ToString();
            Shared.messageBox(str);
        }

    }
}
