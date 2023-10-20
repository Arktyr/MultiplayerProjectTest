using CodeBase.Gameplay.Services.Spawner;
using Cysharp.Threading.Tasks;

namespace CodeBase.Infrastructure.Services.Providers.LevelSpawnerProvider
{
    public interface ILevelSpawnerProvider
    {
        public UniTask<ILevelSpawner> GetSpawner();
        public void SetLevelSpawner(ILevelSpawner levelSpawner);
    }
}