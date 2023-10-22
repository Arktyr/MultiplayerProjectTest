using Cysharp.Threading.Tasks;

namespace CodeBase.Gameplay.Services.Spawners.Level
{
    public interface ILevelServices
    {
        public UniTask WarmUpFactories();
        public UniTask SpawnLevelObjects();
        public void EnableServices();
    }
}