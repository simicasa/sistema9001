using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgettoCMA.Controller
{
    public class StateController : StateGraph
    {
        List<Control> controls;
        List<State> activeState;

        public StateController(List<Control> controls)
        {
            this.controls = controls;
            this.ResetActiveStates();
            this.AddState("init", controls.ToArray(), true);
            this.SetState("init");
        }
        /*
        public StateController(List<Control> controls, Control[] initStateControls, bool initStateDefaultEnabled)
        {
            this.controls = controls;
            this.ResetActiveStates();
            foreach (var control in this.controls)
            {
                if(
                    control.GetType() != typeof(Panel) &&
                    control.GetType() != typeof(GroupBox) &&
                    control.GetType() != typeof(Label)
                    )
                {
                    control.Enabled = !initStateDefaultEnabled;
                }
            }
            this.AddState("init", initStateControls, initStateDefaultEnabled);
            this.SetState("init");
        }
        */
        public void AddState(String name, Control control, bool defaultEnabled = true)
        {
            this.AddState(name, new Control[] { control }, defaultEnabled);
        }
        public void AddState(String name, Control[] controls, bool defaultEnabled = true)
        {
            this.AddState(name, State.Create(name, controls.ToList(), defaultEnabled));
        }
        public void SetState(String[] names)
        {
            if(names.Count() > 0)
            {
                List<Control> controls = new List<Control>();
                bool isIntersectionEmpty = true;
                foreach (var name in names)
                {
                    if (this.ExistsState(name))
                    {
                        //controls = controls.Intersect(this.states[name].controls).ToList();
                        if (controls.Count == 0)
                        {
                            continue;
                        }
                    }
                    isIntersectionEmpty = false;
                    break;
                }
                if (isIntersectionEmpty)
                {
                    this.SetStateBody(names);
                }
            }
        }
        public void SetState(String name)
        {
            this.SetStateBody(new String[] { name });
        }
        private void SetStateBody(String[] names)
        {
            this.InvertActiveState();
            this.ResetActiveStates();
            foreach (var name in names)
            {
                Console.Write(this.GetState(name).GetName());
                if (this.ExistsState(name))
                {
                    Console.WriteLine(" found and setted");
                    this.activeState.Add(this.GetState(name));
                    this.GetState(name).Activate();
                }
                else
                {
                    throw new Exception("stato " + name + " non trovato");
                }
            }
        }
        private void InvertActiveState()
        {
            foreach (var state in this.activeState)
            {
                state.Deactivate();
            }
        }
        private void ResetActiveStates()
        {
            this.activeState = new List<State>();
        }
        public void ChooseAndSetState(String stateName, int choosingValue)
        {
            State choosedState = this.Choose(stateName, choosingValue);
            this.SetState(choosedState.GetName());
        }
        public void ChooseAndSetState(int choosingValue)
        {
            if(this.activeState.Count == 1)
            {
                State choosedState = this.Choose(this.activeState.First().GetName(), choosingValue);
                this.SetState(choosedState.GetName());
                return;
            }
            throw new Exception("Non e' possibile scegliere uno stato quando si hanno piu' stati attivi");
        }
    }
}
