using Cysharp.Threading.Tasks;

namespace _Project.CodeBase.Infrastructure.Factories.Characters.Camera
{
    public interface ICameraFactory
    {
        public UniTask WarmUp();
        public UniTask Create();
    }
}