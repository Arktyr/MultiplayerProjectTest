using CodeBase.Infrastructure.Services.AddressablesLoader.Addresses;
using CodeBase.Infrastructure.Services.Providers.StaticDataProvider.Data;

namespace CodeBase.Infrastructure.Services.Providers.StaticDataProvider
{
    public class StaticDataProvider : IStaticDataProvider
    {
        public StaticDataProvider(AllAssetsData allAssetsData)
        {
            AllAssetsAddresses = allAssetsData.AllAssetsAddresses;
            GameBalanceData = allAssetsData.GameBalanceData;
        }

        public AllAssetsAddresses AllAssetsAddresses { get; }
        public GameBalanceData GameBalanceData { get; }
    }
}