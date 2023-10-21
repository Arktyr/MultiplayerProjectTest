using CodeBase.Gameplay;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CodeBase.Infrastructure.Factories.Apples
{
    public interface IAppleFactory
    {
        public UniTask WarmUp();
        public UniTask<Apple> Create();
    }
}