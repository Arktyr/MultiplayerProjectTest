using CodeBase.Infrastructure.Services.AddressablesLoader.Addresses;

namespace CodeBase.Infrastructure.Services.Providers.StaticDataProvider
{
    public interface IStaticDataProvider
    {
        public AllAssetsAddresses AllAssetsAddresses { get; }
    }
}