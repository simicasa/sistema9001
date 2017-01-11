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
            GenericFactory g = new GenericFactory(typeof(Enumerable));
            list = g.invokeMethod("ToList", null, this.type, new Object[] { list });
            this.bindingList = GenericFactory.createInstance(typeof(BindingList<>), new Object[] { list }, this.type);
        }
        public dynamic bindingListGet()
        {
            return this.bindingList;
        }
    }
}
