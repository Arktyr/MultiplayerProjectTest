using CodeBase.Infrastructure.Services.AddressablesLoader.Addresses;
using CodeBase.Infrastructure.Services.Providers.StaticDataProvider.Data;

namespace CodeBase.Infrastructure.Services.Providers.StaticDataProvider
{
    public interface IStaticDataProvider
    {
        public AllAssetsAddresses AllAssetsAddresses { get; }
        public GameBalanceData GameBalanceData { get; }
    }
}