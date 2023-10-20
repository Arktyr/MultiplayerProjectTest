using CodeBase.Gameplay.Spawner;
using Cysharp.Threading.Tasks;

namespace CodeBase.Infrastructure.Services.Providers.LevelSpawnerProvider
{
    public class LevelSpawnerProvider : ILevelSpawnerProvider
    {
        private ILevelSpawner _levelSpawner;

        public async UniTask<ILevelSpawner> GetSpawner()
        {
            await UniTask.WaitUntil(() => _levelSpawner != null);

            return _levelSpawner;
        }

        public void SetLevelSpawner(ILevelSpawner levelSpawner) => 
            _levelSpawner = levelSpawner;
    }
}