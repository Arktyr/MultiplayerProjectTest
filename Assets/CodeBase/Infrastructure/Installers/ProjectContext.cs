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
        }

        private void BindStateMachine(IContainerBuilder builder)
        {
            builder.Register<IAppStateMachine, AppStateMachine>(Lifetime.Singleton);

            builder.Register<InitializationState>(Lifetime.Singleton);
            builder.Register<GameplayState>(Lifetime.Singleton);
        }
    }
}
