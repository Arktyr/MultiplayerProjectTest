using _Project.CodeBase.Gameplay.Apples;
using Cysharp.Threading.Tasks;

namespace _Project.CodeBase.Infrastructure.Factories.Apples
{
    public interface IAppleFactory
    {
        public UniTask WarmUp();
        public UniTask<Apple> Create();
    }
}