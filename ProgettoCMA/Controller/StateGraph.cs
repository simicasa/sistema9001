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
        public void AddStateAdjacent(String stateName, String stateNameAdj, bool alsoAddReturn = false)
        {
            if(this.ExistsState(stateName) && this.ExistsState(stateNameAdj))
            {
                if (this.HasAdjacenceFunctions(stateName))
                {
                    if(this.ExistsStateAdjFunc(stateName, stateNameAdj))
                    {
                        this.adjState[this.GetState(stateName)].Add(this.GetState(stateNameAdj));
                        return;
                    }
                    throw new Exception("non e' possibile aggiungere adiacenze, lo stato " + stateName + " contiene transazioni naturali");
                }
                this.adjState[this.GetState(stateName)].Add(this.GetState(stateNameAdj));
                if (alsoAddReturn)
                {
                    this.AddStateAdjacent(stateNameAdj, stateName);
                }
            }
        }
        public void AddStateAdjacentFunc(String stateName, String stateNameAdj, Func<int, bool> adjFunc)
        {
            if (this.ExistsState(stateName) && this.ExistsState(stateNameAdj))
            {
                if (this.HasNonNaturalTransitiveAdjacences(stateName))
                {
                    throw new Exception("non e' possibile aggiungere la funzione di adiacenza, lo stato " + stateName + " contiene adiacenze");
                }
                this.adjFuncState[this.GetState(stateName)].Add(adjFunc, this.GetState(stateNameAdj));
                this.AddStateAdjacent(stateName, stateNameAdj);
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
        protected State GetState(String stateName)
        {
            if (this.state.ContainsKey(stateName))
            {
                return this.state[stateName];
            }
            return null;
        }
        protected bool ExistsState(String stateName)
        {
            return this.state.ContainsKey(stateName);
        }
        protected bool ExistsStateAdj(String stateName, String stateNameAdj)
        {
            return this.adjState[this.GetState(stateName)].Contains(this.GetState(stateNameAdj));
        }
        protected bool ExistsStateAdjFunc(String stateName, String stateNameAdj)
        {
            return this.adjFuncState[this.GetState(stateName)].Values.Contains(this.GetState(stateNameAdj));
        }
        protected bool HasAdjacences(String stateName)
        {
            if(this.adjState[this.state[stateName]].Count > 0)
            {
                return true;
            }
            return false;
        }
        protected bool HasNonNaturalTransitiveAdjacences(String stateName)
        {
            foreach (var adj in this.adjState[this.state[stateName]])
            {
                if (!this.ExistsStateAdjFunc(stateName, adj.GetName()))
                {
                    return true;
                }
            }
            return false;
        }
        protected bool HasAdjacenceFunctions(String stateName)
        {
            if (this.adjFuncState[this.state[stateName]].Count > 0)
            {
                return true;
            }
            return false;
        }
        protected List<State> GetAdjacences(String stateName)
        {
            if (this.HasAdjacences(stateName))
            {
                return this.adjState[this.state[stateName]];
            }
            return new List<State>();
        }
    }
}
