using _Project.CodeBase.Infrastructure.Services.AddressablesLoader.Addresses;
using UnityEngine;

namespace _Project.CodeBase.Infrastructure.Services.Providers.StaticDataProvider.Data
{
    [CreateAssetMenu(menuName = "StaticData/AllAssets", fileName = "AllAssetsData")]
    public class AllAssetsData : ScriptableObject
    {
        public AllAssetsAddresses AllAssetsAddresses;
        public GameBalanceData GameBalanceData;
    }
}