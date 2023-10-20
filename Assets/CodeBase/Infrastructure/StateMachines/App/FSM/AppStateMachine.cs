﻿using CodeBase.Common.FSM;
using CodeBase.Common.FSM.States;
using CodeBase.Infrastructure.Services.Logger;

namespace CodeBase.Infrastructure.StateMachines.App.FSM
{
    public class AppStateMachine : IAppStateMachine
    {
        private readonly StateMachine _stateMachine;
        private readonly ICustomLogger _logger;
        
        public AppStateMachine(ICustomLogger logger)
        {
            _stateMachine = new StateMachine();
            
            _logger = logger;
        } 
        
        public void Enter<TState>() where TState : IState
        {
            _logger.Log($"AppStateMachine Entered: {typeof(TState).Name}");
            
            _stateMachine.Enter<TState>();
        }

        public void Add<TState>(TState state) where TState : IExitableState =>
            _stateMachine.AddState(state);
    }
}