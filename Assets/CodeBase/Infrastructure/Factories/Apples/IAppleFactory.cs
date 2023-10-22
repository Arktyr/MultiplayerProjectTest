using CodeBase.Gameplay.Apples;
using Cysharp.Threading.Tasks;

namespace CodeBase.Infrastructure.Factories.Apples
{
    public interface IAppleFactory
    {
        public UniTask WarmUp();
        public UniTask<Apple> Create();
    }
}