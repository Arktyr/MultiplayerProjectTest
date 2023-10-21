using Cysharp.Threading.Tasks;

namespace CodeBase.Infrastructure.Factories.Characters.Camera
{
    public interface ICameraFactory
    {
        public UniTask WarmUp();
        public UniTask Create();
    }
}