using System;

namespace _Project.CodeBase.Infrastructure.Services.Tickable
{
    public interface ITickableService
    {
        public event Action Ticked;
        public event Action FixedTicked;
        public event Action LateTicked;

        public void StartTicking();

        public void StopTicking();
    }
}