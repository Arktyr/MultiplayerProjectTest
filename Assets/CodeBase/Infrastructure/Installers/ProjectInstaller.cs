using CodeBase.Infrastructure.Factories;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.AddressablesLoader.Loader;
using CodeBase.Infrastructure.Services.Logger;
using CodeBase.Infrastructure.Services.Providers.LevelSpawnerProvider;
using CodeBase.Infrastructure.Services.Providers.StaticDataProvider;
using CodeBase.Infrastructure.Services.Providers.UIProvider;
using CodeBase.Infrastructure.Services.SceneLoader;
using CodeBase.Infrastructure.StateMachines.App.FSM;
using CodeBase.Infrastructure.StateMachines.App.States;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace CodeBase.Infrastructure.Installers
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
            builder.Register<ICustomLogger, CustomLogger>(Lifetime.Singleton);
            builder.Register<ISceneLoader, SceneLoader>(Lifetime.Singleton);
            builder.Register<IAddressablesLoader, AddressablesLoader>(Lifetime.Singleton);
            builder.Register<IJoystickFactory, JoystickFactory>(Lifetime.Singleton);

            builder.Register<ILevelSpawnerProvider, LevelSpawnerProvider>(Lifetime.Singleton);
            builder.Register<IJoystickProvider, JoystickProvider>(Lifetime.Singleton);
            builder.Register<IStaticDataProvider, StaticDataProvider>(Lifetime.Singleton)
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
