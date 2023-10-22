using CodeBase.Common.FSM.States;
using CodeBase.Infrastructure.Services.AddressablesLoader.Loader;
using CodeBase.Infrastructure.Services.Tickable;

namespace CodeBase.Infrastructure.StateMachines.App.States
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

        public void Enter()
        {
            _tickableService.StartTicking();
        }

        public void Exit()
        {
            _addressablesLoader.ClearCache();
        }
    }
}