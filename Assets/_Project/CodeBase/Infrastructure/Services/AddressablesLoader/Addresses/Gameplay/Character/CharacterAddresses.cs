using UnityEngine;
using UnityEngine.AddressableAssets;

namespace _Project.CodeBase.Infrastructure.Services.AddressablesLoader.Addresses.Gameplay.Character
{
    [CreateAssetMenu(menuName = "StaticData/Addresses/Gameplay/Character", fileName = "CharacterAddresses")]
    public class CharacterAddresses : ScriptableObject
    {
        public AssetReferenceGameObject Head;
        public AssetReferenceGameObject Body;
    }
}