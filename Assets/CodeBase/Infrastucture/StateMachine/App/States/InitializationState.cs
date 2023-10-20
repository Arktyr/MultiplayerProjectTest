using CodeBase.Common.FSM.States;
using CodeBase.Infrastructure.StateMachines.App.FSM;

namespace CodeBase.Infrastructure.StateMachines.App.States
{
    public class InitializationState : IState
    {
        private readonly IAppStateMachine _appStateMachine;

        public InitializationState(IAppStateMachine appStateMachine)
        {
            _appStateMachine = appStateMachine;
        }

        public void Enter()
        {
          
            
            _appStateMachine.Enter<GameplayState>();
        }

        public void Exit()
        {
        }
    }
}