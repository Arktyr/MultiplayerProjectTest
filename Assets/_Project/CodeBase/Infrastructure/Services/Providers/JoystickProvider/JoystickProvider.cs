using _Project.CodeBase.Gameplay.Input.Joysticks;

namespace _Project.CodeBase.Infrastructure.Services.Providers.JoystickProvider
{
    public class JoystickProvider : IJoystickProvider
    {
        public Joystick Joystick { get; private set; }
        
        public void SetJoystick(Joystick joystick) =>
            Joystick = joystick;
    }
}