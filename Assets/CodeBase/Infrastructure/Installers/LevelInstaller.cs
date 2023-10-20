using CodeBase.Infrastructure.Factories;
using VContainer;
using VContainer.Unity;

namespace CodeBase.Infrastructure.Installers
{
    public class LevelInstaller : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            BindFactories(builder);
        }

        private void BindFactories(IContainerBuilder builder)
        {
            builder.Register<IJoystickFactory, JoystickFactory>(Lifetime.Singleton);
        }
    }
}