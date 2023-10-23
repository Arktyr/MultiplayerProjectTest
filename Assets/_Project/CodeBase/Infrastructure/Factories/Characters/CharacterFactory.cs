using _Project.CodeBase.Gameplay.Characters;
using _Project.CodeBase.Gameplay.Characters.Config;
using _Project.CodeBase.Gameplay.Input.Joysticks;
using _Project.CodeBase.Gameplay.Services.Gravity;
using _Project.CodeBase.Infrastructure.Services.AddressablesLoader.Addresses.Gameplay.Character;
using _Project.CodeBase.Infrastructure.Services.AddressablesLoader.Loader;
using _Project.CodeBase.Infrastructure.Services.Providers.CharacterProvider;
using _Project.CodeBase.Infrastructure.Services.Providers.JoystickProvider;
using _Project.CodeBase.Infrastructure.Services.Providers.StaticDataProvider;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using VContainer;
using VContainer.Unity;

namespace _Project.CodeBase.Infrastructure.Factories.Characters
{
    public class CharacterFactory : Factory, ICharacterFactory
    {
        private readonly IGravityAttraction _gravityAttraction;
        private readonly CharacterAddresses _characterAddresses;
        private readonly IJoystickProvider _joystickProvider;
        private readonly ICharacterProvider _characterProvider;

        private readonly CharacterConfig _characterConfig;
        private readonly AssetReferenceGameObject _emptyObject;

        private Transform _root;
        
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

            _characterAddresses = staticDataProvider.AllAssetsAddresses.AllGameplayAddresses.DynamicObjectsAddresses
                .CharacterAddresses;
            _characterConfig = staticDataProvider.GameBalanceData.CharacterConfig;
            _emptyObject = staticDataProvider.AllAssetsAddresses.EmptyObject;
        }
        
        public override async UniTask WarmUp()
        {
            await _addressablesLoader.LoadGameObject(_characterAddresses.Head);
            await _addressablesLoader.LoadGameObject(_emptyObject);
        }

        public async UniTask<BodyParts> CreateBodyPart()
        {
            GameObject prefab = await _addressablesLoader.LoadGameObject(_characterAddresses.Body);
            GameObject gameObject = _objectResolver.Instantiate(prefab, _root);
            
            return gameObject.GetComponent<BodyParts>();
        }

        public override async UniTask Create()
        {
            if (_root == null)
            {
                GameObject rootGameObject = await CreateRootGameObject();
                _root = rootGameObject.transform;
            }

            GameObject head = await CreateHead();
            head.transform.position = _characterConfig.StartPosition;

            SetupCharacterMovement(head);
            await SetupCharacterBody(head);
            SetupCharacter(head);
            SetupCharacterToAttraction(head);
        }

        private void SetupCharacterToAttraction(GameObject head)
        {
            Rigidbody rigidbody = head.GetComponent<Rigidbody>();
            _gravityAttraction.AddObjectToAttraction(rigidbody);
        }

        private async UniTask<GameObject> CreateHead()
        {
            GameObject prefab = await _addressablesLoader.LoadGameObject(_characterAddresses.Head);

            return _objectResolver.Instantiate(prefab, _root);
        }
        private async UniTask<GameObject> CreateRootGameObject()
        {
            GameObject prefab = await _addressablesLoader.LoadGameObject(_emptyObject);

            GameObject gameObject = _objectResolver.Instantiate(prefab);

            gameObject.name = "Snake";
            return gameObject;
        }

        private async UniTask SetupCharacterBody(GameObject gameObject)
        {
            CharacterBody characterBody = gameObject.GetComponent<CharacterBody>();
            _objectResolver.Inject(characterBody);
            
            for (int i = 0; i < _characterConfig.StartNumberBodyParts; i++) 
                await characterBody.AddBodyPiece();
        }
        
        private Character SetupCharacter(GameObject gameObject)
        {
            Character character = gameObject.GetComponent<Character>();
            _objectResolver.Inject(character);
            character.Initialize();
            _characterProvider.SetCharacter(character);

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