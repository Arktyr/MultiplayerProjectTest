using Cysharp.Threading.Tasks;

namespace CodeBase.Infrastructure.Factories
{
    public interface IJoystickFactory
    {
        public UniTask Create();
    }
}