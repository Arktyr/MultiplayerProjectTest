using UnityEngine;

namespace CodeBase.Gameplay.Services.Gravity
{
    [CreateAssetMenu(menuName = "StaticData/Balance/Configs/Gravity", fileName = "GravityConfig")]
    public class GravityConfig : ScriptableObject
    {
        public float GravityStrength;
        public float TimeToRotate;
    }
}