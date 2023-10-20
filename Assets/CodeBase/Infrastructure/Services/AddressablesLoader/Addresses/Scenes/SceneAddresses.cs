using UnityEngine;
using UnityEngine.AddressableAssets;

namespace CodeBase.Infrastructure.Services.AddressablesLoader.Addresses.Scenes
{
    [CreateAssetMenu(menuName = "StaticData/Addresses/Scenes", fileName = "SceneAddresses")]
    public class SceneAddresses : ScriptableObject
    {
        public AssetReference Level;
    }
}