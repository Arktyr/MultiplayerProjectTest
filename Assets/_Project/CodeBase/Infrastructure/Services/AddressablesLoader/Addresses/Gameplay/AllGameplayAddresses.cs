using _Project.CodeBase.Infrastructure.Services.AddressablesLoader.Addresses.Gameplay.DynamicObjects;
using _Project.CodeBase.Infrastructure.Services.AddressablesLoader.Addresses.Gameplay.Joystick;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace _Project.CodeBase.Infrastructure.Services.AddressablesLoader.Addresses.Gameplay
{
    [CreateAssetMenu(menuName = "StaticData/Addresses/Gameplay/AllGameplay", fileName = "GameplayAddresses")]
    public class AllGameplayAddresses : ScriptableObject
    {
        public JoystickAddresses JoystickAddresses;
        public DynamicObjectsAddresses DynamicObjectsAddresses;
        public AssetReferenceGameObject Canvas;
    }
}