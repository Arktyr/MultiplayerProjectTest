using UnityEngine;

namespace _Project.CodeBase.Gameplay.Services.Gravity.Config
{
    [CreateAssetMenu(menuName = "StaticData/Balance/Configs/Gravity", fileName = "GravityConfig")]
    public class GravityConfig : ScriptableObject
    {
        public float GravityStrength;
        public float TimeToRotate;
    }
}