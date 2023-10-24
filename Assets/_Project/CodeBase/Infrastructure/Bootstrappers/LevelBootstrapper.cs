using _Project.CodeBase.Gameplay.Services.Spawners.Level;
using _Project.CodeBase.Infrastructure.StateMachines.App.States;
using VContainer.Unity;

namespace _Project.CodeBase.Infrastructure.Bootstrappers
{
    public class LevelBootstrapper : IInitializable
    {
        private readonly InitializationState _initializationState;
        private readonly ILevelServices _levelServices;

        public LevelBootstrapper(InitializationState initializationState,
            ILevelServices levelServices)
        {
            _initializationState = initializationState;
            _levelServices = levelServices;
        }
        
        public void Initialize() => 
            _initializationState.SetLocalDependencies(_levelServices);
    }
}