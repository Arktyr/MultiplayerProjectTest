using UnityEngine;

namespace CodeBase.Infrastructure.Services.Providers.UIProvider
{
    public class JoystickProvider : IJoystickProvider
    {
        public Joystick Joystick { get; private set; }
        
        public void SetJoystick(Joystick joystick) =>
            Joystick = joystick;
    }
}