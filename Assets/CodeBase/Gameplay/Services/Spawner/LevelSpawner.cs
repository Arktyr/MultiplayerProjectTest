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

        public LevelSpawner(IJoystickFactory joystickFactory,
            ILevelSpawnerProvider levelSpawnerProvider)
        {
            _joystickFactory = joystickFactory;
            _levelSpawnerProvider = levelSpawnerProvider;
        }

        public async UniTask Spawn() => 
            await _joystickFactory.Create();

        public void Initialize()
        {
            Debug.Log("1");
            _levelSpawnerProvider.SetLevelSpawner(this);
        }
            
    }
}