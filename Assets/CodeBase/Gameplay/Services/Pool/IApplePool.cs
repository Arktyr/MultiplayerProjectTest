using Cysharp.Threading.Tasks;

namespace CodeBase.Gameplay.Services.Pool
{
    public interface IApplePool
    {
        public UniTask<Apple> Take();
    }
}