using CodeBase.Gameplay.Services.Spawners.Level;
using Cysharp.Threading.Tasks;

namespace CodeBase.Infrastructure.Services.Providers.LevelSpawnerProvider
{
    public interface ILevelServicesProvider
    {
        public UniTask<ILevelServices> GetLevelServices();
        public void SetLevelServices(ILevelServices levelServices);
    }
}