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
            Console.WriteLine(this.name + " " + this.defaultEnabled.ToString());
            if (this.name.Equals("init"))
            {
                this.controls.RemoveAll(
                    item =>
                    item.GetType() == typeof(Panel) ||
                    item.GetType() == typeof(GroupBox) ||
                    item.GetType() == typeof(Label)
                );
            }
            foreach (var control in this.controls)
            {
                if (control.Name.StartsWith("add"))
                {
                    Console.WriteLine(control.Name + " " + control.Enabled.ToString());
                }
                control.Enabled = this.defaultEnabled;
                if (!this.name.Equals("init"))
                {
                    Console.WriteLine(control.Name + " " + control.Enabled.ToString());
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
