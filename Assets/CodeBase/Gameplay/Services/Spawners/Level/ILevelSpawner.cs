using Cysharp.Threading.Tasks;

namespace CodeBase.Gameplay.Services.Spawner
{
    public interface ILevelSpawner
    {
        public UniTask WarmUp();
        public UniTask Spawn();
    }
}