using CodeBase.Common.Factories;
using CodeBase.Gameplay.Input.Joysticks;
using CodeBase.Infrastructure.Services.AddressablesLoader.Addresses.Joystick;
using CodeBase.Infrastructure.Services.AddressablesLoader.Loader;
using CodeBase.Infrastructure.Services.Providers.JoystickProvider;
using CodeBase.Infrastructure.Services.Providers.StaticDataProvider;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace CodeBase.Infrastructure.Factories.Joysticks
{
    public class JoystickFactory : Factory, IJoystickFactory
    {
        private readonly IJoystickProvider _joystickProvider;

        private readonly JoystickAddresses joystickAddresses;
        
        public JoystickFactory(IObjectResolver objectResolver, 
            IAddressablesLoader addressablesLoader,
            IJoystickProvider joystickProvider,
            IStaticDataProvider staticDataProvider) 
            : base(objectResolver, addressablesLoader)
        {
            _joystickProvider = joystickProvider;
            joystickAddresses = staticDataProvider.AllAssetsAddresses.JoystickAddresses;
        }

        public override async UniTask WarmUp()
        {
            await _addressablesLoader.LoadGameObject(joystickAddresses.Canvas);
            await _addressablesLoader.LoadGameObject(joystickAddresses.Joystick);
        }
        
        public override async UniTask Create()
        {
            Canvas canvas = await CreateCanvas();

            Joystick joystick = await CreateJoystick(canvas);
            _joystickProvider.SetJoystick(joystick);
        }
        
        private async UniTask<Canvas> CreateCanvas()
        {
            Canvas prefab = await _addressablesLoader.LoadComponent<Canvas>(joystickAddresses.Canvas);
            
            return _objectResolver.Instantiate(prefab, null, false);
        }
        
        private async UniTask<Joystick> CreateJoystick(Canvas canvas)
        {
           Joystick prefab = await _addressablesLoader.LoadComponent<Joystick>(joystickAddresses.Joystick);

            return _objectResolver.Instantiate(prefab, canvas.transform);
        }
    }
}
