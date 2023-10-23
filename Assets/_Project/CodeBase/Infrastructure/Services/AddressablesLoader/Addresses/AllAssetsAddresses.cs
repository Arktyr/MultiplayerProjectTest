using _Project.CodeBase.Infrastructure.Services.AddressablesLoader.Addresses.Gameplay;
using _Project.CodeBase.Infrastructure.Services.AddressablesLoader.Addresses.Scenes;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace _Project.CodeBase.Infrastructure.Services.AddressablesLoader.Addresses
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