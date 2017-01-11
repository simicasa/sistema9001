using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgettoCMA.Controller
{
    class ListBoxUC : ListBox, IController
    {
        private Controller controller;

        public ListBoxUC()
        {
            this.controller = new Controller();
        }
        public void Initialize(Type type, dynamic list, string memberToShow)
        {
            this.controller.type = type;
            this.controller.bindingListCreate(list);
            this.DataSource = this.controller.bindingListGet();
            this.ValueMember = memberToShow;
            this.DisplayMember = memberToShow;
        }
    }
}
