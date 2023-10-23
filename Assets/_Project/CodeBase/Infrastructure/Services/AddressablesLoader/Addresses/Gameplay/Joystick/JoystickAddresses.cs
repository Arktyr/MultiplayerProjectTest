using UnityEngine;
using UnityEngine.AddressableAssets;

namespace _Project.CodeBase.Infrastructure.Services.AddressablesLoader.Addresses.Gameplay.Joystick
{
    [CreateAssetMenu(menuName = "StaticData/Addresses/Gameplay/Joystick", fileName = "JoystickAddresses")]
    public class JoystickAddresses : ScriptableObject
    {
        public AssetReferenceGameObject Joystick;
    }
}