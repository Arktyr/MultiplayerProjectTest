using _Project.CodeBase.Gameplay.Services.Spawners.Level;
using _Project.CodeBase.Infrastructure.Services.Providers.LevelSpawnerProvider;
using _Project.CodeBase.Infrastructure.Services.SceneLoader;
using _Project.CodeBase.Infrastructure.StateMachines.App.FSM;
using _Project.CodeBase.Infrastructure.StateMachines.States;
using Cysharp.Threading.Tasks;

namespace _Project.CodeBase.Infrastructure.StateMachines.App.States
{
    public class InitializationState : IState
    {
        private readonly IAppStateMachine _appStateMachine;
        private readonly ISceneLoader _sceneLoader;
        
        private ILevelServices _levelServices;
        
        public InitializationState(IAppStateMachine appStateMachine,
            ISceneLoader sceneLoader)
        {
            _appStateMachine = appStateMachine;
            _sceneLoader = sceneLoader;
        }

        public void SetLocalDependencies(ILevelServices levelServices) => 
            _levelServices = levelServices;

        public async void Enter()
        {
            await _sceneLoader.Load(SceneType.Level);
            await SpawnLevel();

            _appStateMachine.Enter<GameplayState>();
        }

        private async UniTask SpawnLevel()
        {
            await _levelServices.WarmUpFactories();
            await _levelServices.SpawnLevelObjects();
            
            _levelServices.EnableServices();
        }

        public void Exit()
        {
        }
    }
}