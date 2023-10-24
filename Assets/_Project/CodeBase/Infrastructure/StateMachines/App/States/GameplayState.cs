using _Project.CodeBase.Gameplay.Services.Spawners.Level;
using _Project.CodeBase.Infrastructure.Services.AddressablesLoader.Loader;
using _Project.CodeBase.Infrastructure.Services.Tickable;
using _Project.CodeBase.Infrastructure.StateMachines.States;
using VContainer;

namespace _Project.CodeBase.Infrastructure.StateMachines.App.States
{
    public class GameplayState : IState
    {
        private readonly ITickableService _tickableService;
        private readonly IAddressablesLoader _addressablesLoader;

        public GameplayState(ITickableService tickableService,
            IAddressablesLoader addressablesLoader)
        {
            _tickableService = tickableService;
            _addressablesLoader = addressablesLoader;
        }

        public  void Enter()
        {
            _tickableService.StartTicking();
        }

        public void Exit()
        {
            _addressablesLoader.ClearCache();
        }
    }
}