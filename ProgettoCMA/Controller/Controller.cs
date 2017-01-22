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
        bool hasDataSource;
        public Controller(bool hasDataSource)
        {
            this.hasDataSource = hasDataSource;
        }
        public dynamic bindingListCreate(dynamic list, Type type)
        {
            GenericFactory g = new GenericFactory(typeof(Enumerable));
            list = g.invokeMethod("ToList", null, type, new Object[] { list });
            return GenericFactory.createInstance(typeof(BindingList<>), new Object[] { list }, type);
        }
        public dynamic DataSourceUpdate(dynamic list, Type type)
        {
            if (!this.hasDataSource)
            {
                throw new Exception("Il controller non prevede DataSource");
            }
            return this.bindingListCreate(list, type);
        }
    }
}
