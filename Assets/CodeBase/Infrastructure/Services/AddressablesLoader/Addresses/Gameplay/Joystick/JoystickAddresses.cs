using UnityEngine;
using UnityEngine.AddressableAssets;

namespace CodeBase.Infrastructure.Services.AddressablesLoader.Addresses.Joystick
{
    [CreateAssetMenu(menuName = "StaticData/Addresses/Gameplay/Joystick", fileName = "JoystickAddresses")]
    public class JoystickAddresses : ScriptableObject
    {
        public AssetReferenceGameObject Canvas;
        public AssetReferenceGameObject Joystick;
    }
}