using _Project.CodeBase.Gameplay.Characters;
using Cysharp.Threading.Tasks;

namespace _Project.CodeBase.Infrastructure.Factories.Characters
{
    public interface ICharacterFactory
    {
        public UniTask WarmUp();
        public UniTask Create();
        public UniTask<BodyParts> CreateBodyPart();
    }
}