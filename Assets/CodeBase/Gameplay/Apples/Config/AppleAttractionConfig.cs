using UnityEngine;

namespace CodeBase.Gameplay.Apples.Config
{
    [CreateAssetMenu(menuName = "StaticData/Balance/Configs/AppleAttraction", fileName = "AppleAttractionConfig")]
    public class AppleAttractionConfig : ScriptableObject
    {
        public float AttractiveStrength;
    }
}