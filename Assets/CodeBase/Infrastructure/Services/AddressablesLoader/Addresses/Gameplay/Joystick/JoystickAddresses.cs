using UnityEngine;
using UnityEngine.AddressableAssets;

namespace CodeBase.Infrastructure.Services.AddressablesLoader.Addresses.Gameplay.Joystick
{
    [CreateAssetMenu(menuName = "StaticData/Addresses/Gameplay/Joystick", fileName = "JoystickAddresses")]
    public class JoystickAddresses : ScriptableObject
    {
        public AssetReferenceGameObject Joystick;
    }
}