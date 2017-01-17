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
        private List<Control> controls;
        private List<Control> persistentDisabledControls;
        private List<Control> persistentEnabledControls;
        private List<Control> persistentControls;
        private List<State> activeState;
        public const String INITIAL_STATE_NAME = "init";

        public StateController(List<Control> controls)
        {
            this.controls = controls;
            this.persistentDisabledControls = null;
            this.persistentEnabledControls = null;
            this.persistentControls = null;
            this.ResetActiveStates();
            this.AddState(StateController.INITIAL_STATE_NAME, true, controls.ToArray());
            this.SetState(StateController.INITIAL_STATE_NAME);
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
        public void AddState(String name, bool defaultEnabled = true, params Control[] controls)
        {
            this.AddState(name, State.Create(name, controls.ToList(), defaultEnabled));
        }
        public void AddState(String name, bool defaultEnabled = true, params String[] statesWithSameControlsName)
        {
            List<Control> controls = new List<Control>();
            foreach (String stateName in statesWithSameControlsName)
            {
                controls.AddRange(this.GetState(stateName).controls);
            }
            this.AddState(name, State.Create(name, controls, defaultEnabled));
        }
        public void SetState(params String[] names)
        {
            if(names.Count() > 1)
            {
                List<Control> controls = new List<Control>();
                bool isIntersectionEmpty = true;
                foreach (var name in names)
                {
                    if (this.ExistsState(name))
                    {
                        controls = controls.Intersect(this.state[name].controls).ToList();
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
                return;
            }
            this.SetStateBody(names);
        }
        private void SetStateBody(String[] names)
        {
            this.InvertActiveState();
            List<State> activeAdjacences = this.GetActiveAdjacences();
            this.ResetActiveStates();
            foreach (var name in names)
            {
                if (this.ExistsState(name))
                {
                    if (activeAdjacences.Contains(this.state[name]) || name.Equals(StateController.INITIAL_STATE_NAME))
                    {
                        Debug.ConsoleWriteLine(this.GetState(name).GetName() + " found and setted");
                        this.activeState.Add(this.GetState(name));
                        this.GetState(name).Activate(this.persistentControls);
                        continue;
                    }
                    throw new Exception("stato " + name + " trovato ma non presente nelle adiacenze");
                }
                throw new Exception("stato " + name + " non trovato");
            }
        }
        private void InvertActiveState()
        {
            foreach (var state in this.activeState)
            {
                state.Deactivate(this.persistentControls);
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
        private List<State> GetActiveAdjacences()
        {
            List<State> adjacences = new List<State>();
            foreach (var state in this.activeState)
            {
                if (this.HasAdjacences(state.GetName()))
                {
                    adjacences.AddRange(this.GetAdjacences(state.GetName()));
                }
            }
            return adjacences.Distinct().ToList();
        }
        public void SetPersistentDisabledControls(params Control[] controls)
        {
            this.persistentDisabledControls = controls.ToList();
            foreach (var control in this.persistentDisabledControls)
            {
                if(typeof(Label) != control.GetType())
                {
                    control.Enabled = false;
                }
            }
            this.persistentControls = (this.persistentEnabledControls?.Union(this.persistentDisabledControls))?.ToList() ?? this.persistentDisabledControls;
        }
        public void SetPersistentEnabledControls(params Control[] controls)
        {
            this.persistentEnabledControls = controls.ToList();
            foreach (var control in this.persistentEnabledControls)
            {
                if (typeof(Label) != control.GetType())
                {
                    control.Enabled = true;
                }
            }
            this.persistentControls = (this.persistentDisabledControls?.Union(this.persistentEnabledControls))?.ToList() ?? this.persistentEnabledControls;
        }
        public List<String> GetActiveStates()
        {
            List<String> names = new List<String>();
            foreach (State state in this.activeState)
            {
                names.Add(state.GetName());
            }
            return names;
        }
        public bool IsActiveState(String stateName)
        {
            return this.activeState.Contains(this.GetState(stateName));
        }
    }
}
