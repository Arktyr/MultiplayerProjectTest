using Cysharp.Threading.Tasks;

namespace CodeBase.Gameplay.Services.Spawners.Apples
{
    public interface IAppleSpawner
    {
        public UniTask SpawnApples();
    }
}