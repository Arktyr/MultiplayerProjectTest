using CodeBase.Gameplay.Services.Gravity;
using CodeBase.Infrastructure.Factories;
using CodeBase.Infrastructure.Services.Providers.LevelSpawnerProvider;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer.Unity;

namespace CodeBase.Gameplay.Spawner
{
    public class LevelSpawner : ILevelSpawner, IInitializable
    {
        private readonly ILevelSpawnerProvider _levelSpawnerProvider;
        
        private readonly IJoystickFactory _joystickFactory;
        private readonly IGravityAttraction _gravityAttraction;

        public LevelSpawner(IJoystickFactory joystickFactory,
            ILevelSpawnerProvider levelSpawnerProvider,
            IGravityAttraction gravityAttraction)
        {
            _joystickFactory = joystickFactory;
            _levelSpawnerProvider = levelSpawnerProvider;
            _gravityAttraction = gravityAttraction;
        }

        public async UniTask Spawn()
        {
            await _joystickFactory.Create();
            _gravityAttraction.Enable();
        } 
            

        public void Initialize() => 
            _levelSpawnerProvider.SetLevelSpawner(this);
    }
}