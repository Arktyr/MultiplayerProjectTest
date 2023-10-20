using UnityEngine;
using UnityEngine.AddressableAssets;

namespace CodeBase.Infrastructure.Services.AddressablesLoader.Addresses.UI
{
    [CreateAssetMenu(menuName = "StaticData/Addresses/UI", fileName = "UIAddresses")]
    public class UIAddresses : ScriptableObject
    {
        public AssetReferenceGameObject Canvas;
        public AssetReferenceGameObject EventSystem;
        public AssetReferenceGameObject Joystick;
    }
}