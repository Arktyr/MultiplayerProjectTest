using _Project.CodeBase.Gameplay.Services.Spawners.Level;
using Cysharp.Threading.Tasks;

namespace _Project.CodeBase.Infrastructure.Services.Providers.LevelSpawnerProvider
{
    public interface ILevelServicesProvider
    {
        public UniTask<ILevelServices> GetLevelServices();
        public void SetLevelServices(ILevelServices levelServices);
    }
}