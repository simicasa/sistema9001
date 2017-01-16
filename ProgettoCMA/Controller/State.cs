using ProgettoCMA.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgettoCMA.Controller
{
    public class State
    {
        public List<Control> controls { get; private set; }
        private bool defaultEnabled;
        private String name;

        private State(String name, List<Control> controls, bool defaultEnabled)
        {
            this.name = name;
            this.controls = controls;
            this.defaultEnabled = defaultEnabled;
        }
        public static State Create(String name, List<Control> controls, bool defaultEnabled)
        {
            return new State(name, controls, defaultEnabled);
        }
        public void Activate()
        {
            /*
            if (this.name.Equals("init"))
            {
                this.controls.RemoveAll(item => new Type[]{ typeof(Panel), typeof(GroupBox), typeof(Label)}.Contains(item.GetType()));
            }
            */
            foreach (var control in this.controls)
            {
                control.Enabled = this.defaultEnabled;
                if (new Type[] { typeof(Panel), typeof(GroupBox) }.Contains(control.GetType()))
                {
                    foreach (var subControl in ControllerUC.GetAllControlsRecursive<Control>(control))
                    {
                        subControl.Enabled = this.defaultEnabled;
                    }
                }
            }
        }
        public void Deactivate()
        {
            this.Invert();
            this.Activate();
            this.Invert();
        }
        private void Invert()
        {
            this.defaultEnabled = !this.defaultEnabled;
        }
        public String GetName()
        {
            return this.name;
        }
    }
}
