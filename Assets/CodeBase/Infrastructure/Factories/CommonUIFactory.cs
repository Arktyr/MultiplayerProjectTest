using System.Threading.Tasks;
using CodeBase.Infrastructure.Services.AddressablesLoader.Addresses.UI;
using CodeBase.Infrastructure.Services.AddressablesLoader.Loader;
using CodeBase.Infrastructure.Services.Providers.StaticDataProvider;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using VContainer;
using VContainer.Unity;

namespace CodeBase.Infrastructure.Factories
{
    public class CommonUIFactory : ICommonUIFactory
    {
        private readonly IObjectResolver _objectResolver;
        private readonly IAddressablesLoader _addressablesLoader;

        private readonly UIAddresses _uiAddresses;

        public CommonUIFactory(IObjectResolver objectResolver,
            IAddressablesLoader addressablesLoader,
            IStaticDataProvider staticDataProvider)
        {
            _objectResolver = objectResolver;
            _addressablesLoader = addressablesLoader;
            
            _uiAddresses = staticDataProvider.AllAssetsAddresses.UIAddresses;
        }
        
        public async UniTask Create()
        {
            Canvas canvas = await CreateCanvas();

        }
        
        private async UniTask<Canvas> CreateCanvas()
        {
            Canvas prefab = await _addressablesLoader.LoadComponent<Canvas>(_uiAddresses.Canvas);
            
            return _objectResolver.Instantiate(prefab);
        }
    }
}
