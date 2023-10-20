using CodeBase.Infrastructure.Services.Tickable;
using VContainer;

namespace CodeBase.Gameplay.Characters
{
    public class Character
    {
        private ITickableService _tickableService;
        
        [Inject]
        public void Inject(ITickableService tickableService) => 
            _tickableService = tickableService;

        public void Construct(CharacterMovement characterMovement)
        {
            CharacterMovement = characterMovement;
        }
        
        public CharacterMovement CharacterMovement { get; private set; }

        public void Initialize()
        {
            _tickableService.FixedTicked += CharacterMovement.Move;
        }

        public void Dispose()
        {
            _tickableService.FixedTicked -= CharacterMovement.Move;
        }
    }
}