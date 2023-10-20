using UnityEngine;

namespace CodeBase.Gameplay.Characters.Config
{
    [CreateAssetMenu(menuName = "StaticData/Balance/Configs/Character", fileName = "CharacterConfig")]
    public class CharacterConfig : ScriptableObject
    {
        public float Speed;
        public float RotatingSpeed;
    }
}