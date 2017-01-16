using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoCMA.Controller
{
    public class StateGraph
    {
        protected Dictionary<String, State> state;
        protected Dictionary<State, List<State>> adjState;
        protected Dictionary<State, Dictionary<Func<int, bool>, State>> adjFuncState;
        protected StateGraph()
        {
            this.state = new Dictionary<String, State>();
            this.adjState = new Dictionary<State, List<State>>();
            this.adjFuncState = new Dictionary<State, Dictionary<Func<int, bool>, State>>();
        }
        protected void AddState(String name, State state)
        {
            this.state.Add(name, state);
            this.adjState.Add(state, new List<State>());
            this.adjFuncState.Add(state, new Dictionary<Func<int, bool>, State>());
        }
        public void AddStateAdjacent(String stateName, String stateNameAdj)
        {
            if(this.ExistsState(stateName) && this.ExistsState(stateNameAdj))
            {
                this.adjState[this.GetState(stateName)].Add(this.GetState(stateNameAdj));
            }
        }
        public void AddStateAdjacentFunc(String stateName, String stateNameAdj, Func<int, bool> adjFunc)
        {
            if (this.ExistsState(stateName) && this.ExistsState(stateNameAdj))
            {
                this.adjFuncState[this.GetState(stateName)].Add(adjFunc, this.GetState(stateNameAdj));
            }
        }
        protected State Choose(String stateName, int choosingValue)
        {
            if(this.adjFuncState[this.GetState(stateName)].Count > 1)
            {
                foreach (var item in this.adjFuncState[this.GetState(stateName)])
                {
                    if (item.Key(choosingValue))
                    {
                        return item.Value;
                    }
                }
            }
            else if(this.adjFuncState[this.GetState(stateName)].Count == 1)
            {
                return this.adjFuncState[this.GetState(stateName)].First().Value;
            }
            throw new Exception("Non ci sono funzioni per stati tra cui scegliere");
        }
        protected State GetState(String name)
        {
            if (this.state.ContainsKey(name))
            {
                return this.state[name];
            }
            return null;
        }
        protected bool ExistsState(String name)
        {
            return this.state.ContainsKey(name);
        }
    }
}
