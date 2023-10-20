using CodeBase.Infrastructure.Services.AddressablesLoader.Addresses.UI;
using CodeBase.Infrastructure.Services.AddressablesLoader.Loader;
using CodeBase.Infrastructure.Services.Providers.StaticDataProvider;
using CodeBase.Infrastructure.Services.Providers.UIProvider;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace CodeBase.Infrastructure.Factories
{
    public class JoystickFactory : IJoystickFactory
    {
        private readonly IObjectResolver _objectResolver;
        private readonly IAddressablesLoader _addressablesLoader;
        private readonly IJoystickProvider _joystickProvider;

        private readonly UIAddresses _uiAddresses;

        public JoystickFactory(IObjectResolver objectResolver,
            IAddressablesLoader addressablesLoader,
            IJoystickProvider joystickProvider,
            IStaticDataProvider staticDataProvider)
        {
            _objectResolver = objectResolver;
            _addressablesLoader = addressablesLoader;
            _joystickProvider = joystickProvider;
            
            _uiAddresses = staticDataProvider.AllAssetsAddresses.UIAddresses;
        }
        
        public async UniTask Create()
        {
            Canvas canvas = await CreateCanvas();

            Joystick joystick = await CreateJoystick(canvas);
            _joystickProvider.SetJoystick(joystick);
        }
        
        private async UniTask<Canvas> CreateCanvas()
        {
            Canvas prefab = await _addressablesLoader.LoadComponent<Canvas>(_uiAddresses.Canvas);
            
            return _objectResolver.Instantiate(prefab);
        }
        
        private async UniTask<Joystick> CreateJoystick(Canvas canvas)
        {
            Joystick prefab = await _addressablesLoader.LoadComponent<Joystick>(_uiAddresses.Joystick);

            return _objectResolver.Instantiate(prefab, canvas.transform);
        }
    }
}
