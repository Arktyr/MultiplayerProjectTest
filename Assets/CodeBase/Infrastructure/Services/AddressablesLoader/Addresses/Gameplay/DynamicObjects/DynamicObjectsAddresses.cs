using CodeBase.Infrastructure.Services.AddressablesLoader.Addresses.Gameplay.Character;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace CodeBase.Infrastructure.Services.AddressablesLoader.Addresses
{
    [CreateAssetMenu(menuName = "StaticData/Addresses/Gameplay/DynamicObjects", fileName = "DynamicObjectAddresses")]
    public class DynamicObjectsAddresses : ScriptableObject
    {
        public CharacterAddresses CharacterAddresses;
        public AssetReferenceGameObject Apple;
    }
}