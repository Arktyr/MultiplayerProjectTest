using CodeBase.Common.FSM;
using CodeBase.Common.FSM.States;

namespace CodeBase.Infrastructure.StateMachines.App.FSM
{
    public class AppStateMachine : IAppStateMachine
    {
        private readonly StateMachine _stateMachine;

        public AppStateMachine() => 
            _stateMachine = new StateMachine();

        public void Enter<TState>() where TState : IState
        {
           
            _stateMachine.Enter<TState>();
        }

        public void Add<TState>(TState state) where TState : IExitableState =>
            _stateMachine.AddState(state);
    }
}