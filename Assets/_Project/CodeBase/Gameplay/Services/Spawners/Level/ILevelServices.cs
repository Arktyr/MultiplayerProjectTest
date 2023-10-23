using Cysharp.Threading.Tasks;

namespace _Project.CodeBase.Gameplay.Services.Spawners.Level
{
    public interface ILevelServices
    {
        public UniTask WarmUpFactories();
        public UniTask SpawnLevelObjects();
        public void EnableServices();
    }
}