using CodeBase.Gameplay.Input.Joysticks;

namespace CodeBase.Infrastructure.Services.Providers.JoystickProvider
{
    public interface IJoystickProvider
    {
        public Joystick Joystick { get; }
        
        public void SetJoystick(Joystick joystick);
    }
}