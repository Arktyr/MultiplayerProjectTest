using CodeBase.Gameplay;
using CodeBase.Gameplay.Apples;
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