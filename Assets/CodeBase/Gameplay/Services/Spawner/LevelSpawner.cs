using CodeBase.Gameplay.Services.Gravity;
using CodeBase.Infrastructure.Factories.Characters;
using CodeBase.Infrastructure.Factories.Joysticks;
using CodeBase.Infrastructure.Services.Providers.LevelSpawnerProvider;
using Cysharp.Threading.Tasks;
using VContainer.Unity;

namespace CodeBase.Gameplay.Services.Spawner
{
    public class LevelSpawner : ILevelSpawner, IInitializable
    {
        private readonly ILevelSpawnerProvider _levelSpawnerProvider;
        
        private readonly IJoystickFactory _joystickFactory;
        private readonly ICharacterFactory _characterFactory;
        private readonly IGravityAttraction _gravityAttraction;

        public LevelSpawner(IJoystickFactory joystickFactory,
            ILevelSpawnerProvider levelSpawnerProvider,
            ICharacterFactory characterFactory,
            IGravityAttraction gravityAttraction)
        {
            _joystickFactory = joystickFactory;
            _levelSpawnerProvider = levelSpawnerProvider;
            _characterFactory = characterFactory;
            _gravityAttraction = gravityAttraction;
        }

        public async UniTask WarmUp()
        {
            await _joystickFactory.WarmUp();
            await _characterFactory.WarmUp();
        }
        
        public async UniTask Spawn()
        {
            await _joystickFactory.Create();
            await _characterFactory.Create();
            _gravityAttraction.Enable();
        } 
            

        public void Initialize() => 
            _levelSpawnerProvider.SetLevelSpawner(this);
    }
}