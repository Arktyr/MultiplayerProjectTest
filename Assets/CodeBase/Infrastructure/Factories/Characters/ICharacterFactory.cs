using Cysharp.Threading.Tasks;

namespace CodeBase.Infrastructure.Factories.Characters
{
    public interface ICharacterFactory
    {
        public UniTask WarmUp();

        public UniTask Create();
    }
}