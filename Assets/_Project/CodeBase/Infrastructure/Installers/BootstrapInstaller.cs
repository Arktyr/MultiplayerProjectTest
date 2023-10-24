using _Project.CodeBase.Infrastructure.Bootstrappers;
using VContainer;
using VContainer.Unity;

namespace _Project.CodeBase.Infrastructure.Installers
{
    public class BootstrapInstaller : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder) => 
            builder
                .Register<AppBootstrapper>(Lifetime.Singleton)
                .AsImplementedInterfaces();
    }
}