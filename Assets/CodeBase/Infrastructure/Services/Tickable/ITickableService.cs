using System;

namespace CodeBase.Infrastructure.Services.Tickable
{
    public interface ITickableService
    {
        public event Action Ticked;
        public event Action FixedTicked;
        public event Action LateTicked;
        public event Action PostLateTicked;

        public void StartTicking();

        public void StopTicking();
    }
}