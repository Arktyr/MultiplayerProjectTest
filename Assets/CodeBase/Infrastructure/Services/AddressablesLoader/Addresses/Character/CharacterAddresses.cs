using UnityEngine;
using UnityEngine.AddressableAssets;

namespace CodeBase.Infrastructure.Services.AddressablesLoader.Addresses.Character
{
    [CreateAssetMenu(menuName = "StaticData/Addresses/Character/Character", fileName = "CharacterAddresses")]
    public class CharacterAddresses : ScriptableObject
    {
        public AssetReferenceGameObject Head;
        public AssetReferenceGameObject Body;
    }
}