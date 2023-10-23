using _Project.CodeBase.Gameplay.Input.Joysticks;

namespace _Project.CodeBase.Infrastructure.Services.Providers.JoystickProvider
{
    public interface IJoystickProvider
    {
        public Joystick Joystick { get; }
        
        public void SetJoystick(Joystick joystick);
    }
}