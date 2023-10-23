using UnityEngine;

namespace _Project.CodeBase.Gameplay.Characters.Config
{
    [CreateAssetMenu(menuName = "StaticData/Balance/Configs/Character", fileName = "CharacterConfig")]
    public class CharacterConfig : ScriptableObject
    {
        public float Speed;
        public float RotatingSpeed;

        public float PartsSpeed;
        public float PartsRotationSpeed;

        public Vector3 StartPosition;
        public int StartNumberBodyParts;
    }
}