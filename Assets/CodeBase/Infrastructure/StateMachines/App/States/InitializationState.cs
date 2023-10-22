using CodeBase.Common.FSM.States;
using CodeBase.Gameplay.Services.Spawners.Level;
using CodeBase.Infrastructure.Services.Providers.LevelSpawnerProvider;
using CodeBase.Infrastructure.Services.SceneLoader;
using CodeBase.Infrastructure.Services.Tickable;
using CodeBase.Infrastructure.StateMachines.App.FSM;
using Cysharp.Threading.Tasks;

namespace CodeBase.Infrastructure.StateMachines.App.States
{
    public class InitializationState : IState
    {
        private readonly IAppStateMachine _appStateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly ILevelServicesProvider _levelServicesProvider;

        public InitializationState(IAppStateMachine appStateMachine,
            ISceneLoader sceneLoader,
            ILevelServicesProvider levelServicesProvider)
        {
            _appStateMachine = appStateMachine;
            _sceneLoader = sceneLoader;
            _levelServicesProvider = levelServicesProvider;
        }

        public async void Enter()
        {
            await _sceneLoader.Load(SceneType.Level);
            await SpawnLevel();

            _appStateMachine.Enter<GameplayState>();
        }

        private async UniTask SpawnLevel()
        {
            ILevelServices levelServices = await _levelServicesProvider.GetLevelServices();

            await levelServices.WarmUpFactories();
            await levelServices.SpawnLevelObjects();
            
            levelServices.EnableServices();
        }

        public void Exit()
        {
        }
    }
}