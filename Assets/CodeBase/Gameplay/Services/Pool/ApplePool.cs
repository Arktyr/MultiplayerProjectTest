using CodeBase.Common.Pools;
using CodeBase.Infrastructure.Factories.Apples;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CodeBase.Gameplay.Services.Pool
{
    public class ApplePool : Pool<Apple>, IApplePool
    {
        private readonly IAppleFactory _appleFactory;
        
        protected override async UniTask AddToPool()
        {
            Apple gameObject = await _appleFactory.Create();
            _disableObjects.Enqueue(gameObject);
        }

        protected override void PrepareToTakeObject(Apple disableObject)
        {
            disableObject.PickUpped += ReturnToPool;
            disableObject.gameObject.SetActive(true);
        }

        protected override void PrepareToDisableObject(Apple activeObject)
        {
            activeObject.PickUpped += ReturnToPool;
            activeObject.gameObject.SetActive(false);
        }
    }
}