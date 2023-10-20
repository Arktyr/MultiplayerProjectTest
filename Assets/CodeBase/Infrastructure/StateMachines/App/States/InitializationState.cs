using CodeBase.Common.FSM.States;
using CodeBase.Gameplay.Spawner;
using CodeBase.Infrastructure.Services.Providers.LevelSpawnerProvider;
using CodeBase.Infrastructure.Services.SceneLoader;
using CodeBase.Infrastructure.Services.Updater;
using CodeBase.Infrastructure.StateMachines.App.FSM;
using Cysharp.Threading.Tasks;

namespace CodeBase.Infrastructure.StateMachines.App.States
{
    public class InitializationState : IState
    {
        private readonly IAppStateMachine _appStateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly ILevelSpawnerProvider _levelSpawnerProvider;
        private readonly ITickableService _tickableService;

        public InitializationState(IAppStateMachine appStateMachine,
            ISceneLoader sceneLoader,
            ILevelSpawnerProvider levelSpawnerProvider,
            ITickableService tickableService)
        {
            _appStateMachine = appStateMachine;
            _sceneLoader = sceneLoader;
            _levelSpawnerProvider = levelSpawnerProvider;
            _tickableService = tickableService;
        }

        public async void Enter()
        {
            await _sceneLoader.Load(SceneType.Level);

            await SpawnLevel();
            _tickableService.StartTicking();

            _appStateMachine.Enter<GameplayState>();
        }

        private async UniTask SpawnLevel()
        {
            ILevelSpawner levelSpawner = await _levelSpawnerProvider.GetSpawner();

            await levelSpawner.Spawn();
        }

        public void Exit()
        {
        }
    }
}