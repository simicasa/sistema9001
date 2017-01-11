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
        public Type type { get; set; }

        public Controller()
        {

        }
        public void bindingListCreate(dynamic list)
        {
            this.bindingList = Generic.createInstance(typeof(BindingList<>), this.type, new Object[] { list });
        }
        public dynamic bindingListGet()
        {
            return this.bindingList;
        }
    }
}
