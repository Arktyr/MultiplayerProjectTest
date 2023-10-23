using _Project.CodeBase.Gameplay.Apples;
using _Project.CodeBase.Infrastructure.Services.AddressablesLoader.Loader;
using _Project.CodeBase.Infrastructure.Services.Providers.StaticDataProvider;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using VContainer;
using VContainer.Unity;

namespace _Project.CodeBase.Infrastructure.Factories.Apples
{
    public class AppleFactory : IAppleFactory
    {
        private readonly IObjectResolver _objectResolver;
        private readonly IAddressablesLoader _addressablesLoader;

        private readonly AssetReferenceGameObject _appleReference;
        private readonly AssetReferenceGameObject _emptyObject;

        private Transform _root;
        
        public AppleFactory(IObjectResolver objectResolver,
            IAddressablesLoader addressablesLoader,
            IStaticDataProvider staticDataProvider)
        {
            _objectResolver = objectResolver;
            _addressablesLoader = addressablesLoader;
            
            _appleReference = staticDataProvider.AllAssetsAddresses.AllGameplayAddresses.DynamicObjectsAddresses.Apple;
            _emptyObject = staticDataProvider.AllAssetsAddresses.EmptyObject;
        }

        public async UniTask WarmUp()
        {
            await _addressablesLoader.LoadGameObject(_appleReference);
            await _addressablesLoader.LoadGameObject(_emptyObject);
        }

        public async UniTask<Apple> Create()
        {
            if (_root == null)
            {
                GameObject rootGameObject = await CreateRootObject();
                _root = rootGameObject.transform;
            }

            return await CreateApple();
        }

        private async UniTask<Apple> CreateApple()
        {
            Apple prefab = await _addressablesLoader.LoadComponent<Apple>(_appleReference);

            return _objectResolver.Instantiate(prefab, _root);
        }
        
        private async UniTask<GameObject> CreateRootObject()
        {
            GameObject prefab = await _addressablesLoader.LoadGameObject(_emptyObject);
            
            GameObject gameObject = _objectResolver.Instantiate(prefab);
            gameObject.name = "Apples";

            return gameObject;
        }
    }
}