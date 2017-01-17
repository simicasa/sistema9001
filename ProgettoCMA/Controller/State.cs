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
        public void Activate(List<Control> controlsToAvoid = null)
        {
            foreach (var control in this.controls)
            {
                if((!controlsToAvoid?.Contains(control) ?? true) && typeof(Label) != control.GetType())
                {
                    control.Enabled = this.defaultEnabled;
                }
                if (new Type[] { typeof(Panel), typeof(GroupBox) }.Contains(control.GetType()))
                {
                    foreach (var subControl in ControllerUC.GetAllControlsRecursive<Control>(control))
                    {
                        if ((!controlsToAvoid?.Contains(subControl) ?? true) && typeof(Label) != control.GetType())
                        {
                            subControl.Enabled = this.defaultEnabled;
                        }
                    }
                }
            }
        }
        public void Deactivate(List<Control> controlsToAvoid = null)
        {
            this.Invert();
            this.Activate(controlsToAvoid);
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
