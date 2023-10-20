using Cysharp.Threading.Tasks;

namespace CodeBase.Infrastructure.Factories.Joysticks
{
    public interface IJoystickFactory
    {
        public UniTask WarmUp();
        public UniTask Create();
    }
}