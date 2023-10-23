using _Project.CodeBase.Infrastructure.Services.AddressablesLoader.Loader;
using Cysharp.Threading.Tasks;
using VContainer;

namespace _Project.CodeBase.Infrastructure.Factories
{
    public abstract class Factory
    {
        protected readonly IObjectResolver _objectResolver;
        protected readonly IAddressablesLoader _addressablesLoader;

        protected Factory(IObjectResolver objectResolver,
            IAddressablesLoader addressablesLoader)
        {
            _objectResolver = objectResolver;
            _addressablesLoader = addressablesLoader;
        }

        public abstract UniTask WarmUp();
        public abstract UniTask Create();
    }
}