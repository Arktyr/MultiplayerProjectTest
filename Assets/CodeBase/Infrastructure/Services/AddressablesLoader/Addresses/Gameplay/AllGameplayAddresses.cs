using CodeBase.Infrastructure.Services.AddressablesLoader.Addresses.Joystick;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.AddressablesLoader.Addresses
{
    [CreateAssetMenu(menuName = "StaticData/Addresses/Gameplay/AllGameplay", fileName = "GameplayAddresses")]
    public class AllGameplayAddresses : ScriptableObject
    {
        public JoystickAddresses JoystickAddresses;
        public DynamicObjectsAddresses DynamicObjectsAddresses;
    }
}