using CodeBase.Gameplay.Characters;

namespace CodeBase.Infrastructure.Services.Providers.CharacterProvider
{
    public interface ICharacterProvider
    {
        public Character Character { get; }

        public void SetCharacter(Character character);
    }
}