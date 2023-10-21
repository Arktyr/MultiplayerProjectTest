using CodeBase.Common.Factories;
using CodeBase.Gameplay.CameraControl;
using CodeBase.Gameplay.CameraControl.Config;
using CodeBase.Infrastructure.Services.AddressablesLoader.Loader;
using CodeBase.Infrastructure.Services.Providers.CharacterProvider;
using CodeBase.Infrastructure.Services.Providers.StaticDataProvider;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using VContainer;
using VContainer.Unity;

namespace CodeBase.Infrastructure.Factories.Characters.Camera
{
    public class CameraFactory : Factory, ICameraFactory
    {
        private readonly ICharacterProvider _characterProvider;
        
        private readonly AssetReferenceGameObject _cameraReference;
        private readonly CameraConfig _cameraConfig; 
        
        public CameraFactory(IObjectResolver objectResolver,
            IAddressablesLoader addressablesLoader,
            ICharacterProvider characterProvider,
            IStaticDataProvider staticDataProvider) :
            base(objectResolver, addressablesLoader)
        {
            _characterProvider = characterProvider;
            
            _cameraReference = staticDataProvider.AllAssetsAddresses.Camera;
            _cameraConfig = staticDataProvider.GameBalanceData.CameraConfig;
        }

        public override async UniTask WarmUp()
        {
            await _addressablesLoader.LoadGameObject(_cameraReference);
        }

        public override async UniTask Create()
        {
            GameObject prefab = await _addressablesLoader.LoadGameObject(_cameraReference);

            GameObject gameObject = _objectResolver.Instantiate(prefab);

            CreateCameraMovement(gameObject);
        }

        private void CreateCameraMovement(GameObject gameObject)
        {
            CameraMovement cameraMovement = gameObject.GetComponent<CameraMovement>();
            _objectResolver.Inject(cameraMovement);
            cameraMovement.Construct(_characterProvider.Character.transform, _cameraConfig.Offset,
                _cameraConfig.IsLookedAtCharacter);
            cameraMovement.Initialize();
        }
    }
}