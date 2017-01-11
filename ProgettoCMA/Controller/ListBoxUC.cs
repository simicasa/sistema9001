using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgettoCMA.Controller
{
    class ListBoxUC : ListBox
    {
        private Controller controller;

        public ListBoxUC()
        {
            this.controller = new Controller();
        }
    }
}
