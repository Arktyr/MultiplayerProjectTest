using CodeBase.Gameplay.Spawner;
using CodeBase.Infrastructure.Factories;
using VContainer;
using VContainer.Unity;

namespace CodeBase.Infrastructure.Installers
{
    public class LevelInstaller : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            BindServices(builder);
            BindFactories(builder);
            
        }

        private void BindServices(IContainerBuilder builder)
        {
            builder.Register<LevelSpawner>(Lifetime.Singleton)
                .AsImplementedInterfaces();
        }

        private void BindFactories(IContainerBuilder builder)
        {
            builder.Register<IJoystickFactory, JoystickFactory>(Lifetime.Singleton);
        }
    }
}