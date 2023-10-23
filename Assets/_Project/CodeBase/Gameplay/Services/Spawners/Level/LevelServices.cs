using _Project.CodeBase.Gameplay.Services.Gravity;
using _Project.CodeBase.Gameplay.Services.Spawners.Apples;
using _Project.CodeBase.Infrastructure.Factories.Apples;
using _Project.CodeBase.Infrastructure.Factories.Characters;
using _Project.CodeBase.Infrastructure.Factories.Characters.Camera;
using _Project.CodeBase.Infrastructure.Factories.Joysticks;
using _Project.CodeBase.Infrastructure.Services.Providers.LevelSpawnerProvider;
using Cysharp.Threading.Tasks;
using VContainer.Unity;

namespace _Project.CodeBase.Gameplay.Services.Spawners.Level
{
    public class LevelServices : ILevelServices, IInitializable
    {
        private readonly ILevelServicesProvider _levelServicesProvider;
        
        private readonly IJoystickFactory _joystickFactory;
        private readonly ICharacterFactory _characterFactory;
        private readonly IGravityAttraction _gravityAttraction;
        private readonly ICameraFactory _cameraFactory;
        private readonly IAppleSpawner _appleSpawner;
        private readonly IAppleFactory _appleFactory;

        public LevelServices(IJoystickFactory joystickFactory,
            ILevelServicesProvider levelServicesProvider,
            ICharacterFactory characterFactory,
            IGravityAttraction gravityAttraction,
            ICameraFactory cameraFactory,
            IAppleSpawner appleSpawner,
            IAppleFactory appleFactory)
        {
            _joystickFactory = joystickFactory;
            _levelServicesProvider = levelServicesProvider;
            _characterFactory = characterFactory;
            _gravityAttraction = gravityAttraction;
            _cameraFactory = cameraFactory;
            _appleSpawner = appleSpawner;
            _appleFactory = appleFactory;
        }

        public async UniTask WarmUpFactories()
        {
            await _joystickFactory.WarmUp();
            await _characterFactory.WarmUp();
            await _cameraFactory.WarmUp();
            await _appleFactory.WarmUp();
        }
        
        public async UniTask SpawnLevelObjects()
        {
            await _joystickFactory.Create();
            await _characterFactory.Create();
            await _cameraFactory.Create();
            await _appleSpawner.SpawnApples();
        }

        public void EnableServices()
        {
            _gravityAttraction.Enable();
        }
            

        public void Initialize() => 
            _levelServicesProvider.SetLevelServices(this);
    }
}