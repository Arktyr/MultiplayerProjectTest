using _Project.CodeBase.Gameplay.Characters;

namespace _Project.CodeBase.Infrastructure.Services.Providers.CharacterProvider
{
    public interface ICharacterProvider
    {
        public Character Character { get; }

        public void SetCharacter(Character character);
    }
}