using _Project.CodeBase.Infrastructure.Services.AddressablesLoader.Addresses;
using _Project.CodeBase.Infrastructure.Services.Providers.StaticDataProvider.Data;

namespace _Project.CodeBase.Infrastructure.Services.Providers.StaticDataProvider
{
    public interface IStaticDataProvider
    {
        public AllAssetsAddresses AllAssetsAddresses { get; }
        public GameBalanceData GameBalanceData { get; }
    }
}