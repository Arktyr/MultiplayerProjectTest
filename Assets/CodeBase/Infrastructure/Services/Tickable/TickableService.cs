using System;
using UnityEngine;
using VContainer.Unity;

namespace CodeBase.Infrastructure.Services.Updater
{
    public class TickableService : ITickableService, ITickable, IFixedTickable, ILateTickable
    {
        public event Action Ticked;
        public event Action FixedTicked;
        public event Action LateTicked;

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
    }
}