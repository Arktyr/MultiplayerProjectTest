using Cysharp.Threading.Tasks;

namespace _Project.CodeBase.Infrastructure.Factories.Joysticks
{
    public interface IJoystickFactory
    {
        public UniTask WarmUp();
        public UniTask Create();
    }
}