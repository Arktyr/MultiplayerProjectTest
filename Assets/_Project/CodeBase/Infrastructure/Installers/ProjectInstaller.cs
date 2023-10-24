using _Project.CodeBase.Infrastructure.Factories.Joysticks;
using _Project.CodeBase.Infrastructure.Services.AddressablesLoader.Loader;
using _Project.CodeBase.Infrastructure.Services.Logger;
using _Project.CodeBase.Infrastructure.Services.Providers.LevelSpawnerProvider;
using _Project.CodeBase.Infrastructure.Services.Providers.StaticDataProvider;
using _Project.CodeBase.Infrastructure.Services.Providers.StaticDataProvider.Data;
using _Project.CodeBase.Infrastructure.Services.SceneLoader;
using _Project.CodeBase.Infrastructure.Services.Tickable;
using _Project.CodeBase.Infrastructure.StateMachines.App.FSM;
using _Project.CodeBase.Infrastructure.StateMachines.App.States;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Project.CodeBase.Infrastructure.Installers
{
    public class ProjectInstaller : LifetimeScope
    {
        [SerializeField] private AllAssetsData _allAssetsData;
        
        protected override void Configure(IContainerBuilder builder)
        {
            BindStateMachine(builder);
            BindServices(builder);
        }

        private void BindServices(IContainerBuilder builder)
        {
            builder
                .Register<TickableService>(Lifetime.Singleton)
                .AsImplementedInterfaces();
            
            builder.Register<ICustomLogger, CustomLogger>(Lifetime.Singleton);
            builder.Register<ISceneLoader, SceneLoader>(Lifetime.Singleton);
            builder.Register<IAddressablesLoader, AddressablesLoader>(Lifetime.Singleton);
            builder.Register<IJoystickFactory, JoystickFactory>(Lifetime.Singleton);
            
            builder.Register<ILevelServicesProvider, LevelServicesProvider>(Lifetime.Singleton);

            builder
                .Register<IStaticDataProvider, StaticDataProvider>(Lifetime.Singleton)
                .WithParameter(_allAssetsData);
        }

        private void BindStateMachine(IContainerBuilder builder)
        {
            builder.Register<IAppStateMachine, AppStateMachine>(Lifetime.Singleton);

            builder.Register<InitializationState>(Lifetime.Singleton);
            builder.Register<GameplayState>(Lifetime.Singleton);
        }
    }
}
