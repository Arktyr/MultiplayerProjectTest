using _Project.CodeBase.Gameplay.Services.Gravity;
using _Project.CodeBase.Gameplay.Services.Spawners.Apples;
using _Project.CodeBase.Gameplay.Services.Spawners.Level;
using _Project.CodeBase.Infrastructure.Bootstrappers;
using _Project.CodeBase.Infrastructure.Factories.Apples;
using _Project.CodeBase.Infrastructure.Factories.Characters;
using _Project.CodeBase.Infrastructure.Factories.Characters.Camera;
using _Project.CodeBase.Infrastructure.Factories.Joysticks;
using _Project.CodeBase.Infrastructure.Services.Providers.CharacterProvider;
using _Project.CodeBase.Infrastructure.Services.Providers.JoystickProvider;
using _Project.CodeBase.Infrastructure.StateMachines.App;
using _Project.CodeBase.Infrastructure.StateMachines.App.FSM;
using _Project.CodeBase.Infrastructure.StateMachines.App.States;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Project.CodeBase.Infrastructure.Installers
{
    public class LevelInstaller : LifetimeScope
    {
        [SerializeField] private GameObject _attractive;
        
        protected override void Configure(IContainerBuilder builder)
        {
            BindBootstrapper(builder);
            BindServices(builder);
            BindFactories(builder);
        }

        private void BindBootstrapper(IContainerBuilder builder)
        {
            Debug.Log("dsada");
            
            builder
                .Register<LevelBootstrapper>(Lifetime.Singleton)
                .AsImplementedInterfaces();
        }

        private void BindServices(IContainerBuilder builder)
        {
            builder
                .Register<LevelServices>(Lifetime.Singleton)
                .AsImplementedInterfaces();

            builder
                .Register<IGravityAttraction, GravityAttraction>(Lifetime.Singleton)
                .WithParameter(_attractive);

            builder
                .Register<IAppleSpawner, AppleSpawner>(Lifetime.Singleton)
                .WithParameter(_attractive);
            
            builder.Register<ICharacterProvider, CharacterProvider>(Lifetime.Singleton);
            builder.Register<IJoystickProvider, JoystickProvider>(Lifetime.Singleton);
        }

        private void BindFactories(IContainerBuilder builder)
        {
            builder.Register<IJoystickFactory, JoystickFactory>(Lifetime.Singleton);
            builder.Register<ICharacterFactory, CharacterFactory>(Lifetime.Singleton);
            builder.Register<ICameraFactory, CameraFactory>(Lifetime.Singleton);
            builder.Register<IAppleFactory, AppleFactory>(Lifetime.Singleton);
        }
    }
}