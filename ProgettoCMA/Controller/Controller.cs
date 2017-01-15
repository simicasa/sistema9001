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

        public Controller()
        {

        }
        public dynamic bindingListCreate(dynamic list, Type type)
        {
            GenericFactory g = new GenericFactory(typeof(Enumerable));
            list = g.invokeMethod("ToList", null, type, new Object[] { list });
            return GenericFactory.createInstance(typeof(BindingList<>), new Object[] { list }, type);
        }
    }
}
