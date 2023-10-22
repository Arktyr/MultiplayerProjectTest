using CodeBase.Gameplay.Services.Spawners.Level;
using Cysharp.Threading.Tasks;

namespace CodeBase.Infrastructure.Services.Providers.LevelSpawnerProvider
{
    public class LevelServicesProvider : ILevelServicesProvider
    {
        private ILevelServices _levelServices;

        public async UniTask<ILevelServices> GetLevelServices()
        {
            await UniTask.WaitUntil(() => _levelServices != null);

            return _levelServices;
        }

        public void SetLevelServices(ILevelServices levelServices) => 
            _levelServices = levelServices;
    }
}