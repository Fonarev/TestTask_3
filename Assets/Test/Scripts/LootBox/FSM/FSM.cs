using System;
using System.Collections.Generic;

using UnityEngine;

namespace Assets.Test.Scripts.FSM
{
    public class FSM : MonoBehaviour
    {
        protected State currentState;
        
        private readonly Dictionary<Type, State> statesLink = new();

        protected void AddState(State state)
        {
            statesLink.Add(state.GetType(), state);
        }

        public State GetState<T>()
        {
            Type type = typeof(T);

            if (statesLink.TryGetValue(type, out State state))
            {
                return state;
            }

            return null;
        }

        public void SetState<T>() where T : State
        {
            Type type = typeof(T);

            if (currentState.GetType() == type)
            {
                return;
            }

            if (statesLink.TryGetValue(type, out State newState))
            {
                currentState.Exit();
                currentState = newState;
                currentState.Enter();
            }
        }

        public void UpData(float deltaTime) => currentState?.UpDate(deltaTime);

    }
}