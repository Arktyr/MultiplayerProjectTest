using CodeBase.Gameplay;
using CodeBase.Infrastructure.Services.AddressablesLoader.Loader;
using CodeBase.Infrastructure.Services.Providers.StaticDataProvider;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using VContainer;
using VContainer.Unity;

namespace CodeBase.Infrastructure.Factories.Apples
{
    public class AppleFactory : IAppleFactory
    {
        private readonly IObjectResolver _objectResolver;
        private readonly IAddressablesLoader _addressablesLoader;

        private AssetReferenceGameObject _appleReference;
        public AppleFactory(IObjectResolver objectResolver,
            IAddressablesLoader addressablesLoader,
            IStaticDataProvider staticDataProvider)
        {
            _objectResolver = objectResolver;
            _addressablesLoader = addressablesLoader;
            
            _appleReference = staticDataProvider.AllAssetsAddresses.AllGameplayAddresses.DynamicObjectsAddresses.Apple;
        }

        public async UniTask WarmUp()
        {
            await _addressablesLoader.LoadGameObject(_appleReference);
        }

        public async UniTask<Apple> Create()
        {
            Apple prefab = await _addressablesLoader.LoadComponent<Apple>(_appleReference);

            return _objectResolver.Instantiate(prefab);
        }
    }
}