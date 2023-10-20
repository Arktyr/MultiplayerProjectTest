using CodeBase.Common.FSM.States;
using CodeBase.Infrastructure.Services.SceneLoader;
using CodeBase.Infrastructure.StateMachines.App.FSM;

namespace CodeBase.Infrastructure.StateMachines.App.States
{
    public class InitializationState : IState
    {
        private readonly IAppStateMachine _appStateMachine;
        private readonly ISceneLoader _sceneLoader;

        public InitializationState(IAppStateMachine appStateMachine,
            ISceneLoader sceneLoader)
        {
            _appStateMachine = appStateMachine;
            _sceneLoader = sceneLoader;
        }

        public async void Enter()
        {
            await _sceneLoader.Load(SceneType.Level);
            
            _appStateMachine.Enter<GameplayState>();
        }

        public void Exit()
        {
        }
    }
}