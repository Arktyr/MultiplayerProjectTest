using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.Logger;
using CodeBase.Infrastructure.StateMachines.App.FSM;
using CodeBase.Infrastructure.StateMachines.App.States;
using VContainer;
using VContainer.Unity;

namespace CodeBase.Infrastructure.Installers
{
    public class ProjectContext : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            BindStateMachine(builder);
            BindServices(builder);
        }

        private void BindServices(IContainerBuilder builder)
        {
            builder.Register<ICustomLogger, CustomLogger>(Lifetime.Singleton);
        }

        private void BindStateMachine(IContainerBuilder builder)
        {
            builder.Register<IAppStateMachine, AppStateMachine>(Lifetime.Singleton);

            builder.Register<InitializationState>(Lifetime.Singleton);
            builder.Register<GameplayState>(Lifetime.Singleton);
        }
    }
}
