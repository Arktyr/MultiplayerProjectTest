using CodeBase.Infrastructure.Services.AddressablesLoader.Addresses.Scenes;
using CodeBase.Infrastructure.Services.AddressablesLoader.Addresses.UI;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.AddressablesLoader.Addresses
{
    [CreateAssetMenu(menuName = "StaticData/Addresses/AllAssetsAddresses", fileName = "AllAssetsAddresses")]
    public class AllAssetsAddresses : ScriptableObject
    {
        public SceneAddresses SceneAddresses;
        public UIAddresses UIAddresses;
    }
}