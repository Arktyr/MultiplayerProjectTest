using _Project.CodeBase.Gameplay.CameraControl;
using _Project.CodeBase.Gameplay.CameraControl.Config;
using _Project.CodeBase.Infrastructure.Services.AddressablesLoader.Loader;
using _Project.CodeBase.Infrastructure.Services.Providers.CharacterProvider;
using _Project.CodeBase.Infrastructure.Services.Providers.StaticDataProvider;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using VContainer;
using VContainer.Unity;

namespace _Project.CodeBase.Infrastructure.Factories.Characters.Camera
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