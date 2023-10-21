using System;
using VContainer.Unity;

namespace CodeBase.Infrastructure.Services.Tickable
{
    public class TickableService : ITickableService, ITickable, IFixedTickable, ILateTickable, IPostLateTickable
    {
        public event Action Ticked;
        public event Action FixedTicked;
        public event Action LateTicked;
        public event Action PostLateTicked;

        private bool _isPaused;

        public void StartTicking() =>
            _isPaused = false;

        public void StopTicking() =>
            _isPaused = true;
        
        public void Tick()
        {
            if (_isPaused)
                return;
            
            Ticked?.Invoke();
        }

        public void FixedTick()
        {
            if (_isPaused)
                return;
            
            FixedTicked?.Invoke();
        }

        public void LateTick()
        {
            if (_isPaused)
                return;
            
            LateTicked?.Invoke();
        }

        public void PostLateTick()
        {
            if (_isPaused)
                return;
            
            PostLateTicked?.Invoke();;
        }
    }
}