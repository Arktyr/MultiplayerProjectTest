using Cysharp.Threading.Tasks;
using VContainer.Unity;

namespace CodeBase.Gameplay.Spawner
{
    public interface ILevelSpawner
    {
        public UniTask Spawn();
    }
}