using CodeBase.Common.Factories;
using CodeBase.Gameplay.Characters;
using CodeBase.Gameplay.Characters.Config;
using CodeBase.Gameplay.Input.Joysticks;
using CodeBase.Gameplay.Services.Gravity;
using CodeBase.Infrastructure.Services.AddressablesLoader.Addresses.Character;
using CodeBase.Infrastructure.Services.AddressablesLoader.Loader;
using CodeBase.Infrastructure.Services.Providers.CharacterProvider;
using CodeBase.Infrastructure.Services.Providers.JoystickProvider;
using CodeBase.Infrastructure.Services.Providers.StaticDataProvider;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace CodeBase.Infrastructure.Factories.Characters
{
    public class CharacterFactory : Factory, ICharacterFactory
    {
        private readonly IGravityAttraction _gravityAttraction;
        private readonly CharacterAddresses _characterAddresses;
        private readonly IJoystickProvider _joystickProvider;
        private readonly ICharacterProvider _characterProvider;

        private readonly CharacterConfig _characterConfig;

        public CharacterFactory(IObjectResolver objectResolver, 
            IAddressablesLoader addressablesLoader,
            IGravityAttraction gravityAttraction,
            IJoystickProvider joystickProvider,
            ICharacterProvider characterProvider,
            IStaticDataProvider staticDataProvider) : base(objectResolver, addressablesLoader)
        {
            _gravityAttraction = gravityAttraction;
            _joystickProvider = joystickProvider;
            _characterProvider = characterProvider;
            
            _characterAddresses = staticDataProvider.AllAssetsAddresses.CharacterAddresses;
            _characterConfig = staticDataProvider.GameBalanceData.CharacterConfig;
        }
        
        public override async UniTask WarmUp()
        {
            await _addressablesLoader.LoadGameObject(_characterAddresses.Head);
        }

        public override async UniTask Create()
        {
            GameObject gameObject = await CreateGameObject();

            SetupCharacterMovement(gameObject);

            CharacterBody characterBody = gameObject.GetComponent<CharacterBody>();
            GameObject prefab = await _addressablesLoader.LoadGameObject(_characterAddresses.Body);
            GameObject gameObject1 = _objectResolver.Instantiate(prefab);
            GameObject gameObject2 = _objectResolver.Instantiate(prefab);
            GameObject gameObject3 = _objectResolver.Instantiate(prefab);
            BodyParts bodyPiece1 = gameObject1.GetComponent<BodyParts>();
            BodyParts bodyPiece2 = gameObject2.GetComponent<BodyParts>();
            BodyParts bodyPiece3 = gameObject3.GetComponent<BodyParts>();
            characterBody.AddBodyPiece(bodyPiece1);
            characterBody.AddBodyPiece(bodyPiece2);
            characterBody.AddBodyPiece(bodyPiece3);

            Character character = SetupCharacter(gameObject);
            _characterProvider.SetCharacter(character);
            
            Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();
            _gravityAttraction.AddObjectToAttraction(rigidbody);
        }

        private async UniTask<GameObject> CreateGameObject()
        {
            GameObject prefab = await _addressablesLoader.LoadGameObject(_characterAddresses.Head);

            return _objectResolver.Instantiate(prefab);
        }

        private Character SetupCharacter(GameObject gameObject)
        {
            Character character = gameObject.GetComponent<Character>();
            _objectResolver.Inject(character);
            character.Initialize();

            return character;
        }

        private void SetupCharacterMovement(GameObject gameObject)
        {
            CharacterMovement characterMovement = gameObject.GetComponent<CharacterMovement>();
            
            Joystick joystick = _joystickProvider.Joystick;
            
            characterMovement.Construct(joystick, _characterConfig.Speed,
                _characterConfig.RotatingSpeed);
        }
    }
}