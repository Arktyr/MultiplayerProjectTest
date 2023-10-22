using CodeBase.Infrastructure.Services.AddressablesLoader.Addresses.Joystick;
using CodeBase.Infrastructure.Services.AddressablesLoader.Addresses.Scenes;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace CodeBase.Infrastructure.Services.AddressablesLoader.Addresses
{
    [CreateAssetMenu(menuName = "StaticData/Addresses/AllAssetsAddresses", fileName = "AllAssetsAddresses")]
    public class AllAssetsAddresses : ScriptableObject
    {
        public SceneAddresses SceneAddresses;
        public AllGameplayAddresses AllGameplayAddresses;
        public AssetReferenceGameObject Camera;
        public AssetReferenceGameObject EmptyObject;
    }
}