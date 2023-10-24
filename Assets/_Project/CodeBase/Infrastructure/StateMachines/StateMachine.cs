using System;
using System.Collections.Generic;
using _Project.CodeBase.Infrastructure.StateMachines.States;

namespace _Project.CodeBase.Infrastructure.StateMachines
{
    public class StateMachine 
    {
        private readonly Dictionary<Type, IExitableState> _states = new();

        private IExitableState _activeState;

        public void Enter<TState>() where TState : IState
        {
            _activeState?.Exit();

            if (_states[typeof(TState)] is TState state)
            {
                _activeState = state;

                state.Enter();
            }
        }

        public void AddState<TState>(TState state) where TState : IExitableState => 
            _states.Add(typeof(TState), state);
    }
}