using CodeBase.Infrastructure.Services.AddressablesLoader.Addresses;

namespace CodeBase.Infrastructure.Services.Providers.StaticDataProvider
{
    public class StaticDataProvider : IStaticDataProvider
    {
        public StaticDataProvider(AllAssetsData allAssetsData)
        {
            AllAssetsAddresses = allAssetsData.AllAssetsAddresses;
        }
        
        public AllAssetsAddresses AllAssetsAddresses { get; private set; }
    }
}