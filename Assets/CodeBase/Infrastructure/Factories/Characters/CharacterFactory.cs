using CodeBase.Common.Factories;
using CodeBase.Gameplay.Characters;
using CodeBase.Gameplay.Characters.Config;
using CodeBase.Gameplay.Input.Joysticks;
using CodeBase.Gameplay.Services.Gravity;
using CodeBase.Infrastructure.Services.AddressablesLoader.Addresses.Character;
using CodeBase.Infrastructure.Services.AddressablesLoader.Loader;
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

        private readonly CharacterConfig _characterConfig;

        public CharacterFactory(IObjectResolver objectResolver, 
            IAddressablesLoader addressablesLoader,
            IGravityAttraction gravityAttraction,
            IJoystickProvider joystickProvider,
            IStaticDataProvider staticDataProvider) : base(objectResolver, addressablesLoader)
        {
            _gravityAttraction = gravityAttraction;
            _joystickProvider = joystickProvider;
            
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

            CharacterMovement characterMovement = CreateMovement(gameObject);

            CreateCharacter(characterMovement);

            Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();
            _gravityAttraction.AddObjectToAttraction(rigidbody);
        }

        public async UniTask<GameObject> CreateGameObject()
        {
            GameObject prefab = await _addressablesLoader.LoadGameObject(_characterAddresses.Head);

            return _objectResolver.Instantiate(prefab);
        }

        private Character CreateCharacter(CharacterMovement characterMovement)
        {
            Character character = new Character();
            character.Construct(characterMovement);
            _objectResolver.Inject(character);
            character.Initialize();

            return character;
        }

        public CharacterMovement CreateMovement(GameObject gameObject)
        {
            CharacterMovement characterMovement = new CharacterMovement();
            
            Movement movement = gameObject.GetComponent<Movement>();
            Rotate rotate = gameObject.GetComponent<Rotate>();
            Joystick joystick = _joystickProvider.Joystick;
            
            characterMovement.Construct(joystick, movement, rotate, _characterConfig.Speed,
                _characterConfig.RotatingSpeed);

            return characterMovement;
        }
    }
}