using UnityEngine;

namespace CodeBase.Infrastructure.Services.Providers.UIProvider
{
    public interface IJoystickProvider
    {
        public Joystick Joystick { get; }
        
        public void SetJoystick(Joystick joystick);
    }
}