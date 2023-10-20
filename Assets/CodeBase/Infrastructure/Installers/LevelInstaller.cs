using CodeBase.Gameplay.Services.Gravity;
using CodeBase.Gameplay.Spawner;
using CodeBase.Infrastructure.Factories;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace CodeBase.Infrastructure.Installers
{
    public class LevelInstaller : LifetimeScope
    {
        [SerializeField] private GameObject _attractive;
        [SerializeField] private Rigidbody _attraction;
        
        protected override void Configure(IContainerBuilder builder)
        {
            BindServices(builder);
            BindFactories(builder);
        }

        private void BindServices(IContainerBuilder builder)
        {
            builder
                .Register<LevelSpawner>(Lifetime.Singleton)
                .AsImplementedInterfaces();

            builder
                .Register<IGravityAttraction, GravityAttraction>(Lifetime.Singleton)
                .WithParameter(_attractive)
                .WithParameter(_attraction);
        }

        private void BindFactories(IContainerBuilder builder)
        {
            builder.Register<IJoystickFactory, JoystickFactory>(Lifetime.Singleton);
        }
    }
}