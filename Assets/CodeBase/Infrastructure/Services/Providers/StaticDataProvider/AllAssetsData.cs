using CodeBase.Infrastructure.Services.AddressablesLoader.Addresses;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.Providers.StaticDataProvider
{
    [CreateAssetMenu(menuName = "StaticData/AllAssets", fileName = "AllAssetsData")]
    public class AllAssetsData : ScriptableObject
    {
        public AllAssetsAddresses AllAssetsAddresses;
    }
}